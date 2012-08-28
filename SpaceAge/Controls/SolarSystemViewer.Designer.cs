namespace SpaceAge.Controls
{
    partial class SolarSystemViewer
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
            this.ui_BuyResources = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_SurveyObject = new System.Windows.Forms.Button();
            this.ui_SystemList = new System.Windows.Forms.ListView();
            this.ui_Interaction = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ui_BuyResources);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ui_Interaction);
            this.panel1.Controls.Add(this.ui_SurveyObject);
            this.panel1.Controls.Add(this.ui_SystemList);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 620);
            this.panel1.TabIndex = 0;
            // 
            // ui_BuyResources
            // 
            this.ui_BuyResources.ForeColor = System.Drawing.Color.Black;
            this.ui_BuyResources.Location = new System.Drawing.Point(5, 251);
            this.ui_BuyResources.Name = "ui_BuyResources";
            this.ui_BuyResources.Size = new System.Drawing.Size(196, 23);
            this.ui_BuyResources.TabIndex = 23;
            this.ui_BuyResources.Text = "Buy Resources";
            this.ui_BuyResources.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "System Object Details";
            // 
            // ui_SurveyObject
            // 
            this.ui_SurveyObject.ForeColor = System.Drawing.Color.Black;
            this.ui_SurveyObject.Location = new System.Drawing.Point(207, 222);
            this.ui_SurveyObject.Name = "ui_SurveyObject";
            this.ui_SurveyObject.Size = new System.Drawing.Size(196, 23);
            this.ui_SurveyObject.TabIndex = 19;
            this.ui_SurveyObject.Text = "Survey Object";
            this.ui_SurveyObject.UseVisualStyleBackColor = true;
            // 
            // ui_SystemList
            // 
            this.ui_SystemList.Location = new System.Drawing.Point(6, 25);
            this.ui_SystemList.Name = "ui_SystemList";
            this.ui_SystemList.Size = new System.Drawing.Size(399, 180);
            this.ui_SystemList.TabIndex = 21;
            this.ui_SystemList.UseCompatibleStateImageBehavior = false;
            // 
            // ui_Interaction
            // 
            this.ui_Interaction.Enabled = false;
            this.ui_Interaction.ForeColor = System.Drawing.Color.Black;
            this.ui_Interaction.Location = new System.Drawing.Point(5, 222);
            this.ui_Interaction.Name = "ui_Interaction";
            this.ui_Interaction.Size = new System.Drawing.Size(196, 23);
            this.ui_Interaction.TabIndex = 20;
            this.ui_Interaction.Text = "Interaction";
            this.ui_Interaction.UseVisualStyleBackColor = true;
            // 
            // SolarSystemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Name = "SolarSystemViewer";
            this.Size = new System.Drawing.Size(800, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ui_BuyResources;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ui_Interaction;
        private System.Windows.Forms.Button ui_SurveyObject;
        private System.Windows.Forms.ListView ui_SystemList;
    }
}
