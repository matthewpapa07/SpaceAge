namespace SpaceAge.Controls
{
    partial class UniverseMapBrowser
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.clickedsectordistance = new System.Windows.Forms.Label();
            this.clickedsectorcoordinates = new System.Windows.Forms.Label();
            this.clickedsectorname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.bSetWaypoint = new System.Windows.Forms.Button();
            this.bSectorView = new System.Windows.Forms.Button();
            this.ui_buttonVisitSector = new System.Windows.Forms.Button();
            this.sectorViewerPanel = new System.Windows.Forms.Panel();
            this.UniverseMap1 = new SpaceAge.UniverseMap();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.sectorViewerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.bSetWaypoint);
            this.panel1.Controls.Add(this.bSectorView);
            this.panel1.Controls.Add(this.ui_buttonVisitSector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(682, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 682);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(12, 131);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Show Soverignty";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.clickedsectordistance);
            this.panel6.Controls.Add(this.clickedsectorcoordinates);
            this.panel6.Controls.Add(this.clickedsectorname);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Location = new System.Drawing.Point(6, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 83);
            this.panel6.TabIndex = 21;
            // 
            // clickedsectordistance
            // 
            this.clickedsectordistance.AutoSize = true;
            this.clickedsectordistance.ForeColor = System.Drawing.Color.White;
            this.clickedsectordistance.Location = new System.Drawing.Point(93, 57);
            this.clickedsectordistance.Name = "clickedsectordistance";
            this.clickedsectordistance.Size = new System.Drawing.Size(13, 13);
            this.clickedsectordistance.TabIndex = 19;
            this.clickedsectordistance.Text = "0";
            // 
            // clickedsectorcoordinates
            // 
            this.clickedsectorcoordinates.AutoSize = true;
            this.clickedsectorcoordinates.ForeColor = System.Drawing.Color.White;
            this.clickedsectorcoordinates.Location = new System.Drawing.Point(93, 40);
            this.clickedsectorcoordinates.Name = "clickedsectorcoordinates";
            this.clickedsectorcoordinates.Size = new System.Drawing.Size(59, 13);
            this.clickedsectorcoordinates.TabIndex = 18;
            this.clickedsectorcoordinates.Text = "x = 0, y = 0";
            // 
            // clickedsectorname
            // 
            this.clickedsectorname.AutoSize = true;
            this.clickedsectorname.ForeColor = System.Drawing.Color.White;
            this.clickedsectorname.Location = new System.Drawing.Point(93, 24);
            this.clickedsectorname.Name = "clickedsectorname";
            this.clickedsectorname.Size = new System.Drawing.Size(96, 13);
            this.clickedsectorname.TabIndex = 17;
            this.clickedsectorname.Text = "clickedsectorname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Distance:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Coordinates:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Sector Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Sector Info";
            // 
            // bSetWaypoint
            // 
            this.bSetWaypoint.Location = new System.Drawing.Point(6, 92);
            this.bSetWaypoint.Name = "bSetWaypoint";
            this.bSetWaypoint.Size = new System.Drawing.Size(146, 32);
            this.bSetWaypoint.TabIndex = 3;
            this.bSetWaypoint.Text = "Set Waypoint";
            this.bSetWaypoint.UseVisualStyleBackColor = true;
            this.bSetWaypoint.Click += new System.EventHandler(this.bSetWaypoint_Click);
            // 
            // bSectorView
            // 
            this.bSectorView.Location = new System.Drawing.Point(3, 255);
            this.bSectorView.Name = "bSectorView";
            this.bSectorView.Size = new System.Drawing.Size(144, 70);
            this.bSectorView.TabIndex = 2;
            this.bSectorView.Text = "Sector View";
            this.bSectorView.UseVisualStyleBackColor = true;
            this.bSectorView.Click += new System.EventHandler(this.bSectorView_Click);
            // 
            // ui_buttonVisitSector
            // 
            this.ui_buttonVisitSector.Location = new System.Drawing.Point(153, 294);
            this.ui_buttonVisitSector.Name = "ui_buttonVisitSector";
            this.ui_buttonVisitSector.Size = new System.Drawing.Size(146, 30);
            this.ui_buttonVisitSector.TabIndex = 1;
            this.ui_buttonVisitSector.Text = "Sector Details";
            this.ui_buttonVisitSector.UseVisualStyleBackColor = true;
            this.ui_buttonVisitSector.Click += new System.EventHandler(this.ui_buttonVisitSector_Click);
            // 
            // sectorViewerPanel
            // 
            this.sectorViewerPanel.BackColor = System.Drawing.Color.Black;
            this.sectorViewerPanel.Controls.Add(this.UniverseMap1);
            this.sectorViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorViewerPanel.Location = new System.Drawing.Point(0, 0);
            this.sectorViewerPanel.Name = "sectorViewerPanel";
            this.sectorViewerPanel.Size = new System.Drawing.Size(682, 682);
            this.sectorViewerPanel.TabIndex = 1;
            // 
            // UniverseMap1
            // 
            this.UniverseMap1.AutoSize = true;
            this.UniverseMap1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.UniverseMap1.BackColor = System.Drawing.Color.Black;
            this.UniverseMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UniverseMap1.ForeColor = System.Drawing.Color.White;
            this.UniverseMap1.Location = new System.Drawing.Point(0, 0);
            this.UniverseMap1.MinimumSize = new System.Drawing.Size(682, 682);
            this.UniverseMap1.Name = "UniverseMap1";
            this.UniverseMap1.Size = new System.Drawing.Size(682, 682);
            this.UniverseMap1.TabIndex = 0;
            // 
            // UniverseMapBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.sectorViewerPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(984, 682);
            this.Name = "UniverseMapBrowser";
            this.Size = new System.Drawing.Size(984, 682);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.sectorViewerPanel.ResumeLayout(false);
            this.sectorViewerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ui_buttonVisitSector;
        private UniverseMap UniverseMap1;
        private System.Windows.Forms.Panel sectorViewerPanel;
        private System.Windows.Forms.Button bSectorView;
        private System.Windows.Forms.Button bSetWaypoint;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label clickedsectordistance;
        private System.Windows.Forms.Label clickedsectorcoordinates;
        private System.Windows.Forms.Label clickedsectorname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
