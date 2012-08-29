namespace SpaceAge
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Approach = new System.Windows.Forms.Button();
            this.back_systemPanel = new System.Windows.Forms.Panel();
            this.ui_SectorMapPanel = new System.Windows.Forms.Panel();
            this.ui_SectorList = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_Interaction = new System.Windows.Forms.Button();
            this.ui_SystemList = new System.Windows.Forms.ListView();
            this.ui_SurveyObject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_checkBox_planets = new System.Windows.Forms.CheckBox();
            this.ui_checkBox_other = new System.Windows.Forms.CheckBox();
            this.ui_checkBox_stars = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.back_systemPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_Approach);
            this.panel2.Controls.Add(this.back_systemPanel);
            this.panel2.Controls.Add(this.ui_SectorList);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 617);
            this.panel2.TabIndex = 6;
            // 
            // button_Approach
            // 
            this.button_Approach.ForeColor = System.Drawing.Color.Black;
            this.button_Approach.Location = new System.Drawing.Point(4, 563);
            this.button_Approach.Name = "button_Approach";
            this.button_Approach.Size = new System.Drawing.Size(372, 23);
            this.button_Approach.TabIndex = 11;
            this.button_Approach.Text = "Approach";
            this.button_Approach.UseVisualStyleBackColor = true;
            this.button_Approach.Click += new System.EventHandler(this.button_Approach_Click);
            // 
            // back_systemPanel
            // 
            this.back_systemPanel.BackColor = System.Drawing.Color.Red;
            this.back_systemPanel.Controls.Add(this.ui_SectorMapPanel);
            this.back_systemPanel.Location = new System.Drawing.Point(3, 6);
            this.back_systemPanel.Name = "back_systemPanel";
            this.back_systemPanel.Size = new System.Drawing.Size(374, 374);
            this.back_systemPanel.TabIndex = 10;
            // 
            // ui_SectorMapPanel
            // 
            this.ui_SectorMapPanel.Location = new System.Drawing.Point(1, 1);
            this.ui_SectorMapPanel.Name = "ui_SectorMapPanel";
            this.ui_SectorMapPanel.Size = new System.Drawing.Size(372, 372);
            this.ui_SectorMapPanel.TabIndex = 9;
            // 
            // ui_SectorList
            // 
            this.ui_SectorList.Location = new System.Drawing.Point(6, 405);
            this.ui_SectorList.Name = "ui_SectorList";
            this.ui_SectorList.Size = new System.Drawing.Size(371, 151);
            this.ui_SectorList.TabIndex = 6;
            this.ui_SectorList.UseCompatibleStateImageBehavior = false;
            this.ui_SectorList.SelectedIndexChanged += new System.EventHandler(this.ui_SectorList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sector Survey";
            // 
            // ui_Interaction
            // 
            this.ui_Interaction.Enabled = false;
            this.ui_Interaction.ForeColor = System.Drawing.Color.Black;
            this.ui_Interaction.Location = new System.Drawing.Point(0, 268);
            this.ui_Interaction.Name = "ui_Interaction";
            this.ui_Interaction.Size = new System.Drawing.Size(196, 23);
            this.ui_Interaction.TabIndex = 11;
            this.ui_Interaction.Text = "Interaction";
            this.ui_Interaction.UseVisualStyleBackColor = true;
            this.ui_Interaction.Click += new System.EventHandler(this.ui_Interaction_Click);
            // 
            // ui_SystemList
            // 
            this.ui_SystemList.Location = new System.Drawing.Point(3, 24);
            this.ui_SystemList.Name = "ui_SystemList";
            this.ui_SystemList.Size = new System.Drawing.Size(399, 180);
            this.ui_SystemList.TabIndex = 12;
            this.ui_SystemList.UseCompatibleStateImageBehavior = false;
            this.ui_SystemList.SelectedIndexChanged += new System.EventHandler(this.ui_SystemList_SelectedIndexChanged);
            // 
            // ui_SurveyObject
            // 
            this.ui_SurveyObject.ForeColor = System.Drawing.Color.Black;
            this.ui_SurveyObject.Location = new System.Drawing.Point(202, 268);
            this.ui_SurveyObject.Name = "ui_SurveyObject";
            this.ui_SurveyObject.Size = new System.Drawing.Size(196, 23);
            this.ui_SurveyObject.TabIndex = 5;
            this.ui_SurveyObject.Text = "Survey Object";
            this.ui_SurveyObject.UseVisualStyleBackColor = true;
            this.ui_SurveyObject.Click += new System.EventHandler(this.ui_SurveyObject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "System Object Details";
            // 
            // ui_checkBox_planets
            // 
            this.ui_checkBox_planets.AutoSize = true;
            this.ui_checkBox_planets.Checked = true;
            this.ui_checkBox_planets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_planets.Location = new System.Drawing.Point(104, 213);
            this.ui_checkBox_planets.Name = "ui_checkBox_planets";
            this.ui_checkBox_planets.Size = new System.Drawing.Size(61, 17);
            this.ui_checkBox_planets.TabIndex = 14;
            this.ui_checkBox_planets.Text = "Planets";
            this.ui_checkBox_planets.UseVisualStyleBackColor = true;
            // 
            // ui_checkBox_other
            // 
            this.ui_checkBox_other.AutoSize = true;
            this.ui_checkBox_other.Checked = true;
            this.ui_checkBox_other.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_other.Location = new System.Drawing.Point(227, 213);
            this.ui_checkBox_other.Name = "ui_checkBox_other";
            this.ui_checkBox_other.Size = new System.Drawing.Size(52, 17);
            this.ui_checkBox_other.TabIndex = 15;
            this.ui_checkBox_other.Text = "Other";
            this.ui_checkBox_other.UseVisualStyleBackColor = true;
            // 
            // ui_checkBox_stars
            // 
            this.ui_checkBox_stars.AutoSize = true;
            this.ui_checkBox_stars.Checked = true;
            this.ui_checkBox_stars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_stars.Location = new System.Drawing.Point(171, 213);
            this.ui_checkBox_stars.Name = "ui_checkBox_stars";
            this.ui_checkBox_stars.Size = new System.Drawing.Size(50, 17);
            this.ui_checkBox_stars.TabIndex = 16;
            this.ui_checkBox_stars.Text = "Stars";
            this.ui_checkBox_stars.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enabled Elements";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ui_checkBox_stars);
            this.panel1.Controls.Add(this.ui_checkBox_other);
            this.panel1.Controls.Add(this.ui_checkBox_planets);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ui_SurveyObject);
            this.panel1.Controls.Add(this.ui_SystemList);
            this.panel1.Controls.Add(this.ui_Interaction);
            this.panel1.Location = new System.Drawing.Point(390, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(414, 617);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(807, 620);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.back_systemPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView ui_SectorList;
        private System.Windows.Forms.Panel ui_SectorMapPanel;
        private System.Windows.Forms.Panel back_systemPanel;
        private System.Windows.Forms.Button ui_Interaction;
        private System.Windows.Forms.ListView ui_SystemList;
        private System.Windows.Forms.Button ui_SurveyObject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ui_checkBox_planets;
        private System.Windows.Forms.CheckBox ui_checkBox_other;
        private System.Windows.Forms.CheckBox ui_checkBox_stars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Approach;
    }
}
