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

namespace Diplom_arendacar.Forms.Administrator
{
    public partial class new_number : Form
    {
        public new_number()
        {
            InitializeComponent();
        }


        private void bt_change_number_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.user_number = tb_number.Text;
            this.Close();
        }

        private void new_number_Load(object sender, EventArgs e)
        {

        }
    }
}
