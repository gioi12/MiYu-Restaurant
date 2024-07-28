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
    /// Interaction logic for ManageTable.xaml
    /// </summary>
    public partial class ManageTable : UserControl
    {
        public ManageTable()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load(1);

        }
        public void Load(int floorId)
        {
            var floors = MiYuContext.INSTANCE.Tables.Select(t => new { Id = t.Floor, Name = "Floor " + t.Floor }).Distinct().ToList();
            cbFloor.ItemsSource = floors;
            var tables = MiYuContext.INSTANCE.Tables.Where(x => x.Floor == floorId).Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Floor = x.Floor,
                StatusTable = MiYuContext.INSTANCE.Orders.Where(y => y.TableId == x.Id && y.StatusId == 4).Select(y => new
                {
                    Status = new Status()
                    {
                        Name = y.Status.Name,
                        Id = y.Status.Id,
                    }
                })
               .FirstOrDefault(),
            }).ToList();
            lvTables.ItemsSource = tables;
        }

        private void cbFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = cbFloor.SelectedValue;
            Load((int)id);
        }
    }
}
