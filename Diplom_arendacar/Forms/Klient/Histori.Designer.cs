namespace Diplom_arendacar.Forms.Klient
{
    partial class Histori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Histori));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgw_car1 = new System.Windows.Forms.DataGridView();
            this.bt_exite = new System.Windows.Forms.Button();
            this.bt_report_pdf = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_car1)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(-2, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 115);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(336, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "История";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(721, 16);
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
            // dgw_car1
            // 
            this.dgw_car1.AllowUserToAddRows = false;
            this.dgw_car1.AllowUserToDeleteRows = false;
            this.dgw_car1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgw_car1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw_car1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgw_car1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw_car1.Location = new System.Drawing.Point(-2, 104);
            this.dgw_car1.Name = "dgw_car1";
            this.dgw_car1.ReadOnly = true;
            this.dgw_car1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw_car1.Size = new System.Drawing.Size(852, 219);
            this.dgw_car1.TabIndex = 90;
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
            this.bt_exite.Location = new System.Drawing.Point(12, 334);
            this.bt_exite.Name = "bt_exite";
            this.bt_exite.Size = new System.Drawing.Size(144, 30);
            this.bt_exite.TabIndex = 96;
            this.bt_exite.Text = "Назад";
            this.bt_exite.UseVisualStyleBackColor = false;
            this.bt_exite.Click += new System.EventHandler(this.bt_exite_Click);
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
            this.bt_report_pdf.Location = new System.Drawing.Point(622, 334);
            this.bt_report_pdf.Name = "bt_report_pdf";
            this.bt_report_pdf.Size = new System.Drawing.Size(214, 30);
            this.bt_report_pdf.TabIndex = 97;
            this.bt_report_pdf.Text = "Сформировать PDF";
            this.bt_report_pdf.UseVisualStyleBackColor = false;
            this.bt_report_pdf.Click += new System.EventHandler(this.bt_report_pdf_Click);
            // 
            // Histori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 376);
            this.Controls.Add(this.bt_report_pdf);
            this.Controls.Add(this.bt_exite);
            this.Controls.Add(this.dgw_car1);
            this.Controls.Add(this.panel1);
            this.Name = "Histori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histori";
            this.Load += new System.EventHandler(this.Histori_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgw_car1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView dgw_car1;
        private System.Windows.Forms.Button bt_exite;
        private System.Windows.Forms.Button bt_report_pdf;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}