using Altkom._20_22._11.CSharp.Module2.Models;
using System;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        public event EventHandler LogInSuccess;

        // TODO 3.2a: Dodaj zdarzenie LogInFailed

        // TODO 3.2b: Wyszukaj użytkownika wykorzystując kolekcje nauczycieli i uczniów ze źródła danych
        private void LogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Password))
                return;

            SessionContext.UserName = username.Text;
            SessionContext.UserRole = (bool)userrole.IsChecked ? Role.Teacher : Role.Student;

            if (SessionContext.UserRole == Role.Student)
            {
                SessionContext.CurrentStudent = "Some Student";
            }

            LogInSuccess?.Invoke(this, null);
        }
    }
}
