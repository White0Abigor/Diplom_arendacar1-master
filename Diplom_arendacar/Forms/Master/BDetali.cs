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

namespace Diplom_arendacar.Forms.Master
{
    public partial class BDetali : Form
    {
        public BDetali()
        {
            InitializeComponent();
        }

        class color
        {
            public string name { get; set; }
            public int id { get; set; }


            public color(int id, string nm, int c)
            {
                this.id = id;
                this.name = nm;

            }
        }

        class detli
        {
            public int count { get; set; }
            public int id { get; set; }

            public string name { get; set; }

            public detli(int id, string nm ,int ct)
            {
                this.id = id;
                this.name= nm;
                this.count = ct;

            }
        }
        List<detli> lst = new List<detli>();

        class color1
        {
            public string name { get; set; }
            public int id { get; set; }

            public int count { get; set; }


            public color1(int id, string nm, int c)
            {
                this.id = id;
                this.name = nm;
                this.count = c;
            }
        }

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand cmd = new SqlCommand();
        private void BDetali_Load(object sender, EventArgs e)
        {
            dgw_basket.Columns.Add("detl_id", "detal");
            dgw_basket.Columns.Add("detl_name", "Детали");
            dgw_basket.Columns.Add("detl_count", "Количество");
            dgw_basket.Columns[0].Visible = false;

            conn.Open();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "list_detali";
            cmd.Connection= conn;
            SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable(); 
                dt.Load(reader);
                dgw_list_detali.DataSource= dt;

            conn.Close();

            dgw_list_detali.Columns[0].Visible = false;


        }

        private void dgw_list_detali_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn clm = new DataGridViewColumn();
            clm.Name = "name";
            clm.HeaderText = "HeaderText";
            clm.Visible = false;


            int r = dgw_basket.Rows.Add();
            dgw_basket.Rows[r].Cells[0].Value = dgw_list_detali.CurrentRow.Cells[0].Value;
            dgw_basket.Rows[r].Cells[1].Value = dgw_list_detali.CurrentRow.Cells[1].Value;
            dgw_basket.Rows[r].Cells[2].Value = 1;
        }



        private void bt_remove_product_Click(object sender, EventArgs e)
        {
            if (dgw_basket.CurrentRow.Cells[0].Value.ToString() == "")
            {
                MessageBox.Show("Вы не выбрали товар для удаления");
            }
            else
            {
                int delt = dgw_basket.CurrentRow.Index;
                int delet = dgw_basket.SelectedCells[0].RowIndex;
                dgw_basket.Rows.RemoveAt(delt);
            }
        }

        private void bt_order_product_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"", Convert.ToString(Convert.ToInt32(dgw_basket.Rows[0].Cells[0].Value)));

            if (dgw_basket.Rows.Count == 0)
            {
                MessageBox.Show("Корзина пуста, чтобы заказать товар наполните корзину!");
            }
            else
            {
                for (int i = 0; i < dgw_basket.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < dgw_basket.Columns.Count - 1; j++)
                    {
                        lst.Add(new detli((Convert.ToInt32(dgw_basket.Rows[i].Cells[j-1].Value)), (Convert.ToString(dgw_basket.Rows[i].Cells[j].Value)), (Convert.ToInt32(dgw_basket.Rows[i].Cells[j+1].Value))));

                        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
                        SqlCommand cmd = new SqlCommand();
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Ordering_parts";
                        cmd.Parameters.AddWithValue("@service_id", Properties.Settings.Default.service_id);
                        cmd.Parameters.AddWithValue("@detali_id", Convert.ToInt32(dgw_basket.Rows[i].Cells[j - 1].Value));
                        cmd.Parameters.AddWithValue("@detali_count", Convert.ToInt32(dgw_basket.Rows[i].Cells[j + 1].Value));
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        
                    }
                }
                PDF_Contract();
                this.Close();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(dgw_basket.CurrentRow) == "")
            {
                MessageBox.Show("Вы не выбрали товар для изменения количесвто");
            }
            else
            {
                dgw_basket.CurrentRow.Cells[2].Value = numericUpDown1.Value;

                if(Convert.ToInt32(dgw_basket.CurrentRow.Cells[2].Value) == 0)
                {
                    int delt = dgw_basket.CurrentRow.Index;
                    int delet = dgw_basket.SelectedCells[0].RowIndex;
                    dgw_basket.Rows.RemoveAt(delt);
                }
            }
        }

        private void dgw_basket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(dgw_basket.CurrentRow.Cells[2].Value);
        }

        void PDF_Contract()
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString);
            /// Путь по которому он будет создан
            string pp = Properties.Settings.Default.order_number;
            string outputPath = "";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.FileName = $" Заказ деталей {pp}";
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
            PdfPTable car = new PdfPTable(new float[] { 50f, 50f, });
            PdfPTable car_info = new PdfPTable(new float[] { 50f, 50f, });

            //уменьшим размер таблицы до 60% от страницы
            car.WidthPercentage = 90;
            car_info.WidthPercentage = 90;

            //заголовок. Выравнивается по центру
            Paragraph t = new Paragraph($"Заявка на заказ деталей \n", font);
            t.Alignment = Element.ALIGN_CENTER;
            doc.Add(t);

            //дополнительный отступ
            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "Greeting";
            cmd1.Parameters.AddWithValue("@user_id", Properties.Settings.Default.user_id);
            cmd1.Connection = conn;
            SqlDataReader rd1 = cmd1.ExecuteReader();
            while (rd1.Read())
            {
                Paragraph pop = new Paragraph($"Я мастер:  {rd1.GetString(0)} {rd1.GetString(1)} {rd1.GetString(2)} \n Прошу заказать перечень ниже указаных детелей, в указаном количестве: \n", font);
                pop.Alignment = Element.ALIGN_CENTER;
                doc.Add(pop);
            }
            conn.Close();

            t = new Paragraph("\n", font);
            doc.Add(t);

            Paragraph vin = new Paragraph($"Вин номер для заказа:  {Convert.ToString(Properties.Settings.Default.VIN2)}  \n", font);
            vin.Alignment = Element.ALIGN_CENTER;
            doc.Add(vin);

            t = new Paragraph("\n", font);
            doc.Add(t);

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Detali_PDF";
            cmd.Parameters.AddWithValue("@service_id", Properties.Settings.Default.service_id);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                PdfPCell cell1 = new PdfPCell(new Paragraph(rdr.GetString(0), font));
                car_info.AddCell(cell1);

                PdfPCell cell2 = new PdfPCell(new Paragraph(Convert.ToString(rdr.GetInt32(1)), font));
                car_info.AddCell(cell2);
            }
            conn.Close();
            /// Заполняеим оглавление таблицы
            car.AddCell(new Paragraph("Название", font));
            car.AddCell(new Paragraph("КОличество", font));

            //добавить написанную таблицу в документ
            doc.Add(car);
            doc.Add(car_info);

            //не забываем закрывать, иначе не откроется
            doc.Close();
            writer.Close();


            MessageBox.Show(" Заявка успешно сохранена  ");


        }
    }
}
