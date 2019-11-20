using Altkom._20_22._11.CSharp.Module2.Services;
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


        private void LogIn_Click(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Password))
                return;

            SessionContext.UserName = username.Text;
            SessionContext.UserRole = userrole.IsChecked.Value ? Models.Role.Teacher : Models.Role.Student;

            LogInSuccess?.Invoke(this, EventArgs.Empty);
        }
    }
}
