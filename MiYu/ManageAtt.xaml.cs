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
    /// Interaction logic for ManageAtt.xaml
    /// </summary>
    public partial class ManageAtt : UserControl
    {
        public ManageAtt()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load("");
        }
        private void Load(string a)
        {

            var ctAtts1 = MiYuContext.INSTANCE.Attendences.Where(x => x.Date.Date == DateTime.Now.Date).Select(x => new
            {
                Id = x.Id,
                Name = MiYuContext.INSTANCE.Accounts.FirstOrDefault(y => y.Id == x.EmployeeId).Name,

                Position = "Employee",
                Date = x.Date,
                StatusName = (x.StatusId == 7 ? "Present" : "Absent"),
            }).ToList();
            var ctAtts2 = MiYuContext.INSTANCE.Attendences.Select(x => new
            {
                Id = x.Id,
                Name = MiYuContext.INSTANCE.Accounts.FirstOrDefault(y=>y.Id == x.EmployeeId).Name,
                Position = "Employee",
                Date = x.Date,
                StatusName = (x.StatusId == 7 ? "Present" : "Absent"),
            }).ToList();
            if (a != null)
            {
                ctAtts2 = MiYuContext.INSTANCE.Attendences.Where(x => x.Date.ToString().Contains(a)).Select(x => new
                {
                    Id = x.Id,
                    Name = MiYuContext.INSTANCE.Accounts.FirstOrDefault(y => y.Id == x.EmployeeId).Name,

                    Position = "Employee",
                    Date = x.Date,
                    StatusName = (x.StatusId == 7 ? "Present" : "Absent"),
                }).ToList();
            }
            lvAtt1.ItemsSource = ctAtts1;
            lvAtt2.ItemsSource = ctAtts2;

        }

        private void txFindName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load(txFindName.Text);
        }
    }
}
