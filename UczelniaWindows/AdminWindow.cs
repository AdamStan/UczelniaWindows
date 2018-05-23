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
        private BindingSource bs_currently;
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
            dataGridView1.AutoGenerateColumns = true;
            if (comboBox1.Text == "(wybierz tabele)")
            {
                MessageBox.Show("Nie wybrano tabeli");
            }
            else
            {
                if (comboBox1.Text == "tutors")
                {
                    this.dataGridView1.DataSource = this.tutorsBindingSource;
                    this.bs_currently = this.tutorsBindingSource;
                }
                else if (comboBox1.Text == "administrators")
                {
                    this.dataGridView1.DataSource = this.administratorsBindingSource;
                    this.bs_currently = this.administratorsBindingSource;
                }
                else if (comboBox1.Text == "students")
                    this.dataGridView1.DataSource = this.studentsBindingSource;
                else if (comboBox1.Text == "marks")
                    this.dataGridView1.DataSource = this.marksBindingSource;
                else if (comboBox1.Text == "subjects")
                    this.dataGridView1.DataSource = this.subjectsBindingSource;
                else if (comboBox1.Text == "faculties")
                    this.dataGridView1.DataSource = this.facultiesBindingSource;
            }
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Tutors' . Możesz go przenieść lub usunąć.
            this.tutorsTableAdapter.Fill(this.uczelniaDataSet.Tutors);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Subjects' . Możesz go przenieść lub usunąć.
            this.subjectsTableAdapter.Fill(this.uczelniaDataSet.Subjects);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Students' . Możesz go przenieść lub usunąć.
            this.studentsTableAdapter.Fill(this.uczelniaDataSet.Students);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Marks' . Możesz go przenieść lub usunąć.
            this.marksTableAdapter.Fill(this.uczelniaDataSet.Marks);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Faculties' . Możesz go przenieść lub usunąć.
            this.facultiesTableAdapter.Fill(this.uczelniaDataSet.Faculties);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'uczelniaDataSet.Administrators' . Możesz go przenieść lub usunąć.
            this.administratorsTableAdapter.Fill(this.uczelniaDataSet.Administrators);

        }

        private void Confirm(object sender, EventArgs e)
        {
            this.bs_currently.EndEdit();
            
        }
    }
}
