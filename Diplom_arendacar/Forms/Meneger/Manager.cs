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
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using System.Globalization;

namespace Diplom_arendacar.Forms
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }
        int p;
        private void Manager_Load(object sender, EventArgs e)
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

            SqlConnection cmd = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand command = new SqlCommand();


            cmd.Open();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "list_Order";
            command.Connection = cmd;
            using(SqlDataReader red = command.ExecuteReader())
            {
                var datatabel = new DataTable();
                datatabel.Load(red);
                dgw_order_klinet_list.DataSource= datatabel;
            }
            dgw_order_klinet_list.Columns[0].Visible = false;
            dgw_order_klinet_list.Columns[1].Visible = false;
            dgw_order_klinet_list.Columns[2].Visible = false;

            cmd.Close();
            
            SqlConnection cmd1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "list_order2";
            command1.Connection = cmd1;
            using(SqlDataReader red2 = command1.ExecuteReader())
            {
                var datatabel1 = new DataTable();
                datatabel1.Load(red2);
                dgw_list_car_pinat.DataSource= datatabel1;
            }
            dgw_list_car_pinat.Columns[0].Visible = false;
            dgw_list_car_pinat.Columns[1].Visible = false;
            dgw_list_car_pinat.Columns[2].Visible = false;

            cmd1.Close();
            

            //// Отоброжение инециалов юсера
            SqlConnection connу = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connу.Open();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "inicialu";
            sqlCommand1.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
            sqlCommand1.Connection = connу;
            SqlDataReader reading1 = sqlCommand1.ExecuteReader();
            while (reading1.Read())
            {
                label3.Text = reading1.GetString(0);
                label4.Text = reading1.GetString(1);
            }
            connу.Close();


        }



        private void dgw_order_klinet_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection connу1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            connу1.Open();
            SqlCommand sqlCommand11 = new SqlCommand();
            sqlCommand11.CommandType = CommandType.StoredProcedure;
            sqlCommand11.CommandText = "inicialu";
            sqlCommand11.Parameters.AddWithValue("@user_id", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[1].Value.ToString()));
            sqlCommand11.Connection = connу1;
            SqlDataReader reading11 = sqlCommand11.ExecuteReader();
            while (reading11.Read())
            {
                lbl_Name_Klient.Visible = true;
                lbl_Surname_Klient.Visible = true;
                lbl_Patronymic_Klient.Visible = true;
                lbl_Phone_Klient.Visible = true;

                lbl_Name_Klient.Text = reading11.GetString(0);
                lbl_Surname_Klient.Text = reading11.GetString(1);
                lbl_Patronymic_Klient.Text = reading11.GetString(2);
                lbl_Phone_Klient.Text = reading11.GetString(3);
            }
            connу1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           MessageBox.Show("В данный момент эта функция не возможна");
        }


        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection connу21 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                connу21.Open();
                SqlCommand sqlCommand112 = new SqlCommand();
                sqlCommand112.CommandType = CommandType.StoredProcedure;
                sqlCommand112.CommandText = "Update_Status_Order";
                sqlCommand112.Parameters.AddWithValue("@order_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[0].Value.ToString()));
                sqlCommand112.Parameters.AddWithValue("@care_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[2].Value.ToString()));
                sqlCommand112.Connection = connу21;
                sqlCommand112.ExecuteNonQuery();
                connу21.Close();
                MessageBox.Show("Заявка успешно обработана");

            Properties.Settings.Default.car_id = Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[2].Value.ToString());
            Properties.Settings.Default.order_id = Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[0].Value.ToString());
            Properties.Settings.Default.order_number =  dgw_order_klinet_list.CurrentRow.Cells[3].Value.ToString();

            SqlConnection cmd23 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                cmd23.Open();
                SqlCommand command23 = new SqlCommand();
                command23.CommandType = CommandType.StoredProcedure;
                command23.CommandText = "list_Order";
                command23.Connection = cmd23;
                using (SqlDataReader red23 = command23.ExecuteReader())
                {
                    var datatabel23 = new DataTable();
                    datatabel23.Load(red23);
                    dgw_order_klinet_list.DataSource = datatabel23;
                }
                dgw_order_klinet_list.Columns[0].Visible = false;
                dgw_order_klinet_list.Columns[1].Visible = false;
                dgw_order_klinet_list.Columns[2].Visible = false;
                cmd23.Close();
                PDF_Contract();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.car_id = Convert.ToInt32(dgw_list_car_pinat.CurrentRow.Cells[2].Value.ToString());
            Properties.Settings.Default.order_id = Convert.ToInt32(dgw_list_car_pinat.CurrentRow.Cells[0].Value.ToString());
            AcceptanceForm form = new AcceptanceForm();
            form.ShowDialog();

            SqlConnection cmd23 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd23.Open();
            SqlCommand command23 = new SqlCommand();
            command23.CommandType = CommandType.StoredProcedure;
            command23.CommandText = "list_Order";
            command23.Connection = cmd23;
            using (SqlDataReader red23 = command23.ExecuteReader())
            {
                var datatabel23 = new DataTable();
                datatabel23.Load(red23);
                dgw_order_klinet_list.DataSource = datatabel23;
            }
            dgw_order_klinet_list.Columns[0].Visible = false;
            dgw_order_klinet_list.Columns[1].Visible = false;
            dgw_order_klinet_list.Columns[2].Visible = false;
            cmd23.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(dgw_order_klinet_list.CurrentRow.Cells[9].Value) == "Обрабатываеться")
            {
                MessageBox.Show("Нельзя выдать не обработануую машину!");
            }
            else
            {
                SqlConnection connу121 = new SqlConnection(Properties.Settings.Default.ConnectionString);
                connу121.Open();
                SqlCommand sqlCommand1122 = new SqlCommand();
                sqlCommand1122.CommandType = CommandType.StoredProcedure;
                sqlCommand1122.CommandText = "Update_Status_Order2";
                sqlCommand1122.Parameters.AddWithValue("@order_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[0].Value.ToString()));
                sqlCommand1122.Parameters.AddWithValue("@care_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[2].Value.ToString()));
                sqlCommand1122.Connection = connу121;
                sqlCommand1122.ExecuteNonQuery();
                connу121.Close();

                MessageBox.Show("Машина выдана клиенту");
            }

            SqlConnection cmd23 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            cmd23.Open();
            SqlCommand command23 = new SqlCommand();
            command23.CommandType = CommandType.StoredProcedure;
            command23.CommandText = "list_Order";
            command23.Connection = cmd23;
            using (SqlDataReader red23 = command23.ExecuteReader())
            {
                var datatabel23 = new DataTable();
                datatabel23.Load(red23);
                dgw_order_klinet_list.DataSource = datatabel23;
            }
            dgw_order_klinet_list.Columns[0].Visible = false;
            dgw_order_klinet_list.Columns[1].Visible = false;
            dgw_order_klinet_list.Columns[2].Visible = false;

            cmd23.Close();

            SqlConnection cmd1 = new SqlConnection(Properties.Settings.Default.ConnectionString);

            cmd1.Open();
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "list_order2";
            command1.Connection = cmd1;
            using (SqlDataReader red2 = command1.ExecuteReader())
            {
                var datatabel1 = new DataTable();
                datatabel1.Load(red2);
                dgw_list_car_pinat.DataSource = datatabel1;
            }
            dgw_list_car_pinat.Columns[0].Visible = false;
            dgw_list_car_pinat.Columns[1].Visible = false;
            dgw_list_car_pinat.Columns[2].Visible = false;

            cmd1.Close();

        }

        public void PDF_Contract()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            /// Путь по которому он будет создан
            string pp = Properties.Settings.Default.order_number;
            string outputPath = "";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = $"Договор по заявке {pp}";
            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)

                outputPath = saveFileDialog1.FileName;
            else
                return;
            /// Создание документа
            Document doc = new Document();
            //объект для записи
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(outputPath, FileMode.Create));

            doc.Open();

            //добавляем шрифт, без него кирилица не отобразится
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL);

            //таблица из двух колонок, одна займёт 88% процентов ширины, вторая 12%
            PdfPTable car = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, });
            PdfPTable car_info = new PdfPTable(new float[] { 20f, 20f, 20f, 20f, 20f, });

            //уменьшим размер таблицы до 60% от страницы
            car.WidthPercentage = 90;
            car_info.WidthPercentage = 90;

            //заголовок. Выравнивается по центру
            Paragraph t = new Paragraph($"ДОГОВОР АРЕНДЫ \n", font);
            t.Alignment = Element.ALIGN_CENTER;
            doc.Add(t);

            //дополнительный отступ
            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "user_for_pdf";
            cmd1.Parameters.AddWithValue("@order_id", Properties.Settings.Default.order_id);
            cmd1.Connection = conn;
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while(rd1.Read())
            {
                Paragraph pop = new Paragraph($" {rd1.GetString(0)} {rd1.GetString(1)} {rd1.GetString(2)}. В дальнешем арендатор.\n Согласно договору, арендует автомобиль: \n", font);
                pop.Alignment = Element.ALIGN_CENTER;
                doc.Add(pop);
            }
            conn.Close();

            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Contract_PDF";
            cmd.Parameters.AddWithValue("@car_id", Properties.Settings.Default.car_id);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PdfPCell cell1 = new PdfPCell(new Paragraph(rdr.GetString(0), font));
                car_info.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Paragraph(rdr.GetString(1), font));
                car_info.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(2)), font));
                car_info.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(3)), font));
                car_info.AddCell(cell4);

                PdfPCell cell5 = new PdfPCell(new Paragraph($"{Convert.ToString(rdr.GetInt32(4))} рублей", font));
                car_info.AddCell(cell5);

            }
            cmd.Connection = conn;
            conn.Close();
            /// Заполняеим оглавление таблицы
            car.AddCell(new Paragraph("Бренд", font));
            car.AddCell(new Paragraph("Модель", font));
            car.AddCell(new Paragraph("Дата начала аренды ", font));
            car.AddCell(new Paragraph("Дата конца аренды ", font));
            car.AddCell(new Paragraph("Сумма к оплате", font));



            // (cell)HorizontalAlignment = Element.ALIGN_CENTER; /// центрирование ячейки

            PdfContentByte cb = writer.DirectContent;
            PdfContentByte cb1 = writer.DirectContent;

            //добавить написанную таблицу в документ
            doc.Add(car);
            doc.Add(car_info);

            Paragraph ttt = new Paragraph("\n", font);
            doc.Add(ttt);

            /// doc.Add(tabel_coment);  {rd1.GetString(0)} {rd1.GetString(1)} {rd1.GetString(2)}
            /// 
            Paragraph klient = new Paragraph($"Арендатор", font);
            //отступ от левого края для надписи
            klient.IndentationLeft = 290;
            //отступ сверху
            klient.SpacingBefore = 75;

            doc.Add(klient);

            Paragraph Menedger = new Paragraph("«ООО Аренда АВТО»", font);
            //отступ от левого края для надписи
            Menedger.IndentationLeft = 20;
            //отступ сверху
            Menedger.SpacingBefore = -15;

            doc.Add(Menedger);



            //отрисовка линии для подписи
            cb.MoveTo(400, 550);
            cb.LineTo(480, 550);
            cb.Stroke();

            cb1.MoveTo(200, 550);
            cb1.LineTo(280, 550);
            cb1.Stroke();
            
            //не забываем закрывать, иначе не откроется
            doc.Close();
            writer.Close();


            MessageBox.Show(" Договор успешно сохранён  ");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection conect = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conect.Open();
            SqlCommand comand = new SqlCommand();
            comand.CommandType = CommandType.StoredProcedure;
            comand.CommandText = "Abandonment";
            comand.Parameters.AddWithValue("@order_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[0].Value.ToString()));
            comand.Parameters.AddWithValue("@care_ID", Convert.ToInt32(dgw_order_klinet_list.CurrentRow.Cells[2].Value.ToString()));
            comand.Connection = conect;
            comand.ExecuteNonQuery();
            conect.Close();

            MessageBox.Show("Машина выдана клиенту");
            
        }

        private void Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Hide();
        }
    }
    
}
