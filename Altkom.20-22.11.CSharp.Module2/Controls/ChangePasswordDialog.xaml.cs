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
            //TODO 8.3a: Pobierz użytkonika

            //TODO 8.3b: Sprawdź czy stare hasło (oldPassword.Password) jest prawidłowe

            //TODO 8.3c: Sprawdź czy nowe hasło (newPassword.Password) i jego potwierdzenie (confirm.Password) są takie same

            //TODO 8.3d: Podejmij próbę zapisania hasła. Jeśli hasło nie spełnia wymagań wyświetl MessageBox.

            DialogResult = true;
        }
    }
}
