using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Diplom_arendacar.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            GetSettings();
        }
        SqlConnection connect = new SqlConnection(Properties.Settings.Default.ConnectionString);

        int cntr = 0;

        private void GetSettings()
        {
            tb_number.Text = Properties.Settings.Default.Save_number;
            tb_password_maine.Text = Properties.Settings.Default.Save_password;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save_number = tb_number.Text;
            Properties.Settings.Default.Save_password = tb_password_maine.Text;
            Properties.Settings.Default.Save();
        }

        private void bt_authorization_Click_1(object sender, EventArgs e)
        {
            string number = (tb_number.Text);
            string password = (tb_password_maine.Text);
            try
            {
                if (number == "")
                {
                    MessageBox.Show("Вы не заполнили поле номер");
                }
                else if (password == "")
                {
                    MessageBox.Show("Вы не заполнили поле пароль");
                }
                else
                {

                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Entrance";
                    cmd.Parameters.AddWithValue("@number", tb_number.Text);
                    cmd.Parameters.AddWithValue("@password", tb_password_maine.Text);
                    cmd.Connection = connect;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {

                            int id_user = reader.GetInt32(0);
                            Properties.Settings.Default.user_id = id_user;
                            int role_user = reader.GetInt32(1);

                            if (role_user == 5)
                            {
                                MessageBox.Show("Вам ограничили доступ к приложению");
                            }
                            else
                            {
                                Properties.Settings.Default.role_id = role_user;
                                CaphcaForm frmCaphca = new CaphcaForm();
                                frmCaphca.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден");
                            cntr++;
                            if (cntr == 3)
                            {
                                MessageBox.Show("Слишком много попыток входа. Повторите через 10 секунд!");
                                tb_number.Enabled = false;
                                tb_password_maine.Enabled = false;
                                bt_authorization.Enabled = false;
                                timer1.Enabled = true;
                                cntr = 0;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка подключения:  ", ex.Message);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка :  ", ex.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();

            }
        }

        private void AuthorizationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            tb_password_maine.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            RegistrationForm frm_Avtoreg1 = new RegistrationForm();
            frm_Avtoreg1.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                tb_password_maine.UseSystemPasswordChar = false;
            }
            else
            {
                tb_password_maine.UseSystemPasswordChar = true;
            }
        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Properties.Settings.Default.role_id = 5;
            CaphcaForm frmCaphca = new CaphcaForm();
            frmCaphca.Show();
            this.Hide();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            bt_authorization.Enabled = true;
            tb_number.Enabled = true;
            tb_password_maine.Enabled = true;
            timer1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
            GetSettings();
        }
    }    
}
