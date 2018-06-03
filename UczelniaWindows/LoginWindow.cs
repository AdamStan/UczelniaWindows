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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginFunction(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            UsernameTextBox.Text = "";
            PasswordTextBox.Text = "";

            Connection c = new Connection("Data Source=DESKTOP-8G4C4MF;" +
                "Initial Catalog=Uczelnia;Integrated Security=True");

            if (comboBox1.Text.Equals("student"))
            { 
                int index;
                int.TryParse(username, out index);
                if (c.IsItStudent(index, password))
                {
                    this.Hide();
                    new StudentWindow(this, index).Show();
                }
                else
                {
                    MessageBox.Show("Nie udało się zalogować");
                }
            }
            else if (comboBox1.Text.Equals("tutor"))
            {
                if (c.IsItTutorOrAdm(username, password, "tutors"))
                {
                    this.Hide();
                    new TutorWindow(this, username).Show();
                }
                else
                {
                    MessageBox.Show("Nie udało się zalogować");
                }
            }
            else if (comboBox1.Text.Equals("administrator"))
            {
                if (c.IsItTutorOrAdm(username, password, "administrators"))
                {
                    this.Hide();
                    new AdminWindow(this).Show();
                }
                else
                {
                    MessageBox.Show("Nie udało się zalogować");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano nic w combo");
            }
        }
    }
}
