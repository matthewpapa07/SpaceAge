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
            this.label8 = new System.Windows.Forms.Label();
            this.ui_Inhabited = new System.Windows.Forms.CheckBox();
            this.ui_Approach = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ui_SectorList = new System.Windows.Forms.ListView();
            this.ui_SurveyObject = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_Interaction = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ui_checkBox_stars = new System.Windows.Forms.CheckBox();
            this.ui_checkBox_other = new System.Windows.Forms.CheckBox();
            this.ui_checkBox_planets = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ui_SystemList = new System.Windows.Forms.ListView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.ui_Inhabited);
            this.panel2.Controls.Add(this.ui_Approach);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ui_SectorList);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(7, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 478);
            this.panel2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "label8";
            // 
            // ui_Inhabited
            // 
            this.ui_Inhabited.AutoSize = true;
            this.ui_Inhabited.Location = new System.Drawing.Point(5, 343);
            this.ui_Inhabited.Name = "ui_Inhabited";
            this.ui_Inhabited.Size = new System.Drawing.Size(80, 17);
            this.ui_Inhabited.TabIndex = 9;
            this.ui_Inhabited.Text = "checkBox1";
            this.ui_Inhabited.UseVisualStyleBackColor = true;
            // 
            // ui_Approach
            // 
            this.ui_Approach.Location = new System.Drawing.Point(6, 210);
            this.ui_Approach.Name = "ui_Approach";
            this.ui_Approach.Size = new System.Drawing.Size(321, 23);
            this.ui_Approach.TabIndex = 8;
            this.ui_Approach.Text = "Approach";
            this.ui_Approach.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Survey Results";
            // 
            // ui_SectorList
            // 
            this.ui_SectorList.Location = new System.Drawing.Point(5, 24);
            this.ui_SectorList.Name = "ui_SectorList";
            this.ui_SectorList.Size = new System.Drawing.Size(322, 180);
            this.ui_SectorList.TabIndex = 6;
            this.ui_SectorList.UseCompatibleStateImageBehavior = false;
            this.ui_SectorList.SelectedIndexChanged += new System.EventHandler(this.ui_SectorList_SelectedIndexChanged);
            // 
            // ui_SurveyObject
            // 
            this.ui_SurveyObject.Location = new System.Drawing.Point(3, 239);
            this.ui_SurveyObject.Name = "ui_SurveyObject";
            this.ui_SurveyObject.Size = new System.Drawing.Size(321, 23);
            this.ui_SurveyObject.TabIndex = 5;
            this.ui_SurveyObject.Text = "Survey Object";
            this.ui_SurveyObject.UseVisualStyleBackColor = true;
            this.ui_SurveyObject.Click += new System.EventHandler(this.ui_SurveyObject_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sector Survey";
            // 
            // ui_Interaction
            // 
            this.ui_Interaction.Enabled = false;
            this.ui_Interaction.Location = new System.Drawing.Point(3, 210);
            this.ui_Interaction.Name = "ui_Interaction";
            this.ui_Interaction.Size = new System.Drawing.Size(320, 23);
            this.ui_Interaction.TabIndex = 11;
            this.ui_Interaction.Text = "Interaction";
            this.ui_Interaction.UseVisualStyleBackColor = true;
            this.ui_Interaction.Click += new System.EventHandler(this.ui_Interaction_Click);
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
            this.panel1.Location = new System.Drawing.Point(343, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 478);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Enabled Elements";
            // 
            // ui_checkBox_stars
            // 
            this.ui_checkBox_stars.AutoSize = true;
            this.ui_checkBox_stars.Checked = true;
            this.ui_checkBox_stars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_stars.Location = new System.Drawing.Point(76, 448);
            this.ui_checkBox_stars.Name = "ui_checkBox_stars";
            this.ui_checkBox_stars.Size = new System.Drawing.Size(50, 17);
            this.ui_checkBox_stars.TabIndex = 16;
            this.ui_checkBox_stars.Text = "Stars";
            this.ui_checkBox_stars.UseVisualStyleBackColor = true;
            // 
            // ui_checkBox_other
            // 
            this.ui_checkBox_other.AutoSize = true;
            this.ui_checkBox_other.Checked = true;
            this.ui_checkBox_other.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_other.Location = new System.Drawing.Point(132, 448);
            this.ui_checkBox_other.Name = "ui_checkBox_other";
            this.ui_checkBox_other.Size = new System.Drawing.Size(52, 17);
            this.ui_checkBox_other.TabIndex = 15;
            this.ui_checkBox_other.Text = "Other";
            this.ui_checkBox_other.UseVisualStyleBackColor = true;
            // 
            // ui_checkBox_planets
            // 
            this.ui_checkBox_planets.AutoSize = true;
            this.ui_checkBox_planets.Checked = true;
            this.ui_checkBox_planets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ui_checkBox_planets.Location = new System.Drawing.Point(9, 448);
            this.ui_checkBox_planets.Name = "ui_checkBox_planets";
            this.ui_checkBox_planets.Size = new System.Drawing.Size(61, 17);
            this.ui_checkBox_planets.TabIndex = 14;
            this.ui_checkBox_planets.Text = "Planets";
            this.ui_checkBox_planets.UseVisualStyleBackColor = true;
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
            // ui_SystemList
            // 
            this.ui_SystemList.Location = new System.Drawing.Point(3, 24);
            this.ui_SystemList.Name = "ui_SystemList";
            this.ui_SystemList.Size = new System.Drawing.Size(320, 180);
            this.ui_SystemList.TabIndex = 12;
            this.ui_SystemList.UseCompatibleStateImageBehavior = false;
            this.ui_SystemList.SelectedIndexChanged += new System.EventHandler(this.ui_SystemList_SelectedIndexChanged);
            // 
            // SectorBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SectorBrowser";
            this.Size = new System.Drawing.Size(681, 488);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button ui_Approach;
        private System.Windows.Forms.ListView ui_SectorList;
        private System.Windows.Forms.Button ui_SurveyObject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ui_Inhabited;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ui_Interaction;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ui_SystemList;
        private System.Windows.Forms.CheckBox ui_checkBox_stars;
        private System.Windows.Forms.CheckBox ui_checkBox_other;
        private System.Windows.Forms.CheckBox ui_checkBox_planets;
        private System.Windows.Forms.Label label3;
    }
}
