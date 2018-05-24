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
        //DataClasses1DataContext dc = new DataClasses1DataContext();
        UczelniaEntities context;

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

        private void LoadTableToGrid(object sender, EventArgs e)
        {
            if (comboBox1.Text == "(wybierz tabele)")
            {
                MessageBox.Show("Nie wybrano tabeli");
            }
            else
            {
                context = new UczelniaEntities();
                if (comboBox1.Text == "tutors")
                {
                    dataGridView1.DataSource = context.Tutors.ToList();
                }
                else if (comboBox1.Text == "administrators")
                {
                    dataGridView1.DataSource = context.Administrators.ToList();
                }
                else if (comboBox1.Text == "students")
                {
                    dataGridView1.DataSource = context.Students.ToList();
                }
                else if (comboBox1.Text == "marks")
                {
                    dataGridView1.DataSource = context.Marks.ToList();
                }
                else if (comboBox1.Text == "subjects")
                {
                    dataGridView1.DataSource = context.Students.ToList();
                }
                else if (comboBox1.Text == "faculties")
                {
                    dataGridView1.DataSource = context.Faculties.ToList();
                }
            }
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {

        }
        private void Confirm(object sender, EventArgs e)
        {
            context.SaveChanges();
        }
    }
}
