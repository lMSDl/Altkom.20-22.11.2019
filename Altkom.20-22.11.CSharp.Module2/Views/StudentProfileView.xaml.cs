using Altkom._20_22._11.CSharp.Module2.Controls;
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//TODO 10.2a: Dodaj przestrzeń nazw Newtonsoft.Json

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

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (SessionContext.UserRole != Role.Teacher)
            {
                return;
            }

            try
            {
                var gd = new GradeDialog();

                if (gd.ShowDialog().Value)
                {
                    var newGrade = new Grade
                    {
                        AssessmentDate = gd.assessmentDate.SelectedDate.Value.ToString("d"),
                        SubjectName = gd.subject.SelectedValue.ToString(),
                        Assessment = gd.assessmentGrade.Text,
                        Comments = gd.comments.Text
                    };

                    DataSource.Grades.Add(newGrade);

                    SessionContext.CurrentStudent.AddGrade(newGrade);

                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding assessment grade", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (SessionContext.UserRole != Role.Teacher)
            {
                return;
            }

            try
            {
                var message = $"Remove {SessionContext.CurrentStudent.FirstName} {SessionContext.CurrentStudent.LastName}";
                var reply = MessageBox.Show(message, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (reply == MessageBoxResult.Yes)
                {
                    SessionContext.CurrentTeacher.RemoveFromClass(SessionContext.CurrentStudent);

                    Back?.Invoke(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error removing student from class", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //TODO 10.1: Pobierz listę ocen aktualnie wybranego studenta

                //TODO 10.2b: Przeprowadź serializację do JSON

                //TODO 10.3a: Pokaż raport w postaci MessageBox i zadaj pytanie użytkownikowi czy chce zapisać raport 



                    var dialog = new SaveFileDialog
                    {
                        Filter = "JSON documents|*.json",
                        FileName = "Grades",
                        DefaultExt = ".json"
                    };
                //TODO 10.3b: Pokaż SaveFileDialog i zapisz rezultat do zmiennej lokalnej

                //TODO 10.3c: W przypadku pozytywnej odpowiedzi, zapisz raport do pliku używająć FileStream

                //TODO 10.3d: Zwolnij zasoby klasy strumieniowej

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Generating Report", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Refresh()
        {
            studentName.DataContext = SessionContext.CurrentStudent;

            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
                btnRemove.Visibility = Visibility.Hidden;
                btnAddGrade.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
                btnAddGrade.Visibility = Visibility.Visible;
            }

            studentGrades.ItemsSource = from Grade g in DataSource.Grades
                                        where g.StudentID == SessionContext.CurrentStudent.StudentID
                                        select g;
        }

        private void LoadReport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
