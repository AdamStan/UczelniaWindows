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
                "dbo.Tutors.id = stt.tutor_id " +
                "where dbo.Tutors.username = '" + this.UsernameLabel.Text + "'";
            SqlDataAdapter sda1 = new SqlDataAdapter(commandSubjects, connect);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                comboBoxSubjects.Items.Add(row["subject_name"]);
            }
            connect.Close();
            //uzupelnic datagrid jego ocenami + przedmiotami

            /*connect.Open();
            string commandMarks = "select m.mark_value[wartosc], " +
                "m.student_id[index number], sub.subject_name[subject's name], " +
                "concat(t.t_name, ' ', t.surname)[tutor], m.id[mark's id] " +
                "from Marks m inner join Subjects sub on sub.id = m.subject_id " +
                "left join SubjectToTutors stt on sub.id = stt.subject_id " +
                "left join Tutors t on t.id = stt.tutor_id " +
                "where t.username = '" + this.UsernameLabel.Text + "'";
            SqlDataAdapter sda2 = new SqlDataAdapter(commandMarks, connect);
            DataTable dt_marks = new DataTable();
            sda2.Fill(dt_marks);
            dataGridView1.DataSource = dt_marks;
            connect.Close();*/
            UczelniaEntities db = new UczelniaEntities();
            var query = from vm in db.View_Marks
                        where vm.username == this.UsernameLabel.Text
                        select new { vm.subject_name,
                            vm.student_id,
                            vm.mark_value
                        };
            
            var dataTable = query.ToList();

            dataGridView1.DataSource = dataTable;
            //(nullowe wartosci tym bardziej wyswietlic left join lub riht)
        }

        private void searchStudent(object sender, EventArgs e)
        {
            UczelniaEntities db = new UczelniaEntities();
            int buff = Convert.ToInt32(this.textBoxStudentIndex.Text);

            var query = from vm in db.View_Marks
                        where vm.username == this.UsernameLabel.Text && 
                        vm.student_id == buff
                        select new
                        {
                            vm.subject_name,
                            vm.student_id,
                            vm.mark_value
                        };

            var dataTable = query.ToList();

            dataGridView1.DataSource = dataTable;
        }
    }
}
