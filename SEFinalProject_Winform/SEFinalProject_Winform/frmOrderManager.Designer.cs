namespace SEFinalProject_Winform
{
    partial class frmOrderManager
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOrdID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAgentName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAgentAddress = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbAgentEmail = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAgentPhone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbOrderDate = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbOrderID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTinhTrangDonHang = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPhiShip = new System.Windows.Forms.Label();
            this.cbDonViVanChuyen = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbHinhThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTinhTrangThanhToan = new System.Windows.Forms.ComboBox();
            this.tbTongTien = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnPrintOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(411, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "XỬ LÝ ĐƠN HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đơn hàng chưa xử lý";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn đơn hàng";
            // 
            // cbOrdID
            // 
            this.cbOrdID.FormattingEnabled = true;
            this.cbOrdID.Location = new System.Drawing.Point(339, 99);
            this.cbOrdID.Name = "cbOrdID";
            this.cbOrdID.Size = new System.Drawing.Size(156, 21);
            this.cbOrdID.TabIndex = 4;
            this.cbOrdID.SelectedIndexChanged += new System.EventHandler(this.cbOrdID_choose);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên khách hàng";
            // 
            // tbAgentName
            // 
            this.tbAgentName.AutoSize = true;
            this.tbAgentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgentName.Location = new System.Drawing.Point(136, 27);
            this.tbAgentName.Name = "tbAgentName";
            this.tbAgentName.Size = new System.Drawing.Size(103, 16);
            this.tbAgentName.TabIndex = 6;
            this.tbAgentName.Text = "Tên khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Địa chỉ";
            // 
            // tbAgentAddress
            // 
            this.tbAgentAddress.AutoSize = true;
            this.tbAgentAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgentAddress.Location = new System.Drawing.Point(136, 126);
            this.tbAgentAddress.Name = "tbAgentAddress";
            this.tbAgentAddress.Size = new System.Drawing.Size(47, 16);
            this.tbAgentAddress.TabIndex = 8;
            this.tbAgentAddress.Text = "Địa chỉ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbAgentEmail);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbAgentPhone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbAgentAddress);
            this.groupBox1.Controls.Add(this.tbAgentName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(53, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 208);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khách hàng";
            // 
            // tbAgentEmail
            // 
            this.tbAgentEmail.AutoSize = true;
            this.tbAgentEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgentEmail.Location = new System.Drawing.Point(136, 91);
            this.tbAgentEmail.Name = "tbAgentEmail";
            this.tbAgentEmail.Size = new System.Drawing.Size(47, 16);
            this.tbAgentEmail.TabIndex = 12;
            this.tbAgentEmail.Text = "Địa chỉ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Email";
            // 
            // tbAgentPhone
            // 
            this.tbAgentPhone.AutoSize = true;
            this.tbAgentPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAgentPhone.Location = new System.Drawing.Point(136, 57);
            this.tbAgentPhone.Name = "tbAgentPhone";
            this.tbAgentPhone.Size = new System.Drawing.Size(47, 16);
            this.tbAgentPhone.TabIndex = 10;
            this.tbAgentPhone.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số điện thoại";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbOrderDate);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tbOrderID);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cbTinhTrangDonHang);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbPhiShip);
            this.groupBox2.Controls.Add(this.cbDonViVanChuyen);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbHinhThucThanhToan);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbTinhTrangThanhToan);
            this.groupBox2.Controls.Add(this.tbTongTien);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(559, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(746, 350);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết đơn hàng";
            // 
            // tbOrderDate
            // 
            this.tbOrderDate.Location = new System.Drawing.Point(523, 23);
            this.tbOrderDate.Mask = "00/00/0000";
            this.tbOrderDate.Name = "tbOrderDate";
            this.tbOrderDate.Size = new System.Drawing.Size(113, 20);
            this.tbOrderDate.TabIndex = 17;
            this.tbOrderDate.ValidatingType = typeof(System.DateTime);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(439, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "Ngày đặt";
            // 
            // tbOrderID
            // 
            this.tbOrderID.AutoSize = true;
            this.tbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOrderID.Location = new System.Drawing.Point(124, 30);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(45, 16);
            this.tbOrderID.TabIndex = 14;
            this.tbOrderID.Text = "O0001";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Mã đơn hàng";
            // 
            // cbTinhTrangDonHang
            // 
            this.cbTinhTrangDonHang.FormattingEnabled = true;
            this.cbTinhTrangDonHang.Location = new System.Drawing.Point(160, 308);
            this.cbTinhTrangDonHang.Name = "cbTinhTrangDonHang";
            this.cbTinhTrangDonHang.Size = new System.Drawing.Size(156, 21);
            this.cbTinhTrangDonHang.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 311);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Tình trạng đơn hàng";
            // 
            // tbPhiShip
            // 
            this.tbPhiShip.AutoSize = true;
            this.tbPhiShip.Location = new System.Drawing.Point(508, 263);
            this.tbPhiShip.Name = "tbPhiShip";
            this.tbPhiShip.Size = new System.Drawing.Size(44, 13);
            this.tbPhiShip.TabIndex = 11;
            this.tbPhiShip.Text = "15000đ";
            // 
            // cbDonViVanChuyen
            // 
            this.cbDonViVanChuyen.FormattingEnabled = true;
            this.cbDonViVanChuyen.Location = new System.Drawing.Point(511, 219);
            this.cbDonViVanChuyen.Name = "cbDonViVanChuyen";
            this.cbDonViVanChuyen.Size = new System.Drawing.Size(176, 21);
            this.cbDonViVanChuyen.TabIndex = 10;
            this.cbDonViVanChuyen.SelectedIndexChanged += new System.EventHandler(this.cbDonViVanChuyen_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 271);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Hình thức thanh toán";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(398, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Phí ship";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(398, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Đơn vị vận chuyển";
            // 
            // cbHinhThucThanhToan
            // 
            this.cbHinhThucThanhToan.FormattingEnabled = true;
            this.cbHinhThucThanhToan.Location = new System.Drawing.Point(160, 263);
            this.cbHinhThucThanhToan.Name = "cbHinhThucThanhToan";
            this.cbHinhThucThanhToan.Size = new System.Drawing.Size(156, 21);
            this.cbHinhThucThanhToan.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Tình trạng thanh toán";
            // 
            // cbTinhTrangThanhToan
            // 
            this.cbTinhTrangThanhToan.FormattingEnabled = true;
            this.cbTinhTrangThanhToan.Location = new System.Drawing.Point(160, 219);
            this.cbTinhTrangThanhToan.Name = "cbTinhTrangThanhToan";
            this.cbTinhTrangThanhToan.Size = new System.Drawing.Size(156, 21);
            this.cbTinhTrangThanhToan.TabIndex = 3;
            // 
            // tbTongTien
            // 
            this.tbTongTien.AutoSize = true;
            this.tbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongTien.ForeColor = System.Drawing.Color.DarkGreen;
            this.tbTongTien.Location = new System.Drawing.Point(570, 305);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.Size = new System.Drawing.Size(95, 24);
            this.tbTongTien.TabIndex = 2;
            this.tbTongTien.Text = "900.000đ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(459, 305);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tổng tiền:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(581, 121);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdate.Location = new System.Drawing.Point(559, 505);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(105, 30);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_clicked);
            // 
            // btnPrintOrder
            // 
            this.btnPrintOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPrintOrder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrintOrder.Location = new System.Drawing.Point(1205, 505);
            this.btnPrintOrder.Name = "btnPrintOrder";
            this.btnPrintOrder.Size = new System.Drawing.Size(100, 30);
            this.btnPrintOrder.TabIndex = 12;
            this.btnPrintOrder.Text = "In hóa đơn";
            this.btnPrintOrder.UseVisualStyleBackColor = false;
            this.btnPrintOrder.Click += new System.EventHandler(this.btnPrintOrder_clicked);
            // 
            // frmOrderManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 603);
            this.Controls.Add(this.btnPrintOrder);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbOrdID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmOrderManager";
            this.Text = "Quản lý đơn hàng";
            this.Load += new System.EventHandler(this.frmOrderManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbOrdID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tbAgentName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tbAgentAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label tbAgentEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label tbAgentPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbHinhThucThanhToan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTinhTrangThanhToan;
        private System.Windows.Forms.Label tbTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label tbOrderID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTinhTrangDonHang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label tbPhiShip;
        private System.Windows.Forms.ComboBox cbDonViVanChuyen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.MaskedTextBox tbOrderDate;
        private System.Windows.Forms.Button btnPrintOrder;
    }
}