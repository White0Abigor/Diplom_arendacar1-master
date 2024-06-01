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
using Diplom_arendacar.Forms.Administrator;

namespace Diplom_arendacar.Forms
{
    public partial class Administratorr : Form
    {
        public Administratorr()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand cmd = new SqlCommand();

        class worker
        {

            public string name { get; set; }
            public int id { get; set; }

            public worker(int id, string nm)
            {
                this.id = id;
                this.name = nm;


            }
        }

        private void bt_add_klient_Click(object sender, EventArgs e)
        {
            list_user();

            pnl_add_user.Visible = true;
            pnl_change_user.Visible = true;
            panel7.Visible = true;

        }

        private void bt_maine_add_user_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();
            string surname = tb_surname.Text.Trim();
            string patronymic = tb_patronymic.Text.Trim();
            string number = tb_number.Text.Trim();
            string password = tb_password.Text.Trim();

            conn.Open();
            int roleid = Convert.ToInt32(cb_role.SelectedValue);
            string proverka = $"SELECT Number FROM [User] WHERE Number='{number}'";
            SqlCommand sqlCommand = new SqlCommand(proverka, conn);
            SqlDataReader reed = sqlCommand.ExecuteReader();
            reed.Read();
            if (reed.HasRows)
            {
                MessageBox.Show("Пользователь с таким номером уже существует!");
                conn.Close();
            }
            else
            {
                reed.Close();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "add_worker";
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@surname", surname);
                sqlCommand.Parameters.AddWithValue("@patronymic", patronymic);
                sqlCommand.Parameters.AddWithValue("@number", number);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@role_id", roleid);

                sqlCommand.Connection = conn;
                sqlCommand.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Пользователь успешно добавлен");

            }
            conn.Close();

            tb_name.Text = "";
            tb_surname.Text = "";
            tb_patronymic.Text = "";
            tb_number.Text = "";
            tb_password.Text = "";
        }

        private void Administratorr_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Greeting > 0)
            {

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

        void list_user()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM [Role] WHERE RoleID = 2 OR RoleID = 3", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_role.DataSource = lst;
            cb_role.ValueMember = "id";
            cb_role.DisplayMember = "name";
            conn.Close();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "list_users";
            cmd.Connection = conn;
            SqlDataReader rdrd = cmd.ExecuteReader();
            rdrd.Read();

            DataTable db = new DataTable();
            db.Load(rdrd);
            dgw_user.DataSource = db;
            dgw_user.Columns[0].Visible = false;

            conn.Close();
        }

        private void bt_change_user_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgw_user.CurrentRow.Cells[0].Value) == 0)
            {
                MessageBox.Show("Выберите пользователя");
                
            }
            else
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_role_id";
                cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(dgw_user.CurrentRow.Cells[0].Value));
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Успешно ограничили доступ");
                list_user();
            }

        }

        private void bt_change_number_Click(object sender, EventArgs e)
        {
            new_number frm_number = new new_number();
            frm_number.ShowDialog();

                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "update_number";
                cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(dgw_user.CurrentRow.Cells[0].Value));
                cmd.Parameters.AddWithValue("@number", Properties.Settings.Default.user_number);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Номер успешно изменён");
                list_user();

        }

        private void bt_recover_access_Click(object sender, EventArgs e)
        {
            Recover_Access frm_a= new Recover_Access();
            frm_a.ShowDialog();

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "restoring_access";
            cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(dgw_user.CurrentRow.Cells[0].Value));
            cmd.Parameters.AddWithValue("@role_id", Properties.Settings.Default.role_id2);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
            list_user();
        }

        private void Administratorr_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm frm_logn = new AuthorizationForm();
            frm_logn.Show();
            this.Close();
        }

        private void bt_add_car_Click(object sender, EventArgs e)
        {
           AddCar frm_AddCar= new AddCar();
            frm_AddCar.ShowDialog();
            pnl_add_user.Visible = false;
            pnl_change_user.Visible = false;
            panel7.Visible = false;
        }

        private void bt_add_detali_open_form_Click(object sender, EventArgs e)
        {
            AddDetal frm_AddDetal = new AddDetal();
            frm_AddDetal.Show();
            pnl_add_user.Visible = false;
            pnl_change_user.Visible = false;
            panel7.Visible = false;
        }

        private void bt_change_car_Click(object sender, EventArgs e)
        {
            ChangeCar1 frm_ChangeCar = new ChangeCar1();
            frm_ChangeCar.Show();
            pnl_add_user.Visible = false;
            pnl_change_user.Visible = false;
            panel7.Visible = false;
        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {


            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_surname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_patronymic_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void bt_add_data_Click(object sender, EventArgs e)
        {
            New_data frm_nd = new New_data();
            frm_nd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report frm_report = new Report();
            frm_report.Show();
        }
    }
}
