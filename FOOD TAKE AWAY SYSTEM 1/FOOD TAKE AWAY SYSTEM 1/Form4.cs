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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@" Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Akash\projects\SanadeeFoodTakeAway\FOOD TAKE AWAY SYSTEM 1\FOOD TAKE AWAY SYSTEM 1\Database1.mdf;Integrated Security=True");
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Refresh Button Code
            con.Open();

            SqlDataAdapter data = new SqlDataAdapter(@"SELECT*FROM PM4", con);

            DataTable t = new DataTable();

            dataGridView1.DataSource = t;

            data.Fill(t);

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search Button Code
            con.Open();
            string orderNo = numericUpDown1.Text;

            string Sql_search = "SELECT * FROM PM4 where CONVERT(VARCHAR, OrderNo) =  '" + orderNo + "'";

            SqlCommand cmd = new SqlCommand(Sql_search, con);

            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                numericUpDown1.Text = r[1].ToString();
                numericUpDown2.Text = r[2].ToString();
                textBox1.Text = r[6].ToString();
                textBox2.Text = r[3].ToString();
                textBox3.Text = r[4].ToString();
                textBox4.Text = r[5].ToString();
                comboBox1.Text = r[6].ToString();
                textBox5.Text = r[7].ToString();
                MessageBox.Show("Found Successfully");
            }
            else
            {
                numericUpDown2.Text = null;
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                comboBox1.Text = null;
                textBox5.Text = null;
                
                MessageBox.Show("NOT Found");
            }

            con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button Code
            con.Open();
            string billNo = numericUpDown1.Text;
            string orderNo = numericUpDown2.Text;
            string date = textBox1.Text;
            string customerName = textBox2.Text;
            string cashierName = textBox3.Text;
            string foodName = textBox4.Text;
            string paymentMethod = comboBox1.Text;
            string price = textBox5.Text;

            string sql_insert = "INSERT INTO PM4 (billNo,orderNo,date,customerName,cashierName,foodName,paymentMethod,price)VALUES('" + billNo + "','" + orderNo + "','" + date + "','" + customerName + "','" + cashierName + "','" + foodName + "','" + paymentMethod + "','" + price + "')";

            SqlCommand cmd = new SqlCommand(sql_insert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");

            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Update Button Code
            con.Open();
            string billNo = numericUpDown1.Text;
            string orderNo = numericUpDown2.Text;
            string date = textBox1.Text;
            string customerName = textBox2.Text;
            string cashierName = textBox3.Text;
            string foodName = textBox4.Text;
            string paymentMethod = comboBox1.Text;
            string price = textBox5.Text;

            string sql_update = "update PM4 set orderNo='" + orderNo + "', date='" + date + "',customerName='" + customerName + "',cashierName='" + cashierName + "',foodName='" + foodName + "',paymentMethod='" + paymentMethod + "',price='" + price + "'WHERE BILLNO='" + billNo + "'";

            SqlCommand cmd = new SqlCommand(sql_update, con);

            cmd.ExecuteNonQuery();
            //Successfull Message after the execution

            MessageBox.Show("Updated Sucessfully!");

            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Delete button Code
            con.Open();

            string orderNo = textBox1.Text;

            string sql_delete = "DELETE FROM PM4 WHERE BILLNO='" + billNo + "'";

            SqlCommand cmd = new SqlCommand(sql_delete, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Deleted Successfully");

            con.Close();
        }

        public string billNo { get; set; }

        private void button6_Click(object sender, EventArgs e)
        {
            MDIParent1 m = new MDIParent1();
            m.Show();
            this.Hide();

        }

        public string OrderNo { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
