using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_arendacar.Forms
{
    public partial class end_detail_info : Form
    {
        public end_detail_info()
        {
            InitializeComponent();
        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void end_detail_info_Load(object sender, EventArgs e)
        {

        }

        private void bt_end_deteling_Click(object sender, EventArgs e)
        {
            if(tb_detail_cost.Text == "")
            {
                MessageBox.Show("Вы не указали цену!");
            }
            else
            {
                Properties.Settings.Default.servise_cost = Convert.ToInt32(tb_detail_cost.Text);
                this.Close();
            }

        }

        private void tb_detail_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
