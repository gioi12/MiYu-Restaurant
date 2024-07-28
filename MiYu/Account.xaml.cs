using MiYu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MiYu
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        public Account()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Enter the username")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (textBox.Text == "Enter the password")
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter the username";
                textBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(pass.Password))
            {
                passwordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var acc = MiYuContext.INSTANCE.Accounts.Where(x => x.Username == user.Text && x.Password == pass.Password).Select(x => new
            {
                Id = x.Id,
                Status = x.StatusId,
                Role = x.RoleId,
            }).FirstOrDefault();
            if (acc != null)
            {
                if (acc.Status == 1 && acc.Role == 1)
                {
                    EmployeeView employeeView = new EmployeeView(acc.Id);

                    employeeView.Show();
                    Window currentWindow = Window.GetWindow(this);
                    if (currentWindow != null)
                    {
                        currentWindow.Close();
                    }
                }
                if (acc.Status == 1 && acc.Role == 3)
                {
                    ManagerView employeeView = new ManagerView(acc.Id);

                    employeeView.Show();
                    Window currentWindow = Window.GetWindow(this);
                    if (currentWindow != null)
                    {
                        currentWindow.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Username or password wrong");
            }
        }
    }

}
