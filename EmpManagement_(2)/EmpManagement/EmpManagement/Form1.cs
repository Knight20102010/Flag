namespace EmpManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee EmployeeInfo = new Employee();

            EmployeeInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeInfo EmployeeInfo = new EmployeeInfo();

            EmployeeInfo.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
