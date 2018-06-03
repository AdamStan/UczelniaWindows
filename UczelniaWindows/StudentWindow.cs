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
    public partial class StudentWindow : Form
    {
        private Form formBehind;
        private Connection studentConnection;

        public StudentWindow(Form behind, int i)
        {
            InitializeComponent();
            this.studentConnection = new Connection("Data Source=DESKTOP-8G4C4MF;" +
                "Initial Catalog=Uczelnia;User ID=student;Password=student123");
            this.formBehind = behind;
            this.UsernameLabel.Text = i.ToString();
        }

        private void ShowMarks(object sender, EventArgs e)
        {
            SqlConnection connect = this.studentConnection.con;
            connect.Open();
            string aliasMarkValue = "Ocena";
            string aliasStudentId = "[Numer albumu]";
            string aliasSubjectName = "[Nazwa przedmiotu]";
            String select = "SELECT m.mark_value " + aliasMarkValue 
                + ", m.student_id " + aliasStudentId +
                ", sub.subject_name " + aliasSubjectName +
                " FROM dbo.Marks m " +
                " INNER JOIN dbo.StudentToSubject sts ON" +
                " m.student_id = sts.student_id AND " +
                " m.subject_id = sts.subject_id " +
                " INNER JOIN dbo.Subjects sub ON " +
                " sts.subject_id = sub.id" +
                " Where sts.student_id = " + this.UsernameLabel.Text;
            SqlDataAdapter sda = new SqlDataAdapter(select,connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void ShowSubjects(object sender, EventArgs e)
        {
            SqlConnection connect = this.studentConnection.con;
            connect.Open();
            string alias = "[Nazwa przedmiotu]";
            String select = "SELECT sub.subject_name " + alias +
                " FROM Subjects sub " +
                " INNER JOIN StudentToSubject sts on " +
                " sub.id = sts.subject_id " +
                " Where sts.student_id = " + this.UsernameLabel.Text;
            SqlDataAdapter sda = new SqlDataAdapter(select, connect);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
        }

        private void Wyloguj(object sender, EventArgs e)
        {
            this.formBehind.Show();
            this.Close();
        }

        private void StudentWindow_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            Application.Exit();
        }

        private void StudentWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.formBehind.Show();
        }
    }
}
