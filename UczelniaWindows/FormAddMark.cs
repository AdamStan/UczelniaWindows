using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UczelniaWindows
{
    public partial class FormAddMark : Form
    {
        private Form behind;
        private string username;
        private Connection tcon;

        public FormAddMark(Form f, string us)
        {
            this.behind = f;
            this.username = us;
            string serverName = UczelniaWindows.Properties.Resources.NazwaServera;
            this.tcon = new Connection("Data Source=" + serverName + ";" +
                "Initial Catalog=Uczelnia;User ID=tutor;Password=tutor123");
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = this.tcon.con;
                con.Open();
                string getSubjectId = "select id from subjects where subject_name = '" + comboBoxSubject.Text + "'";
                SqlCommand cmd = new SqlCommand(getSubjectId, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string subject_id = reader[0].ToString();
                reader.Close();
                string insert = "insert into Marks values ("
                    + textBoxMark.Text + ", " + comboBoxIndex.Text + ", "
                    + subject_id + ")";
                new SqlCommand(insert, con).ExecuteNonQuery();
                con.Close();
                this.behind.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.behind.Show();
            this.Close();
        }

        private void FormAddMark_Load(object sender, EventArgs e)
        {
            SqlConnection connect = this.tcon.con;
            connect.Open();
            string commandSubjects = "SELECT sub.subject_name " +
                "FROM dbo.Subjects sub " +
                "INNER JOIN dbo.SubjectToTutors stt ON " +
                "sub.id = stt.subject_id " +
                "INNER JOIN dbo.Tutors ON " +
                "dbo.Tutors.id = stt.tutor_id " +
                "where dbo.Tutors.username = '" + this.username + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(commandSubjects, connect);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                comboBoxSubject.Items.Add(row["subject_name"]);
            }
            connect.Close();
            connect.Open();
            string commandIndex = "select sts.student_id from StudentToSubject sts " +
                "where subject_id IN( " +
                "select stt.subject_id from SubjectToTutors stt where tutor_id IN( " +
                "select id from Tutors t where t.username = 'pnowacki'))";
            SqlDataAdapter sda2 = new SqlDataAdapter(commandIndex, connect);
            DataTable dt_index = new DataTable();
            sda2.Fill(dt_index);
            foreach (DataRow row in dt_index.Rows)
            {
                comboBoxIndex.Items.Add(row["student_id"]);
            }
            connect.Close();
        }
    }
}
