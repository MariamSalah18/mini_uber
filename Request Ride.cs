using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Mini_Uber
{
    public partial class Request_Ride : Form
    {
        string ordb = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=PersonalDiary;Password=1234;";
        OracleConnection conn;
        public Request_Ride()
        {
            InitializeComponent();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Request_Ride_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

         //private void GetInfo()
         //{

         //}

        private void button1_Click(object sender, EventArgs e)
        {
            string rideType = GetSelectedRideType();
            string startLocation = GetSelectedStartLocation();
            string endLocation = GetSelectedEndLocation();

            Ride ride = new Ride(startLocation, endLocation , rideType);
            ride.RequestRide(conn);
            MessageBox.Show("Data saved to database!");
        }

        private string GetSelectedRadioButtonText(GroupBox groupBox)
        {
            foreach (RadioButton radioButton in groupBox.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return null; // No radio button selected
        }

        private string GetSelectedRideType()
        {
            return GetSelectedRadioButtonText(rideTypeGroupBox); 
        }

        private string GetSelectedStartLocation()
        {
            return GetSelectedRadioButtonText(startLocationGroupBox); 
        }

        private string GetSelectedEndLocation()
        {
            return GetSelectedRadioButtonText(endLocationGroupBox); 
        }

    }
}
