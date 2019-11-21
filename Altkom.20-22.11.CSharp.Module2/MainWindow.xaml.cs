using System;
using System.Windows;
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Views;

namespace Altkom._20_22._11.CSharp.Module2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataSource.CreateData(); 
            // TODO 5.3: Posortuj kolekcję studentów
            GotoLogon();
        }

        public void GotoLogon()
        {
            gridLoggedIn.Visibility = Visibility.Collapsed;

            studentsView.Visibility = Visibility.Collapsed;
            studentProfileView.Visibility = Visibility.Collapsed;
            logInView.Visibility = Visibility.Visible;
        }

        private void GotoStudentsPage()
        {
            studentProfileView.Visibility = Visibility.Collapsed;
            studentsView.Visibility = Visibility.Visible;
            studentsView.Refresh();
        }

        public void GotoStudentProfile()
        {
            studentsView.Visibility = Visibility.Collapsed;
            studentProfileView.Visibility = Visibility.Visible;
            studentProfileView.Refresh();
        }

        private void LogInView_LogInSuccess(object sender, EventArgs e)
        {
            logInView.Visibility = Visibility.Collapsed;
            gridLoggedIn.Visibility = Visibility.Visible;
            Refresh();
        }

        private void LogInView_LogInFailed(object sender, EventArgs e)
        {
            MessageBox.Show("Invalid Username or Password", "Logon Failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void LogOff_Click(object sender, EventArgs e)
        {
            GotoLogon();
        }

        private void StudentProfileView_Back(object sender, EventArgs e)
        {
            GotoStudentsPage();
        }

        private void StudentsView_StudentSelected(object sender, StudentEventArgs e)
        {
            SessionContext.CurrentStudent = e.Student;
            GotoStudentProfile();
        }

        private void Refresh()
        {
            switch (SessionContext.UserRole)
            {
                case Role.Student:
                    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentStudent.FirstName, SessionContext.CurrentStudent.LastName);
                    GotoStudentProfile();
                    break;

                case Role.Teacher:
                    txtName.Text = string.Format("Welcome {0} {1}", SessionContext.CurrentTeacher.FirstName, SessionContext.CurrentTeacher.LastName);
                    GotoStudentsPage();
                    break;
            }
        }
    }
}
