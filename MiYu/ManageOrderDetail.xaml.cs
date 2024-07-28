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
    /// Interaction logic for ManageOrderDetail.xaml
    /// </summary>
    public partial class ManageOrderDetail : Window
    {
        public ManageOrderDetail()
        {
            InitializeComponent();
        }
        public int TableID { get; set; }
        public int OrderID { get; set; }
       public int StatusId {  get; set; }
        public ManageOrderDetail(int TableID, int orderID, int statusId) : this()
        {
            this.TableID = TableID;
            this.OrderID = orderID;
            StatusId = statusId;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load(TableID);
        }
        public void Load(int TableID)
        {
            var ctOrder = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID && x.StatusId == this.StatusId).Select(x => new
            {
                Id = x.Id,
                Timestart = x.TimeStart,
                TimeEnd = x.TimeEnd,
                CurstomerId = x.CustormerId,
                EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(x.EmployeeId)).Select(x => x.Name).FirstOrDefault(),
                Price = x.Price,
                VoucherId = x.VoucherId,
                Status = new Status()
                {
                    Name = x.Status.Name,
                    Id = x.Status.Id,
                }
            }).FirstOrDefault();
            lbTable.Content = $"Table : {TableID}";
            lbEm.Content = $"EmployeeName: {ctOrder.EmployeeName}";
            lbId.Content = $"Id : {ctOrder.Id}";
            lbStart.Content = $"Start Time : {ctOrder.Timestart}";
            lbEnd.Content = $"End Time :  {ctOrder.TimeEnd}";
            lbVoucher.Content = $"VoucherID : {ctOrder.VoucherId}";
            lbTotal.Content = $"Total Price : {ctOrder.Price}";
            txStatusOrder.Text = ctOrder.Status.Name;
            
            var ctOrderMenu = MiYuContext.INSTANCE.OrderMenus.Where(x => x.OrderId == this.OrderID).Select(x => new
            {
                Id = x.Id,
                Food = new Models.Menu()
                {
                    Id = x.Menu.Id,
                    Name = x.Menu.Name,
                    Price = x.Menu.Price * x.Quantity,
                },
                Quantity = x.Quantity,
            }).ToList();
            lvFoods.ItemsSource = ctOrderMenu;
        }
    }
}
