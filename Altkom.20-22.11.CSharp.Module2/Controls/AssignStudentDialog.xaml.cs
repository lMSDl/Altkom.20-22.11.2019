using System.Windows;
using System.Linq;
using System.Windows.Controls;
using Altkom._20_22._11.CSharp.Module2.Services;
using Altkom._20_22._11.CSharp.Module2.Models;

namespace Altkom._20_22._11.CSharp.Module2.Controls
{
    public partial class AssignStudentDialog : Window
    {
        public AssignStudentDialog()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            var unassignedStudents = DataSource.Students
                .Where(s => s.TeacherID == 0)
                .ToList();
            if (!unassignedStudents.Any())
            {
                txtMessage.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtMessage.Visibility = Visibility.Collapsed;
                list.Visibility = Visibility.Visible;

                list.ItemsSource = unassignedStudents;
            }
        }

        private void AssignStudentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var studentClicked = sender as Button;
                int studentID = (int)studentClicked.Tag;

                var student = DataSource.Students.SingleOrDefault(s => s.StudentID == studentID);

                if (student == null)
                    return;

                string message = string.Format("Add {0} {1} to your class?", student.FirstName, student.LastName);
                var reply = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (reply == MessageBoxResult.Yes)
                {
                    SessionContext.CurrentTeacher.AddToClass(student);
                    Refresh();
                }
            }
            catch(ClassFullException cfe)
            {
                MessageBox.Show($"{cfe.Message}. Class: {cfe.ClassName}", "Enrolling failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
