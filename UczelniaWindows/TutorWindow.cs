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
    public partial class TutorWindow : Form
    {
        private Form formBehind;

        public TutorWindow(Form behind)
        {
            InitializeComponent();
            this.formBehind = behind;
        }

        private void Logout(object sender, EventArgs e)
        {
            this.formBehind.Show();
            this.Close();
        }
    }
}
