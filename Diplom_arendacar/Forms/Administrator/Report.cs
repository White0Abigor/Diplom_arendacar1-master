using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Org.BouncyCastle.Asn1.X500;

namespace Diplom_arendacar.Forms.Administrator
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_car1.DataSource = dt;
            conn.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@date_end", dateTimePicker2.Value);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_car1.DataSource = dt;
            conn.Close();
        }

        private void bt_report_one_year_Click(object sender, EventArgs e)
        {           
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", DateTime.Now.AddYears(-1));
            cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_car1.DataSource = dt;
            conn.Close();

            dateTimePicker1.Value = DateTime.Now.AddYears(-1);

        }

        private void bt_report_six_months_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", DateTime.Now.AddMonths(-6));
            cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_car1.DataSource = dt;
            conn.Close();

            dateTimePicker1.Value = DateTime.Now.AddMonths(-6);
        }

        private void bt_report_three_months_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();

            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", DateTime.Now.AddMonths(3));
            cmd.Parameters.AddWithValue("@date_end", DateTime.Now);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            dgw_car1.DataSource = dt;
            conn.Close();

            dateTimePicker1.Value = DateTime.Now.AddMonths(-3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddHours(-1);
            dateTimePicker1.Value = DateTime.Now.AddHours(-1);
        }

        private void bt_report_pdf_Click(object sender, EventArgs e)
        {
            PDF_Contract();
        }
        void PDF_Contract()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            /// Путь по которому он будет создан
            string pp = Properties.Settings.Default.order_number;
            string outputPath = "";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = $"Отчёт по аренде {pp}";
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
            PdfPTable car = new PdfPTable(new float[] { 24f, 8f, 9f, 25f, 10f, 12f, 12f, }); ///9
            PdfPTable car_info = new PdfPTable(new float[] { 8f, 8f, 8f, 8f, 9f, 25f, 10f, 12f, 12f, });  ///9

            //уменьшим размер таблицы до 60% от страницы
            car.WidthPercentage = 110;
            car_info.WidthPercentage = 110;

            //заголовок. Выравнивается по центру
            Paragraph t = new Paragraph($"«ООО Аренда АВТО» \n", font);
            t.Alignment = Element.ALIGN_CENTER;
            doc.Add(t);

            t = new Paragraph("\n", font);
            doc.Add(t);

            Paragraph tее = new Paragraph($"Отчёт по аренде \n", font);
            tее.Alignment = Element.ALIGN_CENTER;
            doc.Add(tее);

            //дополнительный отступ
            t = new Paragraph("\n", font);
            doc.Add(t);

            Paragraph pop = new Paragraph($" С {dateTimePicker1.Value} по {dateTimePicker2.Value} ", font);
            pop.Alignment = Element.ALIGN_CENTER;
            doc.Add(pop);

            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "report";
            cmd.Parameters.AddWithValue("@date_start", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@date_end", dateTimePicker2.Value);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PdfPCell cell1 = new PdfPCell(new Paragraph(rdr.GetString(0), font));
                car_info.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Paragraph(rdr.GetString(1), font));
                car_info.AddCell(cell2);

                PdfPCell cell3 = new PdfPCell(new Paragraph(rdr.GetString(2), font));
                car_info.AddCell(cell3);

                PdfPCell cell4 = new PdfPCell(new Paragraph(rdr.GetString(3), font)); /// brend
                car_info.AddCell(cell4);

                PdfPCell cell5 = new PdfPCell(new Paragraph(rdr.GetString(4), font)); /// model
                car_info.AddCell(cell5);

                PdfPCell cell6 = new PdfPCell(new Paragraph(rdr.GetString(5), font)); /// VIN
                car_info.AddCell(cell6);

                PdfPCell cell7 = new PdfPCell(new Paragraph($"{Convert.ToString(rdr.GetInt32(6))} рублей", font)); /// сумма
                car_info.AddCell(cell7);

                PdfPCell cell8 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(7)), font)); ///Дата начала
                car_info.AddCell(cell8);

                PdfPCell cell9 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(8)), font)); ///Дата конца 
                car_info.AddCell(cell9);

            }
            cmd.Connection = conn;
            conn.Close();
            /// Заполняеим оглавление таблицы
            car.AddCell(new Paragraph("ФИО", font));
            car.AddCell(new Paragraph("Бренд", font));
            car.AddCell(new Paragraph("Модель", font));
            car.AddCell(new Paragraph("VIN-номер", font));
            car.AddCell(new Paragraph("Сумма", font));
            car.AddCell(new Paragraph("Дата начала аренды ", font));
            car.AddCell(new Paragraph("Дата конца аренды ", font));

            // (cell)HorizontalAlignment = Element.ALIGN_CENTER; /// центрирование ячейки

            PdfContentByte cb = writer.DirectContent;
            PdfContentByte cb1 = writer.DirectContent;

            //добавить написанную таблицу в документ
            doc.Add(car);
            doc.Add(car_info);

            //не забываем закрывать, иначе не откроется
            doc.Close();
            writer.Close();


            MessageBox.Show("Отчёт успешно сохранён");

        }

        private void bt_exite_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
