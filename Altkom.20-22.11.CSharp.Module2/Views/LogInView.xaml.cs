
using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
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

        private async void LogIn_Click(object sender, EventArgs e)
        {

            var user = await new UserService().GetUserAsync(username.Text, password.Password);

            if (user != null)
            {
                SessionContext.UserID = user.UserId;
                SessionContext.CurrentStudent = user.Student;
                SessionContext.CurrentTeacher = user.Teacher;
                SessionContext.UserRole = SessionContext.CurrentTeacher != null ? Role.Teacher : Role.Student;
                LogInSuccess(this, null);
            }
            else
                LogInFailed(this, null);


            //var teacher = (from Teacher t in DataSource.Teachers
            //               where string.Compare(t.UserName, username.Text) == 0
            //               && t.VerifyPassword(password.Password)
            //               select t).FirstOrDefault();

            //if (!string.IsNullOrEmpty(teacher?.UserName))
            //{
            //    SessionContext.UserID = teacher.TeacherID;
            //    SessionContext.UserRole = Role.Teacher;
            //    SessionContext.CurrentTeacher = teacher;

            //    LogInSuccess(this, null);
            //    return;
            //}
            //else
            //{
            //    var student = (from Student s in DataSource.Students
            //                   where string.Compare(s.UserName, username.Text) == 0
            //                   && s.VerifyPassword(password.Password)
            //                   select s).FirstOrDefault();

            //    if (student != null && !string.IsNullOrEmpty(student.UserName))
            //    {
            //        SessionContext.UserID = student.StudentID;
            //        SessionContext.UserRole = Role.Student;
            //        SessionContext.CurrentStudent = student;

            //        LogInSuccess(this, null);
            //        return;
            //    }
            //}
            //LogInFailed(this, null);

        }
    }
}
