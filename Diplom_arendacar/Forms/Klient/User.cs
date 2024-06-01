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
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using Microsoft.SqlServer.Server;
using Diplom_arendacar.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom_arendacar.Forms
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            toolTip();
        }


        private void User_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm frm_logn = new AuthorizationForm();
            frm_logn.Show();
            this.Close();
        }
        
        bool fl_name = false;
        bool fl_brend = false;
        bool fl_year = false;
        bool fl_color = false;
        bool fl_typ_engent = false;
        bool fl_body = false;
        bool fl_min_cost = false;
        bool fl_max_cost = false;

        string filter;
        class color
        {

            public string name { get; set; }
            public int id { get; set; }

            public color(int id, string nm)
            {
                this.id = id;
                this.name = nm;


            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            list_car();

            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcon.Open();
            SqlCommand ord11 = new SqlCommand();
            ord11.CommandType = CommandType.StoredProcedure;
            ord11.CommandText = "car_info_cuntry";
            ord11.Parameters.AddWithValue("@car_id", dgw_car.Rows[0].Cells[0].Value.ToString());
            ord11.Connection = sqlcon;
            SqlDataReader reading11 = ord11.ExecuteReader();
            //float a = reading11.GetFloat(1);
            while (reading11.Read())
            {
                label15.Text = reading11.GetString(0);
                label17.Text = reading11.GetString(1);
                label18.Text = reading11.GetString(2);
                label20.Text = reading11.GetString(4);
                int x = Convert.ToInt32(dgw_car.Rows[0].Cells[3].Value);

                if (x == 3)
                {
                    label14.Visible = true;
                    label19.Visible = true;
                    panel15.Visible = true;
                    label19.Text = Convert.ToString(reading11.GetInt32(3));
                }
                else
                {
                    label14.Visible = false;
                    label19.Visible = false;
                    panel15.Visible = false;
                    label19.Visible = false;
                }

            }
            sqlcon.Close();

            sqlcon.Close();

            SqlConnection sqlcon11 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcon11.Open();
            SqlCommand cmd111 = new SqlCommand();
            cmd111.CommandType = CommandType.StoredProcedure;
            cmd111.CommandText = "foto";
            cmd111.Parameters.AddWithValue("@car_id", dgw_car.Rows[0].Cells[0].Value.ToString());
            cmd111.Connection = sqlcon11;
            SqlDataReader rdr111 = cmd111.ExecuteReader();
            rdr111.Read();

            if (rdr111["Image"].ToString() == "")
            {

                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\no_foto.jpg");
            }
            else
            {
                Properties.Settings.Default.care_foto = rdr111.GetString(0);
                string p = Properties.Settings.Default.care_foto;

                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\" + p);


            }
            sqlcon11.Close();

            if (Properties.Settings.Default.role_id == 5)
            {
                bt_registration.Visible = true;
                bt_orders_klient.Visible = false;
            }
            else
            {
                bt_registration.Visible = false;
                bt_orders_klient.Visible = true;
            }


            if(Properties.Settings.Default.Greeting > 0)
            {

            }
            else
            {

                if (Properties.Settings.Default.role_id == 5)
                {
                    string time = DateTime.Now.ToString("HH");
                    int v = Convert.ToInt32(time);

                    if (v >= 6 & v < 12)
                    {
                        MessageBox.Show($"Доброе утро дорогой гость");
                    }
                    else if (v >= 12 & v < 18)
                    {
                        MessageBox.Show($"Добрый день дорогой гость");
                    }
                    else if (v >= 18 & v < 24)
                    {
                        MessageBox.Show($"Доброе вечер дорогой гость");
                    }
                    else
                    {
                        MessageBox.Show($"Доброй ночи дорогой гость");
                    }
                }
                else
                {
                    string time = DateTime.Now.ToString("HH");
                    int v = Convert.ToInt32(time);


                    SqlConnection con = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmdd = new SqlCommand();

                    con.Open();
                    cmdd.CommandType = CommandType.StoredProcedure;
                    cmdd.CommandText = "Greeting";
                    cmdd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
                    cmdd.Connection = con;
                    SqlDataReader dr = cmdd.ExecuteReader();
                    dr.Read();
                    if (v >= 6 & v < 12)
                    {
                        MessageBox.Show($"Доброе утро {dr.GetString(0)} {dr.GetString(1)} {dr.GetString(2)}");
                    }
                    else if (v >= 12 & v < 18)
                    {
                        MessageBox.Show($"Добрый день {dr.GetString(0)} {dr.GetString(1)} {dr.GetString(2)}");
                    }
                    else if (v >= 18 & v < 24)
                    {
                        MessageBox.Show($"Доброе вечер {dr.GetString(0)} {dr.GetString(1)} {dr.GetString(2)}");
                    }
                    else
                    {
                        MessageBox.Show($"Доброй ночи {dr.GetString(0)} {dr.GetString(1)} {dr.GetString(2)}");
                    }

                    con.Close();
                    Properties.Settings.Default.Greeting += 1;
                }
            }
            Engine_Type();
            Body();





            List<color> lst = new List<color>();
            SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand("SELECT ColorID, Color from [Color] ", connect);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new color(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_color.DataSource = lst;
            cb_color.ValueMember = "id";
            cb_color.DisplayMember = "name";
            connect.Close();


            List<color> lst2 = new List<color>();
            SqlConnection sqlconnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlconnection.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT YearID, Year from [Year] ", sqlconnection);
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            while (rdr2.Read())
            {

                lst2.Add(new color(rdr2.GetInt32(0), rdr2.GetString(1)));

            }
            cb_year.DataSource = lst2;
            cb_year.ValueMember = "id";
            cb_year.DisplayMember = "name";
            sqlconnection.Close();

            List<color> lst3 = new List<color>();
            SqlConnection connect2 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connect2.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT BrandID, Brand from [Brand] ", connect2);
            SqlDataReader rdr1 = cmd1.ExecuteReader();
            while (rdr1.Read())
            {

                lst3.Add(new color(rdr1.GetInt32(0), rdr1.GetString(1)));

            }
            cb_brand.DataSource = lst3;
            cb_brand.ValueMember = "id";
            cb_brand.DisplayMember = "name";
            connect2.Close();

            ///dataGridView12.DataSource = dataSet.Tables[0];

        }
        void list_car()
        {
            SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "listcar1";
            sqlCommand.Connection = sqlConnection;
            using (SqlDataReader reading = sqlCommand.ExecuteReader())
            {

                var dataTable = new DataTable();
                dataTable.Load(reading);

                dgw_car.DataSource = dataTable;
            }

            dgw_car.Columns[0].Visible = false;
            dgw_car.Columns[3].Visible = false;
            dgw_car.Columns[8].Visible = false;
            dgw_car.Columns[10].Visible = false;
            dgw_car.Columns[11].Visible = false;
            dgw_car.Columns[12].Visible = false;
            sqlConnection.Close();
        }

        void filterr()
        {
            DataTable dt = (DataTable)dgw_car.DataSource;
            DataView dataView = dt.DefaultView;
            dataView.RowFilter = string.Empty;
            if (fl_name)
            {
                filter += $"and Модель LIKE '%{tb_name.Text}%'";
            }
            if (fl_brend)
            {
                filter += $"and Бренд = '{cb_brand.Text}'";
            }
            if (fl_year)
            {
                filter += $"and Год ='{cb_year.Text}'";
            }
            if (fl_color)
            {
                filter += $"and цвет ='{cb_color.Text}'";
            }
            if (fl_body)
            {
                filter += $"and Кузов ='{cb_Body.Text}'";
            }
            if (fl_typ_engent)
            {
                filter += $"and Typeengine = '{cb_Engine_Type.Text}'";
            }
            if (fl_min_cost)
            {
                filter += $"and Цена >='{tb_costmine.Text}'";
            }
            if (fl_max_cost)
            {
                filter += $"and Цена <= '{tb_costmax.Text}'";
            }
            if (!string.IsNullOrEmpty(filter))
            {
                dataView.RowFilter = filter.Remove(0, 3);

            }
            filter = "";
            dgw_car.Refresh();
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (tb_name.Text != "") fl_name = true;
            else fl_name = false;
            filterr();
        }


        private void cb_brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_brand.SelectedIndex != 0) fl_brend = true;
            else fl_brend = false;
            filterr();
        }

        private void cb_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_year.SelectedIndex != 0) fl_year = true;
            else fl_year = false;
            filterr();
        }

        private void cb_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_color.SelectedIndex != 0) fl_color = true;
            else fl_color = false;
            filterr();
        }

        private void cb_Engine_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Engine_Type.SelectedIndex != 0) fl_typ_engent = true;
            else fl_typ_engent = false;
            filterr();
        }

        private void cb_Body_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Body.SelectedIndex != 0) fl_body = true;
            else fl_body = false;
            filterr();
        }

        private void tb_costmine_TextChanged(object sender, EventArgs e)
        {
            if (tb_costmine.Text != "") fl_min_cost = true;
            else fl_min_cost = false;
            filterr();
        }

        private void tb_costmax_TextChanged(object sender, EventArgs e)
        {
            if (tb_costmax.Text != "") fl_max_cost = true;
            else fl_max_cost = false;
            filterr();
        }

        




        private void dgw_car_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcon.Open();
            SqlCommand ord11 = new SqlCommand();
            ord11.CommandType = CommandType.StoredProcedure;
            ord11.CommandText = "car_info_cuntry";
            ord11.Parameters.AddWithValue("@car_id", dgw_car.CurrentRow.Cells[0].Value.ToString());
            ord11.Connection = sqlcon;
            SqlDataReader reading11 = ord11.ExecuteReader();
            //float a = reading11.GetFloat(1);
            while (reading11.Read())
            {
                label15.Text = reading11.GetString(0);
                label17.Text = reading11.GetString(1);
                label18.Text = reading11.GetString(2);
                label20.Text = reading11.GetString(4);
                int x = Convert.ToInt32(dgw_car.CurrentRow.Cells[3].Value);

                if (x == 3)
                {
                    label14.Visible = true;
                    label19.Visible = true;
                    panel15.Visible = true;
                    label19.Text = Convert.ToString(reading11.GetInt32(3));
                }
                else
                {
                    label14.Visible = false;
                    label19.Visible = false;
                    panel15.Visible = false;
                    label19.Visible = false;
                }
            }
            sqlcon.Close();

            SqlConnection sqlcon1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcon1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "foto";
            cmd.Parameters.AddWithValue("@car_id", dgw_car.CurrentRow.Cells[0].Value.ToString());
            cmd.Connection = sqlcon1;
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();

            if (rdr1["Image"].ToString() == "" )
            {
              
                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\no_foto.jpg");
            }
            else
            {             
                Properties.Settings.Default.care_foto = rdr1.GetString(0);
                string p = Properties.Settings.Default.care_foto;
                
                pictureBox3.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\" + p);


            }
            sqlcon1.Close();
        }          
        
        
        private void dgw_car_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            if(Properties.Settings.Default.role_id == 5)
            {
                MessageBox.Show("Не зарегестрированый пользователь не может арендовть машину\n ");
            }
            else
            {
                Properties.Settings.Default.car_id = Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value.ToString());
                int cost_car = Convert.ToInt32(dgw_car.CurrentRow.Cells[7].Value.ToString());
                Properties.Settings.Default.car_cost = cost_car;
                CreatyOrdersrClient frm_COC = new CreatyOrdersrClient();
                frm_COC.Show();
            }

        }

        private void bt_clearfilter_Click(object sender, EventArgs e)
        {
            fl_name = false;
            fl_brend = false;
            fl_year = false;
            fl_color = false;
            fl_min_cost = false;
            fl_max_cost = false;
            fl_body = false;

            tb_name.Text = "";
            cb_Body.SelectedIndex = 0;
            cb_brand.SelectedIndex= 0;
            cb_color.SelectedIndex= 0;
            cb_year.SelectedIndex= 0;
            tb_costmine.Text = "";
            tb_costmax.Text = "";

            filterr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserProfil frmProfil = new UserProfil();
            frmProfil.Show();
            this.Hide();
        }



        private void bt_registration_Click(object sender, EventArgs e)
        {
            RegistrationForm frm_Avtoreg1 = new RegistrationForm();
            frm_Avtoreg1.Show();
            this.Hide();
        }

        private void tb_costmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_costmine_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        void Body()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            List<color> lst = new List<color>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT BodyID, Body FROM [Body] ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new color(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Body.DataSource = lst;
            cb_Body.ValueMember = "id";
            cb_Body.DisplayMember = "name";
            conn.Close();
        }

        void Engine_Type()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            List<color> lst = new List<color>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TypeEngineID, TypeEngine FROM [TypeEngine]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new color(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Engine_Type.DataSource = lst;
            cb_Engine_Type.ValueMember = "id";
            cb_Engine_Type.DisplayMember = "name";
            conn.Close();
        }

        void toolTip()
        {
            toolTip1.SetToolTip(this.dgw_car, "Для выбора авто кликните 2 раза");
            toolTip1.SetToolTip(this.bt_orders_klient, "Для выбора авто кликните 2 раза");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
