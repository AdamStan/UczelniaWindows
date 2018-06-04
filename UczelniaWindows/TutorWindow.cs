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
    public partial class TutorWindow : Form
    {
        private Form formBehind;
        private Connection tutorConnection;

        public TutorWindow(Form behind, string name)
        {
            InitializeComponent();
            this.tutorConnection = new Connection("Data Source=DESKTOP-8G4C4MF;" +
                "Initial Catalog=Uczelnia;User ID=tutor;Password=tutor123");
            this.formBehind = behind;
            this.UsernameLabel.Text = name;
        }

        private void Logout(object sender, EventArgs e)
        {
            this.formBehind.Show();
            this.Close();
        }

        private void TutorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.formBehind.Show();
        }

        private void TutorWindow_Load(object sender, EventArgs e)
        {
            //uzupełniamy combo z przedmiotami:
            SqlConnection connect = this.tutorConnection.con;
            connect.Open();
            string commandSubjects = "SELECT sub.subject_name " +
                "FROM dbo.Subjects sub " +
                "INNER JOIN dbo.SubjectToTutors stt ON " +
                "sub.id = stt.subject_id " +
                "INNER JOIN dbo.Tutors ON " +
                " dbo.Tutors.id = stt.tutor_id" +
                " where dbo.Tutors.username = " + this.UsernameLabel.Text;
            SqlDataAdapter sda1 = new SqlDataAdapter(commandSubjects, connect);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                comboBoxSubjects.Items.Add(row["subject_name"]);
            }
            connect.Close();
            //uzupelnic datagrid jego ocenami + przedmiotami
            /* TO BEDZIE MAŁY DŻOJN
            SELECT dbo.Students.index_number, dbo.Marks.mark_value, dbo.Subjects.subject_name, dbo.SubjectToTutors.tutor_id
            FROM dbo.Marks 
            INNER JOIN dbo.StudentToSubject 
            ON dbo.Marks.student_id = dbo.StudentToSubject.student_id AND dbo.Marks.subject_id = dbo.StudentToSubject.subject_id 
            INNER JOIN dbo.Students 
            ON dbo.StudentToSubject.student_id = dbo.Students.index_number 
            INNER JOIN dbo.SubjectToTutors 
            ON dbo.StudentToSubject.subject_id = dbo.SubjectToTutors.subject_id 
            INNER JOIN dbo.Subjects 
            ON dbo.StudentToSubject.subject_id = dbo.Subjects.id AND dbo.SubjectToTutors.subject_id = dbo.Subjects.id
            */
            //(nullowe wartosci tym bardziej wyswietlic left join lub right)
        }

        private void searchStudent(object sender, EventArgs e)
        {

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
