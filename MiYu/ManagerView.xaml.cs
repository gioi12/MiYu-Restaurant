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
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public string emID { get; set; }
        public ManagerView(string ID) : this()
        {
            emID = ID;
        }
        public ManagerView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            String EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(emID)).Select(x => x.Name).FirstOrDefault();
            String[] arr = EmployeeName.Split(" ");
            lbhello.Content = "Hello " + arr[arr.Length - 1];
            ContainerManager.Child = new ManageOrders();
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new Account().Show();
            this.Close();
        }

        private void order_Click(object sender, RoutedEventArgs e)
        {
            ContainerManager.Child = new ManageOrders();

        }

        private void Tables_Click(object sender, RoutedEventArgs e)
        {
            ContainerManager.Child = new ManageTable();
        }

        private void Attendence_Click(object sender, RoutedEventArgs e)
        {
            ContainerManager.Child = new ManageAtt();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ContainerManager.Child = new ManageMenu();
        }
    }
}
