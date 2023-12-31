
namespace BTL_HTPT
{
    partial class FormDemo3
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
            this.productControl1 = new BTL_HTPT.ControlProduct();
            this.SuspendLayout();
            // 
            // productControl1
            // 
            this.productControl1.ConnectionStringNext = null;
            this.productControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productControl1.Location = new System.Drawing.Point(0, 0);
            this.productControl1.Name = "productControl1";
            this.productControl1.Size = new System.Drawing.Size(784, 561);
            this.productControl1.TabIndex = 0;
            // 
            // DemoForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.productControl1);
            this.Name = "DemoForm3";
            this.Text = "DemoForm3";
            this.Load += new System.EventHandler(this.DemoForm3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlProduct productControl1;
    }
}