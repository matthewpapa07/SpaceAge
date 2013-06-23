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
            this.SectorBrowserSidePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.wpnt_txt = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listview_sectoritems = new System.Windows.Forms.ListView();
            this.sectorMapComplex1 = new SpaceAge.Controls.SectorMapComplex();
            this.SectorBrowserSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SectorBrowserSidePanel
            // 
            this.SectorBrowserSidePanel.BackColor = System.Drawing.Color.Black;
            this.SectorBrowserSidePanel.Controls.Add(this.listview_sectoritems);
            this.SectorBrowserSidePanel.Controls.Add(this.label1);
            this.SectorBrowserSidePanel.Controls.Add(this.wpnt_txt);
            this.SectorBrowserSidePanel.Controls.Add(this.button3);
            this.SectorBrowserSidePanel.Controls.Add(this.button2);
            this.SectorBrowserSidePanel.Controls.Add(this.button1);
            this.SectorBrowserSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SectorBrowserSidePanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SectorBrowserSidePanel.Location = new System.Drawing.Point(606, 0);
            this.SectorBrowserSidePanel.Name = "SectorBrowserSidePanel";
            this.SectorBrowserSidePanel.Size = new System.Drawing.Size(201, 620);
            this.SectorBrowserSidePanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Throttle Meter: TODO";
            // 
            // wpnt_txt
            // 
            this.wpnt_txt.AutoSize = true;
            this.wpnt_txt.BackColor = System.Drawing.Color.Black;
            this.wpnt_txt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.wpnt_txt.Location = new System.Drawing.Point(13, 43);
            this.wpnt_txt.Name = "wpnt_txt";
            this.wpnt_txt.Size = new System.Drawing.Size(107, 13);
            this.wpnt_txt.TabIndex = 3;
            this.wpnt_txt.Text = "Local Waypoint: bleh";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(6, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Toggle Local Waypoint";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(6, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Autopilot";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(107, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Toggle Waypoint";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listview_sectoritems
            // 
            this.listview_sectoritems.Location = new System.Drawing.Point(6, 114);
            this.listview_sectoritems.Name = "listview_sectoritems";
            this.listview_sectoritems.Size = new System.Drawing.Size(191, 148);
            this.listview_sectoritems.TabIndex = 5;
            this.listview_sectoritems.UseCompatibleStateImageBehavior = false;
            // 
            // sectorMapComplex1
            // 
            this.sectorMapComplex1.BackColor = System.Drawing.Color.Black;
            this.sectorMapComplex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorMapComplex1.Location = new System.Drawing.Point(0, 0);
            this.sectorMapComplex1.Name = "sectorMapComplex1";
            this.sectorMapComplex1.Size = new System.Drawing.Size(606, 620);
            this.sectorMapComplex1.TabIndex = 2;
            this.sectorMapComplex1.Click += new System.EventHandler(this.sectorMapComplex1_Click);
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sectorMapComplex1);
            this.Controls.Add(this.SectorBrowserSidePanel);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(807, 620);
            this.SectorBrowserSidePanel.ResumeLayout(false);
            this.SectorBrowserSidePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SectorBrowserSidePanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private SectorMapComplex sectorMapComplex1;
        private System.Windows.Forms.Label wpnt_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listview_sectoritems;
    }
}
