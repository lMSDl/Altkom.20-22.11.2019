using Altkom._20_22._11.CSharp.Module2.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class StudentProfileView : UserControl
    {
        public StudentProfileView()
        {
            InitializeComponent();
        }

        public event EventHandler Back;

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (SessionContext.UserRole != Role.Teacher)
            {
                return;
            }

            Back?.Invoke(sender, e);
        }

        public void Refresh()
        {
            studentName.DataContext = SessionContext.CurrentStudent;

            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
            }

            studentGrades.ItemsSource = from Grade g in DataSource.Grades
                                        where g.StudentID == SessionContext.CurrentStudent.StudentID
                                        select g;
        }
    }
}
