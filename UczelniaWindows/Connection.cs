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
                variable = true;
            }
            con.Close();
            return variable;
        }
        public DataTable SelectTable(String tablename)
        {
            con.Open();
            String command = "select * from " + tablename;
            SqlDataAdapter adapter = new SqlDataAdapter(command, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        //functions for student
        #region
        public DataTable SelectMarksForStudent(int index)
        {
            con.Open();
            con.Close();
            throw new NotImplementedException();
        }
        public DataTable SelectSubjectsForStudent(int index)
        {
            con.Open();
            con.Close();
            throw new NotImplementedException();
        }
    #endregion 
        
    }
}
