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
            this.label3 = new System.Windows.Forms.Label();
            this.listView_PlanetMoons = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_SystemPlanets = new System.Windows.Forms.ListView();
            this.text_stars = new System.Windows.Forms.Label();
            this.listView_SystemStars = new System.Windows.Forms.ListView();
            this.button_DockAtFactory = new System.Windows.Forms.Button();
            this.ui_SelectedItemInfoText = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_Ports = new System.Windows.Forms.ListView();
            this.button_landAtPort = new System.Windows.Forms.Button();
            this.button_ResourceExtractors = new System.Windows.Forms.Label();
            this.listView_Extractors = new System.Windows.Forms.ListView();
            this.button_ManageResources = new System.Windows.Forms.Button();
            this.text_Factories = new System.Windows.Forms.Label();
            this.listView_Factories = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listView_PlanetMoons);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listView_SystemPlanets);
            this.panel1.Controls.Add(this.text_stars);
            this.panel1.Controls.Add(this.listView_SystemStars);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 620);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Planet Moons";
            // 
            // listView_PlanetMoons
            // 
            this.listView_PlanetMoons.Location = new System.Drawing.Point(6, 312);
            this.listView_PlanetMoons.Name = "listView_PlanetMoons";
            this.listView_PlanetMoons.Size = new System.Drawing.Size(350, 105);
            this.listView_PlanetMoons.TabIndex = 26;
            this.listView_PlanetMoons.UseCompatibleStateImageBehavior = false;
            this.listView_PlanetMoons.SelectedIndexChanged += new System.EventHandler(this.listView_PlanetMoons_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "System Planets";
            // 
            // listView_SystemPlanets
            // 
            this.listView_SystemPlanets.Location = new System.Drawing.Point(6, 171);
            this.listView_SystemPlanets.Name = "listView_SystemPlanets";
            this.listView_SystemPlanets.Size = new System.Drawing.Size(350, 105);
            this.listView_SystemPlanets.TabIndex = 24;
            this.listView_SystemPlanets.UseCompatibleStateImageBehavior = false;
            this.listView_SystemPlanets.SelectedIndexChanged += new System.EventHandler(this.listView_SystemPlanets_SelectedIndexChanged);
            // 
            // text_stars
            // 
            this.text_stars.AutoSize = true;
            this.text_stars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_stars.Location = new System.Drawing.Point(9, 8);
            this.text_stars.Name = "text_stars";
            this.text_stars.Size = new System.Drawing.Size(104, 20);
            this.text_stars.TabIndex = 22;
            this.text_stars.Text = "System Stars";
            // 
            // listView_SystemStars
            // 
            this.listView_SystemStars.Location = new System.Drawing.Point(6, 31);
            this.listView_SystemStars.Name = "listView_SystemStars";
            this.listView_SystemStars.Size = new System.Drawing.Size(350, 105);
            this.listView_SystemStars.TabIndex = 21;
            this.listView_SystemStars.UseCompatibleStateImageBehavior = false;
            this.listView_SystemStars.SelectedIndexChanged += new System.EventHandler(this.listView_SystemStars_SelectedIndexChanged);
            // 
            // button_DockAtFactory
            // 
            this.button_DockAtFactory.ForeColor = System.Drawing.Color.Black;
            this.button_DockAtFactory.Location = new System.Drawing.Point(11, 416);
            this.button_DockAtFactory.Name = "button_DockAtFactory";
            this.button_DockAtFactory.Size = new System.Drawing.Size(196, 23);
            this.button_DockAtFactory.TabIndex = 23;
            this.button_DockAtFactory.Text = "Dock at Factory";
            this.button_DockAtFactory.UseVisualStyleBackColor = true;
            this.button_DockAtFactory.Click += new System.EventHandler(this.button_DockAtFactory_Click);
            // 
            // ui_SelectedItemInfoText
            // 
            this.ui_SelectedItemInfoText.AutoSize = true;
            this.ui_SelectedItemInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ui_SelectedItemInfoText.Location = new System.Drawing.Point(67, 10);
            this.ui_SelectedItemInfoText.Name = "ui_SelectedItemInfoText";
            this.ui_SelectedItemInfoText.Size = new System.Drawing.Size(304, 29);
            this.ui_SelectedItemInfoText.TabIndex = 26;
            this.ui_SelectedItemInfoText.Text = "Selected Moon/Planet Text";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.listView_Ports);
            this.panel2.Controls.Add(this.button_landAtPort);
            this.panel2.Controls.Add(this.button_ResourceExtractors);
            this.panel2.Controls.Add(this.listView_Extractors);
            this.panel2.Controls.Add(this.button_ManageResources);
            this.panel2.Controls.Add(this.text_Factories);
            this.panel2.Controls.Add(this.listView_Factories);
            this.panel2.Controls.Add(this.ui_SelectedItemInfoText);
            this.panel2.Controls.Add(this.button_DockAtFactory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(374, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 620);
            this.panel2.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Available Ports";
            // 
            // listView_Ports
            // 
            this.listView_Ports.Location = new System.Drawing.Point(11, 140);
            this.listView_Ports.Name = "listView_Ports";
            this.listView_Ports.Size = new System.Drawing.Size(350, 105);
            this.listView_Ports.TabIndex = 34;
            this.listView_Ports.UseCompatibleStateImageBehavior = false;
            this.listView_Ports.SelectedIndexChanged += new System.EventHandler(this.listView_Ports_SelectedIndexChanged);
            // 
            // button_landAtPort
            // 
            this.button_landAtPort.ForeColor = System.Drawing.Color.Black;
            this.button_landAtPort.Location = new System.Drawing.Point(11, 251);
            this.button_landAtPort.Name = "button_landAtPort";
            this.button_landAtPort.Size = new System.Drawing.Size(196, 23);
            this.button_landAtPort.TabIndex = 33;
            this.button_landAtPort.Text = "Land At Port";
            this.button_landAtPort.UseVisualStyleBackColor = true;
            this.button_landAtPort.Click += new System.EventHandler(this.button_landAtPort_Click);
            // 
            // button_ResourceExtractors
            // 
            this.button_ResourceExtractors.AutoSize = true;
            this.button_ResourceExtractors.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResourceExtractors.Location = new System.Drawing.Point(14, 446);
            this.button_ResourceExtractors.Name = "button_ResourceExtractors";
            this.button_ResourceExtractors.Size = new System.Drawing.Size(154, 20);
            this.button_ResourceExtractors.TabIndex = 32;
            this.button_ResourceExtractors.Text = "Resource Extractors";
            // 
            // listView_Extractors
            // 
            this.listView_Extractors.Location = new System.Drawing.Point(11, 469);
            this.listView_Extractors.Name = "listView_Extractors";
            this.listView_Extractors.Size = new System.Drawing.Size(350, 105);
            this.listView_Extractors.TabIndex = 31;
            this.listView_Extractors.UseCompatibleStateImageBehavior = false;
            this.listView_Extractors.SelectedIndexChanged += new System.EventHandler(this.listView_Extractors_SelectedIndexChanged);
            // 
            // button_ManageResources
            // 
            this.button_ManageResources.ForeColor = System.Drawing.Color.Black;
            this.button_ManageResources.Location = new System.Drawing.Point(11, 580);
            this.button_ManageResources.Name = "button_ManageResources";
            this.button_ManageResources.Size = new System.Drawing.Size(196, 23);
            this.button_ManageResources.TabIndex = 30;
            this.button_ManageResources.Text = "Manage Resources";
            this.button_ManageResources.UseVisualStyleBackColor = true;
            this.button_ManageResources.Click += new System.EventHandler(this.button_ManageResources_Click);
            // 
            // text_Factories
            // 
            this.text_Factories.AutoSize = true;
            this.text_Factories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_Factories.Location = new System.Drawing.Point(14, 281);
            this.text_Factories.Name = "text_Factories";
            this.text_Factories.Size = new System.Drawing.Size(75, 20);
            this.text_Factories.TabIndex = 29;
            this.text_Factories.Text = "Factories";
            // 
            // listView_Factories
            // 
            this.listView_Factories.Location = new System.Drawing.Point(11, 305);
            this.listView_Factories.Name = "listView_Factories";
            this.listView_Factories.Size = new System.Drawing.Size(350, 105);
            this.listView_Factories.TabIndex = 28;
            this.listView_Factories.UseCompatibleStateImageBehavior = false;
            this.listView_Factories.SelectedIndexChanged += new System.EventHandler(this.listView_Factories_SelectedIndexChanged);
            // 
            // SolarSystemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(800, 620);
            this.Name = "SolarSystemViewer";
            this.Size = new System.Drawing.Size(800, 620);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_DockAtFactory;
        private System.Windows.Forms.Label text_stars;
        private System.Windows.Forms.ListView listView_SystemStars;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView_PlanetMoons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_SystemPlanets;
        private System.Windows.Forms.Label ui_SelectedItemInfoText;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label button_ResourceExtractors;
        private System.Windows.Forms.Button button_ManageResources;
        private System.Windows.Forms.Label text_Factories;
        private System.Windows.Forms.ListView listView_Factories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_Ports;
        private System.Windows.Forms.Button button_landAtPort;
        private System.Windows.Forms.ListView listView_Extractors;
    }
}
