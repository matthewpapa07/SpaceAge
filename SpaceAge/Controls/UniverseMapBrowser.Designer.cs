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
            this.bSetWaypoint = new System.Windows.Forms.Button();
            this.bSectorView = new System.Windows.Forms.Button();
            this.ui_buttonVisitSector = new System.Windows.Forms.Button();
            this.sectorViewerPanel = new System.Windows.Forms.Panel();
            this.UniverseMap1 = new SpaceAge.UniverseMap();
            this.panel1.SuspendLayout();
            this.sectorViewerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.bSetWaypoint);
            this.panel1.Controls.Add(this.bSectorView);
            this.panel1.Controls.Add(this.ui_buttonVisitSector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(620, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 620);
            this.panel1.TabIndex = 0;
            // 
            // bSetWaypoint
            // 
            this.bSetWaypoint.Location = new System.Drawing.Point(3, 130);
            this.bSetWaypoint.Name = "bSetWaypoint";
            this.bSetWaypoint.Size = new System.Drawing.Size(180, 119);
            this.bSetWaypoint.TabIndex = 3;
            this.bSetWaypoint.Text = "SetWaypoint";
            this.bSetWaypoint.UseVisualStyleBackColor = true;
            // 
            // bSectorView
            // 
            this.bSectorView.Location = new System.Drawing.Point(3, 255);
            this.bSectorView.Name = "bSectorView";
            this.bSectorView.Size = new System.Drawing.Size(180, 119);
            this.bSectorView.TabIndex = 2;
            this.bSectorView.Text = "Sector View";
            this.bSectorView.UseVisualStyleBackColor = true;
            this.bSectorView.Click += new System.EventHandler(this.bSectorView_Click);
            // 
            // ui_buttonVisitSector
            // 
            this.ui_buttonVisitSector.Location = new System.Drawing.Point(3, 380);
            this.ui_buttonVisitSector.Name = "ui_buttonVisitSector";
            this.ui_buttonVisitSector.Size = new System.Drawing.Size(180, 119);
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
            this.sectorViewerPanel.Size = new System.Drawing.Size(620, 620);
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
            this.UniverseMap1.MinimumSize = new System.Drawing.Size(620, 620);
            this.UniverseMap1.Name = "UniverseMap1";
            this.UniverseMap1.Size = new System.Drawing.Size(620, 620);
            this.UniverseMap1.TabIndex = 0;
            // 
            // UniverseMapBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.sectorViewerPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Name = "UniverseMapBrowser";
            this.Size = new System.Drawing.Size(806, 620);
            this.panel1.ResumeLayout(false);
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
    }
}
