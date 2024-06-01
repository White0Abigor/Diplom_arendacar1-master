using Diplom_arendacar.Forms.Master;
using iTextSharp.text;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom_arendacar.Properties;

namespace Diplom_arendacar.Forms
{
    public partial class Master1 : Form
    {
        
        public Master1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand cmd = new SqlCommand();

        

        private void Master_FormClosed(object sender, FormClosedEventArgs e)
        {
            AuthorizationForm frm_logn = new AuthorizationForm();
            frm_logn.Show();
            this.Close();

            bt_end_service.Visible = false;
            bt_end_to.Visible = false;
        }

        private void Master1_Load(object sender, EventArgs e)
        {
            List_All_Services();
            List_My_Services();

            //Checking_Start_Detaling();
            //Checking_End_Detaling();


        }

        private void List_All_Services()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_All_Services";
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgw_all_services.DataSource = dt;
                conn.Close();
                dgw_all_services.Columns[0].Visible = false;
                dgw_all_services.Columns[1].Visible = false;
                dgw_all_services.Columns[2].Visible = false;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void List_My_Services()
        {
            try
            {
                SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "List_My_Services";
                cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgv_my_service.DataSource = dt;
                conn.Close();
                dgv_my_service.Columns[0].Visible = false;
                dgv_my_service.Columns[1].Visible = false;
                dgv_my_service.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void bt_start_service_Click(object sender, EventArgs e)
        {

            try
            {

                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Start_Service_Detail";
                    cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
                    cmd.Parameters.AddWithValue("@car_id", dgv_my_service.Rows[0].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@date_start", DateTime.Now);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Время начала работы зафиксировано");
                    bt_start_service.Visible = false;

                    SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connect.Open();
                    SqlCommand cmdd = new SqlCommand($"SELECT TOP 1 CodeService FROM  [Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} ORDER BY CodeService DESC ", connect);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    if (reader.Read())
                    {
                        Properties.Settings.Default.CodeService = reader.GetString(0);
                        Properties.Settings.Default.Save();
                    }
                    connect.Close();

                    SqlConnection connectwpl = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connectwpl.Open();
                    SqlCommand cmdd123 = new SqlCommand($"SELECT TOP 1 ServiceID FROM [Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} ORDER BY ServiceID DESC", connectwpl);
                    SqlDataReader reader123 = cmdd123.ExecuteReader();
                    if (reader123.Read())
                    {
                        Properties.Settings.Default.service_id = reader123.GetInt32(0);
                        Properties.Settings.Default.Save();
                    }

                    connectwpl.Close();

                    bt_end_service.Visible = true;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void bt_end_service_Click(object sender, EventArgs e)
        {
            try
            {
                if(panel3.Visible == false)
                {
                    end_detail_info frm_info = new end_detail_info();
                    frm_info.ShowDialog();
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "End_Service_Detail";
                    cmd.Parameters.AddWithValue("@cost", Properties.Settings.Default.servise_cost);
                    cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CodeService", Properties.Settings.Default.CodeService);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    SqlConnection conn45 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd45 = new SqlCommand();
                    conn45.Open();
                    cmd45.CommandType = CommandType.StoredProcedure;
                    cmd45.CommandText = "Removing_machine";
                    cmd45.Parameters.AddWithValue("@car_id", Convert.ToInt32(dgv_my_service.Rows[0].Cells[0].Value));
                    cmd45.Connection = conn45;
                    cmd45.ExecuteNonQuery();
                    conn45.Close();
                    MessageBox.Show("Спасибо за вашу работу. \n Время конца работы сохраненно. \n Все работы на данном автомобиле закончены.\n Можете брать другое авто в работу!");

                    panel2.Visible = false;
                    List_My_Services();
                }
                else
                {
                    panel2.Visible = false;
                    end_detail_info frm_info = new end_detail_info();
                    frm_info.ShowDialog();
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "End_Service_Detail";
                    cmd.Parameters.AddWithValue("@cost", Properties.Settings.Default.servise_cost);
                    cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CodeService", Properties.Settings.Default.CodeService);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Спасибо за вашу работу. \n Время конца работы сохраненно");


                    SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connect.Open();
                    SqlCommand cmdd = new SqlCommand($"SELECT DateEnd FROM[Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value}", connect);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        bt_end_service.Visible = false;
                    }
                    else
                    {
                        bt_end_service.Visible = true;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ", ex.Message);
            }
        }
    

        private void Checking_Start_Detaling()
        {
            try
            {
                SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                connect.Open();
                SqlCommand cmdd = new SqlCommand($"SELECT DateStart FROM [Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} AND Work = 'Детейлинг'", connect);
                SqlDataReader reader = cmdd.ExecuteReader();
                if (reader.HasRows)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void Checking_End_Detaling()
        {
            try
            {
                SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                connect.Open();
                SqlCommand cmdd = new SqlCommand($"SELECT DateEnd FROM [Service] WHERE CodeService = {Properties.Settings.Default.CodeService} ", connect);
                SqlDataReader reader = cmdd.ExecuteReader();
                if (reader.HasRows)
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Properties.Settings.Default.CodeService);
        }

        private void dgw_all_services_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label19.Text = "Детейлинг";
            label19.Visible = true;

            int mileage = Convert.ToInt32(dgw_all_services.CurrentRow.Cells[1].Value);
            int to = Convert.ToInt32(dgw_all_services.CurrentRow.Cells[2].Value);
            if (to == 0 & mileage >= 10000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 1 && mileage >= 20000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 2 && mileage >= 30000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 3 && mileage >= 40000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 4 && mileage >= 50000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 5 && mileage >= 60000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 6 && mileage >= 70000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else if (to == 7 && mileage >= 80000)
            {
                label10.Text = "Техническое обслуживание";
                label10.Visible = true;
            }
            else
            {
                label10.Text = "";
                label10.Visible = false;
            }

        }

        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List_My_Services();
            List_All_Services();
            if (tabControl1.SelectedIndex == 1)
            {

               
                if(dgv_my_service.RowCount == 0)
                {

                }
                else
                {
                    panel2.Visible = true;
                    int mileage = Convert.ToInt32(dgv_my_service.CurrentRow.Cells[1].Value);
                    int to = Convert.ToInt32(dgv_my_service.CurrentRow.Cells[2].Value);
                    if (to == 0 && mileage >= 10000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 1 && mileage >= 20000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 2 && mileage >= 30000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 3 && mileage >= 40000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 4 && mileage >= 50000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 5 && mileage >= 60000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 6 && mileage >= 70000)
                    {
                        panel3.Visible = true;
                    }
                    else if (to == 7 && mileage >= 80000)
                    {
                        panel3.Visible = true;
                    }
                    else
                    {
                        panel3.Visible = false;
                    }

                    SqlConnection co = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cm = new SqlCommand($"SELECT TOP 1 [DateEnd] FROM Service WHERE  UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} AND Work = 'Детейлинг' ORDER BY DateStart DESC", co);
                    co.Open();
                    SqlDataReader rdr = cm.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        if (rdr["DateEnd"].ToString() == "")
                        {
                            bt_start_service.Visible = false;
                            bt_end_service.Visible = true;
                        }
                        else
                        {
                            panel2.Visible = false;
                        }
                    }
                    else
                    {
                        bt_start_service.Visible = true;
                    }
                    co.Close();

                    SqlConnection co1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cm1 = new SqlCommand($"SELECT TOP 1 [DateEnd] FROM Service WHERE  UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} AND Work = 'Техническое обслуживание' ORDER BY DateStart DESC", co1);
                    co1.Open();
                    SqlDataReader r1 = cm1.ExecuteReader();
                    if (r1.HasRows)
                    {
                        r1.Read();
                        if (r1["DateEnd"].ToString() == "")
                        {
                            bt_start_to.Visible = false;
                            bt_end_to.Visible = true;
                            bt_order_detali.Visible = true;
                        }
                        else
                        {
                            panel2.Visible = false;
                        }
                    }
                    else
                    {
                        bt_start_to.Visible = true;
                    }
                    co1.Close();
                }

            }
            else
            {
                panel3.Visible = false;
                panel2.Visible = false;
            }


        }

        private void bt_start_to_Click(object sender, EventArgs e)
        {
            try
            {              
                    bt_order_detali.Visible = true;
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Start_Service_TO";
                    cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
                    cmd.Parameters.AddWithValue("@car_id", dgv_my_service.Rows[0].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@date_start", DateTime.Now);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Время начала работы зафиксировано");
                    bt_start_to.Visible = false;

                    SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connect.Open();
                    SqlCommand cmdd = new SqlCommand($"SELECT TOP 1 CodeService FROM [Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value} ORDER BY DateStart DESC", connect);
                    SqlDataReader reader = cmdd.ExecuteReader();
                    if (reader.Read())
                    {
                        Properties.Settings.Default.CodeService = reader.GetString(0);
                        Properties.Settings.Default.Save();
                    }
                    connect.Close();

                    SqlConnection connectwpl = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connectwpl.Open();
                    SqlCommand cmdd123 = new SqlCommand($"SELECT ServiceID FROM [Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value}", connectwpl);
                    SqlDataReader reader123 = cmdd123.ExecuteReader();
                    if (reader123.Read())
                    {
                        Properties.Settings.Default.service_id = reader123.GetInt32(0);
                        Properties.Settings.Default.Save();
                    }
                    connectwpl.Close();
                    bt_end_to.Visible = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void bt_order_detali_Click(object sender, EventArgs e)
        {
            BDetali frm_detali = new BDetali();
            frm_detali.ShowDialog();
            Properties.Settings.Default.VIN2 = Convert.ToString(dgv_my_service.Rows[0].Cells[5].Value);
            Properties.Settings.Default.Save();
        }

        private void bt_end_to_Click(object sender, EventArgs e)
        {
            try
            {
                if (panel2.Visible == false)
                {
                    if (checkBox1.Checked == false || checkBox2.Checked == false || checkBox3.Checked == false || checkBox4.Checked == false)
                    {
                        MessageBox.Show("Вы не выполнили минимальные тербовния по работе!");
                    }
                    else
                    {
                        end_detail_info frm_info = new end_detail_info();
                        frm_info.ShowDialog();
                        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "End_Service_TO";
                        cmd.Parameters.AddWithValue("@cost", Properties.Settings.Default.servise_cost);
                        cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
                        MessageBox.Show(Properties.Settings.Default.CodeService);
                        cmd.Parameters.AddWithValue("@CodeService", Properties.Settings.Default.CodeService);
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        connect.Open();
                        SqlCommand cmdd = new SqlCommand($"SELECT DateEnd FROM[Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value}", connect);
                        SqlDataReader reader = cmdd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            bt_end_service.Visible = false;
                        }
                        else
                        {
                            bt_end_service.Visible = true;
                        }

                        SqlConnection conn45 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        SqlCommand cmd45 = new SqlCommand();
                        conn45.Open();
                        cmd45.CommandType = CommandType.StoredProcedure;
                        cmd45.CommandText = "Removing_machine";
                        cmd45.Parameters.AddWithValue("@car_id", Convert.ToInt32(dgv_my_service.Rows[0].Cells[0].Value));
                        cmd45.Connection = conn45;
                        cmd45.ExecuteNonQuery();
                        conn45.Close();
                        MessageBox.Show("Спасибо за вашу работу. \n Время конца работы сохраненно. \n Все работы на данном автомобиле закончены.\n Можете брать другое авто в работу!");

                        panel3.Visible = false;
                        List_My_Services();

                    }
                }
                else
                {
                    if (checkBox1.Checked == false || checkBox2.Checked == false || checkBox3.Checked == false || checkBox4.Checked == false)
                    {
                        MessageBox.Show("Вы не выполнили минимальные тербовния по работе!");
                    }
                    else
                    {
                        end_detail_info frm_info = new end_detail_info();
                        frm_info.ShowDialog();
                        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "End_Service_TO";
                        cmd.Parameters.AddWithValue("@cost", Properties.Settings.Default.servise_cost);
                        cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CodeService", Properties.Settings.Default.CodeService);
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Спасибо за вашу работу. \n Время конца работы сохраненно");


                        SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        connect.Open();
                        SqlCommand cmdd = new SqlCommand($"SELECT DateEnd FROM[Service] WHERE UserID = {Properties.Settings.Default.user_id} AND CareID = {dgv_my_service.Rows[0].Cells[0].Value}", connect);
                        SqlDataReader reader = cmdd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            bt_end_service.Visible = false;
                        }
                        else
                        {
                            bt_end_service.Visible = true;
                        }

                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка",ex.Message);
            }
        }

        private void bt_Choose_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection c = new SqlConnection(Properties.Settings.Default.ConnectionString);
                c.Open();
                SqlCommand cc = new SqlCommand($"SELECT UserID FROM Care WHERE UserID = {Properties.Settings.Default.user_id}", c);
                SqlDataReader r = cc.ExecuteReader();
                if (r.HasRows)
                {
                    MessageBox.Show("За вами уже закреплена машина");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Assigning_Car_Master";
                    cmd.Parameters.AddWithValue("@car_id", Convert.ToInt32(dgw_all_services.CurrentRow.Cells[0].Value));
                    cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Машина успешно закреплена за вами");

                    List_All_Services();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("ERORR", ex.Message);
            }
        }


    }
}
