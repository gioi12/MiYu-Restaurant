using MiYu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    /// Interaction logic for OrderDetail.xaml
    /// </summary>
    public partial class OrderDetail : Window
    {
        public int TableID {  get; set; }
        public int OrderID {  get; set; }
        public OrderDetail()
        {
            InitializeComponent();
        }
        public OrderDetail(int TableID, int orderID) : this()
        {
            this.TableID = TableID;
            this.OrderID = orderID;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load(TableID);
        }
        public void Load(int TableID)
        {
            var ctOrder = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID && x.StatusId == 4).Select(x => new
            {
                Id = x.Id,
                Timestart = x.TimeStart,
                TimeEnd = x.TimeEnd,
                CurstomerId = x.CustormerId,
                EmployeeName = MiYuContext.INSTANCE.Accounts.Where( y => y.Id.Equals(x.EmployeeId)).Select( x => x.Name).FirstOrDefault(),
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
            lbEnd.Content = $"End Time : ";
            lbVoucher.Content = $"VoucherID : {ctOrder.VoucherId}";
            lbTotal.Content = $"Total Price : {ctOrder.Price}";
            txStatusOrder.Text = ctOrder.Status.Name;
            var ctMenu = MiYuContext.INSTANCE.Menus.Select( x=> new
            {
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                Description = x.Description,

            }).ToList();
            lvMenus.ItemsSource = ctMenu;
            var ctOrderMenu = MiYuContext.INSTANCE.OrderMenus.Where(x => x.OrderId == this.OrderID).Select(x => new
            {
                Id= x.Id,
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

        private void Button_Click_AddMenu(object sender, RoutedEventArgs e)
        {
            var selectedMenu = lvMenus.SelectedItem as dynamic;
            int MenuId = selectedMenu.Id;
            OrderMenu menu = MiYuContext.INSTANCE.OrderMenus
                                      .FirstOrDefault(m => m.OrderId == this.OrderID && m.MenuId == MenuId);
            decimal priceMenu = MiYuContext.INSTANCE.Menus.Where(x => x.Id == MenuId).Select(x => x.Price).FirstOrDefault();
            Order order = MiYuContext.INSTANCE.Orders.Find(this.OrderID);
            if (menu != null)
            {
                menu.Quantity++;
                order.Price += priceMenu;
                MiYuContext.INSTANCE.OrderMenus.Update(menu);
                MiYuContext.INSTANCE.Orders.Update(order);
                MiYuContext.INSTANCE.SaveChanges();
                Load(TableID);
            }
            else
            {
                OrderMenu orderMenus = new OrderMenu()
                {
                    OrderId = this.OrderID,
                    MenuId = MenuId,
                    Quantity = 1,
                };
                order.Price += priceMenu;
                MiYuContext.INSTANCE.OrderMenus.Add(orderMenus);
                MiYuContext.INSTANCE.Orders.Update(order);

                MiYuContext.INSTANCE.SaveChanges();
                Load(TableID);
            }
                                               
        }

        private void btDeleteFood_Click(object sender, RoutedEventArgs e)
        {
            var foods = lvFoods.SelectedItem as dynamic;
            int OrdeMenuId = foods.Id;
            int MenuId = 0;
            try
            {
                 MenuId = foods.Food.Id;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose food");
            }

            OrderMenu menu = MiYuContext.INSTANCE.OrderMenus
                                      .FirstOrDefault(m => m.Id == OrdeMenuId);

            decimal priceMenu = MiYuContext.INSTANCE.Menus.Where(x => x.Id == MenuId).Select(x => x.Price).FirstOrDefault();
            
            Order order = MiYuContext.INSTANCE.Orders.Find(this.OrderID);
            if (foods != null)
            {
                menu.Quantity = menu.Quantity - 1;
                order.Price -= priceMenu;
                if(menu.Quantity <= 0)
                {
                    MiYuContext.INSTANCE.OrderMenus.Remove(menu);
                }
                else
                {
                    MiYuContext.INSTANCE.OrderMenus.Update(menu);
                    MiYuContext.INSTANCE.Orders.Update(order);
                }
              
                MiYuContext.INSTANCE.SaveChanges();
                Load(TableID);
            }
            else
            {
                MessageBox.Show("Please choose food");
            }
        }

        private void btPayments_Click(object sender, RoutedEventArgs e)
        {
           
            MessageBoxResult result = MessageBox.Show("Have order Done?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                exportBill();

                Order order = MiYuContext.INSTANCE.Orders.Find(this.OrderID);
                order.StatusId = 3;
                order.TimeEnd = DateTime.Now;
                MiYuContext.INSTANCE.Orders.Update(order);
                MiYuContext.INSTANCE.SaveChanges();

                MessageBox.Show("successfully.", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                /*   var EmID = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID).Select(x => new
                   {
                       Id = x.EmployeeId
                   }).FirstOrDefault();*/
                var EmID = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID).Select(x => new
                {
                    Id = x.EmployeeId
                }).FirstOrDefault();
                new EmployeeView(EmID.Id).Show();


                this.Close();

            }

        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to CANCEL order?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Order order = MiYuContext.INSTANCE.Orders.Find(this.OrderID);
                order.StatusId = 5;
                order.TimeEnd = DateTime.Now;
                MiYuContext.INSTANCE.Orders.Update(order);
                MiYuContext.INSTANCE.SaveChanges();

                MessageBox.Show("Order cancel successfully.", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                var EmID = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID).Select(x => new
                {                
                    Id = x.EmployeeId
                }).FirstOrDefault();
                new EmployeeView(EmID.Id).Show();

                this.Close();
                
            }
            
        }
        private void exportBill()
        {
            var ctOrder = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID && x.StatusId == 4).Select(x => new
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

            try
            {
                // Tạo hoặc mở file và ghi nội dung vào file
                using (StreamWriter writer = new StreamWriter(@"C:\Users\ACER\Documents\CS\MiYu\MiYu\bin\Bill.txt"))
                {
                    writer.Write("------New Bill-------\n");
                    writer.Write($"Customer   : Guest\n");
                    writer.Write($"Employee   : {ctOrder.EmployeeName}\n");
                    writer.Write($"Start Time : {ctOrder.Timestart}\n");
                    writer.Write($"End Time   : {ctOrder.TimeEnd}\n");
                    writer.Write($"Name".PadRight(30) + "Quantity".PadRight(10) + "Price".PadRight(10) + "\n");
                    foreach (var item in ctOrderMenu)
                    {
                        writer.Write($"{item.Food.Name,-30} {item.Quantity,-10} {item.Food.Price,-10}\n");
                    }
                    writer.Write($"\n");
                    writer.Write($"Total Price: {ctOrder.Price}\n");
                    writer.Write("-------------------\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var EmID = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == TableID).Select(x => new
            {
                Id = x.EmployeeId
            }).FirstOrDefault();
            new EmployeeView(EmID.Id).Show();
            this.Close();
        }
    }
}
