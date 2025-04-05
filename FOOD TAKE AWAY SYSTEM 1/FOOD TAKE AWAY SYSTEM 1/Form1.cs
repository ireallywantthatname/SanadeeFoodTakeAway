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

namespace FOOD_TAKE_AWAY_SYSTEM_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Akash\projects\SanadeeFoodTakeAway\FOOD TAKE AWAY SYSTEM 1\FOOD TAKE AWAY SYSTEM 1\Database1.mdf;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Refresh Button Code
            con.Open();
  
            SqlDataAdapter data=new SqlDataAdapter(@"SELECT*FROM customers",con);

            DataTable t=new DataTable();

            dataGridView1.DataSource=t;

            data.Fill(t);

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MDIParent1 m=new MDIParent1();
            m.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button Code
            con.Open();
            string no = textBox1.Text;
            string name = textBox2.Text;
            string address = textBox3.Text;
            string town = textBox4.Text;
            string contact = textBox5.Text;
            string nic = textBox6.Text;
            string email = textBox7.Text;

            string sql_insert = "INSERT INTO customers(no,name,address,town,contact,nic,email)VALUES('"+no+"','"+name+"','"+address+"','"+town+"','"+contact+"','"+nic+"','"+email+"')";

            SqlCommand cmd = new SqlCommand(sql_insert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search Button Code
            con.Open();
            string no=textBox1.Text;

            string Sql_search="SELECT* FROM customers WHERE NO='"+ no +"'";

            SqlCommand cmd=new SqlCommand(Sql_search,con);

            SqlDataReader r=cmd.ExecuteReader();

            if(r.Read())
            {
               textBox2.Text=r[1].ToString();
               textBox3.Text=r[2].ToString();
               textBox4.Text=r[3].ToString();
               textBox5.Text=r[4].ToString();
               MessageBox.Show("Found Successfully");
            } 
            else
            {
               textBox2.Text=null;
               textBox3.Text=null;
               textBox4.Text=null;
               textBox5.Text=null;
               MessageBox.Show("NOT Found");
            }

            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
        //Update Button Code
        con.Open();
        string no=textBox1.Text;
        string name=textBox2.Text;
        string address=textBox3.Text;
        string town=textBox4.Text;
        string contact=textBox5.Text;
        string nic=textBox6.Text;
        string email=textBox7.Text;

        string sql_update="update customers set name='"+name+"',ADDRESS='"+address+"',TOWN='"+town+"',CONTACT='"+contact+"',NIC='"+nic+"',EMAIL='"+email+"'WHERE NO='"+no+"'";

        SqlCommand cmd = new SqlCommand(sql_update,con);
        
        cmd.ExecuteNonQuery();
        //Successfull Message after the execution

        MessageBox.Show("Updated Sucessfully!");

        con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
        //Delete button Code
          con.Open();

          string no=textBox1.Text;

          string sql_delete = "DELETE FROM customers WHERE NO='"+no+"'";

          SqlCommand cmd = new SqlCommand(sql_delete, con);

          cmd.ExecuteNonQuery();
          

          MessageBox.Show("Deleted Successfully");

          con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
