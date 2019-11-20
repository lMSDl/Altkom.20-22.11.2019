using Altkom._20_22._11.CSharp.Module2.Models;
using System;
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
            txtClass.Text = $"Class {SessionContext.CurrentTeacher.Class}";

            list.ItemsSource = from Student s in DataSource.Students
                               where s.TeacherID == SessionContext.CurrentTeacher.TeacherID
                                select s;

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

