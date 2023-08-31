using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace MiniUber
{
    public partial class CustomerSignUp : Form
    {
        string ordb = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=scott;Password=tiger;";
        OracleConnection conn;

        public CustomerSignUp()
        {
            InitializeComponent();
        }

        
        private void CustomerSignUp_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(ordb);
            conn.Open();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox2.Text;
            string password = textBox3.Text;
            string address = textBox4.Text;
            string phone = textBox5.Text;
            Customer customerInstance = new Customer(username, email, password, address, phone);
            customerInstance.SignUp(conn);
            MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
