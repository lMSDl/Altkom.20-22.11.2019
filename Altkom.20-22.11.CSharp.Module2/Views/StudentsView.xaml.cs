using System;
using System.Windows;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class StudentsView : UserControl
    {
        public StudentsView()
        {
            InitializeComponent();
        }

        // TODO 3.4a: Wyśwetl studentów zalogowanego nauczyciela
        public void Refresh()
        {
            txtClass.Text = "3A";
        }
        
        public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        public event StudentSelectionHandler StudentSelected;

        // TODO 3.4c: Pobierz obiekt studenta z kontekstu przycisku (itemClicked.DataContext)
        private void Student_Click(object sender, RoutedEventArgs e)
        {
            var itemClicked = sender as Button;
            if (itemClicked != null)
            {
                string studentName = (string)itemClicked.Tag;
                StudentSelected?.Invoke(sender, new StudentEventArgs(studentName));
            }
        }
    }

    //TODO 3.4b: Zmień właściwość argumentów zdarzenia na typ Student
    public class StudentEventArgs : EventArgs
    {
        public string Name { get; set; }

        public StudentEventArgs(string @string)
        {
            Name = @string;
        }
    }
}

