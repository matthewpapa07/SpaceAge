namespace SpaceAge.Controls
{
    partial class SectorBrowser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sectorMapComplex1 = new SpaceAge.Controls.SectorMapComplex();
            this.button3 = new System.Windows.Forms.Button();
            this.wpnt_txt = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.wpnt_txt);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(606, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 620);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Autopilot";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Toggle Waypoint";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sectorMapComplex1
            // 
            this.sectorMapComplex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorMapComplex1.Location = new System.Drawing.Point(0, 0);
            this.sectorMapComplex1.Name = "sectorMapComplex1";
            this.sectorMapComplex1.Size = new System.Drawing.Size(606, 620);
            this.sectorMapComplex1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 62);
            this.button3.TabIndex = 2;
            this.button3.Text = "Toggle Local Waypoint";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // wpnt_txt
            // 
            this.wpnt_txt.AutoSize = true;
            this.wpnt_txt.Location = new System.Drawing.Point(7, 72);
            this.wpnt_txt.Name = "wpnt_txt";
            this.wpnt_txt.Size = new System.Drawing.Size(107, 13);
            this.wpnt_txt.TabIndex = 3;
            this.wpnt_txt.Text = "Local Waypoint: bleh";
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sectorMapComplex1);
            this.Controls.Add(this.panel1);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(807, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private SectorMapComplex sectorMapComplex1;
        private System.Windows.Forms.Label wpnt_txt;
        private System.Windows.Forms.Button button3;
    }
}
