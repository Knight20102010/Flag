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

namespace EmpManagement
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=12wrx;Initial Catalog=employeedb;Integrated Security=True");

        private void Employee_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlCommand cnn = new SqlCommand("Select  * from emptab", con);

            SqlDataAdapter da = new SqlDataAdapter(cnn);

            DataTable table = new DataTable();

            da.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into emptab (id, name, position, email, technik, manager) values(@id, @name, @position, @email, @technik, @manager)", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));

            cnn.Parameters.AddWithValue("@Position", (textBox3.Text));

            cnn.Parameters.AddWithValue("@Email", (textBox4.Text));

            cnn.Parameters.AddWithValue("@Technik", (textBox5.Text));

            cnn.Parameters.AddWithValue("@Manager", int.Parse(textBox6.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=12wrx;Initial Catalog=employeedb;Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete emptab where id=@id",con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data deleted");


        }
    }
}
