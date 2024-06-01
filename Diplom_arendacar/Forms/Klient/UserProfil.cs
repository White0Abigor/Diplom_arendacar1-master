using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Diplom_arendacar.Forms.Klient;

namespace Diplom_arendacar.Forms
{
    public partial class UserProfil : Form
    {
        public UserProfil()
        {
            InitializeComponent();
        }

        private void UserProfil_Load(object sender, EventArgs e)
        {
            ///Оповещение
            

            ///Таблица с активными заявками
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "OrderCarUserHistori";
            sqlCommand.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);   
            sqlCommand.Connection = conn;
            using (SqlDataReader reading = sqlCommand.ExecuteReader())
            {

                var dataTable = new DataTable();
                dataTable.Load(reading);

                dgw_car_active.DataSource = dataTable;
            }           
            dgw_car_active.Columns[0].Visible = false;
            dgw_car_active.Columns[1].Visible = false;

            conn.Close();





            //// Отоброжение инециалов юсера
            SqlConnection connу = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connу.Open();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "inicialu";
            sqlCommand1.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
            sqlCommand1.Connection = connу;
            SqlDataReader reading1 = sqlCommand1.ExecuteReader();
            while(reading1.Read())
            {
                label1.Text = reading1.GetString(0);
                label2.Text = reading1.GetString(1);
                label3.Text = reading1.GetString(2);
            }
            connу.Close();

        }

        private void bt_authorization_Click(object sender, EventArgs e)
        {
            User frmuser = new User();
            frmuser.Show();
            this.Hide();
        }

        private void UserProfil_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Histori frm_histor = new Histori(); 
            frm_histor.Show();
            this.Hide();
        }


    }
}
