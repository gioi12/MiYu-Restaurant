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
    /// Interaction logic for ManageMenu.xaml
    /// </summary>
    public partial class ManageMenu : UserControl
    {
        public ManageMenu()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            var ctMenu = MiYuContext.INSTANCE.Menus.Select(x => new
            {
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                Description = x.Description,

            }).ToList();
            lvMenus.ItemsSource = ctMenu;
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txName.Text) || string.IsNullOrEmpty(txPrice.Text))
            {
                MessageBox.Show("Name and Price cannot be empty.");
                return;
            }

            try
            {
                Models.Menu menu = new Models.Menu()
                {
                    Name = txName.Text,
                    Description = txDes.Text, 
                    Price = decimal.Parse(txPrice.Text),
                };

                MiYuContext.INSTANCE.Menus.Add(menu);
                MiYuContext.INSTANCE.SaveChanges();

                MessageBox.Show("Successfully added.");
                Load();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid price format.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add menu: {ex.Message}");
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var menu = lvMenus.SelectedItem as dynamic;
            if (menu == null)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            Models.Menu menuUpdate = MiYuContext.INSTANCE.Menus.Find(menu.Id);
            if (menuUpdate == null)
            {
                MessageBox.Show("Menu item not found.");
                return;
            }

            if (!string.IsNullOrEmpty(txName.Text) && !string.IsNullOrEmpty(txPrice.Text))
            {
                try
                {
                    menuUpdate.Name = txName.Text;
                    menuUpdate.Description = txDes.Text;
                    menuUpdate.Price = decimal.Parse(txPrice.Text);

                    MiYuContext.INSTANCE.Menus.Update(menuUpdate);
                    MiYuContext.INSTANCE.SaveChanges();

                    MessageBox.Show("Successfully updated.");
                    Load();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid price format.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update failed: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Name or Price cannot be empty.");
            }
        }

        private void Delelte_Click(object sender, RoutedEventArgs e)
        {
            var menu = lvMenus.SelectedItem as dynamic;

            if (menu == null)
            {
                MessageBox.Show("No item selected.");
                return;
            }

            Models.Menu menuToDelete = MiYuContext.INSTANCE.Menus.Find(menu.Id);

            if (menuToDelete != null)
            {
                MiYuContext.INSTANCE.Menus.Remove(menuToDelete);
                MiYuContext.INSTANCE.SaveChanges();
                MessageBox.Show("Successfully deleted.");
                Load();
            }
            else
            {
                MessageBox.Show("Item not found.");
            }
        }
    }
}
