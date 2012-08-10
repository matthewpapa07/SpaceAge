namespace SpaceAge
{
    partial class SpaceshipStatus
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
            this.ui_ViewInfo = new System.Windows.Forms.Button();
            this.ui_SpaceConsumed = new System.Windows.Forms.Label();
            this.ui_Hide = new System.Windows.Forms.Button();
            this.ui_Dump = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.uiInventory1 = new SpaceAge.Controls.UiInventory();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uiInventory1);
            this.panel1.Controls.Add(this.ui_ViewInfo);
            this.panel1.Controls.Add(this.ui_SpaceConsumed);
            this.panel1.Controls.Add(this.ui_Hide);
            this.panel1.Controls.Add(this.ui_Dump);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 304);
            this.panel1.TabIndex = 12;
            // 
            // ui_ViewInfo
            // 
            this.ui_ViewInfo.Location = new System.Drawing.Point(166, 273);
            this.ui_ViewInfo.Name = "ui_ViewInfo";
            this.ui_ViewInfo.Size = new System.Drawing.Size(75, 23);
            this.ui_ViewInfo.TabIndex = 16;
            this.ui_ViewInfo.Text = "Info";
            this.ui_ViewInfo.UseVisualStyleBackColor = true;
            // 
            // ui_SpaceConsumed
            // 
            this.ui_SpaceConsumed.AutoSize = true;
            this.ui_SpaceConsumed.Location = new System.Drawing.Point(139, 11);
            this.ui_SpaceConsumed.Name = "ui_SpaceConsumed";
            this.ui_SpaceConsumed.Size = new System.Drawing.Size(102, 13);
            this.ui_SpaceConsumed.TabIndex = 15;
            this.ui_SpaceConsumed.Text = "ui_SpaceConsumed";
            // 
            // ui_Hide
            // 
            this.ui_Hide.Location = new System.Drawing.Point(85, 273);
            this.ui_Hide.Name = "ui_Hide";
            this.ui_Hide.Size = new System.Drawing.Size(75, 23);
            this.ui_Hide.TabIndex = 14;
            this.ui_Hide.Text = "Activate";
            this.ui_Hide.UseVisualStyleBackColor = true;
            // 
            // ui_Dump
            // 
            this.ui_Dump.Location = new System.Drawing.Point(4, 273);
            this.ui_Dump.Name = "ui_Dump";
            this.ui_Dump.Size = new System.Drawing.Size(75, 23);
            this.ui_Dump.TabIndex = 13;
            this.ui_Dump.Text = "Dump";
            this.ui_Dump.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ship Cargo:";
            // 
            // uiInventory1
            // 
            this.uiInventory1.Location = new System.Drawing.Point(3, 27);
            this.uiInventory1.Name = "uiInventory1";
            this.uiInventory1.Size = new System.Drawing.Size(342, 240);
            this.uiInventory1.TabIndex = 17;
            // 
            // SpaceshipStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SpaceshipStatus";
            this.Size = new System.Drawing.Size(354, 311);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ui_ViewInfo;
        private System.Windows.Forms.Label ui_SpaceConsumed;
        private System.Windows.Forms.Button ui_Hide;
        private System.Windows.Forms.Button ui_Dump;
        private System.Windows.Forms.Label label6;
        private Controls.UiInventory uiInventory1;
    }
}
