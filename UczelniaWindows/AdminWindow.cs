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
    public partial class AdminWindow : Form
    {
        private Form formBehind;

        public AdminWindow(Form behind)
        {
            this.formBehind = behind;
            InitializeComponent();
        }

        private void Logout(object sender, EventArgs e)
        {
            this.formBehind.Show();
            this.Close();
        }
    }
}
