﻿namespace ExcelInvoiceGenerator
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
            this.lab_notFound = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_PartyName
            // 
            this.cmb_PartyName.FormattingEnabled = true;
            this.cmb_PartyName.Location = new System.Drawing.Point(141, 71);
            this.cmb_PartyName.Name = "cmb_PartyName";
            this.cmb_PartyName.Size = new System.Drawing.Size(340, 27);
            this.cmb_PartyName.TabIndex = 1;
            this.cmb_PartyName.SelectedIndexChanged += new System.EventHandler(this.cmb_PartyName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(487, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Create New Party";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lab_CurrentInvoice
            // 
            this.lab_CurrentInvoice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lab_CurrentInvoice.Font = new System.Drawing.Font("Century Gothic", 14.26415F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CurrentInvoice.Location = new System.Drawing.Point(0, 464);
            this.lab_CurrentInvoice.Name = "lab_CurrentInvoice";
            this.lab_CurrentInvoice.Size = new System.Drawing.Size(1093, 43);
            this.lab_CurrentInvoice.TabIndex = 5;
            this.lab_CurrentInvoice.Text = "  Current Invoice No: 0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_Address);
            this.groupBox1.Location = new System.Drawing.Point(491, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 294);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Details";
            // 
            // lab_Address
            // 
            this.lab_Address.AutoSize = true;
            this.lab_Address.Location = new System.Drawing.Point(21, 40);
            this.lab_Address.Name = "lab_Address";
            this.lab_Address.Size = new System.Drawing.Size(98, 20);
            this.lab_Address.TabIndex = 3;
            this.lab_Address.Text = "Party Name:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 113);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(344, 25);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date:";
            // 
            // btn_UploadSKU
            // 
            this.btn_UploadSKU.Location = new System.Drawing.Point(141, 151);
            this.btn_UploadSKU.Name = "btn_UploadSKU";
            this.btn_UploadSKU.Size = new System.Drawing.Size(165, 33);
            this.btn_UploadSKU.TabIndex = 9;
            this.btn_UploadSKU.Text = "Upload";
            this.btn_UploadSKU.UseVisualStyleBackColor = true;
            // 
            // btn_GenerateInvoice
            // 
            this.btn_GenerateInvoice.Location = new System.Drawing.Point(321, 151);
            this.btn_GenerateInvoice.Name = "btn_GenerateInvoice";
            this.btn_GenerateInvoice.Size = new System.Drawing.Size(165, 33);
            this.btn_GenerateInvoice.TabIndex = 10;
            this.btn_GenerateInvoice.Text = "Invoice";
            this.btn_GenerateInvoice.UseVisualStyleBackColor = true;
            this.btn_GenerateInvoice.Click += new System.EventHandler(this.btn_GenerateInvoice_Click);
            // 
            // lab_notFound
            // 
            this.lab_notFound.AutoSize = true;
            this.lab_notFound.ForeColor = System.Drawing.Color.Red;
            this.lab_notFound.Location = new System.Drawing.Point(12, 429);
            this.lab_notFound.Name = "lab_notFound";
            this.lab_notFound.Size = new System.Drawing.Size(170, 20);
            this.lab_notFound.TabIndex = 11;
            this.lab_notFound.Text = "[Check if sku not exist]";
            this.lab_notFound.Visible = false;
            this.lab_notFound.Click += new System.EventHandler(this.lab_notFound_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 507);
            this.Controls.Add(this.lab_notFound);
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
        private System.Windows.Forms.Label lab_notFound;
    }
}

