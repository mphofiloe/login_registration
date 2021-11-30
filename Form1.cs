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
using System.Text.RegularExpressions;

namespace registratiom_login
{
    public partial class Form1 : Form

    {
        public Form1()
        {

            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source =.; Initial Catalog = project; Integrated Security = True");
        string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")




            {
                MessageBox.Show("Enter all fields");
            }
            else if (textBox4.Text != textBox5.Text)
            {



                MessageBox.Show("Password and Confirm_Password are not the same");



            }






            else if (Regex.IsMatch(textBox2.Text, pattern))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Register]
([FirstName],[Email],[UserName],[Password],[ConfirmPassword])VALUES
('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')", conn);



                cmd.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully");
                this.Hide();
                Login nn = new Login();
                nn.Show();
            }
            else
            {
                MessageBox.Show("The Email you have entered is incorrect, please try again");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login mm = new Login(); 
            mm.Show();  
        }
    }
}
