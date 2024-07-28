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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
        }

        public string emID { get; set; }
       
        public OrderView(string emID) : this()
        {
            this.emID = emID;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load(1);
        }
        public void Load(int floorId)
        {
            var floors = MiYuContext.INSTANCE.Tables.Select(t => new { Id = t.Floor, Name = "Floor " + t.Floor }).Distinct().ToList();
            cbFloor.ItemsSource = floors;

            var tables = MiYuContext.INSTANCE.Tables
                .Where(x => x.Floor == floorId)
                .Select(x => new
                {
                    Name = x.Name,
                    Id = x.Id,
                    Floor = x.Floor,
                    StatusTable = MiYuContext.INSTANCE.Orders
                        .Where(y => y.TableId == x.Id && y.StatusId == 4)
                        .Select(y => new
                        {
                            Status = new Status()
                            {
                                Name = y.Status.Name,
                                Id = y.Status.Id,
                            }
                        })
                        .FirstOrDefault() ?? MiYuContext.INSTANCE.BookingOrders
                        .Where(y => y.TableId == x.Id && y.Booking.StatusId == 9)
                        .Select(y => new
                        {
                            Status = new Status()
                            {
                                Name = y.Booking.Status.Name,
                                Id = y.Booking.Status.Id,
                            }
                        })
                        .FirstOrDefault(),
                })
                .ToList();
            lvTables.ItemsSource = tables;
        }

        private void cbFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = cbFloor.SelectedValue;
            Load((int)id);
        }

        private void btOrderTable_Click(object sender, RoutedEventArgs e)
        {
            if (cbFloor.SelectedValue == null)
            {
                MessageBox.Show("Please select a floor.");
                return;
            }

            if (!int.TryParse(cbFloor.SelectedValue.ToString(), out int idFloor))
            {
                MessageBox.Show("Invalid floor selection.");
                return;
            }

            if (!int.TryParse(txIdTable.Text, out int idTable))
            {
                MessageBox.Show("Invalid table ID.");
                return;
            }

            var StatusTable = MiYuContext.INSTANCE.Orders
                .Where(y => y.TableId == idTable && y.StatusId == 4)
                .Select(y => new { y.Id })
                .FirstOrDefault();

            if (StatusTable == null)
            {
                if (emID == null)
                {
                    MessageBox.Show("Employee ID is not set.");
                    return;
                }

                DateTime daynow = DateTime.Now;
                Order newOrder = new Order()
                {
                    TimeStart = daynow,
                    TimeEnd = daynow,
                    StatusId = 4,
                    TableId = idTable,
                    EmployeeId = emID
                };

                MiYuContext.INSTANCE.Orders.Add(newOrder);
                MiYuContext.INSTANCE.SaveChanges();
                Load(idFloor);

            }
            else
            {
                var ctOrder = MiYuContext.INSTANCE.Orders.Where(x => x.TableId == idTable && x.StatusId == 4).FirstOrDefault();
                new OrderDetail(idTable,ctOrder.Id).Show();
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.Close();
                }
            }

        }

    }
}
