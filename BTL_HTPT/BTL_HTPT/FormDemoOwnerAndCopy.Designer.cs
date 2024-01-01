
namespace BTL_HTPT
{
    partial class FormDemoOwnerAndCopy
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.controlProductOwner = new BTL_HTPT.ControlProduct();
            this.controlProductCopy = new BTL_HTPT.ControlProduct();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.controlProductOwner);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.controlProductCopy);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // controlProductOwner
            // 
            this.controlProductOwner.ConnectionString = null;
            this.controlProductOwner.ConnectionStringNext = null;
            this.controlProductOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlProductOwner.Location = new System.Drawing.Point(3, 3);
            this.controlProductOwner.Name = "controlProductOwner";
            this.controlProductOwner.Size = new System.Drawing.Size(970, 529);
            this.controlProductOwner.TabIndex = 0;
            // 
            // controlProductCopy
            // 
            this.controlProductCopy.ConnectionString = null;
            this.controlProductCopy.ConnectionStringNext = null;
            this.controlProductCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlProductCopy.Location = new System.Drawing.Point(3, 3);
            this.controlProductCopy.Name = "controlProductCopy";
            this.controlProductCopy.Size = new System.Drawing.Size(786, 418);
            this.controlProductCopy.TabIndex = 0;
            // 
            // FormDemoOwnerAndCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormDemoOwnerAndCopy";
            this.Text = "Demo2";
            this.Load += new System.EventHandler(this.DemoForm2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ControlProduct controlProductOwner;
        private ControlProduct controlProductCopy;
    }
}