using Altkom._20_22._11.CSharp.Module2.Controls;
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

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
                var grades = DataSource.Grades.Where(g => g.StudentID == SessionContext.CurrentStudent.StudentID).ToList();
                var output = JsonConvert.SerializeObject(grades, Newtonsoft.Json.Formatting.Indented);
                
                var reply = MessageBox.Show(output, "Save Report?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (reply == MessageBoxResult.Yes)
                {
                    var dialog = new SaveFileDialog
                    {
                        Filter = "JSON documents|*.json|XML documents|*.xml",
                        FileName = "Grades"
                    };
                    var result = dialog.ShowDialog();

                    if (result.HasValue && result.Value)
                    {
                        if(dialog.FileName.EndsWith(".xml"))
                            output = JsonConvert.DeserializeXNode("{\"Grade\": " + output + " }", "Grades").ToString();

                        var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.Write);
                        using (var streamWriter = new StreamWriter(file))
                                streamWriter.Write(output);
                    }
                }
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
            var dialog = new OpenFileDialog();
            dialog.Filter = "JSON documents|*.json|XML documents|*.xml";
            bool? result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                string gradesAsJson;
                if (dialog.FileName.EndsWith(".xml")) {
                    var xml = new XmlDocument();
                    xml.LoadXml(File.ReadAllText(dialog.FileName));
                    gradesAsJson = JsonConvert.SerializeXmlNode(xml, Newtonsoft.Json.Formatting.Indented, true);
                    var indexOfStart = gradesAsJson.IndexOf('[');
                    var indexOfEnd = gradesAsJson.IndexOf(']');
                    gradesAsJson = gradesAsJson.Substring(indexOfStart, indexOfEnd - indexOfStart + 1);
                }
                else
                    gradesAsJson = File.ReadAllText(dialog.FileName);
                var gradeList = JsonConvert.DeserializeObject<List<Grade>>(gradesAsJson);
                studentGrades.ItemsSource = gradeList;
            }
        }
    }
}
