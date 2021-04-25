namespace WaTor_2
{
    partial class Startscreen
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
            this.BtnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnRun
            // 
            this.BtnRun.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnRun.BackColor = System.Drawing.Color.Teal;
            this.BtnRun.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.BtnRun.FlatAppearance.BorderSize = 2;
            this.BtnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRun.Location = new System.Drawing.Point(98, 155);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(188, 60);
            this.BtnRun.TabIndex = 0;
            this.BtnRun.Text = "Run Simulation";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // Startscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.BtnRun);
            this.Name = "Startscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startscreen";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnRun;
    }
}