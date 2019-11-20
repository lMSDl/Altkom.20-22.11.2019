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

        public void Refresh()
        {
            txtClass.Text = "3A";
        }
        
        public delegate void StudentSelectionHandler(object sender, StudentEventArgs e);
        public event StudentSelectionHandler StudentSelected;
        
        // TODO: 1.4a: Obsłuż kliknięcie w przycik studenta. Podnieś zdarzenie StudentSelected  i przekaż informację, który student został wybrany. Informację tę można odczytać z właściwości Tag nadawcy zdarzenia.
        private void Student_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class StudentEventArgs : EventArgs
    {
        public string Name { get; set; }

        public StudentEventArgs(string @string)
        {
            Name = @string;
        }
    }
}

