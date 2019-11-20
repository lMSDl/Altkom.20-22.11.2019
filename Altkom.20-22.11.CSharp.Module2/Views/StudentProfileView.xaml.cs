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

        public void Refresh()
        {
            // TODO 3.5a: Pobierz dane studenta z kontekstu sesji i przypisz do studentName.DataContext

            var spittedName = SessionContext.CurrentStudent.Split(' ');
            var firstName = spittedName[0];
            var lastName = spittedName[1];

            ((TextBlock)studentName.Children[0]).Text = firstName;
            ((TextBlock)studentName.Children[1]).Text = lastName;

            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
            }
            // TODO 3.5b: Utwórz listę ocen studenta i wyświetl je przypisując do studentGrades.ItemsSource
        }
    }
}
