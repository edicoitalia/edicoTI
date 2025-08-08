/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2025 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdicoTI
{
	public partial class DlgInfoText : Form
	{
		public string InfoText { get; set; }
		public string InfoTitle { get; set; }
		public DlgInfoText()
		{
			InitializeComponent();
		}

		private void DlgInfoText_Load(object sender, EventArgs e)
		{
			txtText.Text = "Usare le frecce per scorrere il testo\r\n\r\n"+ this.InfoText;
			this.Text = this.Text + InfoTitle;
			txtText.SelectionStart = 0;
			txtText.SelectionLength = 0;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
