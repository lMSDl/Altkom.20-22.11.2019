using Altkom._20_22._11.CSharp.Module2.Controls;
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class StudentsView : UserControl
    {
        public StudentsView()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            /*var students = from Student s in DataSource.Students
                            where s.TeacherID == SessionContext.CurrentTeacher.TeacherID
                           select s;*/

            var students = new ArrayList();
            foreach (var student in DataSource.Students)
            {
                if (student.TeacherID == SessionContext.CurrentTeacher.TeacherID)
                {
                    students.Add(student);
                }
            }

            list.ItemsSource = students;

            txtClass.Text = $"Class {SessionContext.CurrentTeacher.Class}";
        }

        public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        public event StudentSelectionHandler StudentSelected;

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            var itemClicked = sender as Button;
            if (itemClicked != null)
            {
                StudentSelected?.Invoke(sender, new StudentEventArgs((Student)itemClicked.DataContext));
            }
        }

        private void NewStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sd = new StudentDialog();
                if (sd.ShowDialog().Value)
                {
                    var newStudent = new Student
                    {
                        FirstName = sd.firstName.Text,
                        LastName = sd.lastName.Text,
                        Password = sd.password.Text
                    };

                    newStudent.UserName = (newStudent.LastName + newStudent.FirstName.Substring(0, 1)).ToLower();
                    newStudent.StudentID = DataSource.Students.Max(s => s.StudentID) + 1;

                    DataSource.Students.Add(newStudent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error creating new student", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnrollStudent_Click(object sender, RoutedEventArgs e)
        {
            new AssignStudentDialog().ShowDialog();
            Refresh();
        }
    }

    public class StudentEventArgs : EventArgs
    {
        public Student Student { get; set; }

        public StudentEventArgs(Student student)
        {
            Student = student;
        }
    }
}

