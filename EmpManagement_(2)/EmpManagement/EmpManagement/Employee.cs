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
        //Predstavuje pripojenie k databáze SQL Server. Táto trieda sa nedá zdediť.

        private void Employee_Load(object sender, EventArgs e)
        {
            BindData();
            //Naviaže zdroj údajov na vyvolaný ovládací prvok servera a všetky jeho dcérske ovládacie prvky.
        }

        void BindData()
        {
            SqlCommand cnn = new SqlCommand("Select  * from emptab", con);  //Predstavuje príkaz transakciu-SQL alebo uloženú procedúru na vykonanie v databáze SQL Server. Táto trieda sa nedá zdediť.

            SqlDataAdapter da = new SqlDataAdapter(cnn);   //Predstavuje množinu údajových príkazov a databázové pripojenie, ktoré sa používajú na vyplnenie množiny údajov a aktualizáciu databázy SQL Server. Táto trieda sa nedá zdediť.

            DataTable table = new DataTable(); //Predstavuje jednu tabuľku údajov v pamäti.

            da.Fill(table); //Pridá alebo obnoví riadky v množine údajov tak, aby sa zhodovali s riadkami v zdroji údajov.

            dataGridView1.DataSource = table;  //Zobrazuje údaje v prispôsobiteľnej mriežke.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open(); //Otvorí pripojenie k databáze s nastaveniami vlastností

            SqlCommand cnn = new SqlCommand("Insert into emptab (id, name, position, email, technik, manager) values(@id, @name, @position, @email, @technik, @manager)", con); ////Predstavuje príkaz transakciu-SQL alebo uloženú procedúru na vykonanie v databáze SQL Server

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));

            cnn.Parameters.AddWithValue("@Position", (textBox3.Text));

            cnn.Parameters.AddWithValue("@Email", (textBox4.Text));

            cnn.Parameters.AddWithValue("@Technik", (textBox5.Text));

            cnn.Parameters.AddWithValue("@Manager", int.Parse(textBox6.Text));

            cnn.ExecuteNonQuery(); //Vykoná príkaz Transact-SQL proti pripojeniu a vráti počet ovplyvnených riadkov.

            con.Close();//Zatvorí pripojenie k databáze s nastaveniami vlastností

            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // nový príkaz
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

            SqlCommand cnn = new SqlCommand("Delete emptab where id=@id",con);////Predstavuje príkaz transakciu-SQL alebo uloženú procedúru na vykonanie v databáze SQL Server

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data deleted");


        }
    }
}
