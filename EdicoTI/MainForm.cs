/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace EdicoTI
{
	public partial class MainForm : Form
	{
		private static string EDICO_CIDAT_DEPLOYMENT_URL = "http://cidat.once.es/repos/edico/Edico.application";
		private int tick;
		private ClickOnceApplicationService clickOnceService;
		private JAWSManager jawsManager;
		public MainForm()
		{
			InitializeComponent();
			this.clickOnceService = new ClickOnceApplicationService(EDICO_CIDAT_DEPLOYMENT_URL);
			this.jawsManager = new JAWSManager();

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			if(JAWSManager.amIAdmin())
			{
				//running admin to copy JAWS system files. Copy them and exits after a dialog alert.
				jawsManager.adminCopy();
			}
			else
			{
				timer1.Start();
			}
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hwnd);

		private enum ShowWindowEnum
		{
			Hide = 0,
			ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
			Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
			Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
			Restore = 9, ShowDefault = 10, ForceMinimized = 11
		};

		private bool maximizeRunningEdico()
		{
			var edicoExe = isProcessRunning("Edico");
			if (edicoExe != null)
			{
				if (edicoExe.MainWindowHandle == IntPtr.Zero)
				{
					ShowWindow(edicoExe.Handle, ShowWindowEnum.Maximize);
				}
				SetForegroundWindow(edicoExe.MainWindowHandle);
				return true;
			}
			return false;
		}

		private Process isProcessRunning(string processName)
		{
			Process[] processExes = Process.GetProcessesByName(processName);
			if (processExes != null && processExes.Length > 0) return processExes[0];
			return null;
		}

		private void launchAll()
		{
			if (JAWSManager.amIAdmin()) return;
			if(!clickOnceService.isInstalled())
			{
				DlgInfoText dlgWelcome = new DlgInfoText();
				dlgWelcome.InfoText = Properties.Resources.welcomeText;
				dlgWelcome.InfoTitle = Properties.Resources.welcomeTitle;
				DialogResult result = dlgWelcome.ShowDialog();
				if (result == DialogResult.Cancel) return;
			}
			if ((isProcessRunning("nvda") != null) && 
				(Properties.Settings.Default.nvdaCheck))
			{
				if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "nvda", "addons", "edico")))
				{
					string url = LiveUpdate.getNVDAUrl();
					if (url == null) //no internet
					{
						MessageBox.Show(Properties.Resources.nvdaSuggestion + Properties.Resources.nvdaNoInternet, "EDICO Targato Italia");
					}
					else
					{
						DialogResult result = MessageBox.Show(Properties.Resources.nvdaSuggestion + Properties.Resources.nvdaInternet, "EDICO Targato Italia");
						if (result == DialogResult.No)
						{
							result = MessageBox.Show(Properties.Resources.nvdaSkip, "EDICO Targato Italia", MessageBoxButtons.YesNo);
							if (result == DialogResult.No)
							{
								Properties.Settings.Default.nvdaCheck = false;
								Properties.Settings.Default.Save();
							}
						}
						else
						{
							new LiveUpdate(url, false, "Addon di EDICO per NVDA", "Download dell'addon di NVDA per EDICO.\n");
						}
					}
				}
			}
			else
			{
				jawsManager.userConfig();
				if (jawsManager.needAdminCopy())
				{
					//alert
					var result = MessageBox.Show(Properties.Resources.jfwAdminNeeded, "EDICO Targato Italia", MessageBoxButtons.YesNo);
					if (result == DialogResult.Yes)
					{
						jawsManager.adminCopy();
					}
					else
					{
						result = MessageBox.Show(Properties.Resources.jfwSkip, "EDICO Targato Italia", MessageBoxButtons.YesNo);
						if (result == DialogResult.No)
						{
							Properties.Settings.Default.jfwCheck = false;
							Properties.Settings.Default.Save();
						}
					}
				}
				if ((isProcessRunning("jfw") != null) && (jawsManager.getSupportedJAWSList().Length == 0))
				{
					MessageBox.Show(Properties.Resources.jfwOld, "EDICO Targato Italia");
					var result = MessageBox.Show(Properties.Resources.jfwSkip, "EDICO Targato Italia", MessageBoxButtons.YesNo);
					if (result == DialogResult.No)
					{
						Properties.Settings.Default.jfwCheck = false;
						Properties.Settings.Default.Save();
					}
				}
			}

			if (maximizeRunningEdico())
			{
				//then edico is already running...
				return;
			}
			Process proc = new Process();
			proc.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName.ToLower().Replace("edicoti.exe", "EdicoTray.exe");
			proc.StartInfo.UseShellExecute = true;
			proc.Start();
			EdicoFileChanger.crawlAndChange();
			if (clickOnceService.isInstalled())
			{
				clickOnceService.runClickOnce();
			}
			else
			{
				clickOnceService.installClickOnce();
			}
		}

		private void liveUpdate()
		{
			if (!Properties.Settings.Default.updateCheck) return;
			try
			{
				var url = LiveUpdate.checkForUpdate();
				if(url != null)
				{
					var dResult = MessageBox.Show(Properties.Resources.updateText, "Aggiornamenti disponibili",MessageBoxButtons.YesNo);
					if(dResult == DialogResult.Yes)
					{
						new LiveUpdate(url).ShowDialog();
					}
					else
					{
						dResult = MessageBox.Show(Properties.Resources.updateReminder, "Notifiche aggiornamenti", MessageBoxButtons.YesNo);
						if(dResult == DialogResult.No)
						{
							Properties.Settings.Default.updateCheck = false;
							Properties.Settings.Default.Save();
						}
					}
				}
			} catch { } //no internet... skip
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			tick = tick + 1;
			if(tick == 10)
			{
				liveUpdate();
				try
				{
					launchAll();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Si è verificato un errore\n" + ex.Message, "EDICO Targato Italia", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Application.Exit();

			}
		}
	}
}
