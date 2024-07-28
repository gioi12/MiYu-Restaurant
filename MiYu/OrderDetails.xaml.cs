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
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : UserControl
    {
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load("");
        }
        public void Load(string a)
        {
            var ctOrders = MiYuContext.INSTANCE.Orders.Where( x=> x.StatusId == 4 ).Select(x=> new
            {
                Id=x.Id,
                TimeStart=x.TimeStart,
                Price = x.Price,
                EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(x.EmployeeId)).Select(x => x.Name).FirstOrDefault(),
                status = "Processing",
                CustomerName = "Guest",
                TableId = x.TableId,
                TableName = x.Table.Name,
                Floor = x.Table.Floor,
            }).ToList();
            if(a !=null )
            {
                ctOrders = MiYuContext.INSTANCE.Orders.Where(x => x.StatusId == 4 && x.Table.Name.Contains(a)).Select(x => new
                {
                    Id = x.Id,
                    TimeStart = x.TimeStart,
                    Price = x.Price,
                    EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(x.EmployeeId)).Select(x => x.Name).FirstOrDefault(),
                    status = "Processing",
                    CustomerName = "Guest",
                    TableId = x.TableId,
                    TableName = x.Table.Name,
                    Floor = x.Table.Floor,
                }).ToList();
            }
            lvOrders.ItemsSource = ctOrders;
        }

      

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = lvOrders.SelectedItem as dynamic;
            int idTable = selectedOrder.TableId;
            int id = selectedOrder.Id;
            new OrderDetail(idTable, id).Show();
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
        }

        private void txFindTable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load(txFindTable.Text);

        }
    }
}
