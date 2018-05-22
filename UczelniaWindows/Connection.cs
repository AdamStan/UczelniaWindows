using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace UczelniaWindows
{
    class Connection
    {
        public SqlConnection con { get; set; }

        public Connection(String url)
        {
            this.con = new SqlConnection(url);
        }

        public bool IsItStudent()
        {
            throw new NotImplementedException();
        }
        public bool IsItTutor()
        {
            throw new NotImplementedException();
        }
        public bool IsItAdministrator()
        {
            throw new NotImplementedException();
        }
    }
}
