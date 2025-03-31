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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ADMIN\documents\visual studio 2012\Projects\FOOD TAKE AWAY SYSTEM 1\FOOD TAKE AWAY SYSTEM 1\Database1.mdf;Integrated Security=True");
        private object halfPrice;
        private string foodType;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button Code
            con.Open();
            string no = textBox1.Text;
            string foodName = textBox2.Text;
            string foddType = comboBox1.Text;
            string halfRrice = textBox3.Text;
            string fullPrice = textBox4.Text;

            string sql_insert = "INSERT INTO Food (no,foodName,foodType,halfPrice,fullPrice)VALUES('" + no + "','" + foodName + "','" + foodType + "','" + halfPrice + "','" + fullPrice + "')";

            SqlCommand cmd = new SqlCommand(sql_insert, con);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");

            con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search Button Code
            con.Open();
            string no = textBox1.Text;

            string Sql_search = "SELECT* FROM Food WHERE NO='" + no + "'";

            SqlCommand cmd = new SqlCommand(Sql_search, con);

            SqlDataReader r = cmd.ExecuteReader();

            if (r.Read())
            {
                textBox2.Text = r[1].ToString();
                comboBox1.Text = r[2].ToString();
                textBox3.Text = r[3].ToString();
                textBox4.Text = r[4].ToString();
                MessageBox.Show("Found Successfully");
            }
            else
            {
                textBox2.Text = null;
                comboBox1.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                MessageBox.Show("NOT Found");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Update Button Code
            con.Open();
            string no = textBox1.Text;
            string foodName = textBox2.Text;
            string foodType = comboBox1.Text;
            string halfPrice = textBox3.Text;
            string fullPrice = textBox4.Text;

            string sql_update = "update Food set foodName='" + foodName + "',foodType='" + foodType + "',halfPrice='" + halfPrice + "',fullPrice='" + fullPrice + "'WHERE NO='" + no + "'";

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

            string no = textBox1.Text;

            string sql_delete = "DELETE FROM Food WHERE NO='" + no + "'";

            SqlCommand cmd = new SqlCommand(sql_delete, con);

            cmd.ExecuteNonQuery();


            MessageBox.Show("Deleted Successfully");

            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Refresh Button Code
            con.Open();

            SqlDataAdapter data = new SqlDataAdapter(@"SELECT*FROM Food", con);

            DataTable t = new DataTable();

            dataGridView1.DataSource = t;

            data.Fill(t);

            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MDIParent1 m = new MDIParent1();
            m.Show();
            this.Hide();
            
        }

        public object HalfPrice { get; set; }

        public string FoodType { get; set; }

        public string FoodName { get; set; }

        public string FullPrice { get; set; }
    }
}
