namespace SpaceAge.Controls
{
    partial class SectorBrowserWhole
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
            this.ui_buttonVisitSector = new System.Windows.Forms.Button();
            this.uiMap1 = new SpaceAge.UiMap();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.ui_buttonVisitSector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(620, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 620);
            this.panel1.TabIndex = 0;
            // 
            // ui_buttonVisitSector
            // 
            this.ui_buttonVisitSector.Location = new System.Drawing.Point(3, 245);
            this.ui_buttonVisitSector.Name = "ui_buttonVisitSector";
            this.ui_buttonVisitSector.Size = new System.Drawing.Size(180, 119);
            this.ui_buttonVisitSector.TabIndex = 1;
            this.ui_buttonVisitSector.Text = "Visit Sector";
            this.ui_buttonVisitSector.UseVisualStyleBackColor = true;
            this.ui_buttonVisitSector.Click += new System.EventHandler(this.ui_buttonVisitSector_Click);
            // 
            // uiMap1
            // 
            this.uiMap1.AutoSize = true;
            this.uiMap1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uiMap1.BackColor = System.Drawing.Color.Black;
            this.uiMap1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uiMap1.ForeColor = System.Drawing.Color.White;
            this.uiMap1.Location = new System.Drawing.Point(0, 0);
            this.uiMap1.MinimumSize = new System.Drawing.Size(620, 620);
            this.uiMap1.Name = "uiMap1";
            this.uiMap1.Size = new System.Drawing.Size(620, 620);
            this.uiMap1.TabIndex = 0;
            // 
            // SectorBrowserWhole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiMap1);
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Name = "SectorBrowserWhole";
            this.Size = new System.Drawing.Size(800, 620);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ui_buttonVisitSector;
        private UiMap uiMap1;
    }
}
