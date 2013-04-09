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
            this.sectorMapComplex1 = new SpaceAge.Controls.SectorMapComplex();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(607, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 620);
            this.panel1.TabIndex = 1;
            // 
            // sectorMapComplex1
            // 
            this.sectorMapComplex1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sectorMapComplex1.Location = new System.Drawing.Point(0, 0);
            this.sectorMapComplex1.Name = "sectorMapComplex1";
            this.sectorMapComplex1.Size = new System.Drawing.Size(807, 620);
            this.sectorMapComplex1.TabIndex = 0;
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sectorMapComplex1);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(807, 620);
            this.ResumeLayout(false);

        }

        #endregion

        private SectorMapComplex sectorMapComplex1;
        private System.Windows.Forms.Panel panel1;
    }
}
