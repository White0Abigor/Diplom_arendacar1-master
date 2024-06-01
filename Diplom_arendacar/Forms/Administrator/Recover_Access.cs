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
    public partial class Recover_Access : Form
    {
        public Recover_Access()
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

        private void Recover_Access_Load(object sender, EventArgs e)
        {
            List<worker> lst = new List<worker>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT RoleID, RoleName FROM [Role] WHERE RoleID = 2 OR RoleID = 3 OR RoleID = 1", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

                lst.Add(new worker(rdr.GetInt32(0), rdr.GetString(1)));

            }
            cb_role.DataSource = lst;
            cb_role.ValueMember = "id";
            cb_role.DisplayMember = "name";
            conn.Close();
        }

        private void bt_maine_add_user_Click(object sender, EventArgs e)
        {
          Properties.Settings.Default.role_id2 = Convert.ToInt32(cb_role.SelectedValue);
            MessageBox.Show("Пользователь успешно востановлен в доступе");
            this.Close();
        }
    }
}
