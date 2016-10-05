namespace SpaceAge.Controls
{
    partial class UiInventory
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
            this.ui_InventoryListview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ui_InventoryListview
            // 
            this.ui_InventoryListview.Location = new System.Drawing.Point(7, 0);
            this.ui_InventoryListview.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ui_InventoryListview.Name = "ui_InventoryListview";
            this.ui_InventoryListview.Size = new System.Drawing.Size(605, 429);
            this.ui_InventoryListview.TabIndex = 0;
            this.ui_InventoryListview.UseCompatibleStateImageBehavior = false;
            // 
            // UiInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ui_InventoryListview);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "UiInventory";
            this.Size = new System.Drawing.Size(629, 451);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ui_InventoryListview;
    }
}
