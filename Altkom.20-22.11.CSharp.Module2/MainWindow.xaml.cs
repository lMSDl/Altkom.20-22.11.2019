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

        // TODO 1.3c: Wyświetl widok listy studentów
        private void GotoStudentsPage()
        {

        }

        // TODO 1.3b: Wyświetl widok szczegółów studenta
        public void GotoStudentProfile()
        {

        }

        // TODO 1.2a: Obsłuż zdarzenie zalogowania.
        private void LogInView_LogInSuccess(object sender, EventArgs e)
        {
        }

        // TODO 1.2b: Obsłuż zdarzenie wylogowania
        private void LogOff_Click(object sender, EventArgs e)
        {
        }

        private void StudentProfileView_Back(object sender, EventArgs e)
        {
            GotoStudentsPage();
        }

        // TODO 1.4b: Obsłuż zdarzenie StudentSelected. Ustaw nazwę studenta w kontekście sesji i przejź do profilu studenta.
        private void StudentsView_StudentSelected(object sender, StudentEventArgs e)
        {

        }

        // TODO 1.3a: Wyświelt widok odpowiedni do roli zalogowanego użytkownika
        private void Refresh()
        {

        }
    }
}
