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

        public TutorWindow(Form behind, string name)
        {
            InitializeComponent();
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
            //uzupełnić tamte 2 comboboxy
            //uzupelnic datagrid jego ocenami + przedmiotami 
            //(nullowe wartosci tym bardziej wyswietlic left join lub right)
        }

        private void insertMark(object sender, EventArgs e)
        {
            //wstawianie ocen
        }
    }
}
