namespace SpaceAge.Controls
{
    partial class SectorNavigationPane
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
            this.North_Panel = new System.Windows.Forms.Panel();
            this.East_Panel = new System.Windows.Forms.Panel();
            this.West_Panel = new System.Windows.Forms.Panel();
            this.South_Panel = new System.Windows.Forms.Panel();
            this.sectorMapComplex1 = new SpaceAge.Controls.SectorMapComplex();
            this.SuspendLayout();
            // 
            // North_Panel
            // 
            this.North_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.North_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.North_Panel.Location = new System.Drawing.Point(0, 0);
            this.North_Panel.Name = "North_Panel";
            this.North_Panel.Size = new System.Drawing.Size(559, 10);
            this.North_Panel.TabIndex = 1;
            this.North_Panel.DoubleClick += new System.EventHandler(this.North_Panel_DoubleClick);
            // 
            // East_Panel
            // 
            this.East_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.East_Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.East_Panel.Location = new System.Drawing.Point(549, 10);
            this.East_Panel.Name = "East_Panel";
            this.East_Panel.Size = new System.Drawing.Size(10, 381);
            this.East_Panel.TabIndex = 2;
            this.East_Panel.DoubleClick += new System.EventHandler(this.East_Panel_DoubleClick);
            // 
            // West_Panel
            // 
            this.West_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.West_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.West_Panel.Location = new System.Drawing.Point(0, 10);
            this.West_Panel.Name = "West_Panel";
            this.West_Panel.Size = new System.Drawing.Size(10, 381);
            this.West_Panel.TabIndex = 3;
            this.West_Panel.DoubleClick += new System.EventHandler(this.West_Panel_DoubleClick);
            // 
            // South_Panel
            // 
            this.South_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.South_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.South_Panel.Location = new System.Drawing.Point(10, 381);
            this.South_Panel.Name = "South_Panel";
            this.South_Panel.Size = new System.Drawing.Size(539, 10);
            this.South_Panel.TabIndex = 4;
            this.South_Panel.DoubleClick += new System.EventHandler(this.South_Panel_DoubleClick);
            // 
            // sectorMapComplex1
            // 
            this.sectorMapComplex1.BackColor = System.Drawing.Color.Black;
            this.sectorMapComplex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorMapComplex1.Location = new System.Drawing.Point(0, 0);
            this.sectorMapComplex1.Name = "sectorMapComplex1";
            this.sectorMapComplex1.Size = new System.Drawing.Size(559, 391);
            this.sectorMapComplex1.TabIndex = 0;
            // 
            // SectorNavigationPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.South_Panel);
            this.Controls.Add(this.West_Panel);
            this.Controls.Add(this.East_Panel);
            this.Controls.Add(this.North_Panel);
            this.Controls.Add(this.sectorMapComplex1);
            this.Name = "SectorNavigationPane";
            this.Size = new System.Drawing.Size(559, 391);
            this.ResumeLayout(false);

        }

        #endregion

        private SectorMapComplex sectorMapComplex1;
        private System.Windows.Forms.Panel North_Panel;
        private System.Windows.Forms.Panel East_Panel;
        private System.Windows.Forms.Panel West_Panel;
        private System.Windows.Forms.Panel South_Panel;
    }
}
