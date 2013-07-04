namespace SpaceAge
{
    partial class UserInterface
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
            this.label1 = new System.Windows.Forms.Label();
            this.ui_CoordinateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ui_Credits = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_Time = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_sectorBrowser = new System.Windows.Forms.Button();
            this.ui_buttonBack = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ui_pilotName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ui_MAINPANEL = new System.Windows.Forms.Panel();
            this.userFuelMeter1 = new SpaceAge.UserFuelMeter();
            this.uiShipInventory1 = new SpaceAge.Controls.UiInventory();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coordinate:";
            // 
            // ui_CoordinateLabel
            // 
            this.ui_CoordinateLabel.AutoSize = true;
            this.ui_CoordinateLabel.Location = new System.Drawing.Point(69, 3);
            this.ui_CoordinateLabel.Name = "ui_CoordinateLabel";
            this.ui_CoordinateLabel.Size = new System.Drawing.Size(98, 13);
            this.ui_CoordinateLabel.TabIndex = 2;
            this.ui_CoordinateLabel.Text = "ui_CoordinateLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fuel Level";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Credits:";
            // 
            // ui_Credits
            // 
            this.ui_Credits.AutoSize = true;
            this.ui_Credits.Location = new System.Drawing.Point(69, 20);
            this.ui_Credits.Name = "ui_Credits";
            this.ui_Credits.Size = new System.Drawing.Size(53, 13);
            this.ui_Credits.TabIndex = 9;
            this.ui_Credits.Text = "ui_Credits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Time:";
            // 
            // ui_Time
            // 
            this.ui_Time.AutoSize = true;
            this.ui_Time.Location = new System.Drawing.Point(69, 37);
            this.ui_Time.Name = "ui_Time";
            this.ui_Time.Size = new System.Drawing.Size(44, 13);
            this.ui_Time.TabIndex = 15;
            this.ui_Time.Text = "ui_Time";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button_sectorBrowser);
            this.panel1.Controls.Add(this.ui_buttonBack);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 682);
            this.panel1.TabIndex = 17;
            // 
            // button_sectorBrowser
            // 
            this.button_sectorBrowser.ForeColor = System.Drawing.Color.Black;
            this.button_sectorBrowser.Location = new System.Drawing.Point(3, 512);
            this.button_sectorBrowser.Name = "button_sectorBrowser";
            this.button_sectorBrowser.Size = new System.Drawing.Size(194, 39);
            this.button_sectorBrowser.TabIndex = 22;
            this.button_sectorBrowser.Text = "Sector Browser";
            this.button_sectorBrowser.UseVisualStyleBackColor = true;
            this.button_sectorBrowser.Click += new System.EventHandler(this.button_sectorBrowser_Click);
            // 
            // ui_buttonBack
            // 
            this.ui_buttonBack.ForeColor = System.Drawing.Color.Black;
            this.ui_buttonBack.Location = new System.Drawing.Point(3, 557);
            this.ui_buttonBack.Name = "ui_buttonBack";
            this.ui_buttonBack.Size = new System.Drawing.Size(194, 39);
            this.ui_buttonBack.TabIndex = 21;
            this.ui_buttonBack.Text = "<===== Back";
            this.ui_buttonBack.UseVisualStyleBackColor = true;
            this.ui_buttonBack.Click += new System.EventHandler(this.ui_buttonBack_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label11);
            this.panel6.Location = new System.Drawing.Point(3, 188);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 58);
            this.panel6.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Current Waypoint Info";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.ui_pilotName);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(194, 58);
            this.panel5.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pilot Name:";
            // 
            // ui_pilotName
            // 
            this.ui_pilotName.AutoSize = true;
            this.ui_pilotName.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_pilotName.Location = new System.Drawing.Point(3, 16);
            this.ui_pilotName.Name = "ui_pilotName";
            this.ui_pilotName.Size = new System.Drawing.Size(182, 30);
            this.ui_pilotName.TabIndex = 17;
            this.ui_pilotName.Text = "Captain Matt P";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(3, 64);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 58);
            this.panel4.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(106, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Hull: 100%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Guage 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Shields: 100%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Crew Status: 34/50";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ship Status: Moderate";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.userFuelMeter1);
            this.panel3.Location = new System.Drawing.Point(3, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(194, 58);
            this.panel3.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ui_Credits);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ui_CoordinateLabel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ui_Time);
            this.panel2.Location = new System.Drawing.Point(3, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(194, 58);
            this.panel2.TabIndex = 17;
            // 
            // ui_MAINPANEL
            // 
            this.ui_MAINPANEL.AutoSize = true;
            this.ui_MAINPANEL.BackColor = System.Drawing.Color.Black;
            this.ui_MAINPANEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ui_MAINPANEL.Location = new System.Drawing.Point(200, 0);
            this.ui_MAINPANEL.MinimumSize = new System.Drawing.Size(984, 682);
            this.ui_MAINPANEL.Name = "ui_MAINPANEL";
            this.ui_MAINPANEL.Size = new System.Drawing.Size(984, 682);
            this.ui_MAINPANEL.TabIndex = 18;
            // 
            // userFuelMeter1
            // 
            this.userFuelMeter1.Location = new System.Drawing.Point(6, 26);
            this.userFuelMeter1.Name = "userFuelMeter1";
            this.userFuelMeter1.Size = new System.Drawing.Size(185, 23);
            this.userFuelMeter1.TabIndex = 6;
            this.userFuelMeter1.Load += new System.EventHandler(this.userFuelMeter1_Load);
            // 
            // uiShipInventory1
            // 
            this.uiShipInventory1.Location = new System.Drawing.Point(592, 299);
            this.uiShipInventory1.Name = "uiShipInventory1";
            this.uiShipInventory1.Size = new System.Drawing.Size(334, 235);
            this.uiShipInventory1.TabIndex = 14;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1184, 682);
            this.Controls.Add(this.ui_MAINPANEL);
            this.Controls.Add(this.panel1);
            this.Name = "UserInterface";
            this.Text = "SpaceAge";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserInterface_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ui_CoordinateLabel;
        private UserFuelMeter userFuelMeter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ui_Credits;
        private Controls.UiInventory uiShipInventory1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ui_Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ui_pilotName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel ui_MAINPANEL;
        private System.Windows.Forms.Button ui_buttonBack;
        private System.Windows.Forms.Button button_sectorBrowser;







    }
}