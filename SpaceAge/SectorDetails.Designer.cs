namespace SpaceAge
{
    partial class SectorDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.uiSectorMap1 = new SpaceAge.Controls.UiSectorMap();
            this.sectorBrowser1 = new SpaceAge.SectorBrowser();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Scan Region";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Visit Coordinate";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // uiSectorMap1
            // 
            this.uiSectorMap1.Location = new System.Drawing.Point(12, 12);
            this.uiSectorMap1.Name = "uiSectorMap1";
            this.uiSectorMap1.Size = new System.Drawing.Size(200, 200);
            this.uiSectorMap1.TabIndex = 1;
            // 
            // sectorBrowser1
            // 
            this.sectorBrowser1.Location = new System.Drawing.Point(218, 2);
            this.sectorBrowser1.Name = "sectorBrowser1";
            this.sectorBrowser1.Size = new System.Drawing.Size(710, 378);
            this.sectorBrowser1.TabIndex = 0;
            // 
            // SectorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 392);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiSectorMap1);
            this.Controls.Add(this.sectorBrowser1);
            this.Name = "SectorDetails";
            this.Text = "Sector Details";
            this.ResumeLayout(false);

        }

        #endregion

        private SectorBrowser sectorBrowser1;
        private Controls.UiSectorMap uiSectorMap1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}