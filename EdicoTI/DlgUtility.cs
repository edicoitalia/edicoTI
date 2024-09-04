using System;
using System.IO;
using System.Windows.Forms;

namespace EdicoTI
{
	public partial class DlgUtility : Form
	{
		public DlgUtility()
		{
			InitializeComponent();
		}

		private void DlgUtility_Load(object sender, EventArgs e)
		{
			txtDescription.Text = Properties.Resources.dlgUtility;
			txtDescription.SelectionStart = 0;
			txtDescription.SelectionLength = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (EdicoFileChanger.resetSettings())
				{
					MessageBox.Show("Operazione conclusa con successo!", "EDICO Targato Italia");
				}
				else
				{
					MessageBox.Show("Impossibile completare l'operazione.", "EDICO Targato Italia");
				}
			}
			catch
			{
				MessageBox.Show("Impossibile completare l'operazione.", "EDICO Targato Italia");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string JAWS_USER_SETTINGS_PATH = @"Freedom Scientific\JAWS\";
			string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			if(Directory.Exists(Path.Combine(appData,JAWS_USER_SETTINGS_PATH)))
			{
				deleteAllEdicos(Path.Combine(appData, JAWS_USER_SETTINGS_PATH));
			}
			if (Directory.Exists(Path.Combine(localAppData, JAWS_USER_SETTINGS_PATH)))
			{
				deleteAllEdicos(Path.Combine(appData, JAWS_USER_SETTINGS_PATH));
			}
		}

		private void deleteAllEdicos(string path)
		{
			foreach(string file in Directory.GetFiles(path, "EdicoTI.*", SearchOption.AllDirectories))
			{
				File.Delete(file);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/edicoitalia/edicoTI");
		}
	}
}
