using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOOD_TAKE_AWAY_SYSTEM_1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "123"){
            
                MessageBox.Show("Login Success");

                MDIParent1 m = new MDIParent1();
                m.Show();
                this.Hide();
            }
            else{
            
                MessageBox.Show("Login Fail");
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            
        }
    }
}
