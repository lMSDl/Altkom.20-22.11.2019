using Altkom._20_22._11.CSharp.Module2.Models;
using Altkom._20_22._11.CSharp.Module2.Services;
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
            var splittedName = SessionContext.UserName.Split(' ');

            ((TextBlock)studentName.Children[0]).Text = splittedName[0];
            ((TextBlock)studentName.Children[1]).Text = splittedName[1];

            btnBack.Visibility = SessionContext.UserRole == Role.Student ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
