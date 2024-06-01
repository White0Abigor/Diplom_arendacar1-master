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

namespace Diplom_arendacar.Forms.Klient
{
    public partial class Histori : Form
    {
        public Histori()
        {
            InitializeComponent();
        }

        private void Histori_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            conn.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "histori_klient";
            cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgw_car1.DataSource = dt;
            conn.Close();

        }

        private void bt_exite_Click(object sender, EventArgs e)
        {
            UserProfil frm = new UserProfil();  
            frm.ShowDialog();
            this.Close();
        }

        private void bt_report_pdf_Click(object sender, EventArgs e)
        {
            history_pdf();
        }

        private void Histori_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void history_pdf()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            /// Путь по которому он будет создан

            string outputPath = "";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = $"История аренды";
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
            PdfPTable car = new PdfPTable(new float[] { 16f, 16f, 20f, 16f, 16f, 16f, }); ///9
            PdfPTable car_info = new PdfPTable(new float[] { 16f, 16f, 20f, 16f, 16f, 16f, });  ///9

            //уменьшим размер таблицы до 60% от страницы
            car.WidthPercentage = 110;
            car_info.WidthPercentage = 110;

            //заголовок. Выравнивается по центру
            Paragraph t = new Paragraph($"«ООО Аренда АВТО» \n", font);
            t.Alignment = Element.ALIGN_CENTER;
            doc.Add(t);

            t = new Paragraph("\n", font);
            doc.Add(t);

            Paragraph tее = new Paragraph($"История аренды \n", font);
            tее.Alignment = Element.ALIGN_CENTER;
            doc.Add(tее);

            //дополнительный отступ
            t = new Paragraph("\n", font);
            doc.Add(t);

            SqlConnection conn1 = new SqlConnection(Properties.Settings.Default.ConnectionString);
            conn1.Open();
            SqlCommand cmd23 = new SqlCommand($"SELECT [Name], [Surname], [Patronymic] FROM [User] WHERE [UserID] = {Properties.Settings.Default.user_id}", conn1);
            SqlDataReader r = cmd23.ExecuteReader();
            r.Read();
            Paragraph tееt = new Paragraph($"{r.GetString(0)} {r.GetString(1)} {r.GetString(2)}\n", font);
            tееt.Alignment = Element.ALIGN_CENTER;
            doc.Add(tееt);
            conn1.Close();
            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "history_order_user";
            cmd.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
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
                 
                PdfPCell cell4 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetInt32(3)), font)); /// brend
                car_info.AddCell(cell4);

                PdfPCell cell5 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(4)), font)); /// model
                car_info.AddCell(cell5);

                PdfPCell cell6 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetDateTime(5)), font)); /// VIN
                car_info.AddCell(cell6);

            }
            cmd.Connection = conn;
            conn.Close();
            /// Заполняеим оглавление таблицы
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
    }
}
