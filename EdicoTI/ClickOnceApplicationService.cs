/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2025 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;


namespace EdicoTI
{
	/// <summary>
	/// This class manage the ClickOnce interface using the standard Windows Library
	/// </summary>
	internal class ClickOnceApplicationService
	{
		private string url;
		private string localUrl;
		/// <summary>
		/// ClickOnce Service
		/// </summary>
		/// <param name="url">appId url</param>
		public ClickOnceApplicationService(string url)
		{
			this.url = url;
			this.localUrl = getLocalUrl();
		}

		private string getLocalUrl()
		{
			foreach (var key in Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall").GetSubKeyNames())
			{
				var keyVal = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + key).GetValue("ShortcutAppId");
				if ((keyVal != null) && (((string)keyVal).StartsWith(url)))
				{
					return (string)keyVal;
				}
			}
			return null;
		}

		/// <summary>
		/// Checks if a given appId has been installed
		/// </summary>
		/// <returns></returns>
		public bool isInstalled()
		{
			return localUrl != null;
		}
		/// <summary>
		/// Deploy the ClickOnce application from the web
		/// </summary>
		/// <returns></returns>
		public bool installClickOnce()
		{
			try
			{
				Process.Start("rundll32.exe", "dfshim.dll, ShOpenVerbApplication " + url);
			} catch { return false; }
			return true;
		}
		/// <summary>
		/// Start the clickOnce application
		/// </summary>
		/// <returns></returns>
		public bool runClickOnce()
		{
			string fileName = System.IO.Path.GetTempPath() + "edico.appref-ms";
			try
			{ 
				using (StreamWriter writer = new StreamWriter(fileName,false,Encoding.Unicode))
				{
					writer.WriteLine(localUrl);
				}
				Process.Start(fileName);
			} catch { return false; }
			return true;
		}
	}
}
