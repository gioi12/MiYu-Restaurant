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
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        public string emID { get; set; }
        public EmployeeView()
        {
            InitializeComponent();


        }
        public EmployeeView(string ID) : this()
        {
            emID = ID;
        }

        private void Button_Click_Table(object sender, RoutedEventArgs e)
        {
            ContainerEmployee.Child = new OrderView(emID);
        }

        private void Button_Click_Order(object sender, RoutedEventArgs e)
        {
            ContainerEmployee.Child = new OrderDetails();
        }

        private void profile_Click(object sender, RoutedEventArgs e)
        {
            ContainerEmployee.Child = new ProfileEmployee(emID);
        }

        private void Button_Click_att(object sender, RoutedEventArgs e)
        {
            ContainerEmployee.Child = new AttendenceView(emID);
        }

        private void PreOrder_Click(object sender, RoutedEventArgs e)
        {
            ContainerEmployee.Child = new PreOrder(emID);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
          String  EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(emID)).Select(x => x.Name).FirstOrDefault();
            String[] arr = EmployeeName.Split(" ");
            lbhello.Content = "Hello "+ arr[arr.Length - 1];
            ContainerEmployee.Child = new OrderView(emID);
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new Account().Show();
            this.Close();
        }
    }
}
