/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2025 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

using System;
using System.Windows.Forms;

namespace EdicoTI
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string openFile = null;
			if(args.Length > 0 && args[0].ToLower().Trim().EndsWith(".edi"))
			{
				openFile = args[0];
			}
			if (args.Length > 0 && args[0] == "/utility")
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new DlgUtility());
			}
			else if (args.Length > 0 && args[0] == "/admInstall")
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm(openFile,adminInstall:true));
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm(openFile));
			}
		}
	}
}
