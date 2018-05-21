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

            if (username.Equals("student"))
            {
                Console.WriteLine("DZIALA");
                this.Hide();
                new StudentWindow().Show();
            }
        }
    }
}
