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
    public partial class AddDetal : Form
    {
        public AddDetal()
        {
            InitializeComponent();
        }

        private void AddDetal_Load(object sender, EventArgs e)
        {
            list_detali();
        }

        private void bt_maine_add_user_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "add_detali";
            cmd.Parameters.AddWithValue("@name_detali", tb_name_detali.Text);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Деталь успешно добавлена!");
            tb_name_detali.Text = "";
            list_detali();
        }

        void list_detali()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "list_detali";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_list_detali.DataSource = dt;
            conn.Close();

            dgw_list_detali.Columns[0].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
