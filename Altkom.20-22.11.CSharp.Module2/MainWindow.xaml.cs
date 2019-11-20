using Altkom._20_22._11.CSharp.Module2.Services;
using Altkom._20_22._11.CSharp.Module2.Views;
using System;
using System.Windows;

namespace Altkom._20_22._11.CSharp.Module2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            gridLoggedIn.Visibility = Visibility.Visible;
            logInView.Visibility = Visibility.Collapsed;
            Refresh();
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
        }

        private void Refresh()
        {
            txtName.Text = $"Welcome {SessionContext.UserName}";

            switch (SessionContext.UserRole)
            {
                case Models.Role.Teacher:
                    GotoStudentsPage();
                    break;
                case Models.Role.Student:
                    GotoStudentProfile();
                    break;
            }
        }
    }
}
