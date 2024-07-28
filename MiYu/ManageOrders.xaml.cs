using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiYu
{
    /// <summary>
    /// Interaction logic for ManageOrders.xaml
    /// </summary>
    public partial class ManageOrders : UserControl
    {
        public ManageOrders()
        {
            InitializeComponent();
        }
        public void Load(string a,string b)
        {
            int staId = 4;
            string staName = "Processing";
            if(b.Equals("Cancel")) { staId = 5; staName = "Cancel"; }
            if (b.Equals("Done")) { staId = 3; staName = "Done"; }
            var ctOrders = MiYuContext.INSTANCE.Orders.Where(x => x.StatusId == staId).Select(x => new
            {
                Id = x.Id,
                TimeStart = x.TimeStart,
                Price = x.Price,
                EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(x.EmployeeId)).Select(x => x.Name).FirstOrDefault(),
                status = staName,
                CustomerName = "Guest",
                TableId = x.TableId,
                TableName = x.Table.Name,
                Floor = x.Table.Floor,
            }).ToList();
            if (!a.IsNullOrEmpty())
            {
                ctOrders = MiYuContext.INSTANCE.Orders.Where(x => x.StatusId == staId && x.Table.Name.Contains(a)).Select(x => new
                {
                    Id = x.Id,
                    TimeStart = x.TimeStart,
                    Price = x.Price,
                    EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(x.EmployeeId)).Select(x => x.Name).FirstOrDefault(),
                    status = staName,
                    CustomerName = "Guest",
                    TableId = x.TableId,
                    TableName = x.Table.Name,
                    Floor = x.Table.Floor,
                }).ToList();
            }
            var ctStatus = MiYuContext.INSTANCE.Statuses.Where(x => x.Id == 4 || x.Id == 5 || x.Id == 3).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
            cbStatus.ItemsSource = ctStatus;
            lvOrders.ItemsSource = ctOrders ;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load("","");
        }
        private void txFindTable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load(txFindTable.Text, "");


        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbStatus.SelectedValue;

            if ((int )selectedItem == 4) { Load(txFindTable.Text, "Processing"); }
            if ((int)selectedItem == 5) { Load(txFindTable.Text, "Cancel"); }
            if ((int)selectedItem == 3) { Load(txFindTable.Text, "Done"); }


        }

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = lvOrders.SelectedItem as dynamic;
            int idTable = selectedOrder.TableId;
            int id = selectedOrder.Id;
            var selectedItem = cbStatus.SelectedValue;
            new ManageOrderDetail(idTable, id, (int)selectedItem).Show();
        }
    }
}
