using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
using System;
using System.Windows;

namespace Altkom._20_22._11.CSharp.Module2.Controls
{
    public partial class GradeDialog : Window
    {
        public GradeDialog()
        {
            InitializeComponent();
        }

        private void GradeDialog_Loaded(object sender, RoutedEventArgs e)
        {
            subject.ItemsSource = DataSource.Subjects;

            assessmentDate.SelectedDate = DateTime.Now;
            subject.SelectedValue = subject.Items[0];
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var testGrade = new Grade(assessmentDate.SelectedDate.Value.ToString("d"), subject.SelectedValue.ToString(), assessmentGrade.Text, comments.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error creating assessment", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

    }
}
