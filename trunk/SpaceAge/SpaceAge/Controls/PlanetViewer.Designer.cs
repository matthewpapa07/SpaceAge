namespace SpaceAge.Controls
{
    partial class PlanetViewer
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
            this.sdgsdgasgasfg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.listview_elementResources = new System.Windows.Forms.ListView();
            this.asfgfsagafsg = new System.Windows.Forms.Label();
            this.listview_atmosphericGas = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sdgsdgasgasfg
            // 
            this.sdgsdgasgasfg.AutoSize = true;
            this.sdgsdgasgasfg.Location = new System.Drawing.Point(257, 6);
            this.sdgsdgasgasfg.Name = "sdgsdgasgasfg";
            this.sdgsdgasgasfg.Size = new System.Drawing.Size(99, 13);
            this.sdgsdgasgasfg.TabIndex = 0;
            this.sdgsdgasgasfg.Text = "Element Resources";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 231);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Planet Picture Will Generate Here";
            // 
            // listview_elementResources
            // 
            this.listview_elementResources.Location = new System.Drawing.Point(260, 22);
            this.listview_elementResources.Name = "listview_elementResources";
            this.listview_elementResources.Size = new System.Drawing.Size(233, 97);
            this.listview_elementResources.TabIndex = 2;
            this.listview_elementResources.UseCompatibleStateImageBehavior = false;
            // 
            // asfgfsagafsg
            // 
            this.asfgfsagafsg.AutoSize = true;
            this.asfgfsagafsg.Location = new System.Drawing.Point(257, 131);
            this.asfgfsagafsg.Name = "asfgfsagafsg";
            this.asfgfsagafsg.Size = new System.Drawing.Size(87, 13);
            this.asfgfsagafsg.TabIndex = 3;
            this.asfgfsagafsg.Text = "Atmospheric Gas";
            // 
            // listview_atmosphericGas
            // 
            this.listview_atmosphericGas.Location = new System.Drawing.Point(260, 147);
            this.listview_atmosphericGas.Name = "listview_atmosphericGas";
            this.listview_atmosphericGas.Size = new System.Drawing.Size(233, 97);
            this.listview_atmosphericGas.TabIndex = 4;
            this.listview_atmosphericGas.UseCompatibleStateImageBehavior = false;
            // 
            // PlanetViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listview_atmosphericGas);
            this.Controls.Add(this.asfgfsagafsg);
            this.Controls.Add(this.listview_elementResources);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sdgsdgasgasfg);
            this.Name = "PlanetViewer";
            this.Size = new System.Drawing.Size(505, 263);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sdgsdgasgasfg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listview_elementResources;
        private System.Windows.Forms.Label asfgfsagafsg;
        private System.Windows.Forms.ListView listview_atmosphericGas;
    }
}
