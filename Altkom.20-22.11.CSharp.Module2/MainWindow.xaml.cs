using Altkom._20_22._11.CSharp.Module2.Views;
﻿using Altkom._20_22._11.CSharp.Module2.Models;
using System;
using System.Windows;

namespace Altkom._20_22._11.CSharp.Module2
{
    public partial class MainWindow : Window
    {
        //TODO 3.1 Zainicjuj źródło danych 
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
            logInView.Visibility = Visibility.Collapsed;
            gridLoggedIn.Visibility = Visibility.Visible;
            Refresh();
        }

        // TODO 3.2a: Obsłuż nieudane logowanie. Wyświetl wiadomość błedu (MessageBox.Show)

        private void LogOff_Click(object sender, EventArgs e)
        {
            GotoLogon();
        }

        private void StudentProfileView_Back(object sender, EventArgs e)
        {
            GotoStudentsPage();
        }

        //TODO 3.4d: Popraw powstałe błędy
        private void StudentsView_StudentSelected(object sender, StudentEventArgs e)
        {
            SessionContext.CurrentStudent = e.Name;
            GotoStudentProfile();
        }

        private void Refresh()
        {
            //TODO 3.3f Popraw powitanie zalogowanego użytkownika
            txtName.Text = string.Format("Welcome {0}", SessionContext.UserName);
            switch (SessionContext.UserRole)
            {
                case Role.Student:
                    GotoStudentProfile();
                    break;

                case Role.Teacher:
                    GotoStudentsPage();
                    break;
            }
        }
    }
}
