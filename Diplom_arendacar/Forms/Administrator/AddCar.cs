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
using System.IO;

namespace Diplom_arendacar.Forms.Administrator
{
    public partial class AddCar : Form
    {
        public AddCar()
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

        private void AddCar_Load(object sender, EventArgs e)
        {
            Brend();
            Body();
            Color();
            Year();
            Engine_Type();
            Engine_Capacity();
            Transmission_Type();
            tb_Model_Name.Text = " ";
            tb_Horsepower.Text = " ";
            tb_Milage.Text = " ";
            tb_TO.Text = " ";
            tb_Cost_One_Day.Text = " ";
            tb_VIN_Number.Text = " ";

        }


        void Brend()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT BrandID, Brand FROM [Brand]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Brend.DataSource = lst;
            cb_Brend.ValueMember = "id";
            cb_Brend.DisplayMember = "name";
            conn.Close();
        }



        void Body()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT BodyID, Body FROM [Body] ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Body.DataSource = lst;
            cb_Body.ValueMember = "id";
            cb_Body.DisplayMember = "name";
            conn.Close();
        }

        void Color()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT ColorID, Color FROM [Color]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Color.DataSource = lst;
            cb_Color.ValueMember = "id";
            cb_Color.DisplayMember = "name";
            conn.Close();
        }

        void Year()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT YearID, Year FROM [Year]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Year.DataSource = lst;
            cb_Year.ValueMember = "id";
            cb_Year.DisplayMember = "name";
            conn.Close();
        }

        void Engine_Type()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TypeEngineID, TypeEngine FROM [TypeEngine]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Engine_Type.DataSource = lst;
            cb_Engine_Type.ValueMember = "id";
            cb_Engine_Type.DisplayMember = "name";
            conn.Close();
        }

        void Engine_Capacity()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT EngineCapacityID, Capacity FROM [EngineCapacity] ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Engine_Capacity.DataSource = lst;
            cb_Engine_Capacity.ValueMember = "id";
            cb_Engine_Capacity.DisplayMember = "name";
            conn.Close();
        }


        void Transmission_Type()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TransmissioneID, Trans FROM [Transmissione]", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Transmission_Type.DataSource = lst;
            cb_Transmission_Type.ValueMember = "id";
            cb_Transmission_Type.DisplayMember = "name";
            conn.Close();
        }

        private void cb_Engine_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Engine_Type.SelectedIndex == 3)
            {
                label9.Visible = true;
                tb_power_reserve.Visible = true;
                panel5.Visible = true;

                label14.Visible = false;
                cb_Engine_Capacity.Visible = false;

            }
            else
            {
                label9.Visible = false;
                tb_power_reserve.Visible = false;
                panel5.Visible = false;

                label14.Visible = true;
                cb_Engine_Capacity.Visible = true;

            }
        }

        private void bt_add_car_Click(object sender, EventArgs e)
        {
            if (tb_Horsepower.TextLength < 2)
            {
                MessageBox.Show("Мощность двигателя не может быть меншье 50 (лс)");
            }
            ///Без доп секции


            if (cb_Brend.SelectedIndex == 0)
            {
                MessageBox.Show("Вы не выбрали поле бренд");
            }

            if (cb_Color.SelectedIndex == 0)
            {
                MessageBox.Show("Вы не выбрали поле цвет");
            }

            if (cb_Year.SelectedIndex == 0)
            {
                MessageBox.Show("Вы не выбрали поле год");
            }

            if (cb_Engine_Type.SelectedIndex == 0)
            {
                MessageBox.Show("Вы не выбрали тип двигателя");
            }


            if (tb_Model_Name.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле название модели");
            }

            if (tb_Horsepower.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле количесвто лошидинных сил");
            }

            if (tb_Milage.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле пробег");
            }

            if (tb_TO.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле количесвто ТО");
            }

            if (tb_Cost_One_Day.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле ценаз один день");
            }

            if (tb_VIN_Number.Text == " ")
            {
                MessageBox.Show("Вы не заполнили поле VIN-номер");
            }
            try
            {
                if (cb_Engine_Type.SelectedIndex == 3)
                {
                    if (tb_power_reserve.Text == " ")
                    {
                        MessageBox.Show("Вы не заполнили поле запас хода");
                    }
                    else
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "add_new_car_electro";
                        cmd.Parameters.AddWithValue("@status_car_id", 1);
                        cmd.Parameters.AddWithValue("@brand_id", cb_Brend.SelectedIndex);
                        cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                        cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                        cmd.Parameters.AddWithValue("car_name", tb_Model_Name.Text);
                        cmd.Parameters.AddWithValue("@year_id", cb_Year.SelectedIndex);
                        cmd.Parameters.AddWithValue("@type_engent_id", cb_Engine_Type.SelectedIndex); /// тип двигателя
                        cmd.Parameters.AddWithValue("@engine_capacity_id", 0); ///Объём двигателя 
                        cmd.Parameters.AddWithValue("@powe", tb_Horsepower.Text);
                        cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                        cmd.Parameters.AddWithValue("@transmissione_id", cb_Transmission_Type.SelectedIndex);
                        cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                        cmd.Parameters.AddWithValue("@power_reserve", Convert.ToInt32(tb_power_reserve.Text));
                        cmd.Parameters.AddWithValue("@number_uses", 0);
                        cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                        cmd.Parameters.AddWithValue("@VIN", tb_VIN_Number.Text);
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        tb_Model_Name.Text = " ";
                        tb_Horsepower.Text = " ";
                        tb_Milage.Text = " ";
                        tb_TO.Text = " ";
                        tb_Cost_One_Day.Text = " ";
                        tb_VIN_Number.Text = " ";

                        cb_Body.SelectedIndex = 0;
                        cb_Brend.SelectedIndex = 0;
                        cb_Color.SelectedIndex = 0;
                        cb_Engine_Capacity.SelectedIndex = 0;
                        cb_Engine_Type.SelectedIndex = 0;
                        cb_Year.SelectedIndex = 0;
                        cb_Transmission_Type.SelectedIndex = 0;

                        MessageBox.Show("Машина успешно добавлена");
                    }
                }
                else if (cb_Engine_Type.SelectedIndex == 1 || cb_Engine_Type.SelectedIndex == 2)
                {

                    if (cb_Engine_Capacity.SelectedIndex == 0)
                    {
                        MessageBox.Show("Вы не выбрали поле объём двигателя");
                    }
                    else
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "add_new_car_electro";
                        cmd.Parameters.AddWithValue("@status_car_id", 1);
                        cmd.Parameters.AddWithValue("@brand_id", cb_Brend.SelectedIndex);
                        cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                        cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                        cmd.Parameters.AddWithValue("car_name", tb_Model_Name.Text);
                        cmd.Parameters.AddWithValue("@year_id", cb_Year.SelectedIndex);
                        cmd.Parameters.AddWithValue("@type_engent_id", cb_Engine_Type.SelectedIndex); /// тип двигателя
                        cmd.Parameters.AddWithValue("@engine_capacity_id", cb_Engine_Capacity.SelectedIndex); ///Объём двигателя 
                        cmd.Parameters.AddWithValue("@powe", tb_Horsepower.Text);
                        cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                        cmd.Parameters.AddWithValue("@transmissione_id", cb_Transmission_Type.SelectedIndex);
                        cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                        cmd.Parameters.AddWithValue("@power_reserve", 0);
                        cmd.Parameters.AddWithValue("@number_uses", 0);
                        cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                        cmd.Parameters.AddWithValue("@VIN", tb_VIN_Number.Text);
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        tb_Model_Name.Text = " ";
                        tb_Horsepower.Text = " ";
                        tb_Milage.Text = " ";
                        tb_TO.Text = " ";
                        tb_Cost_One_Day.Text = " ";
                        tb_VIN_Number.Text = " ";

                        cb_Body.SelectedIndex = 0;
                        cb_Brend.SelectedIndex = 0;
                        cb_Color.SelectedIndex = 0;
                        cb_Engine_Capacity.SelectedIndex = 0;
                        //cb_Engine_Type.SelectedIndex= 0;
                        cb_Year.SelectedIndex = 0;
                        cb_Transmission_Type.SelectedIndex = 0;

                        MessageBox.Show("Машина успешно добавлена");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bt_exite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_insert_img_Click(object sender, EventArgs e)
        {

        }

        private void tb_Horsepower_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_Milage_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_Cost_One_Day_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void tb_TO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }

        private void tb_VIN_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetterOrDigit(ch) && ch != 8)
            {
                e.Handled = true;

            }
        }
    }
}
