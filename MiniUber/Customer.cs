using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace MiniUber
{
    internal class Customer:User
    {
        string Address;
        public Customer()
        {
        }
        public Customer(string username,string Email, string password, string address,string phone)
        {
            UserName = username;
            email = Email;
            Address = address;
            Password = password;
            Phone = phone;
        }
        public override void SignUp(OracleConnection conn)
        {
            using (OracleCommand cmd = conn.CreateCommand())
            {

                cmd.CommandText = "INSERT INTO CUSTOMERS(customer_id, username, email, password, address, phone) VALUES (customers_seq.nextval, :username, :email, :password, :address, :phone)";
                cmd.Parameters.Add("username", UserName);
                cmd.Parameters.Add("email", email);  
                cmd.Parameters.Add("password", Password);
                cmd.Parameters.Add("address", Address);
                cmd.Parameters.Add("phone", Phone);
                int rowsAffected = cmd.ExecuteNonQuery();
                
            }

        }
        public override bool Login(OracleConnection conn, string email, string password)
        {
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM customers WHERE username = :username AND password = :password";
                cmd.Parameters.Add("username", email);
                cmd.Parameters.Add("password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
