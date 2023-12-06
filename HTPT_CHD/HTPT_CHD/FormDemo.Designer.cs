namespace HTPT_CHD
{
    partial class FormDemo
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
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_fullname = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.date_birthday = new System.Windows.Forms.DateTimePicker();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_day_du_lieu = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btn_lam_moi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(256, 16);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(229, 22);
            this.txt_id.TabIndex = 66;
            // 
            // txt_fullname
            // 
            this.txt_fullname.Location = new System.Drawing.Point(256, 64);
            this.txt_fullname.Name = "txt_fullname";
            this.txt_fullname.Size = new System.Drawing.Size(229, 22);
            this.txt_fullname.TabIndex = 65;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(256, 118);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(229, 22);
            this.txt_phone.TabIndex = 64;
            // 
            // date_birthday
            // 
            this.date_birthday.Location = new System.Drawing.Point(747, 11);
            this.date_birthday.Name = "date_birthday";
            this.date_birthday.Size = new System.Drawing.Size(229, 22);
            this.date_birthday.TabIndex = 63;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(869, 192);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(96, 52);
            this.btn_reset.TabIndex = 62;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(646, 192);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(96, 52);
            this.btn_sua.TabIndex = 61;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(389, 192);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(96, 52);
            this.btn_xoa.TabIndex = 60;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(153, 192);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(96, 52);
            this.btn_them.TabIndex = 59;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(747, 67);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(229, 22);
            this.txt_address.TabIndex = 58;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(643, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Address";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(643, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 56;
            this.label11.Text = "Birthday";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(150, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 55;
            this.label12.Text = "PhoneNo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(150, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 54;
            this.label13.Text = "FullName";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 16);
            this.label14.TabIndex = 53;
            this.label14.Text = "EmployeeID";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1083, 307);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 16);
            this.label15.TabIndex = 52;
            this.label15.Text = "Table";
            // 
            // btn_day_du_lieu
            // 
            this.btn_day_du_lieu.Location = new System.Drawing.Point(47, 267);
            this.btn_day_du_lieu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_day_du_lieu.Name = "btn_day_du_lieu";
            this.btn_day_du_lieu.Size = new System.Drawing.Size(150, 52);
            this.btn_day_du_lieu.TabIndex = 51;
            this.btn_day_du_lieu.Text = "Đẩy dữ liệu xuống ";
            this.btn_day_du_lieu.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(47, 327);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1079, 285);
            this.dataGridView.TabIndex = 49;
            // 
            // btn_lam_moi
            // 
            this.btn_lam_moi.Location = new System.Drawing.Point(982, 242);
            this.btn_lam_moi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_lam_moi.Name = "btn_lam_moi";
            this.btn_lam_moi.Size = new System.Drawing.Size(144, 52);
            this.btn_lam_moi.TabIndex = 50;
            this.btn_lam_moi.Text = "Làm mới";
            this.btn_lam_moi.UseVisualStyleBackColor = true;
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 634);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.txt_fullname);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.date_birthday);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btn_day_du_lieu);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btn_lam_moi);
            this.Name = "FormDemo";
            this.Text = "FormDemo";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_fullname;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.DateTimePicker date_birthday;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_day_du_lieu;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btn_lam_moi;
    }
}