using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_arendacar.Forms.Administrator
{
    public partial class New_data : Form
    {
        public New_data()
        {
            InitializeComponent();
        }



        string new_country = "1";
        string new_brend = "1";
        string new_body = "1";
        string new_color = "1";
        string new_year = "1";
        string enginecapacity = "1";


        private void tb_new_country_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_new_brend_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_new_body_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_new_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_new_collor_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_new_EngineCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
      
        void toolTip()
        {

            toolTip1.SetToolTip(this.tb_new_EngineCapacity, "Объём записываетья, (1.8) ");
        }






        private void bt_maine_add_user_Click(object sender, EventArgs e)
        {
            try
            {
                if(tb_new_country.Text != "")
                {
                    new_country = tb_new_country.Text;
                }
                if (tb_new_brend.Text != "")
                {
                    new_brend = tb_new_brend.Text;
                }
                if (tb_new_body.Text != "")
                {
                    new_body = tb_new_body.Text;
                }
                if (tb_new_color.Text != "")
                {
                    new_color = tb_new_color.Text;
                }
                if (tb_new_year.Text != "")
                {
                    new_year = tb_new_year.Text;
                }
                if (tb_new_EngineCapacity.Text != "")
                {
                    enginecapacity = tb_new_EngineCapacity.Text;
                }
                if (tb_new_country.Text == "" && tb_new_brend.Text == "" && tb_new_body.Text == "" && tb_new_color.Text == "" &&  tb_new_year.Text == "" && tb_new_EngineCapacity.Text == "")
                {
                    MessageBox.Show("Вы не заполнили не одного поля!");
                }
                else
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "new_data";
                    cmd.Parameters.AddWithValue("@country", new_country);
                    cmd.Parameters.AddWithValue("@brand", new_brend);
                    cmd.Parameters.AddWithValue("@body", new_body);
                    cmd.Parameters.AddWithValue("@color", new_color);
                    cmd.Parameters.AddWithValue("@year", new_year);
                    cmd.Parameters.AddWithValue("@EngineCapacity", enginecapacity);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Данные успешно сохранены в базе данных");

                    tb_new_country.Text = "";
                    tb_new_brend.Text = "";
                    tb_new_body.Text = "";
                    tb_new_color.Text = "";
                    tb_new_year.Text = "";
                    tb_new_EngineCapacity.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void New_data_Load(object sender, EventArgs e)
        {

        }


    }
}
