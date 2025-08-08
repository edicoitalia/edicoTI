/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2025 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

namespace EdicoTI
{
	partial class LiveUpdate
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblDownload = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.lblDownload);
			this.flowLayoutPanel1.Controls.Add(this.progressBar1);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 11);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(722, 152);
			this.flowLayoutPanel1.TabIndex = 0;
			// 
			// lblDownload
			// 
			this.lblDownload.AutoSize = true;
			this.lblDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDownload.Location = new System.Drawing.Point(3, 0);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(415, 60);
			this.lblDownload.TabIndex = 0;
			this.lblDownload.Text = "Download aggiornamento in corso: \n ";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(3, 63);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(710, 32);
			this.progressBar1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(566, 168);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(156, 36);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Annulla";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// Updater
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(130F, 130F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(733, 215);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.flowLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Updater";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EDICO Targato Italia - Aggiornamento";
			this.Load += new System.EventHandler(this.Updater_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label lblDownload;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnCancel;
	}
}