using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UczelniaWindows
{
    public partial class AddStudentToSubjectForm : Form
    {
        public static StudentToSubject sts;

        public AddStudentToSubjectForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                sts = null;
                int student, subject;
                student = Int32.Parse(this.textBoxStudentId.Text);
                subject = Int32.Parse(this.textBoxSubjectId.Text);
                sts = new StudentToSubject { subject_id = subject, student_id = student };
            }
            catch(Exception ex)
            {
                //do nothing
            }
            finally
            {
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
