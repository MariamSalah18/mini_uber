using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniUber
{
    public partial class Menu : Form
    {

        DriverSignUp driverForm = new DriverSignUp();
        CustomerSignUp customerForm = new CustomerSignUp();
        LoginForm loginForm = new LoginForm();
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsRadioButtonChecked())
            {
                MessageBox.Show("Please select a user type (Driver or Customer).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton1.Checked)
            {
                driverForm.Show();
               // this.Hide();
            }
            else 
            {

                customerForm.Show();
               // this.Hide();
            }
        }
        private bool IsRadioButtonChecked()
        {
            
            return radioButton1.Checked || radioButton2.Checked;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsRadioButtonChecked())
            {
                MessageBox.Show("Please select a user type (Driver or Customer).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton1.Checked)
            {
                loginForm.UserType = "Driver";

                loginForm.Show();
               // this.Hide();
            }
            else
            {
                loginForm.UserType = "Customer";
                loginForm.Show();
               // this.Hide();
            }
        }
    }
}
