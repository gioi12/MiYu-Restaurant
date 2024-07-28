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
    /// Interaction logic for AttendenceView.xaml
    /// </summary>
    public partial class AttendenceView : UserControl
    {
        public AttendenceView()
        {
            InitializeComponent();
        }
        public string emID { get; set; }

        public AttendenceView(string emID) : this()
        {
            this.emID = emID;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load("");
        }
        private void Load(string a)
        {
            var ctInfo = MiYuContext.INSTANCE.Accounts.FirstOrDefault(x => x.Id == this.emID);
            var ctAttEm = MiYuContext.INSTANCE.Attendences.FirstOrDefault(x => x.EmployeeId == this.emID && x.Date.Date == DateTime.Now.Date && x.StatusId == 7);
            EmName.Content = "NAME : " + ctInfo.Name;
            EmPosition.Content = "POSITION : " + (ctInfo.RoleId == 1 ? "Employee" : "None");
            if(ctAttEm != null)
            {
                EmAtt.Content = "Today Attendence : " + (ctAttEm.StatusId == 7 ? "Present" : "Absent");

            }
            else
            {
                EmAtt.Content = "Today Attendence : Absent";
            }
            var ctAtts = MiYuContext.INSTANCE.Attendences.Where(x => x.EmployeeId == emID).Select(x=> new
            {
                Id =x.Id,
                Date = x.Date,
                StatusName = (x.StatusId == 7 ? "Present" : "Absent") ,
            }).ToList();
            if (a != null)
            {
                ctAtts = MiYuContext.INSTANCE.Attendences.Where(x => x.EmployeeId == emID && x.Date.ToString().Contains(a)).Select(x => new
                {
                    Id = x.Id,
                    Date = x.Date,
                    StatusName = (x.StatusId == 7 ? "Present" : "Absent"),
                }).ToList();
            }

            lvAtt.ItemsSource = ctAtts;
        }
        private void btPresent_Click(object sender, RoutedEventArgs e)
        {
            var ctAttEm = MiYuContext.INSTANCE.Attendences.FirstOrDefault(x => x.EmployeeId == this.emID && x.Date.Date == DateTime.Now.Date && x.StatusId == 7);
            if(ctAttEm == null)
            {
                DateTime now = DateTime.Now;

                TimeSpan start1 = new TimeSpan(10, 0, 0); // 10:00 AM
                TimeSpan end1 = new TimeSpan(14, 0, 0);   // 2:00 PM
                TimeSpan start2 = new TimeSpan(19, 0, 0);  // 7:00 AM
                TimeSpan end2 = new TimeSpan(22, 0, 0);   // 10:00 PM

                TimeSpan currentTime = now.TimeOfDay;

                if ((currentTime >= start1 && currentTime <= end1) || (currentTime >= start2 && currentTime <= end2))
                {

                    Attendence att = new Attendence()
                    {
                        EmployeeId = this.emID,
                        Date = DateTime.Now,
                        StatusId = 7,
                        Description = "Present successfully"
                    };
                    MiYuContext.INSTANCE.Attendences.Add(att);
                    MiYuContext.INSTANCE.SaveChanges();
                    Load("");
                }
                else
                {
                    MessageBox.Show("Out Of Time");
                }

            }
            else
            {
                MessageBox.Show("Today alreday attendece");
            }
        }

        private void txFindTable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load(txFindDay.Text);
        }

        
    }
}
