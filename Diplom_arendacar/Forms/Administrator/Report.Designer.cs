namespace Diplom_arendacar.Forms.Administrator
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.bt_report_one_year = new System.Windows.Forms.Button();
            this.bt_report_six_months = new System.Windows.Forms.Button();
            this.bt_report_three_months = new System.Windows.Forms.Button();
            this.dgw_car1 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt_report_pdf = new System.Windows.Forms.Button();
            this.bt_exite = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_car1)).BeginInit();
            this.panel15.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 111);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(343, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Отчёты";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(779, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(14, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 156);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(204, 20);
            this.dateTimePicker1.TabIndex = 83;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(230, 156);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 84;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // bt_report_one_year
            // 
            this.bt_report_one_year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_report_one_year.BackColor = System.Drawing.Color.Crimson;
            this.bt_report_one_year.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_report_one_year.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_report_one_year.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_report_one_year.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_report_one_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_report_one_year.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_report_one_year.Location = new System.Drawing.Point(452, 146);
            this.bt_report_one_year.Name = "bt_report_one_year";
            this.bt_report_one_year.Size = new System.Drawing.Size(144, 30);
            this.bt_report_one_year.TabIndex = 85;
            this.bt_report_one_year.Text = "За год";
            this.bt_report_one_year.UseVisualStyleBackColor = false;
            this.bt_report_one_year.Click += new System.EventHandler(this.bt_report_one_year_Click);
            // 
            // bt_report_six_months
            // 
            this.bt_report_six_months.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_report_six_months.BackColor = System.Drawing.Color.Crimson;
            this.bt_report_six_months.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_report_six_months.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_report_six_months.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_report_six_months.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_report_six_months.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_report_six_months.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_report_six_months.Location = new System.Drawing.Point(599, 146);
            this.bt_report_six_months.Name = "bt_report_six_months";
            this.bt_report_six_months.Size = new System.Drawing.Size(144, 30);
            this.bt_report_six_months.TabIndex = 86;
            this.bt_report_six_months.Text = "За пол-года";
            this.bt_report_six_months.UseVisualStyleBackColor = false;
            this.bt_report_six_months.Click += new System.EventHandler(this.bt_report_six_months_Click);
            // 
            // bt_report_three_months
            // 
            this.bt_report_three_months.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_report_three_months.BackColor = System.Drawing.Color.Crimson;
            this.bt_report_three_months.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_report_three_months.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_report_three_months.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_report_three_months.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_report_three_months.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_report_three_months.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_report_three_months.Location = new System.Drawing.Point(749, 146);
            this.bt_report_three_months.Name = "bt_report_three_months";
            this.bt_report_three_months.Size = new System.Drawing.Size(144, 30);
            this.bt_report_three_months.TabIndex = 87;
            this.bt_report_three_months.Text = "За квартал";
            this.bt_report_three_months.UseVisualStyleBackColor = false;
            this.bt_report_three_months.Click += new System.EventHandler(this.bt_report_three_months_Click);
            // 
            // dgw_car1
            // 
            this.dgw_car1.AllowUserToAddRows = false;
            this.dgw_car1.AllowUserToDeleteRows = false;
            this.dgw_car1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_car1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_car1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgw_car1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_car1.Location = new System.Drawing.Point(8, 206);
            this.dgw_car1.Name = "dgw_car1";
            this.dgw_car1.ReadOnly = true;
            this.dgw_car1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_car1.Size = new System.Drawing.Size(885, 270);
            this.dgw_car1.TabIndex = 89;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Crimson;
            this.label14.Location = new System.Drawing.Point(7, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 90;
            this.label14.Text = "Начало ";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(2, 8);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker3.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(-1, -24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Дата начала аренды";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Location = new System.Drawing.Point(2, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 4);
            this.panel2.TabIndex = 67;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Crimson;
            this.panel15.Controls.Add(this.panel2);
            this.panel15.Controls.Add(this.label3);
            this.panel15.Controls.Add(this.dateTimePicker3);
            this.panel15.Location = new System.Drawing.Point(10, 146);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(200, 4);
            this.panel15.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(228, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 18);
            this.label4.TabIndex = 92;
            this.label4.Text = "Конец";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(2, 8);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker4.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(-1, -24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 66;
            this.label2.Text = "Дата начала аренды";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Crimson;
            this.panel4.Location = new System.Drawing.Point(2, -2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 4);
            this.panel4.TabIndex = 67;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dateTimePicker4);
            this.panel3.Location = new System.Drawing.Point(229, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 4);
            this.panel3.TabIndex = 93;
            // 
            // bt_report_pdf
            // 
            this.bt_report_pdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_report_pdf.BackColor = System.Drawing.Color.Crimson;
            this.bt_report_pdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_report_pdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_report_pdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_report_pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_report_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_report_pdf.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_report_pdf.Location = new System.Drawing.Point(679, 498);
            this.bt_report_pdf.Name = "bt_report_pdf";
            this.bt_report_pdf.Size = new System.Drawing.Size(214, 30);
            this.bt_report_pdf.TabIndex = 94;
            this.bt_report_pdf.Text = "Сформировать PDF";
            this.bt_report_pdf.UseVisualStyleBackColor = false;
            this.bt_report_pdf.Click += new System.EventHandler(this.bt_report_pdf_Click);
            // 
            // bt_exite
            // 
            this.bt_exite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_exite.BackColor = System.Drawing.Color.Crimson;
            this.bt_exite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_exite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_exite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_exite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_exite.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_exite.Location = new System.Drawing.Point(8, 498);
            this.bt_exite.Name = "bt_exite";
            this.bt_exite.Size = new System.Drawing.Size(144, 30);
            this.bt_exite.TabIndex = 95;
            this.bt_exite.Text = "Назад";
            this.bt_exite.UseVisualStyleBackColor = false;
            this.bt_exite.Click += new System.EventHandler(this.bt_exite_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(529, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 30);
            this.button1.TabIndex = 96;
            this.button1.Text = "Сбросить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 536);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_exite);
            this.Controls.Add(this.bt_report_pdf);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgw_car1);
            this.Controls.Add(this.bt_report_three_months);
            this.Controls.Add(this.bt_report_six_months);
            this.Controls.Add(this.bt_report_one_year);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчёт";
            this.Load += new System.EventHandler(this.Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_car1)).EndInit();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button bt_report_one_year;
        private System.Windows.Forms.Button bt_report_six_months;
        private System.Windows.Forms.Button bt_report_three_months;
        private System.Windows.Forms.DataGridView dgw_car1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bt_report_pdf;
        private System.Windows.Forms.Button bt_exite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}