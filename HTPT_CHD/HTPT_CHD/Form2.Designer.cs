namespace HTPT_CHD
{
    partial class Form2
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
            this.txt_phoneNo = new System.Windows.Forms.TextBox();
            this.date_birthday = new System.Windows.Forms.DateTimePicker();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_day_du_lieu = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_lam_moi = new System.Windows.Forms.Button();
            this.rbtn_demo1 = new System.Windows.Forms.RadioButton();
            this.rbtn_demo2 = new System.Windows.Forms.RadioButton();
            this.rbtn_demo3 = new System.Windows.Forms.RadioButton();
            this.rbtn_demo4 = new System.Windows.Forms.RadioButton();
            this.rbtn_demo5 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(252, 73);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(229, 22);
            this.txt_id.TabIndex = 48;
           // this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            // 
            // txt_fullname
            // 
            this.txt_fullname.Location = new System.Drawing.Point(252, 121);
            this.txt_fullname.Name = "txt_fullname";
            this.txt_fullname.Size = new System.Drawing.Size(229, 22);
            this.txt_fullname.TabIndex = 47;
            //this.txt_fullname.TextChanged += new System.EventHandler(this.txt_fullname_TextChanged);
            // 
            // txt_phoneNo
            // 
            this.txt_phoneNo.Location = new System.Drawing.Point(252, 175);
            this.txt_phoneNo.Name = "txt_phoneNo";
            this.txt_phoneNo.Size = new System.Drawing.Size(229, 22);
            this.txt_phoneNo.TabIndex = 46;
            //this.txt_phoneNo.TextChanged += new System.EventHandler(this.txt_phoneNo_TextChanged);
            // 
            // date_birthday
            // 
            this.date_birthday.Location = new System.Drawing.Point(743, 68);
            this.date_birthday.Name = "date_birthday";
            this.date_birthday.Size = new System.Drawing.Size(229, 22);
            this.date_birthday.TabIndex = 45;
            //this.date_birthday.ValueChanged += new System.EventHandler(this.date_birthday_ValueChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(865, 249);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(96, 52);
            this.btn_reset.TabIndex = 44;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            //this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.Location = new System.Drawing.Point(642, 249);
            this.btn_sua.Margin = new System.Windows.Forms.Padding(4);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(96, 52);
            this.btn_sua.TabIndex = 43;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Location = new System.Drawing.Point(385, 249);
            this.btn_xoa.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(96, 52);
            this.btn_xoa.TabIndex = 42;
            this.btn_xoa.Text = "Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(149, 249);
            this.btn_them.Margin = new System.Windows.Forms.Padding(4);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(96, 52);
            this.btn_them.TabIndex = 41;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(743, 124);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(229, 22);
            this.txt_address.TabIndex = 40;
           // this.txt_address.TextChanged += new System.EventHandler(this.txt_address_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(639, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 38;
            this.label7.Text = "Birthday";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 37;
            this.label8.Text = "PhoneNo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 36;
            this.label9.Text = "FullName";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(146, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "EmployeeID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1079, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Table";
            // 
            // btn_day_du_lieu
            // 
            this.btn_day_du_lieu.Location = new System.Drawing.Point(43, 324);
            this.btn_day_du_lieu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_day_du_lieu.Name = "btn_day_du_lieu";
            this.btn_day_du_lieu.Size = new System.Drawing.Size(150, 52);
            this.btn_day_du_lieu.TabIndex = 33;
            this.btn_day_du_lieu.Text = "Đẩy dữ liệu xuống ";
            this.btn_day_du_lieu.UseVisualStyleBackColor = true;
            this.btn_day_du_lieu.Click += new System.EventHandler(this.btn_day_du_lieu_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(43, 384);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1079, 285);
            this.dataGridView1.TabIndex = 31;
            //this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btn_lam_moi
            // 
            this.btn_lam_moi.Location = new System.Drawing.Point(978, 299);
            this.btn_lam_moi.Margin = new System.Windows.Forms.Padding(4);
            this.btn_lam_moi.Name = "btn_lam_moi";
            this.btn_lam_moi.Size = new System.Drawing.Size(144, 52);
            this.btn_lam_moi.TabIndex = 32;
            this.btn_lam_moi.Text = "Làm mới";
            this.btn_lam_moi.UseVisualStyleBackColor = true;
            this.btn_lam_moi.Click += new System.EventHandler(this.btn_lam_moi_Click);
            // 
            // rbtn_demo1
            // 
            this.rbtn_demo1.AutoSize = true;
            this.rbtn_demo1.Location = new System.Drawing.Point(43, 22);
            this.rbtn_demo1.Name = "rbtn_demo1";
            this.rbtn_demo1.Size = new System.Drawing.Size(72, 20);
            this.rbtn_demo1.TabIndex = 49;
            this.rbtn_demo1.TabStop = true;
            this.rbtn_demo1.Text = "Demo1";
            this.rbtn_demo1.UseVisualStyleBackColor = true;
            //this.rbtn_demo1.CheckedChanged += new System.EventHandler(this.rbtn_demo1_CheckedChanged);
            // 
            // rbtn_demo2
            // 
            this.rbtn_demo2.AutoSize = true;
            this.rbtn_demo2.Location = new System.Drawing.Point(252, 22);
            this.rbtn_demo2.Name = "rbtn_demo2";
            this.rbtn_demo2.Size = new System.Drawing.Size(72, 20);
            this.rbtn_demo2.TabIndex = 50;
            this.rbtn_demo2.TabStop = true;
            this.rbtn_demo2.Text = "Demo2";
            this.rbtn_demo2.UseVisualStyleBackColor = true;
            //this.rbtn_demo2.CheckedChanged += new System.EventHandler(this.rbtn_demo2_CheckedChanged);
            // 
            // rbtn_demo3
            // 
            this.rbtn_demo3.AutoSize = true;
            this.rbtn_demo3.Location = new System.Drawing.Point(476, 22);
            this.rbtn_demo3.Name = "rbtn_demo3";
            this.rbtn_demo3.Size = new System.Drawing.Size(72, 20);
            this.rbtn_demo3.TabIndex = 51;
            this.rbtn_demo3.TabStop = true;
            this.rbtn_demo3.Text = "Demo3";
            this.rbtn_demo3.UseVisualStyleBackColor = true;
            //this.rbtn_demo3.CheckedChanged += new System.EventHandler(this.rbtn_demo3_CheckedChanged);
            // 
            // rbtn_demo4
            // 
            this.rbtn_demo4.AutoSize = true;
            this.rbtn_demo4.Location = new System.Drawing.Point(693, 22);
            this.rbtn_demo4.Name = "rbtn_demo4";
            this.rbtn_demo4.Size = new System.Drawing.Size(72, 20);
            this.rbtn_demo4.TabIndex = 52;
            this.rbtn_demo4.TabStop = true;
            this.rbtn_demo4.Text = "Demo4";
            this.rbtn_demo4.UseVisualStyleBackColor = true;
            //this.rbtn_demo4.CheckedChanged += new System.EventHandler(this.rbtn_demo4_CheckedChanged);
            // 
            // rbtn_demo5
            // 
            this.rbtn_demo5.AutoSize = true;
            this.rbtn_demo5.Location = new System.Drawing.Point(905, 22);
            this.rbtn_demo5.Name = "rbtn_demo5";
            this.rbtn_demo5.Size = new System.Drawing.Size(72, 20);
            this.rbtn_demo5.TabIndex = 53;
            this.rbtn_demo5.TabStop = true;
            this.rbtn_demo5.Text = "Demo5";
            this.rbtn_demo5.UseVisualStyleBackColor = true;
            //this.rbtn_demo5.CheckedChanged += new System.EventHandler(this.rbtn_demo5_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 682);
            this.Controls.Add(this.rbtn_demo5);
            this.Controls.Add(this.rbtn_demo4);
            this.Controls.Add(this.rbtn_demo3);
            this.Controls.Add(this.rbtn_demo2);
            this.Controls.Add(this.rbtn_demo1);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.txt_fullname);
            this.Controls.Add(this.txt_phoneNo);
            this.Controls.Add(this.date_birthday);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.btn_xoa);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_day_du_lieu);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_lam_moi);
            this.Name = "Form2";
            this.Text = "Form2";
            //this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_fullname;
        private System.Windows.Forms.TextBox txt_phoneNo;
        private System.Windows.Forms.DateTimePicker date_birthday;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_day_du_lieu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_lam_moi;
        private System.Windows.Forms.RadioButton rbtn_demo1;
        private System.Windows.Forms.RadioButton rbtn_demo2;
        private System.Windows.Forms.RadioButton rbtn_demo3;
        private System.Windows.Forms.RadioButton rbtn_demo4;
        private System.Windows.Forms.RadioButton rbtn_demo5;
    }
}