/*
 * A part of Edico Targato Italia
 * Copyright (C) 2023-2024 Alberto Zanella - EdicoItalia.it
 * This file is covered by the GNU General Public License.
 * See the file LICENSE for more details.
 * 
*/

namespace EdicoTI
{
	partial class DlgUtility
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.txtDescription, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.button3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.button4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.button2, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(382, 551);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// txtDescription
			// 
			this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescription.Location = new System.Drawing.Point(3, 3);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(376, 284);
			this.txtDescription.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(91, 293);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(200, 42);
			this.button1.TabIndex = 1;
			this.button1.Text = "Reset del &profilo di EDICO";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button3.AutoSize = true;
			this.button3.Location = new System.Drawing.Point(91, 353);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(200, 42);
			this.button3.TabIndex = 3;
			this.button3.Text = "Reset della configurazione\ndi &JAWS per EDICO";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.AutoSize = true;
			this.button4.Location = new System.Drawing.Point(304, 501);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 26);
			this.button4.TabIndex = 5;
			this.button4.Text = "&Esci";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button2.AutoSize = true;
			this.button2.Location = new System.Drawing.Point(91, 413);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(200, 42);
			this.button2.TabIndex = 4;
			this.button2.Text = "Vai a codice &sorgente\ndi EDICO Targato Italia";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// DlgUtility
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(130F, 130F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(382, 551);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "DlgUtility";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EDICO Targato Italia - Utility";
			this.Load += new System.EventHandler(this.DlgUtility_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button2;
	}
}