using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_arendacar.Forms.Administrator
{
    public partial class ChangeCar1 : Form
    {
        public ChangeCar1()
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

        private void ChangeCar1_Load(object sender, EventArgs e)
        {
            list_car();
            Brend();
            Country();
            Body();
            Color();
            Year();
            Engine_Type();
            Engine_Capacity();
            Transmission_Type();
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        void list_car()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "list_care_change1";
            cmd.Connection = conn;
            SqlDataReader reed = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reed);
            dgw_car.DataSource = dt;
            conn.Close();
            dgw_car.Columns[0].Visible = false;
            dgw_car.Columns[1].Visible = false;
            dgw_car.Columns[2].Visible = false;
            dgw_car.Columns[3].Visible = false;
            dgw_car.Columns[4].Visible = false;
            dgw_car.Columns[5].Visible = false;
            dgw_car.Columns[6].Visible = false;
            dgw_car.Columns[7].Visible = false;
            dgw_car.Columns[8].Visible = false;
            dgw_car.Columns[9].Visible = false;
            dgw_car.Columns[13].Visible = false;
            dgw_car.Columns[14].Visible = false;
            dgw_car.Columns[15].Visible = false;
            dgw_car.Columns[16].Visible = false;
        }

        private void dgw_car_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            tb_Model_Name.Text = dgw_car.CurrentRow.Cells[11].Value.ToString();

            cb_Brend.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[1].Value);
            cb_Country.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[2].Value);
            cb_Color.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[4].Value);
            cb_Body.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[3].Value);
            cb_Year.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[5].Value);
            cb_Engine_Type.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[6].Value);
            cb_Transmission_Type.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[8].Value);
            cb_Engine_Capacity.SelectedIndex = Convert.ToInt32(dgw_car.CurrentRow.Cells[7].Value);

            tb_power_reserve.Text = dgw_car.CurrentRow.Cells[9].Value.ToString();
            tb_Horsepower.Text = dgw_car.CurrentRow.Cells[13].Value.ToString();
            tb_Milage.Text = dgw_car.CurrentRow.Cells[14].Value.ToString();
            tb_TO.Text = dgw_car.CurrentRow.Cells[15].Value.ToString();
            tb_Cost_One_Day.Text = dgw_car.CurrentRow.Cells[16].Value.ToString();
            tb_VIN_Number.Text = dgw_car.CurrentRow.Cells[12].Value.ToString();

            if (cb_Engine_Type.SelectedIndex == 3)
            {
                ///Запас хода
                label9.Visible = true;
                tb_power_reserve.Visible = true;
                panel5.Visible = true;

                /// объём двигателя
                label14.Visible = false;
                cb_Engine_Capacity.Visible = false;
                cb_Engine_Capacity.SelectedIndex = 1;
            }
            else
            {
                ///Запас хода
                label9.Visible = false;
                tb_power_reserve.Visible = false;
                panel5.Visible = false;

                /// объём двигателя
                label14.Visible = true;
                cb_Engine_Capacity.Visible = true;

            }
            Foto_car();


        }

        private void cb_Engine_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Engine_Type.SelectedIndex == 3)
            {
                ///Запас хода
                label9.Visible = true;
                tb_power_reserve.Visible = true;
                panel5.Visible = true;

                /// объём двигателя
                label14.Visible = false;
                cb_Engine_Capacity.Visible = false;
            }
            else
            {
                ///Запас хода
                label9.Visible = false;
                tb_power_reserve.Visible = false;
                panel5.Visible = false;

                /// объём двигателя
                label14.Visible = true;
                cb_Engine_Capacity.Visible = true;
            }
        }

        private void bt_change_name_Click(object sender, EventArgs e)
        {
            if (cb_Brend.SelectedIndex == 0)
            {
                MessageBox.Show("Для машины нельзя выбрать все бренды!");
            }
            else if (cb_Color.SelectedIndex == 0)
            {
                MessageBox.Show("Для машины нельзя выбрать все цвета!");
            }
            else if (cb_Year.SelectedIndex == 0)
            {
                MessageBox.Show("Для машины нельзя выбрать все года!");
            }
            else if (cb_Engine_Capacity.SelectedIndex == 0)
            {                            
                    MessageBox.Show("Для машины нельзя выбрать объём двигателя 0");                       
            }
            else
            {
                if (tb_VIN_Number.Text == dgw_car.CurrentRow.Cells[12].Value.ToString())
                {
                    if (cb_Engine_Type.SelectedIndex == 3)
                    {
                        if (cb_Engine_Type.SelectedIndex == Convert.ToInt32(dgw_car.CurrentRow.Cells[6].Value))
                        {
                            
                            /// обнавляем всё кроме вин номера, типа двигателя
                            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlCommand cmd1 = new SqlCommand();
                            conn1.Open();
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.CommandText = "change_car_electro_true";
                            cmd1.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
                            cmd1.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
                            cmd1.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@power_reserve", Convert.ToInt32(tb_power_reserve.Text));
                            cmd1.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
                            cmd1.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                            cmd1.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                            cmd1.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                            cmd1.Parameters.AddWithValue("@vin", Convert.ToString(0));
                            cmd1.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex = 0);
                            cmd1.Parameters.AddWithValue("@Engine_Type", cb_Engine_Type.SelectedIndex);

                            cmd1.Connection = conn1;
                            cmd1.ExecuteNonQuery();
                            conn1.Close();


                            list_car();
                            MessageBox.Show("Изменения успешно сохранены");
                        }
                        else
                        {
                            /// обнавляем !тип двигателя на бенз/саляра обновсляе объём двигателя!
                            /// сбрасываем запас хода до 0
                            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlCommand cmd1 = new SqlCommand();
                            conn1.Open();
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.CommandText = "change_car_electro_false";
                            cmd1.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
                            cmd1.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
                            cmd1.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@power_reserve", Convert.ToInt32(tb_power_reserve.Text));
                            cmd1.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
                            cmd1.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                            cmd1.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                            cmd1.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                            cmd1.Parameters.AddWithValue("@Engine_Type", cb_Engine_Type.SelectedIndex);
                            cmd1.Parameters.AddWithValue("@Engine_Capacity", 0);
                            cmd1.Parameters.AddWithValue("@vin", Convert.ToString(0));
                            cmd1.Connection = conn1;
                            cmd1.ExecuteNonQuery();
                            conn1.Close();


                            list_car();
                            MessageBox.Show("Изменения успешно сохранены");
                        }
                    }
                    else
                    {
                        if (cb_Engine_Type.SelectedIndex == Convert.ToInt32(dgw_car.CurrentRow.Cells[6].Value))
                        {
                            ///Это бензин или дизель для кторого не меняли вин код и не меняли тип двигателя
                            ///НЕ ПОМЕНЯЛ ТИП ДВИГАТЕЛЯ ВИН код не трогал
                            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlCommand cmd = new SqlCommand();
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "change_car_true";
                            cmd.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
                            cmd.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
                            cmd.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
                            cmd.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
                            cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                            cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                            cmd.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
                            cmd.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
                            cmd.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
                            cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                            cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                            cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                            cmd.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex);
                            cmd.Parameters.AddWithValue("@vin", Convert.ToString(0));
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();

                            conn.Close();


                            list_car();
                            MessageBox.Show("Изменения успешно сохранены");
                        }
                        else
                        {
                            ///Это поменяный тип двигателя не менял вин кода
                            ///ПОМЕНЯЛ ТИП ДВИГАТЕЛЯ(ALL) ВИН КОД НЕ ТРОГАЛ
                            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                            SqlCommand cmd = new SqlCommand();
                            conn.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "change_car_false";
                            cmd.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
                            cmd.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
                            cmd.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
                            cmd.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
                            cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
                            cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
                            cmd.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
                            cmd.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
                            cmd.Parameters.AddWithValue("@power_reserve", 0);
                            cmd.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
                            cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
                            cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
                            cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
                            cmd.Parameters.AddWithValue("@Engine_Type", cb_Engine_Type.SelectedIndex);
                            cmd.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex);
                            cmd.Parameters.AddWithValue("@vin", Convert.ToString(0));
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();

                            conn.Close();

                            
                            list_car();
                            MessageBox.Show("Изменения успешно сохранены");
                        }
                    }
                }
                else
                {
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "proverka_vin";
                    cmd.Parameters.AddWithValue("@vin_cod", tb_VIN_Number.Text);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("В базе данных уже существует такой VIN код");
                        conn.Close();
                    }
                    else
                    {
                        if (cb_Engine_Type.SelectedIndex == 3)
                        {
                            if (cb_Engine_Type.SelectedIndex == Convert.ToInt32(dgw_car.CurrentRow.Cells[6].Value))
                            {
                                /// обнавляем всё кроме вин номера, типа двигателя
                                change_car_electro_true();

                                list_car();
                                MessageBox.Show("Изменения успешно сохранены");
                            }
                            else
                            {
                                /// обнавляем !тип двигателя на бенз/саляра обновсляе объём двигателя!
                                /// сбрасываем запас хода до 0
                                change_car_electro_false();

                                list_car();
                                MessageBox.Show("Изменения успешно сохранены");
                            }
                        }
                        else
                        {
                            if (cb_Engine_Type.SelectedIndex == Convert.ToInt32(dgw_car.CurrentRow.Cells[6].Value))
                            {
                                ///Это бензин или дизель для кторого не меняли вин код и не меняли тип двигателя
                                ///НЕ ПОМЕНЯЛ ТИП ДВИГАТЕЛЯ ВИН код не трогал
                                change_car_true();
  
                                list_car();
                                MessageBox.Show("Изменения успешно сохранены");

                            }
                            else
                            {
                                ///Это поменяный тип двигателя не менял вин кода
                                ///ПОМЕНЯЛ ТИП ДВИГАТЕЛЯ(ALL) ВИН КОД НЕ ТРОГАЛ
                                change_car_false();

                                list_car();
                                MessageBox.Show("Изменения успешно сохранены");
                            }
                        }
                    }
                }
            }
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

        void Country()
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT CountryID, Country FROM [Country] ", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_Country.DataSource = lst;
            cb_Country.ValueMember = "id";
            cb_Country.DisplayMember = "name";
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

        void change_car_electro_true()
        {
            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd1 = new SqlCommand();
            conn1.Open();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "change_car_electro_true";
            cmd1.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
            cmd1.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
            cmd1.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
            cmd1.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
            cmd1.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
            cmd1.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
            cmd1.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
            cmd1.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
            cmd1.Parameters.AddWithValue("@power_reserve", Convert.ToInt32(tb_power_reserve.Text));
            cmd1.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
            cmd1.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
            cmd1.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
            cmd1.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
            cmd1.Parameters.AddWithValue("@vin", tb_VIN_Number.Text);
            cmd1.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex = 0);

            cmd1.Connection = conn1;
            cmd1.ExecuteNonQuery();
            conn1.Close();
        }

        void change_car_electro_false()
        {
            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd1 = new SqlCommand();
            conn1.Open();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "change_car_electro_false";
            cmd1.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
            cmd1.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
            cmd1.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
            cmd1.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
            cmd1.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
            cmd1.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
            cmd1.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
            cmd1.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
            cmd1.Parameters.AddWithValue("@power_reserve", 0);
            cmd1.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
            cmd1.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
            cmd1.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
            cmd1.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
            cmd1.Parameters.AddWithValue("@Engine_Type", cb_Engine_Type.SelectedIndex);
            cmd1.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex);
            cmd1.Parameters.AddWithValue("@vin", tb_VIN_Number.Text);
            cmd1.Connection = conn1;
            cmd1.ExecuteNonQuery();
            conn1.Close();
        }

        void change_car_true()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "change_car_true";
            cmd.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
            cmd.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
            cmd.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
            cmd.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
            cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
            cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
            cmd.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
            cmd.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
            cmd.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
            cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
            cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
            cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
            cmd.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex);
            cmd.Parameters.AddWithValue("@vin", tb_VIN_Number.Text);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        void change_car_false()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "change_car_false";
            cmd.Parameters.AddWithValue("@care_id", Convert.ToInt32(dgw_car.CurrentRow.Cells[0].Value));
            cmd.Parameters.AddWithValue("@model_name", tb_Model_Name.Text);
            cmd.Parameters.AddWithValue("@brend_id", cb_Brend.SelectedIndex);
            cmd.Parameters.AddWithValue("@country_id", cb_Country.SelectedIndex);
            cmd.Parameters.AddWithValue("@color_id", cb_Color.SelectedIndex);
            cmd.Parameters.AddWithValue("@body_id", cb_Body.SelectedIndex);
            cmd.Parameters.AddWithValue("@Year_id", cb_Year.SelectedIndex);
            cmd.Parameters.AddWithValue("@Transmission_Type", cb_Transmission_Type.SelectedIndex);
            cmd.Parameters.AddWithValue("@power_reserve", 0);
            cmd.Parameters.AddWithValue("@horsepower", Convert.ToInt32(tb_Horsepower.Text));
            cmd.Parameters.AddWithValue("@mileage", Convert.ToInt32(tb_Milage.Text));
            cmd.Parameters.AddWithValue("@to", Convert.ToInt32(tb_TO.Text));
            cmd.Parameters.AddWithValue("@cost", Convert.ToInt32(tb_Cost_One_Day.Text));
            cmd.Parameters.AddWithValue("@Engine_Type", cb_Engine_Type.SelectedIndex);
            cmd.Parameters.AddWithValue("@Engine_Capacity", cb_Engine_Capacity.SelectedIndex);
            cmd.Parameters.AddWithValue("@vin", tb_VIN_Number.Text);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Foto_car()
        {
            SqlConnection sqlcon1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            sqlcon1.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "foto";
            cmd.Parameters.AddWithValue("@car_id", dgw_car.CurrentRow.Cells[0].Value.ToString());
            cmd.Connection = sqlcon1;
            SqlDataReader rdr1 = cmd.ExecuteReader();
            rdr1.Read();

            if (rdr1["Image"].ToString() == "")
            {

                pictureBox4.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\no_foto.jpg");

            }
            else
            {
                Properties.Settings.Default.care_foto = rdr1.GetString(0);
                string p = Properties.Settings.Default.care_foto;

                pictureBox4.Image = Image.FromFile(Environment.CurrentDirectory + "\\FotoCar1\\" + p);


            }
            sqlcon1.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string namePath = "";
                string namePath2 = "";
                if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    namePath = openFileDialog1.FileName;
                    namePath2 = Path.GetFileName(openFileDialog1.FileName);
                    File.Copy(namePath, Environment.CurrentDirectory + @"\FotoCar1\" + namePath2);
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "update_foto_car";
                    cmd.Parameters.AddWithValue("@care_id", dgw_car.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@foto", namePath2);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Фото успешно измененно!");
                    Foto_car();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }
    }
}
