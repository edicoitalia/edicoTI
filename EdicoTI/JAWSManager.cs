/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2024 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

using System;
using System.Linq;
using Microsoft.Win32;
using System.Security.Principal;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace EdicoTI
{
	internal class JAWSManager
	{
		//JAWS paths
		private static string JAWS_REGPATH = @"SOFTWARE\Freedom Scientific\JAWS";
		private static string JAWS_USER_SETTINGS_PATH = @"Freedom Scientific\JAWS\{0}\Settings\ita";
		private string strExeFilePath;
		private string strWorkPath;
		public JAWSManager()
		{
			this.strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			this.strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
		}

		public string[] getSupportedJAWSList()
		{
			try
			{
				return Registry.LocalMachine.OpenSubKey(JAWS_REGPATH).GetSubKeyNames()
					.Where(s => Convert.ToInt16(s) >= 2020) //jaws 2020+ only
					.ToArray();
			} catch { return new string[] { }; }
		}

		public static bool amIAdmin()
		{
				return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
						  .IsInRole(WindowsBuiltInRole.Administrator);
		}

		public bool needAdminCopy()
		{
			bool retval = false;
			foreach (string version in getSupportedJAWSList())
			{
				string path = (string)Registry.LocalMachine.OpenSubKey(Path.Combine(JAWS_REGPATH, version)).GetValue("Target");
				if (path != null)
				{
					retval = retval || jawsInstanceProcessor(path, true);
				}
			}
			return retval;
		}

		public void adminCopy()
		{
			if(amIAdmin())
			{
				foreach(string version in getSupportedJAWSList())
				{
					string path = (string)Registry.LocalMachine.OpenSubKey(Path.Combine(JAWS_REGPATH, version)).GetValue("Target");
					if (path != null) jawsInstanceProcessor(path,false);
				}
				System.Windows.Forms.MessageBox.Show(Properties.Resources.jfwCompleted, "EDICO Targato Italia");
			}
			else
			{
				Process proc = new Process();
				proc.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
				proc.StartInfo.Arguments = "/admInstall";
				proc.StartInfo.UseShellExecute = true;
				proc.StartInfo.Verb = "runas";
				proc.Start();
			}
			System.Windows.Forms.Application.Exit();
		}

		private bool jawsInstanceProcessor(string path, bool emul)
		{
			bool retval = false;
			var generalLouisPath = Path.Combine(path, "Liblouis");
			if (!Directory.Exists(generalLouisPath)) return false;
			foreach (string louisPath in Directory.GetDirectories(generalLouisPath))
			{
				retval = retval || copyTable(louisPath,emul);
				retval = retval || liblouisTransXMLProcessor(Path.Combine(louisPath, "LiblouisTrans.xml"),emul);
			}
			return retval;
		}

		private bool copyTable(string louisPath,bool emul)
		{
			var fileName = Path.Combine(strWorkPath, "JAWS", "edico-ita.utb");
			if (!File.Exists(fileName)) return false;
			var dest = Path.Combine(louisPath, "tables");
			if( (emul) && (!File.Exists(Path.Combine(dest, "edico-ita.utb")))) return true;
			if (!Directory.Exists(dest)) return false;
			if(!emul) File.Copy(fileName, Path.Combine(dest, "edico-ita.utb"),true);
			return false;
		}
		private bool liblouisTransXMLProcessor(string xmlFile, bool emul)
		{
			if (!File.Exists(xmlFile)) return false;
			XDocument doc = XDocument.Load(xmlFile);
			var elem = doc.Element("LiblouisTrans");
			if(elem == null) return false;
			elem = elem.Element("Modes");
			if (elem == null) return false;
			if (elem.Elements().Where(e => e.Attribute("Id").Value == "999").Any()) return false;
			if (emul) return true; //in emulation mode stops before writing (admin privileges needed)
			//we need to do this because the file is an handwritten XML...
			string xmlData = File.ReadAllText(xmlFile);
			xmlData = xmlData.Replace(Properties.Resources.jfwXMLFrom, Properties.Resources.jfwXMLTo);
			File.WriteAllText(xmlFile, xmlData);
			return false;
		}

		public void userConfig()
		{
			foreach (string version in getSupportedJAWSList())
			{
				string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				if (Directory.Exists(Path.Combine(localAppData, String.Format(JAWS_USER_SETTINGS_PATH, version)))) appData = localAppData;
				string path = Path.Combine(appData, String.Format(JAWS_USER_SETTINGS_PATH, version));
				if (Directory.Exists(path))
				{
					string configNamesFilePath = Path.Combine(path, "ConfigNames.ini");
					if(!File.Exists(configNamesFilePath))
					{
						File.Create(configNamesFilePath);
					}
					var configNames = new IniFile(configNamesFilePath);
					if(!configNames.KeyExists("Edico", "ConfigNames"))
					{
						configNames.Write("Edico", "EdicoTI", "ConfigNames");
					}
					var sourceDir = Path.Combine(strWorkPath, "JAWS");
					var destDir = path;
					if(Convert.ToInt16(version) >= 2022)
					{
						copyIfNotExists(Path.Combine(sourceDir, "edico22.jcf"), Path.Combine(destDir, "edicoTI.jcf"));
					}
					else
					{
						copyIfNotExists(Path.Combine(sourceDir, "edico.jcf"), Path.Combine(destDir, "edicoTI.jcf"));
					}
					copyIfNotExists(Path.Combine(sourceDir, "edicoTI.jkm"), Path.Combine(destDir, "edicoTI.jkm"));
					copyIfNotExists(Path.Combine(sourceDir, "edicoTI.jsb"), Path.Combine(destDir, "edicoTI.jsb"));
					copyIfNotExists(Path.Combine(sourceDir, "edicoTI.jsm"), Path.Combine(destDir, "edicoTI.jsm"));
					copyIfNotExists(Path.Combine(sourceDir, "edicoTI.jss"), Path.Combine(destDir, "edicoTI.jss"));
				}
			}
		}

		private void copyIfNotExists(string source, string dest)
		{
			if(!File.Exists(dest)) File.Copy(source, dest);
		}
	}
}
