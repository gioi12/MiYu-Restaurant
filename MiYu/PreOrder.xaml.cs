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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MiYu
{
    /// <summary>
    /// Interaction logic for PreOrder.xaml
    /// </summary>
    public partial class PreOrder : UserControl
    {
        public PreOrder()
        {
            InitializeComponent();
        }
        public string emID { get; set; }

        public PreOrder(string emID) : this()
        {
            this.emID = emID;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
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
            lvTablesOrder.ItemsSource = tables;

            var ctBookings = MiYuContext.INSTANCE.Bookings.Where(x => x.StatusId == 9).Select(x => new
            {
                Id=x.Id,
                Name=x.Name,
                Time =x.Time,
                Number = x.Number,
                StatusName = "Waiting",
                EmployeeName = MiYuContext.INSTANCE.Accounts.Where(y => y.Id.Equals(emID)).Select(x => x.Name).FirstOrDefault(),

                TableName = MiYuContext.INSTANCE.BookingOrders.Where(y => y.BookingId == x.Id).Select(x => x.Table.Name).FirstOrDefault(),
                TableId = MiYuContext.INSTANCE.BookingOrders.Where(y => y.BookingId == x.Id).Select(x => x.TableId).FirstOrDefault(),
                Floor = MiYuContext.INSTANCE.BookingOrders.Where(y => y.BookingId == x.Id).Select(x => x.Table.Floor).FirstOrDefault(),
            }).ToList();
            lvTables.ItemsSource = ctBookings;
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            if(txName.Text != null && txNumber.Text != null && dtTime.Text != null)
            {
                try
                {
                    Booking b = new Booking()
                    {
                        Name = txName.Text,
                        Number = int.Parse(txNumber.Text),
                        Time = dtTime.Value,
                        StatusId = 9,
                        EmployeeId = emID,
                    };
                    MiYuContext.INSTANCE.Bookings.Add(b);             
                    MiYuContext.INSTANCE.SaveChanges();
                    int boID = MiYuContext.INSTANCE.Bookings
                    .Where(x => x.Name == txName.Text && x.Number == int.Parse(txNumber.Text) &&
                    x.Time == dtTime.Value && x.StatusId == 9 && x.EmployeeId == emID)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                    BookingOrder bo = new BookingOrder()
                    {
                        BookingId = boID,
                        TableId = int.Parse(txID.Text),
                    };
                     MiYuContext.INSTANCE.BookingOrders.Add(bo);
                    MiYuContext.INSTANCE.SaveChanges();
                    Load(1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Input wrong ");
                }
            }
            else
            {
                MessageBox.Show("Enter full information");
            }
        }

        private void arrived_Click(object sender, RoutedEventArgs e)
        {
            var b = lvTables.SelectedItem as dynamic;
            int bookingId = b.Id;
            Booking booking = MiYuContext.INSTANCE.Bookings.Find(bookingId);
            booking.StatusId = 3;
            MiYuContext.INSTANCE.Bookings.Update(booking);
            MiYuContext.INSTANCE.SaveChanges();
            MessageBox.Show("Successfully");
            Load(1);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            var b = lvTables.SelectedItem as dynamic;
            int bookingId = b.Id;
            Booking booking = MiYuContext.INSTANCE.Bookings.Find(bookingId);
            booking.StatusId = 5;
            MiYuContext.INSTANCE.Bookings.Update(booking);
            MiYuContext.INSTANCE.SaveChanges();
            MessageBox.Show("Cancel Successfully");
            Load(1);
        }
        private void cbFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = cbFloor.SelectedValue;
            Load((int)id);
        }

    }
}
