using System.Windows;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Controls
{
    public partial class AssignStudentDialog : Window
    {
        public AssignStudentDialog()
        {
            InitializeComponent();
        }

        private void Refresh()
        {
            //TODO 6.3a: Utwórz kolekcję unassignedStudents, która zawiera studentów nieprzypisanych do klasy

            if (unassignedStudents.Count() == 0)
            {
                txtMessage.Visibility = Visibility.Visible;
                list.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtMessage.Visibility = Visibility.Collapsed;
                list.Visibility = Visibility.Visible;

                list.ItemsSource = unassignedStudents;
            }
        }

        private void AssignStudentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            var studentClicked = sender as Button;
            int studentID = (int)studentClicked.Tag;

            //TODO 6.3b: Znajdź studenta o id zapisanym w studentID

            string message = string.Format("Add {0} {1} to your class?", student.FirstName, student.LastName);
            var reply = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (reply == MessageBoxResult.Yes)
            {
                //TODO 6.3c: Przypisz studenta do klasy zalogowanego nauczyciela

                Refresh();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
