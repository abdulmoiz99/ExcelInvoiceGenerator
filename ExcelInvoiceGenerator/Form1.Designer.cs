namespace ExcelInvoiceGenerator
{
    partial class Form1
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
            this.cmb_PartyName = new SergeUtils.EasyCompletionComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_CurrentInvoice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_Address = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_UploadSKU = new System.Windows.Forms.Button();
            this.btn_GenerateInvoice = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.resetPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_InvoiceNo = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.rb_sameState = new System.Windows.Forms.RadioButton();
            this.rb_differentState = new System.Windows.Forms.RadioButton();
            this.txt_TCS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.resetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_PartyName
            // 
            this.cmb_PartyName.FormattingEnabled = true;
            this.cmb_PartyName.Location = new System.Drawing.Point(142, 72);
            this.cmb_PartyName.Name = "cmb_PartyName";
            this.cmb_PartyName.Size = new System.Drawing.Size(345, 29);
            this.cmb_PartyName.TabIndex = 1;
            this.cmb_PartyName.SelectedIndexChanged += new System.EventHandler(this.cmb_PartyName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Party Name:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 25.81132F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1093, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "NEW INVOICE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(515, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Create New Party";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            // 
            // lab_CurrentInvoice
            // 
            this.lab_CurrentInvoice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lab_CurrentInvoice.Font = new System.Drawing.Font("Century Gothic", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CurrentInvoice.Location = new System.Drawing.Point(0, 482);
            this.lab_CurrentInvoice.Name = "lab_CurrentInvoice";
            this.lab_CurrentInvoice.Size = new System.Drawing.Size(1093, 43);
            this.lab_CurrentInvoice.TabIndex = 5;
            this.lab_CurrentInvoice.Text = "  Current Invoice No: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_Address);
            this.groupBox1.Location = new System.Drawing.Point(519, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 309);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Details";
            // 
            // lab_Address
            // 
            this.lab_Address.AutoSize = true;
            this.lab_Address.Location = new System.Drawing.Point(21, 40);
            this.lab_Address.Name = "lab_Address";
            this.lab_Address.Size = new System.Drawing.Size(106, 21);
            this.lab_Address.TabIndex = 3;
            this.lab_Address.Text = "Party Name:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 181);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(344, 27);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date:";
            // 
            // btn_UploadSKU
            // 
            this.btn_UploadSKU.Location = new System.Drawing.Point(142, 245);
            this.btn_UploadSKU.Name = "btn_UploadSKU";
            this.btn_UploadSKU.Size = new System.Drawing.Size(165, 33);
            this.btn_UploadSKU.TabIndex = 9;
            this.btn_UploadSKU.Text = "Upload";
            this.btn_UploadSKU.UseVisualStyleBackColor = true;
            this.btn_UploadSKU.Click += new System.EventHandler(this.btn_UploadSKU_Click);
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(322, 245);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(165, 33);
            this.btn_GenerateInvoice.TabIndex = 10;
            this.btn_GenerateInvoice.Text = "Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = true;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(321, 478);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(165, 33);
            this.btn_Reset.TabIndex = 12;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // resetPanel
            // 
            this.resetPanel.Controls.Add(this.label6);
            this.resetPanel.Controls.Add(this.txt_InvoiceNo);
            this.resetPanel.Controls.Add(this.btn_Cancel);
            this.resetPanel.Controls.Add(this.btn_Update);
            this.resetPanel.Controls.Add(this.label4);
            this.resetPanel.Controls.Add(this.txt_Password);
            this.resetPanel.Location = new System.Drawing.Point(102, 326);
            this.resetPanel.Name = "resetPanel";
            this.resetPanel.Size = new System.Drawing.Size(385, 147);
            this.resetPanel.TabIndex = 13;
            this.resetPanel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "New Invoice No:";
            // 
            // txt_InvoiceNo
            // 
            this.txt_InvoiceNo.Location = new System.Drawing.Point(166, 58);
            this.txt_InvoiceNo.Name = "txt_InvoiceNo";
            this.txt_InvoiceNo.Size = new System.Drawing.Size(200, 27);
            this.txt_InvoiceNo.TabIndex = 16;
            this.txt_InvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_InvoiceNo_KeyPress);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(166, 100);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(97, 33);
            this.btn_Cancel.TabIndex = 15;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(269, 100);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(97, 33);
            this.btn_Update.TabIndex = 14;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Password:";
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(166, 15);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(200, 27);
            this.txt_Password.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "Order No:";
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(142, 111);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(345, 27);
            this.txt_OrderNo.TabIndex = 16;
            // 
            // rb_sameState
            // 
            this.rb_sameState.AutoSize = true;
            this.rb_sameState.Checked = true;
            this.rb_sameState.Location = new System.Drawing.Point(142, 214);
            this.rb_sameState.Name = "rb_sameState";
            this.rb_sameState.Size = new System.Drawing.Size(119, 25);
            this.rb_sameState.TabIndex = 17;
            this.rb_sameState.TabStop = true;
            this.rb_sameState.Text = "Same State";
            this.rb_sameState.UseVisualStyleBackColor = true;
            // 
            // rb_differentState
            // 
            this.rb_differentState.AutoSize = true;
            this.rb_differentState.Location = new System.Drawing.Point(321, 214);
            this.rb_differentState.Name = "rb_differentState";
            this.rb_differentState.Size = new System.Drawing.Size(142, 25);
            this.rb_differentState.TabIndex = 18;
            this.rb_differentState.Text = "Different State";
            this.rb_differentState.UseVisualStyleBackColor = true;
            // 
            // txt_TCS
            // 
            this.txt_TCS.Location = new System.Drawing.Point(142, 148);
            this.txt_TCS.Name = "txt_TCS";
            this.txt_TCS.Size = new System.Drawing.Size(345, 27);
            this.txt_TCS.TabIndex = 20;
            this.txt_TCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TCS_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "TCS:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 525);
            this.Controls.Add(this.txt_TCS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rb_differentState);
            this.Controls.Add(this.rb_sameState);
            this.Controls.Add(this.txt_OrderNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resetPanel);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.btn_GenerateInvoice);
            this.Controls.Add(this.btn_UploadSKU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lab_CurrentInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_PartyName);
            this.Font = new System.Drawing.Font("Century Gothic", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvoiceGenerator";
            this.Load += new System.EventHandler(this.cmb_PartyName_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.resetPanel.ResumeLayout(false);
            this.resetPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SergeUtils.EasyCompletionComboBox cmb_PartyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_CurrentInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lab_Address;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_UploadSKU;
        private System.Windows.Forms.Button btn_GenerateInvoice;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Panel resetPanel;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_OrderNo;
        private System.Windows.Forms.RadioButton rb_sameState;
        private System.Windows.Forms.RadioButton rb_differentState;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_InvoiceNo;
        private System.Windows.Forms.TextBox txt_TCS;
        private System.Windows.Forms.Label label8;
    }
}

