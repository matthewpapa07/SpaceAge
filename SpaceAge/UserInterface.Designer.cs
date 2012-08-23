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
            this.visitSectorButton = new System.Windows.Forms.Button();
            this.spaceshipStatus1 = new SpaceAge.SpaceshipStatus();
            this.userFuelMeter1 = new SpaceAge.UserFuelMeter();
            this.uiMap1 = new SpaceAge.UiMap();
            this.uiShipInventory1 = new SpaceAge.Controls.UiInventory();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_Time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(590, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coordinate:";
            // 
            // ui_CoordinateLabel
            // 
            this.ui_CoordinateLabel.AutoSize = true;
            this.ui_CoordinateLabel.Location = new System.Drawing.Point(656, 9);
            this.ui_CoordinateLabel.Name = "ui_CoordinateLabel";
            this.ui_CoordinateLabel.Size = new System.Drawing.Size(98, 13);
            this.ui_CoordinateLabel.TabIndex = 2;
            this.ui_CoordinateLabel.Text = "ui_CoordinateLabel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 601);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fuel Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Credits:";
            // 
            // ui_Credits
            // 
            this.ui_Credits.AutoSize = true;
            this.ui_Credits.Location = new System.Drawing.Point(656, 26);
            this.ui_Credits.Name = "ui_Credits";
            this.ui_Credits.Size = new System.Drawing.Size(53, 13);
            this.ui_Credits.TabIndex = 9;
            this.ui_Credits.Text = "ui_Credits";
            // 
            // visitSectorButton
            // 
            this.visitSectorButton.Location = new System.Drawing.Point(592, 81);
            this.visitSectorButton.Name = "visitSectorButton";
            this.visitSectorButton.Size = new System.Drawing.Size(281, 26);
            this.visitSectorButton.TabIndex = 13;
            this.visitSectorButton.Text = "Visit Sector";
            this.visitSectorButton.UseVisualStyleBackColor = true;
            this.visitSectorButton.Click += new System.EventHandler(this.visitSectorButton_Click);
            // 
            // spaceshipStatus1
            // 
            this.spaceshipStatus1.Location = new System.Drawing.Point(592, 123);
            this.spaceshipStatus1.Name = "spaceshipStatus1";
            this.spaceshipStatus1.Size = new System.Drawing.Size(368, 312);
            this.spaceshipStatus1.TabIndex = 12;
            // 
            // userFuelMeter1
            // 
            this.userFuelMeter1.Location = new System.Drawing.Point(74, 601);
            this.userFuelMeter1.Name = "userFuelMeter1";
            this.userFuelMeter1.Size = new System.Drawing.Size(304, 23);
            this.userFuelMeter1.TabIndex = 6;
            // 
            // uiMap1
            // 
            this.uiMap1.Location = new System.Drawing.Point(4, 9);
            this.uiMap1.Name = "uiMap1";
            this.uiMap1.Size = new System.Drawing.Size(580, 580);
            this.uiMap1.TabIndex = 0;
            // 
            // uiShipInventory1
            // 
            this.uiShipInventory1.Location = new System.Drawing.Point(592, 299);
            this.uiShipInventory1.Name = "uiShipInventory1";
            this.uiShipInventory1.Size = new System.Drawing.Size(334, 235);
            this.uiShipInventory1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(590, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Time:";
            // 
            // ui_Time
            // 
            this.ui_Time.AutoSize = true;
            this.ui_Time.Location = new System.Drawing.Point(656, 43);
            this.ui_Time.Name = "ui_Time";
            this.ui_Time.Size = new System.Drawing.Size(44, 13);
            this.ui_Time.TabIndex = 15;
            this.ui_Time.Text = "ui_Time";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 646);
            this.Controls.Add(this.ui_Time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.visitSectorButton);
            this.Controls.Add(this.spaceshipStatus1);
            this.Controls.Add(this.ui_Credits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userFuelMeter1);
            this.Controls.Add(this.ui_CoordinateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uiMap1);
            this.Name = "UserInterface";
            this.Text = "SpaceAge";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserInterface_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UiMap uiMap1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ui_CoordinateLabel;
        private UserFuelMeter userFuelMeter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ui_Credits;
        private SpaceshipStatus spaceshipStatus1;
        private System.Windows.Forms.Button visitSectorButton;
        private Controls.UiInventory uiShipInventory1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ui_Time;







    }
}