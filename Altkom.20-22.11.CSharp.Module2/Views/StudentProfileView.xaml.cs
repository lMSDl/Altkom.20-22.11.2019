using Altkom._20_22._11.CSharp.Module2.Controls;
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
using System;
using System.Linq;
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

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var gd = new GradeDialog();
                if (gd.ShowDialog() == true)
                {
                    var grade = new Grade(
                        gd.assessmentDate.SelectedDate.Value.ToShortDateString(),
                        gd.subject.Text,
                        gd.assessmentGrade.Text,
                        gd.comments.Text
                        );

                    SessionContext.CurrentStudent.AddGrade(grade);
                    DataSource.Grades.Add(grade);
                    Refresh();
                }
            }
            catch (ArgumentException aex) when (aex.ParamName == nameof(Grade))
            {
                MessageBox.Show(aex.Message, "Error adding grade", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
          if(MessageBox.Show($"Remove {SessionContext.CurrentStudent.LastName} {SessionContext.CurrentStudent.FirstName}",
                "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SessionContext.CurrentStudent.TeacherID = 0;
                SessionContext.CurrentTeacher.RemoveFromClass(SessionContext.CurrentStudent);
                Back?.Invoke(sender, EventArgs.Empty);
            }

        }

        public void Refresh()
        {
            studentName.DataContext = SessionContext.CurrentStudent;

            if (SessionContext.UserRole == Role.Student)
            {
                btnBack.Visibility = Visibility.Hidden;
                btnAddGrade.Visibility = Visibility.Hidden;
                btnRemove.Visibility = Visibility.Hidden;
            }
            else
            {
                btnBack.Visibility = Visibility.Visible;
                btnAddGrade.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
            }

            studentGrades.ItemsSource = from Grade g in DataSource.Grades
                                        where g.StudentID == SessionContext.CurrentStudent.StudentID
                                        select g;
        }
    }
}
