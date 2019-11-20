using Altkom._20_22._11.CSharp.Module2.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class StudentProfileView : UserControl
    {
        public StudentProfileView()
        {
            InitializeComponent();
        }

        public event EventHandler Back;

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (SessionContext.UserRole != Role.Teacher)
            {
                return;
            }

            Back?.Invoke(sender, e);
        }

        // TODO 1.3d: Wyświetl imię i nazwisko wybranego studenta. Jeśli użytkownik zalogowany jest jako uczeń - ukryj przycisk btnBack;
        public void Refresh()
        {
            //((TextBlock)studentName.Children[0]).Text = firstName;
            //((TextBlock)studentName.Children[1]).Text = lastName;

            //btnBack.Visibility = Visibility.Hidden;
        }
    }
}
