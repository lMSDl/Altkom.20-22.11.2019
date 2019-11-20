
using Altkom._20_22._11.CSharp.Module2.Models;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Altkom._20_22._11.CSharp.Module2.Views
{
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        public event EventHandler LogInSuccess;
        public event EventHandler LogInFailed;

        private void LogIn_Click(object sender, EventArgs e)
        {
            //TODO 4.2a: Wykorzystaj metodę VerifyPassword z klasy Teacher do autoryzacji
            var teacher = (from Teacher t in DataSource.Teachers
                           where string.Compare(t.UserName, username.Text) == 0
                           && string.Compare(t.Password, password.Password) == 0
                           select t).FirstOrDefault();

            //TODO 4.2b: Sprawdź czy obiekt jest różny od null
            if (!string.IsNullOrEmpty(teacher.UserName))
            {
                SessionContext.UserID = teacher.TeacherID;
                SessionContext.UserRole = Role.Teacher;
                SessionContext.CurrentTeacher = teacher;

                LogInSuccess(this, null);
                return;
            }
            else
            {
                //TODO 4.3a: Wykorzystaj metodę VerifyPassword z klasy Student do autoryzacji
                var student = (from Student s in DataSource.Students
                               where string.Compare(s.UserName, username.Text) == 0
                               && string.Compare(s.Password, password.Password) == 0
                               select s).FirstOrDefault();

                //TODO 4.3b: Sprawdź czy obiekt jest różny od null
                if (!string.IsNullOrEmpty(student.UserName))
                {
                    SessionContext.UserID = student.StudentID;
                    SessionContext.UserRole = Role.Student;
                    SessionContext.CurrentStudent = student;

                    LogInSuccess(this, null);
                    return;
                }
            }

            LogInFailed(this, null);
        }
    }
}
