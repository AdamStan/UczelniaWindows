using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
            try
            {
                button1.Text = "Dodaj";
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
                    dataGridView1.DataSource = context.Subjects.ToList();
                }
                else if (comboBox1.Text == "faculties")
                {
                    dataGridView1.DataSource = context.Faculties.ToList();
                }
                else if (comboBox1.Text == "studenttosubjects")
                {
                    button1.Text = "Dodaj Stud<->Subject";
                    dataGridView1.DataSource = context.StudentToSubjects.ToList();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminWindow_Load(object sender, EventArgs e)
        {

        }
        private void Confirm(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Wybierz tabele");
            }
            catch(DbEntityValidationException ex)
            {
                MessageBox.Show("Zle edytowane dane");
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show("Nie mozna wykonac update'a");
            }
        }

        private void AdminWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
            this.formBehind.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Nie wybrano tabeli");
            }
            else
            {
                if (comboBox1.Text == "administrators")
                {
                    Administrator administrator = 
                        new Administrator {
                            password = "12345",
                            username = "Ad_new"
                        };
                    context.Administrators.Add(administrator);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Administrators.ToList();
                }
                else if (comboBox1.Text == "tutors")
                {
                    Tutor tutor = new Tutor { username = "tutor_new", password = "12345" };
                    context.Tutors.Add(tutor);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Tutors.ToList();
                }
                
                else if (comboBox1.Text == "students")
                {
                    Student student = new Student
                    {
                        password = "12345678",
                        s_name = "(wpisz imie)",
                        surname = "(wpisz nazwisko)",
                        field_of_study = "1",
                        degree = "inz",
                        mode = "dzienne",
                        semester = 1
                    };
                    context.Students.Add(student);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Students.ToList();
                }
                else if (comboBox1.Text == "marks")
                {
                    Mark mark = new Mark();
                    context.Marks.Add(mark);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Marks.ToList();
                }
                else if (comboBox1.Text == "subjects")
                {
                    Subject subject = new Subject { subject_name = "(wpisz nazwe)" };
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Subjects.ToList();
                }
                else if (comboBox1.Text == "faculties")
                {
                    Faculty faculty = new Faculty { faculty_name = "(zmien nazwe)"};
                    context.Faculties.Add(faculty);
                    context.SaveChanges();
                    dataGridView1.DataSource = context.Faculties.ToList();
                }
                else if (comboBox1.Text == "studenttosubjects")
                {
                    new AddStudentToSubjectForm().ShowDialog();
                    StudentToSubject studentToSubject = AddStudentToSubjectForm.sts;
                    if(studentToSubject == null)
                    {
                        MessageBox.Show("Podano zle wartosci");
                    }
                    else
                    {
                        context.StudentToSubjects.Add(studentToSubject);
                        context.SaveChanges();
                        dataGridView1.DataSource = context.StudentToSubjects.ToList();
                    }
                }
            }
            dataGridView1.Refresh();
            //context.SaveChanges();
        }
        // przyznaje sie, to akurat znalazlem na stacku
        // https://stackoverflow.com/questions/30018282/how-can-i-delete-object-with-dbcontext-in-c
        private void deleteSelectedRow(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Nie wybrano tabeli");
                }
                else
                {
                    if (comboBox1.Text == "administrators")
                    {
                        var selectedOrderLine = (Administrator)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Administrators.SingleOrDefault(item => item.id == selectedOrderLine.id);
                        if (orderLine != null)
                        {
                            context.Administrators.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Administrators.ToList();
                        }
                    }
                    else if (comboBox1.Text == "tutors")
                    {
                        var selectedOrderLine = (Tutor)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Tutors.SingleOrDefault(item => item.id == selectedOrderLine.id);
                        if (orderLine != null)
                        {
                            context.Tutors.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Tutors.ToList();
                        }
                    }

                    else if (comboBox1.Text == "students")
                    {
                        var selectedOrderLine = (Student)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Students.SingleOrDefault(item =>
                                item.index_number == selectedOrderLine.index_number);
                        if (orderLine != null)
                        {
                            context.Students.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Students.ToList();
                        }
                    }
                    else if (comboBox1.Text == "marks")
                    {
                        var selectedOrderLine = (Mark)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Marks.SingleOrDefault(item =>
                                item.id == selectedOrderLine.id);
                        if (orderLine != null)
                        {
                            context.Marks.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Marks.ToList();
                        }
                    }
                    else if (comboBox1.Text == "subjects")
                    {
                        var selectedOrderLine = (Subject)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Subjects.SingleOrDefault(item =>
                                item.id == selectedOrderLine.id);
                        if (orderLine != null)
                        {
                            context.Subjects.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Subjects.ToList();
                        }
                    }
                    else if (comboBox1.Text == "faculties")
                    {
                        var selectedOrderLine = (Faculty)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.Faculties.SingleOrDefault(item =>
                                item.id == selectedOrderLine.id);
                        if (orderLine != null)
                        {
                            context.Faculties.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.Faculties.ToList();
                        }
                    }
                    else if (comboBox1.Text == "studenttosubjects")
                    {
                        var selectedOrderLine = (StudentToSubject)dataGridView1.SelectedRows[0].DataBoundItem;
                        var orderLine = context.StudentToSubjects.SingleOrDefault(item =>
                                (item.student_id == selectedOrderLine.student_id)
                                && (item.subject_id == selectedOrderLine.subject_id));
                        if (orderLine != null)
                        {
                            context.StudentToSubjects.Remove(orderLine);
                            context.SaveChanges();
                            dataGridView1.DataSource = context.StudentToSubjects.ToList();
                        }
                    }
                }
                dataGridView1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Pewnie ten exeption nic ci nie powie: " + ex.Message);
            }
        }
    }
}
