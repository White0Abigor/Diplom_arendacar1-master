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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom_arendacar.Forms
{
    public partial class CreatyOrdersrClient : Form
    {


        public CreatyOrdersrClient()
        {
            InitializeComponent();
        }

        private void CreatyOrdersrClient_Load(object sender, EventArgs e)
        {       
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "Ordercar1";
            sqlCommand.Parameters.AddWithValue("@car_id", Properties.Settings.Default.car_id);
            sqlCommand.Connection = sqlConnection;
            using (SqlDataReader reading = sqlCommand.ExecuteReader())
            {

                var dataTable = new DataTable();
                dataTable.Load(reading);

                dgw_car1.DataSource = dataTable;
            }
            dgw_car1.Columns[7].Visible = false;
            dgw_car1.Columns[0].Visible = false;
            sqlConnection.Close();

            dateTimePicker1.MinDate = DateTime.Now;
            dateTimePicker2.MinDate = DateTime.Now;

        }

        private void bt_counting_Click_1(object sender, EventArgs e)
        {
            var dt1 = dateTimePicker1.Value;
            var dt2 = dateTimePicker2.Value;
            TimeSpan x = dt2 - dt1;
            int pp = ((int)x.TotalDays);
            label7.Text = Convert.ToString(pp + 1);
            int xdata = Convert.ToInt32(label7.Text);
            int cost = Convert.ToInt32(dgw_car1.CurrentRow.Cells[6].Value.ToString()); 
            var v = (cost * (xdata));
            lblcost.Text = Convert.ToString(v);
            label6.Visible = true;
        }

        private void bt_creyatorder_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcmd = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcmd.Open();
            SqlCommand comandcmd = new SqlCommand();
            comandcmd.CommandType = CommandType.StoredProcedure;
            comandcmd.CommandText = "CreatOrderUser";
            comandcmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
            comandcmd.Parameters.AddWithValue("@car_id", Convert.ToInt32(dgw_car1.CurrentRow.Cells[0].Value.ToString()));
            comandcmd.Parameters.AddWithValue("@date_start", dateTimePicker1.Value);
            comandcmd.Parameters.AddWithValue("@date_end", dateTimePicker2.Value);
            comandcmd.Parameters.AddWithValue("@cost_renal", Convert.ToInt32(lblcost.Text));
            comandcmd.Connection= sqlcmd;  
            comandcmd.ExecuteNonQuery();
            sqlcmd.Close();

            MessageBox.Show("Заявка успешно созданна! \n Ваша заявка храниться у вас в истории \n В ближайше время вам позвонит менеждер");

            this.Close();
        }


    }
}
