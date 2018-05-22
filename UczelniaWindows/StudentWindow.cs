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
    public partial class StudentWindow : Form
    {
        private Form formBehind;

        public StudentWindow(Form behind, int i)
        {
            InitializeComponent();
            this.formBehind = behind;
            this.UsernameLabel.Text = i.ToString();
        }

        private void ShowMarks(object sender, EventArgs e)
        {

        }

        private void ShowSubjects(object sender, EventArgs e)
        {

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

        private void FormToClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
