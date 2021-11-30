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

namespace registratiom_login
{
    public partial class Login : Form
    {
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mn = new Form1();
            mn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source =.; Initial Catalog = project; Integrated Security = True");
           
            conn.Open();
            int b = 0;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select [Username],[Password] from Register where Username='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            b = Convert.ToInt32(dt.Rows.Count.ToString()); if (b == 0)
            {
                MessageBox.Show("The Username/password you entered did not match our records. Please try again");
            }
            else
            {
               
                this.Hide();
                main qq = new main();
                qq.Show();
            }
            conn.Close();
            Clear();
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

