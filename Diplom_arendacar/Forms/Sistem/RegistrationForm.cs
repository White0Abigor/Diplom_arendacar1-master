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
using Diplom_arendacar.Forms;
using System.Net;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Org.BouncyCastle.Crypto.Tls;

namespace Diplom_arendacar
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void bt_registration_Click(object sender, EventArgs e)
        {
            string name = tb_name.Text.Trim();
            string surname = tb_surname.Text.Trim();
            string patronymic = tb_patronymic.Text.Trim();
            string number = tb_number.Text.Trim();
            string passwordmaine = tb_password_maine.Text.Trim();
            string password = tb_password.Text.Trim();

            if (tb_name.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле имя");
            }
            else if(tb_surname.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле фамилия");
            }
            else if (tb_patronymic.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле отчество");
            }
            else if (tb_number.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле телефон");
            }
            else if (tb_number.TextLength < 11)
            {
                MessageBox.Show("Длина номера минимум 11 цифр");
            }
            else if (tb_password_maine.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле пароль");
            }
            else if (tb_password.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле повторный пароль");
            } 
            else
            {
                if (passwordmaine != password)
                {
                    MessageBox.Show("Введенные пароли не совподают");
                }
                else
                {

                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
                    connection.Open();
                    string cmd = $"SELECT Number FROM [User] WHERE Number='{number}'";
                    SqlCommand sqlCommand = new SqlCommand(cmd, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


                    sqlDataReader.Read();
                    if (sqlDataReader.HasRows)
                    {
                        MessageBox.Show("Пользователь с таким номером уже существует!");
                        connection.Close();
                    }
                    else
                    {
                        sqlDataReader.Close();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "AddClient";
                        sqlCommand.Parameters.AddWithValue("@name", name);
                        sqlCommand.Parameters.AddWithValue("@surname", surname);
                        sqlCommand.Parameters.AddWithValue("@patronymic", patronymic);
                        sqlCommand.Parameters.AddWithValue("@number", number);
                        sqlCommand.Parameters.AddWithValue("@password", password);
                        sqlCommand.Connection = connection;
                        sqlCommand.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Вы успешно зарегистрировались!");
                        AuthorizationForm authForm1 = new AuthorizationForm();
                        authForm1.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthorizationForm authForm1 = new AuthorizationForm();
            authForm1.Show();
            this.Hide();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

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

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}
