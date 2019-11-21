using Altkom._20_22._11.CSharp.Module2.Models;
using System.Windows;

namespace Altkom._20_22._11.CSharp.Module2.Controls
{
    public partial class ChangePasswordDialog : Window
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            var user = SessionContext.UserRole == Role.Student ?
                (User)SessionContext.CurrentStudent : SessionContext.CurrentTeacher;

            if(!user.VerifyPassword(oldPassword.Password))
            {
                MessageBox.Show("Old password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if(string.Compare(newPassword.Password, confirm.Password) != 0)
            {
                MessageBox.Show("The new password and confirm password fields are different", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                user.Password = newPassword.Password;
            }
            catch
            {
                MessageBox.Show("The new password is not sufficiently complex", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
