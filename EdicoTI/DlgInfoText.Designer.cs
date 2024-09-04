/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2024 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

namespace EdicoTI
{
	partial class DlgInfoText
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtText = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtText
			// 
			this.txtText.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.18462F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtText.Location = new System.Drawing.Point(0, 0);
			this.txtText.Multiline = true;
			this.txtText.Name = "txtText";
			this.txtText.ReadOnly = true;
			this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtText.Size = new System.Drawing.Size(782, 310);
			this.txtText.TabIndex = 0;
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(594, 316);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(107, 34);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "&Continua";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(707, 316);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 34);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "&Annulla";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// DlgInfoText
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(782, 351);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgInfoText";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EDICO Targato Italia - ";
			this.Load += new System.EventHandler(this.DlgInfoText_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtText;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}