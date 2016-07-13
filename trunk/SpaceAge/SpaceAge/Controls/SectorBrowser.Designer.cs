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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bFollow = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.listview_sectorships = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.listview_sectoritems = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.wpnt_txt = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sectorNavigationPane1 = new SpaceAge.Controls.SectorNavigationPane();
            this.SectorBrowserSidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // SectorBrowserSidePanel
            // 
            this.SectorBrowserSidePanel.BackColor = System.Drawing.Color.Black;
            this.SectorBrowserSidePanel.Controls.Add(this.button5);
            this.SectorBrowserSidePanel.Controls.Add(this.button4);
            this.SectorBrowserSidePanel.Controls.Add(this.bFollow);
            this.SectorBrowserSidePanel.Controls.Add(this.trackBar1);
            this.SectorBrowserSidePanel.Controls.Add(this.label3);
            this.SectorBrowserSidePanel.Controls.Add(this.listview_sectorships);
            this.SectorBrowserSidePanel.Controls.Add(this.label2);
            this.SectorBrowserSidePanel.Controls.Add(this.listview_sectoritems);
            this.SectorBrowserSidePanel.Controls.Add(this.label1);
            this.SectorBrowserSidePanel.Controls.Add(this.wpnt_txt);
            this.SectorBrowserSidePanel.Controls.Add(this.button3);
            this.SectorBrowserSidePanel.Controls.Add(this.button1);
            this.SectorBrowserSidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SectorBrowserSidePanel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SectorBrowserSidePanel.Location = new System.Drawing.Point(1250, 0);
            this.SectorBrowserSidePanel.Margin = new System.Windows.Forms.Padding(6);
            this.SectorBrowserSidePanel.Name = "SectorBrowserSidePanel";
            this.SectorBrowserSidePanel.Size = new System.Drawing.Size(554, 1259);
            this.SectorBrowserSidePanel.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(357, 847);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 68);
            this.button5.TabIndex = 12;
            this.button5.Text = "Scan";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(184, 847);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 68);
            this.button4.TabIndex = 11;
            this.button4.Text = "Dock";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // bFollow
            // 
            this.bFollow.ForeColor = System.Drawing.Color.Black;
            this.bFollow.Location = new System.Drawing.Point(11, 847);
            this.bFollow.Margin = new System.Windows.Forms.Padding(6);
            this.bFollow.Name = "bFollow";
            this.bFollow.Size = new System.Drawing.Size(161, 68);
            this.bFollow.TabIndex = 10;
            this.bFollow.Text = "Follow";
            this.bFollow.UseVisualStyleBackColor = true;
            this.bFollow.Click += new System.EventHandler(this.bFollow_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(7, 1170);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(6);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(191, 80);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 526);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ships";
            // 
            // listview_sectorships
            // 
            this.listview_sectorships.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_sectorships.HideSelection = false;
            this.listview_sectorships.Location = new System.Drawing.Point(11, 556);
            this.listview_sectorships.Margin = new System.Windows.Forms.Padding(6);
            this.listview_sectorships.Name = "listview_sectorships";
            this.listview_sectorships.Size = new System.Drawing.Size(512, 270);
            this.listview_sectorships.TabIndex = 7;
            this.listview_sectorships.UseCompatibleStateImageBehavior = false;
            this.listview_sectorships.SelectedIndexChanged += new System.EventHandler(this.listview_sectorships_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Star Systems";
            // 
            // listview_sectoritems
            // 
            this.listview_sectoritems.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_sectoritems.Location = new System.Drawing.Point(11, 247);
            this.listview_sectoritems.Margin = new System.Windows.Forms.Padding(6);
            this.listview_sectoritems.Name = "listview_sectoritems";
            this.listview_sectoritems.Size = new System.Drawing.Size(512, 270);
            this.listview_sectoritems.TabIndex = 5;
            this.listview_sectoritems.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Throttle Meter: TODO???";
            // 
            // wpnt_txt
            // 
            this.wpnt_txt.AutoSize = true;
            this.wpnt_txt.BackColor = System.Drawing.Color.Black;
            this.wpnt_txt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.wpnt_txt.Location = new System.Drawing.Point(13, 79);
            this.wpnt_txt.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.wpnt_txt.Name = "wpnt_txt";
            this.wpnt_txt.Size = new System.Drawing.Size(195, 25);
            this.wpnt_txt.TabIndex = 3;
            this.wpnt_txt.Text = "Local Waypoint: bleh";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(11, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 68);
            this.button3.TabIndex = 2;
            this.button3.Text = "Toggle Local Waypoint";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(196, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 68);
            this.button1.TabIndex = 0;
            this.button1.Text = "Toggle Waypoint";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // sectorNavigationPane1
            // 
            this.sectorNavigationPane1.BackColor = System.Drawing.Color.Black;
            this.sectorNavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorNavigationPane1.Location = new System.Drawing.Point(0, 0);
            this.sectorNavigationPane1.Margin = new System.Windows.Forms.Padding(11);
            this.sectorNavigationPane1.Name = "sectorNavigationPane1";
            this.sectorNavigationPane1.Size = new System.Drawing.Size(1250, 1259);
            this.sectorNavigationPane1.TabIndex = 2;
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sectorNavigationPane1);
            this.Controls.Add(this.SectorBrowserSidePanel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(1804, 1259);
            this.Enter += new System.EventHandler(this.SectorBrowser_Enter);
            this.Leave += new System.EventHandler(this.SectorBrowser_Leave);
            this.SectorBrowserSidePanel.ResumeLayout(false);
            this.SectorBrowserSidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SectorBrowserSidePanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label wpnt_txt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listview_sectoritems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listview_sectorships;
        private System.Windows.Forms.Label label2;
        private SectorNavigationPane sectorNavigationPane1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bFollow;
    }
}
