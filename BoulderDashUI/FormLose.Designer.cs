using System.ComponentModel;

namespace BoulderDashUI
{
    partial class FormLose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.labelArrows = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelArrows
            // 
            this.labelArrows.BackColor = System.Drawing.Color.Transparent;
            this.labelArrows.Font = new System.Drawing.Font("Monoid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.labelArrows.ForeColor = System.Drawing.Color.White;
            this.labelArrows.Location = new System.Drawing.Point(189, 278);
            this.labelArrows.Name = "labelArrows";
            this.labelArrows.Size = new System.Drawing.Size(418, 23);
            this.labelArrows.TabIndex = 1;
            this.labelArrows.Text = "↓ Press button to restart the game ↓";
            this.labelArrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.GhostWhite;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRestart.Font = new System.Drawing.Font("Monoid", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.buttonRestart.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.buttonRestart.Location = new System.Drawing.Point(313, 330);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(156, 44);
            this.buttonRestart.TabIndex = 3;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BoulderDashUI.Properties.Resources.lose;
            this.pictureBox1.Location = new System.Drawing.Point(95, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 219);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Monoid", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(447, 411);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(341, 30);
            this.label.TabIndex = 5;
            this.label.Text = "Game by Kirill Bluvband";
            // 
            // FormLose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labelArrows);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FormLose";
            this.Text = "Lose - Boulder Dash";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Button buttonRestart;

        private System.Windows.Forms.Label labelArrows;

        #endregion
    }
}