using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace MiniUber
{
    internal abstract class User
    {
        protected string UserName { get; set; }
        protected string email { get; set; }
        protected string Password { get; set; }
        protected string Id { get; set; }
        
        protected string Phone { get; set; }
        public abstract bool Login(OracleConnection conn, string email, string password);
        public abstract void SignUp(OracleConnection conn);
        
    }
}
