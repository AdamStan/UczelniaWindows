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

        public bool IsItStudent(int index, String password)
        {
            con.Open();
            String command = "select * from students where index_number = " 
                + index + " AND password = '" + password + "';";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            bool variable = false;
            foreach(DataRow r in dt.Rows)
            {
                /*foreach(DataColumn c in dt.Columns)
                {
                    Console.Write(" " + r[c]);
                }*/
                variable = true;
            }
            con.Close();
            return variable;
        }
        public bool IsItTutorOrAdm(string username, string password, string tablename)
        {
            con.Open();
            String command = "select * from " + tablename + " where username = '"
                + username + "' AND password = '" + password + "';";
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            bool variable = false;
            foreach (DataRow r in dt.Rows)
            {
                /*foreach(DataColumn c in dt.Columns)
                {
                    Console.Write(" " + r[c]);
                }*/
                variable = true;
            }
            con.Close();
            return variable;
        }
    }
}
