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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@" Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Akash\projects\SanadeeFoodTakeAway\FOOD TAKE AWAY SYSTEM 1\FOOD TAKE AWAY SYSTEM 1\Database1.mdf;Integrated Security=True");
        

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search Button Code
            con.Open();
            string orderNo = textBox1.Text;

            string Sql_search = "SELECT* FROM Ab WHERE ORDERNO='" + orderNo + "'";

            SqlCommand cmd = new SqlCommand(Sql_search, con);

            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                textBox2.Text = r[1].ToString();
                textBox3.Text = r[2].ToString();
                textBox4.Text = r[3].ToString();
                textBox5.Text = r[4].ToString();
                comboBox1.Text = r[5].ToString();
                numericUpDown1.Text = r[6].ToString();
                textBox6.Text = r[7].ToString();
                MessageBox.Show("Found Successfully");
            }
            else
            {
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                comboBox1.Text = null;
                numericUpDown1.Text = null;
                textBox6.Text = null;
                MessageBox.Show("NOT Found");
            }

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button Code
            con.Open();
            string orderNo = textBox1.Text;
            string date = textBox2.Text;
            string customerName= textBox3.Text;
            string contact = textBox4.Text;
            string foodName = textBox5.Text;
            string foodType = comboBox1.Text;
            string quantity = numericUpDown1.Text;
            string price = textBox6.Text;

            string sql_insert = "INSERT INTO Ab(orderNo,date,customerName,contact,foodName,foodType,quantity,price)VALUES('" + orderNo + "','" + date + "','" + customerName + "','" + contact + "','" + foodName + "','" + foodType + "','" + quantity + "','" + price + "')";

            SqlCommand cmd = new SqlCommand(sql_insert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //Update Button Code
            con.Open();
            string orderNo = textBox1.Text;
            string date = textBox2.Text;
            string customerName = textBox3.Text;
            string contact = textBox4.Text;
            string foodName = textBox5.Text;
            string foodType = comboBox1.Text;
            string quantity = numericUpDown1.Text;
            string price = textBox6.Text;

            string sql_update = "update Ab set date='" + date + "',customerName='" + customerName + "',contact='" + contact  + "',foodType='" + foodType + "',quantity='"+quantity+"',price='"+price+"'WHERE ORDERNO='" + orderNo + "'";

            SqlCommand cmd = new SqlCommand(sql_update, con);

            cmd.ExecuteNonQuery();
            //Successfull Message after the execution

            MessageBox.Show("Updated Sucessfully!");

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //Delete button Code
          con.Open();

          string orderNo=textBox1.Text;

          string sql_delete = "DELETE FROM Ab WHERE ORDERNO='"+orderNo+"'";

          SqlCommand cmd = new SqlCommand(sql_delete, con);

          cmd.ExecuteNonQuery();

          MessageBox.Show("Deleted Successfully");

          con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //Refresh Button Code
            con.Open();
  
            SqlDataAdapter data=new SqlDataAdapter(@"SELECT*FROM Ab",con);

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
    }
}
