namespace SpaceAge
{
    partial class InteractionCenterUi
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_info = new System.Windows.Forms.TabPage();
            this.InteractionCenter_InfoName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tab_market = new System.Windows.Forms.TabPage();
            this.market_cargo_space = new System.Windows.Forms.Label();
            this.cargo_space_label = new System.Windows.Forms.Label();
            this.Market_ShipCommodities = new System.Windows.Forms.ListView();
            this.BuyPrice = new System.Windows.Forms.TextBox();
            this.SellPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Market_MarketCommodities = new System.Windows.Forms.ListView();
            this.InteractionCenter_Credits = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SellQuantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InteractionCenter_SellButton = new System.Windows.Forms.Button();
            this.BuyQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InteractionCenter_BuyButton = new System.Windows.Forms.Button();
            this.tab_escrow = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Escrow_StoreList = new System.Windows.Forms.ListView();
            this.Escrow_PlayerList = new System.Windows.Forms.ListView();
            this.tab_agents = new System.Windows.Forms.TabPage();
            this.tab_people = new System.Windows.Forms.TabPage();
            this.tab_politics = new System.Windows.Forms.TabPage();
            this.Info_Population = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tab_info.SuspendLayout();
            this.tab_market.SuspendLayout();
            this.tab_escrow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_info);
            this.tabControl1.Controls.Add(this.tab_market);
            this.tabControl1.Controls.Add(this.tab_escrow);
            this.tabControl1.Controls.Add(this.tab_agents);
            this.tabControl1.Controls.Add(this.tab_people);
            this.tabControl1.Controls.Add(this.tab_politics);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 367);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_info
            // 
            this.tab_info.Controls.Add(this.Info_Population);
            this.tab_info.Controls.Add(this.InteractionCenter_InfoName);
            this.tab_info.Controls.Add(this.label8);
            this.tab_info.Controls.Add(this.label7);
            this.tab_info.Controls.Add(this.label6);
            this.tab_info.Controls.Add(this.label5);
            this.tab_info.Controls.Add(this.label4);
            this.tab_info.Controls.Add(this.label3);
            this.tab_info.Location = new System.Drawing.Point(4, 22);
            this.tab_info.Name = "tab_info";
            this.tab_info.Padding = new System.Windows.Forms.Padding(3);
            this.tab_info.Size = new System.Drawing.Size(693, 341);
            this.tab_info.TabIndex = 4;
            this.tab_info.Text = "Info";
            this.tab_info.UseVisualStyleBackColor = true;
            // 
            // InteractionCenter_InfoName
            // 
            this.InteractionCenter_InfoName.AutoSize = true;
            this.InteractionCenter_InfoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InteractionCenter_InfoName.Location = new System.Drawing.Point(3, 9);
            this.InteractionCenter_InfoName.Name = "InteractionCenter_InfoName";
            this.InteractionCenter_InfoName.Size = new System.Drawing.Size(276, 31);
            this.InteractionCenter_InfoName.TabIndex = 7;
            this.InteractionCenter_InfoName.Text = "Planet: Sample Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Income Tax: 3%";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sales Tax: 2%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Annual GDP: 0000 Million Credits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Sovereignty: Terran Alliance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Settlement Type: Planet Trade Center";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Population:";
            // 
            // tab_market
            // 
            this.tab_market.Controls.Add(this.market_cargo_space);
            this.tab_market.Controls.Add(this.cargo_space_label);
            this.tab_market.Controls.Add(this.Market_ShipCommodities);
            this.tab_market.Controls.Add(this.BuyPrice);
            this.tab_market.Controls.Add(this.SellPrice);
            this.tab_market.Controls.Add(this.label11);
            this.tab_market.Controls.Add(this.label10);
            this.tab_market.Controls.Add(this.Market_MarketCommodities);
            this.tab_market.Controls.Add(this.InteractionCenter_Credits);
            this.tab_market.Controls.Add(this.label9);
            this.tab_market.Controls.Add(this.SellQuantity);
            this.tab_market.Controls.Add(this.label2);
            this.tab_market.Controls.Add(this.InteractionCenter_SellButton);
            this.tab_market.Controls.Add(this.BuyQuantity);
            this.tab_market.Controls.Add(this.label1);
            this.tab_market.Controls.Add(this.InteractionCenter_BuyButton);
            this.tab_market.Location = new System.Drawing.Point(4, 22);
            this.tab_market.Name = "tab_market";
            this.tab_market.Padding = new System.Windows.Forms.Padding(3);
            this.tab_market.Size = new System.Drawing.Size(693, 341);
            this.tab_market.TabIndex = 0;
            this.tab_market.Text = "Market";
            this.tab_market.UseVisualStyleBackColor = true;
            // 
            // market_cargo_space
            // 
            this.market_cargo_space.AutoSize = true;
            this.market_cargo_space.Location = new System.Drawing.Point(302, 9);
            this.market_cargo_space.Name = "market_cargo_space";
            this.market_cargo_space.Size = new System.Drawing.Size(41, 13);
            this.market_cargo_space.TabIndex = 18;
            this.market_cargo_space.Text = "0/0 m3";
            // 
            // cargo_space_label
            // 
            this.cargo_space_label.AutoSize = true;
            this.cargo_space_label.Location = new System.Drawing.Point(227, 9);
            this.cargo_space_label.Name = "cargo_space_label";
            this.cargo_space_label.Size = new System.Drawing.Size(72, 13);
            this.cargo_space_label.TabIndex = 17;
            this.cargo_space_label.Text = "Cargo Space:";
            // 
            // Market_ShipCommodities
            // 
            this.Market_ShipCommodities.Location = new System.Drawing.Point(7, 28);
            this.Market_ShipCommodities.MultiSelect = false;
            this.Market_ShipCommodities.Name = "Market_ShipCommodities";
            this.Market_ShipCommodities.Size = new System.Drawing.Size(336, 234);
            this.Market_ShipCommodities.TabIndex = 16;
            this.Market_ShipCommodities.UseCompatibleStateImageBehavior = false;
            this.Market_ShipCommodities.SelectedIndexChanged += new System.EventHandler(this.Market_ShipCommodities_SelectedIndexChanged);
            // 
            // BuyPrice
            // 
            this.BuyPrice.Location = new System.Drawing.Point(570, 272);
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.Size = new System.Drawing.Size(100, 20);
            this.BuyPrice.TabIndex = 15;
            this.BuyPrice.Text = "0";
            // 
            // SellPrice
            // 
            this.SellPrice.Location = new System.Drawing.Point(227, 272);
            this.SellPrice.Name = "SellPrice";
            this.SellPrice.Size = new System.Drawing.Size(100, 20);
            this.SellPrice.TabIndex = 14;
            this.SellPrice.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(536, 275);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "For: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "For: ";
            // 
            // Market_MarketCommodities
            // 
            this.Market_MarketCommodities.Location = new System.Drawing.Point(348, 28);
            this.Market_MarketCommodities.MultiSelect = false;
            this.Market_MarketCommodities.Name = "Market_MarketCommodities";
            this.Market_MarketCommodities.Size = new System.Drawing.Size(336, 234);
            this.Market_MarketCommodities.TabIndex = 11;
            this.Market_MarketCommodities.UseCompatibleStateImageBehavior = false;
            this.Market_MarketCommodities.SelectedIndexChanged += new System.EventHandler(this.Market_MarketCommodities_SelectedIndexChanged);
            // 
            // InteractionCenter_Credits
            // 
            this.InteractionCenter_Credits.AutoSize = true;
            this.InteractionCenter_Credits.BackColor = System.Drawing.Color.Lime;
            this.InteractionCenter_Credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InteractionCenter_Credits.ForeColor = System.Drawing.Color.Blue;
            this.InteractionCenter_Credits.Location = new System.Drawing.Point(121, 7);
            this.InteractionCenter_Credits.Name = "InteractionCenter_Credits";
            this.InteractionCenter_Credits.Size = new System.Drawing.Size(48, 17);
            this.InteractionCenter_Credits.TabIndex = 10;
            this.InteractionCenter_Credits.Text = "99999";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Available Credits:";
            // 
            // SellQuantity
            // 
            this.SellQuantity.Location = new System.Drawing.Point(148, 273);
            this.SellQuantity.Name = "SellQuantity";
            this.SellQuantity.Size = new System.Drawing.Size(39, 20);
            this.SellQuantity.TabIndex = 8;
            this.SellQuantity.Text = "0";
            this.SellQuantity.TextChanged += new System.EventHandler(this.SellQuantity_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Quantity";
            // 
            // InteractionCenter_SellButton
            // 
            this.InteractionCenter_SellButton.Location = new System.Drawing.Point(15, 271);
            this.InteractionCenter_SellButton.Name = "InteractionCenter_SellButton";
            this.InteractionCenter_SellButton.Size = new System.Drawing.Size(75, 23);
            this.InteractionCenter_SellButton.TabIndex = 6;
            this.InteractionCenter_SellButton.Text = "Sell";
            this.InteractionCenter_SellButton.UseVisualStyleBackColor = true;
            this.InteractionCenter_SellButton.Click += new System.EventHandler(this.InteractionCenter_SellButton_Click);
            // 
            // BuyQuantity
            // 
            this.BuyQuantity.Location = new System.Drawing.Point(491, 272);
            this.BuyQuantity.Name = "BuyQuantity";
            this.BuyQuantity.Size = new System.Drawing.Size(39, 20);
            this.BuyQuantity.TabIndex = 5;
            this.BuyQuantity.Text = "0";
            this.BuyQuantity.TextChanged += new System.EventHandler(this.BuyQuantity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quantity";
            // 
            // InteractionCenter_BuyButton
            // 
            this.InteractionCenter_BuyButton.Location = new System.Drawing.Point(358, 270);
            this.InteractionCenter_BuyButton.Name = "InteractionCenter_BuyButton";
            this.InteractionCenter_BuyButton.Size = new System.Drawing.Size(75, 23);
            this.InteractionCenter_BuyButton.TabIndex = 3;
            this.InteractionCenter_BuyButton.Text = "Buy";
            this.InteractionCenter_BuyButton.UseVisualStyleBackColor = true;
            this.InteractionCenter_BuyButton.Click += new System.EventHandler(this.InteractionCenter_BuyButton_Click);
            // 
            // tab_escrow
            // 
            this.tab_escrow.Controls.Add(this.button3);
            this.tab_escrow.Controls.Add(this.button2);
            this.tab_escrow.Controls.Add(this.button1);
            this.tab_escrow.Controls.Add(this.Escrow_StoreList);
            this.tab_escrow.Controls.Add(this.Escrow_PlayerList);
            this.tab_escrow.Location = new System.Drawing.Point(4, 22);
            this.tab_escrow.Name = "tab_escrow";
            this.tab_escrow.Size = new System.Drawing.Size(693, 341);
            this.tab_escrow.TabIndex = 5;
            this.tab_escrow.Text = "Escrow";
            this.tab_escrow.UseVisualStyleBackColor = true;
            this.tab_escrow.Click += new System.EventHandler(this.tab_escrow_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(95, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 4;
            this.button3.Text = "Get Quote For Now";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Put Up For Escrow";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buy Item Now";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Escrow_StoreList
            // 
            this.Escrow_StoreList.Location = new System.Drawing.Point(354, 3);
            this.Escrow_StoreList.Name = "Escrow_StoreList";
            this.Escrow_StoreList.Size = new System.Drawing.Size(336, 234);
            this.Escrow_StoreList.TabIndex = 1;
            this.Escrow_StoreList.UseCompatibleStateImageBehavior = false;
            // 
            // Escrow_PlayerList
            // 
            this.Escrow_PlayerList.Location = new System.Drawing.Point(3, 3);
            this.Escrow_PlayerList.Name = "Escrow_PlayerList";
            this.Escrow_PlayerList.Size = new System.Drawing.Size(336, 234);
            this.Escrow_PlayerList.TabIndex = 0;
            this.Escrow_PlayerList.UseCompatibleStateImageBehavior = false;
            // 
            // tab_agents
            // 
            this.tab_agents.Location = new System.Drawing.Point(4, 22);
            this.tab_agents.Name = "tab_agents";
            this.tab_agents.Padding = new System.Windows.Forms.Padding(3);
            this.tab_agents.Size = new System.Drawing.Size(693, 341);
            this.tab_agents.TabIndex = 1;
            this.tab_agents.Text = "Agents";
            this.tab_agents.UseVisualStyleBackColor = true;
            // 
            // tab_people
            // 
            this.tab_people.Location = new System.Drawing.Point(4, 22);
            this.tab_people.Name = "tab_people";
            this.tab_people.Padding = new System.Windows.Forms.Padding(3);
            this.tab_people.Size = new System.Drawing.Size(693, 341);
            this.tab_people.TabIndex = 2;
            this.tab_people.Text = "People";
            this.tab_people.UseVisualStyleBackColor = true;
            // 
            // tab_politics
            // 
            this.tab_politics.Location = new System.Drawing.Point(4, 22);
            this.tab_politics.Name = "tab_politics";
            this.tab_politics.Padding = new System.Windows.Forms.Padding(3);
            this.tab_politics.Size = new System.Drawing.Size(693, 341);
            this.tab_politics.TabIndex = 3;
            this.tab_politics.Text = "Politics";
            this.tab_politics.UseVisualStyleBackColor = true;
            // 
            // Info_Population
            // 
            this.Info_Population.AutoSize = true;
            this.Info_Population.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info_Population.Location = new System.Drawing.Point(91, 75);
            this.Info_Population.Name = "Info_Population";
            this.Info_Population.Size = new System.Drawing.Size(72, 20);
            this.Info_Population.TabIndex = 8;
            this.Info_Population.Text = "0000000";
            // 
            // InteractionCenterUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 375);
            this.Controls.Add(this.tabControl1);
            this.Name = "InteractionCenterUi";
            this.Text = "InteractionCenterUi";
            this.Load += new System.EventHandler(this.InteractionCenterUi_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_info.ResumeLayout(false);
            this.tab_info.PerformLayout();
            this.tab_market.ResumeLayout(false);
            this.tab_market.PerformLayout();
            this.tab_escrow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_market;
        private System.Windows.Forms.TabPage tab_agents;
        private System.Windows.Forms.TabPage tab_people;
        private System.Windows.Forms.TabPage tab_politics;
        private System.Windows.Forms.TextBox SellQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button InteractionCenter_SellButton;
        private System.Windows.Forms.TextBox BuyQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button InteractionCenter_BuyButton;
        private System.Windows.Forms.TabPage tab_info;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tab_escrow;
        private System.Windows.Forms.Label InteractionCenter_Credits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView Escrow_PlayerList;
        private System.Windows.Forms.ListView Market_MarketCommodities;
        private System.Windows.Forms.TextBox BuyPrice;
        private System.Windows.Forms.TextBox SellPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView Market_ShipCommodities;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView Escrow_StoreList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label market_cargo_space;
        private System.Windows.Forms.Label cargo_space_label;
        private System.Windows.Forms.Label InteractionCenter_InfoName;
        private System.Windows.Forms.Label Info_Population;
    }
}