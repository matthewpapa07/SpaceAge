namespace SpaceAge
{
    partial class SurveyResults
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
            this.planetViewer1 = new SpaceAge.Controls.PlanetViewer();
            this.SuspendLayout();
            // 
            // planetViewer1
            // 
            this.planetViewer1.Location = new System.Drawing.Point(12, 4);
            this.planetViewer1.Name = "planetViewer1";
            this.planetViewer1.Size = new System.Drawing.Size(592, 377);
            this.planetViewer1.TabIndex = 0;
            // 
            // SurveyResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 378);
            this.Controls.Add(this.planetViewer1);
            this.Name = "SurveyResults";
            this.Text = "SurveyResults";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PlanetViewer planetViewer1;
    }
}