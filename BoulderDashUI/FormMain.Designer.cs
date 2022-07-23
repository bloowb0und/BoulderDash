namespace BoulderDashUI
{
    sealed partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelArrows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.labelSurrender = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArrows
            // 
            this.labelArrows.BackColor = System.Drawing.Color.Transparent;
            this.labelArrows.Font = new System.Drawing.Font("Monoid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.labelArrows.ForeColor = System.Drawing.Color.White;
            this.labelArrows.Location = new System.Drawing.Point(220, 18);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(349, 23);
            this.labelArrows.TabIndex = 0;
            this.labelArrows.Text = "Use arrows to move around ←↑→↓";
            this.labelArrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monoid", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Collect all    to win";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monoid", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(220, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "_______________________________";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Monoid", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(220, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(349, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "_______________________________";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(149, 150);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.Enabled = false;
            this.pictureBoxMenu.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxMenu.Image")));
            this.pictureBoxMenu.Location = new System.Drawing.Point(404, 66);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMenu.TabIndex = 6;
            this.pictureBoxMenu.TabStop = false;
            // 
            // labelSurrender
            // 
            this.labelSurrender.BackColor = System.Drawing.Color.White;
            this.labelSurrender.Font = new System.Drawing.Font("Dank Mono", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelSurrender.ForeColor = System.Drawing.Color.DarkRed;
            this.labelSurrender.Location = new System.Drawing.Point(12, 18);
            this.labelSurrender.Name = "labelSurrender";
            this.labelSurrender.Size = new System.Drawing.Size(122, 30);
            this.labelSurrender.TabIndex = 8;
            this.labelSurrender.Text = "Surrender";
            this.labelSurrender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSurrender.Click += new System.EventHandler(this.labelSurrender_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelSurrender);
            this.Controls.Add(this.pictureBoxMenu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelArrows);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FormMain";
            this.Text = "Game - Boulder Dash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxMenu)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label labelSurrender;

        private System.Windows.Forms.PictureBox pictureBoxMenu;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label labelArrows;

        #endregion
    }
}