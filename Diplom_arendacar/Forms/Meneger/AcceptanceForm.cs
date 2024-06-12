using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_arendacar.Forms
{
    public partial class AcceptanceForm : Form
    {
        public AcceptanceForm()
        {
            InitializeComponent();
        }

        private void AcceptanceForm_Load(object sender, EventArgs e)
        {
            tb_vin.Text = "";
            tb_number.Text = "";
            SqlConnection bm = new SqlConnection(Properties.Settings.Default.ConnectionString);
            bm.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "prinytie";
            cmd.Parameters.AddWithValue("@order_id", Properties.Settings.Default.order_id);
            cmd.Connection = bm;
            SqlDataReader reading122 = cmd.ExecuteReader();
            while (reading122.Read())
            {
                lbl_numerd_order.Visible= true;
                lbl_numerd_order.Text = reading122.GetString(2);
                Properties.Settings.Default.VIN = reading122.GetString(4);
                Properties.Settings.Default.car_id = Convert.ToInt32(reading122.GetInt32(1));
                Properties.Settings.Default.order_id = Convert.ToInt32(reading122.GetInt32(0));

                Properties.Settings.Default.milege = Convert.ToInt32(reading122.GetInt32(3));

            }
            bm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ap = Convert.ToString(tb_vin.Text);
            string pa = Convert.ToString(Properties.Settings.Default.VIN);
            if (tb_number.Text == "")
            {
                MessageBox.Show(" Вы не заполнили поле пробег");
                
            }
            else if (tb_vin.Text == "")
            {
                MessageBox.Show(" Вы не заполнили поле VIN-номер");
                tb_vin.Text = " ";

            }
            else if(Convert.ToInt32(tb_number.Text) <= Properties.Settings.Default.milege)
            {
                MessageBox.Show(" Пробег не может быть меншье или равен пробегу при выдачи");
                tb_number.Text = " ";
            }
            else if (ap != pa)
            {
                MessageBox.Show("Вин номер не совпадает!\n Проверьте коректность ввода\n Если VIN-номер введён коректно, позовите старшего менеджера");
            }
            else
            {
                int a = Convert.ToInt32(tb_number.Text);
                SqlConnection connу21 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                connу21.Open();
                SqlCommand sqlCommand112 = new SqlCommand();
                sqlCommand112.CommandType = CommandType.StoredProcedure;
                sqlCommand112.CommandText = "Update_Status_Order3";
                sqlCommand112.Parameters.AddWithValue("@order_ID", Properties.Settings.Default.order_id);
                sqlCommand112.Parameters.AddWithValue("@care_ID", Properties.Settings.Default.car_id);
                sqlCommand112.Parameters.AddWithValue("@milleg", a);
                sqlCommand112.Connection = connу21;
                sqlCommand112.ExecuteNonQuery();
                connу21.Close();

                MessageBox.Show("Машина успешно принята");

                this.Close();
            }
        }


    }
}
