﻿namespace SpaceAge
{
    partial class UniverseMap
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
            this.SuspendLayout();
            // 
            // UniverseMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.MinimumSize = new System.Drawing.Size(620, 620);
            this.Name = "UniverseMap";
            this.Size = new System.Drawing.Size(620, 620);
            this.AutoSizeChanged += new System.EventHandler(this.UniverseMap_SizeChanged);
            this.Load += new System.EventHandler(this.UniverseMap_Load);
            this.SizeChanged += new System.EventHandler(this.UniverseMap_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

    }
}