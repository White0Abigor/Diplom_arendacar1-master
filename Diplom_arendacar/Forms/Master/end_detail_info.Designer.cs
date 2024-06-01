namespace Diplom_arendacar.Forms
{
    partial class end_detail_info
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_detail_cost = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_end_deteling = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 83);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(134, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 33);
            this.label2.TabIndex = 60;
            this.label2.Text = "Аренда авто";
            // 
            // tb_detail_cost
            // 
            this.tb_detail_cost.BackColor = System.Drawing.SystemColors.Control;
            this.tb_detail_cost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_detail_cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_detail_cost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tb_detail_cost.Location = new System.Drawing.Point(122, 138);
            this.tb_detail_cost.Name = "tb_detail_cost";
            this.tb_detail_cost.Size = new System.Drawing.Size(198, 19);
            this.tb_detail_cost.TabIndex = 13;
            this.tb_detail_cost.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            this.tb_detail_cost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_detail_cost_KeyPress);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Crimson;
            this.panel2.Location = new System.Drawing.Point(122, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 4);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(85, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Укажите сумму проведённых работ:";
            // 
            // bt_end_deteling
            // 
            this.bt_end_deteling.BackColor = System.Drawing.Color.Crimson;
            this.bt_end_deteling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_end_deteling.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.bt_end_deteling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_end_deteling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_end_deteling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_end_deteling.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_end_deteling.Location = new System.Drawing.Point(150, 186);
            this.bt_end_deteling.Name = "bt_end_deteling";
            this.bt_end_deteling.Size = new System.Drawing.Size(138, 32);
            this.bt_end_deteling.TabIndex = 62;
            this.bt_end_deteling.Text = "Сохранить";
            this.bt_end_deteling.UseVisualStyleBackColor = false;
            this.bt_end_deteling.Click += new System.EventHandler(this.bt_end_deteling_Click);
            // 
            // end_detail_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 241);
            this.Controls.Add(this.bt_end_deteling);
            this.Controls.Add(this.tb_detail_cost);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "end_detail_info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стоимость работ";
            this.Load += new System.EventHandler(this.end_detail_info_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_detail_cost;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bt_end_deteling;
    }
}