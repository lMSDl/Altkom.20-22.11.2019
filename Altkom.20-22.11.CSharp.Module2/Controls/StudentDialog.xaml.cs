using System.Windows;

namespace Altkom._20_22._11.CSharp.Module2.Controls
{
    public partial class StudentDialog : Window
    {
        public StudentDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstName.Text))
            {
                MessageBox.Show("The student must have a first name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(lastName.Text))
            {
                MessageBox.Show("The student must have a last name", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                MessageBox.Show("The student must have a password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }
    }
}
