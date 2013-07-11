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
            this.label3 = new System.Windows.Forms.Label();
            this.listview_sectorships = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.listview_sectoritems = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.wpnt_txt = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.bAutopilot = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sectorNavigationPane1 = new SpaceAge.Controls.SectorNavigationPane();
            this.SectorBrowserSidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SectorBrowserSidePanel
            // 
            this.SectorBrowserSidePanel.BackColor = System.Drawing.Color.Black;
            this.SectorBrowserSidePanel.Controls.Add(this.label3);
            this.SectorBrowserSidePanel.Controls.Add(this.listview_sectorships);
            this.SectorBrowserSidePanel.Controls.Add(this.label2);
            this.SectorBrowserSidePanel.Controls.Add(this.listview_sectoritems);
            this.SectorBrowserSidePanel.Controls.Add(this.label1);
            this.SectorBrowserSidePanel.Controls.Add(this.wpnt_txt);
            this.SectorBrowserSidePanel.Controls.Add(this.button3);
            this.SectorBrowserSidePanel.Controls.Add(this.bAutopilot);
            this.SectorBrowserSidePanel.Controls.Add(this.button1);
            this.SectorBrowserSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SectorBrowserSidePanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SectorBrowserSidePanel.Location = new System.Drawing.Point(682, 0);
            this.SectorBrowserSidePanel.Name = "SectorBrowserSidePanel";
            this.SectorBrowserSidePanel.Size = new System.Drawing.Size(302, 682);
            this.SectorBrowserSidePanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ships";
            // 
            // listview_sectorships
            // 
            this.listview_sectorships.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_sectorships.Location = new System.Drawing.Point(6, 301);
            this.listview_sectorships.Name = "listview_sectorships";
            this.listview_sectorships.Size = new System.Drawing.Size(281, 148);
            this.listview_sectorships.TabIndex = 7;
            this.listview_sectorships.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Star Systems";
            // 
            // listview_sectoritems
            // 
            this.listview_sectoritems.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_sectoritems.Location = new System.Drawing.Point(6, 134);
            this.listview_sectoritems.Name = "listview_sectoritems";
            this.listview_sectoritems.Size = new System.Drawing.Size(281, 148);
            this.listview_sectoritems.TabIndex = 5;
            this.listview_sectoritems.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Throttle Meter: TODO???";
            // 
            // wpnt_txt
            // 
            this.wpnt_txt.AutoSize = true;
            this.wpnt_txt.BackColor = System.Drawing.Color.Black;
            this.wpnt_txt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.wpnt_txt.Location = new System.Drawing.Point(7, 43);
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
            // bAutopilot
            // 
            this.bAutopilot.ForeColor = System.Drawing.Color.Black;
            this.bAutopilot.Location = new System.Drawing.Point(6, 81);
            this.bAutopilot.Name = "bAutopilot";
            this.bAutopilot.Size = new System.Drawing.Size(201, 27);
            this.bAutopilot.TabIndex = 1;
            this.bAutopilot.Text = "Autopilot";
            this.bAutopilot.UseVisualStyleBackColor = true;
            this.bAutopilot.Click += new System.EventHandler(this.bAutopilot_Click);
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
            // 
            // sectorNavigationPane1
            // 
            this.sectorNavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorNavigationPane1.Location = new System.Drawing.Point(0, 0);
            this.sectorNavigationPane1.Name = "sectorNavigationPane1";
            this.sectorNavigationPane1.Size = new System.Drawing.Size(682, 682);
            this.sectorNavigationPane1.TabIndex = 2;
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sectorNavigationPane1);
            this.Controls.Add(this.SectorBrowserSidePanel);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(984, 682);
            this.Enter += new System.EventHandler(this.SectorBrowser_Enter);
            this.Leave += new System.EventHandler(this.SectorBrowser_Leave);
            this.SectorBrowserSidePanel.ResumeLayout(false);
            this.SectorBrowserSidePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SectorBrowserSidePanel;
        private System.Windows.Forms.Button bAutopilot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label wpnt_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listview_sectoritems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listview_sectorships;
        private System.Windows.Forms.Label label2;
        private SectorNavigationPane sectorNavigationPane1;
    }
}
