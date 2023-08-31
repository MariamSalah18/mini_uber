using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace MiniUber
{
    internal class Driver : User
    {
        string car_model;
        string car_plate;
        public Driver()
        {
        }
        public Driver(string username, string Email,string password, string carModel,string carPlate,string phone)
        {
            UserName = username;
            email=Email;
            car_model = carModel;
            car_plate = carPlate;
            Password = password;
            Phone = phone;
        }
        public override void SignUp(OracleConnection conn)
        {
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO drivers (driver_id, username, email, password, car_model, car_plate, phone) VALUES (drivers_seq.nextval, :username, :email, :password, :car_model, :car_plate, :phone)";
                cmd.Parameters.Add("username", UserName);
                cmd.Parameters.Add("email", email);
                cmd.Parameters.Add("password", Password);
                cmd.Parameters.Add("car_model", car_model);
                cmd.Parameters.Add("car_plate", car_plate);
                cmd.Parameters.Add("phone", Phone);

               int rowsAffected = cmd.ExecuteNonQuery();
                
            }
        }

        public override bool Login(OracleConnection conn, string email, string password)
        {
             using (OracleCommand cmd = conn.CreateCommand())
    {
        cmd.CommandText = "SELECT COUNT(*) FROM drivers WHERE username = :username AND password = :password";
        cmd.Parameters.Add("username", email);
        cmd.Parameters.Add("password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }



    }
}
