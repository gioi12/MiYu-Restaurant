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
    /// Interaction logic for ProfileEmployee.xaml
    /// </summary>
    public partial class ProfileEmployee : UserControl
    {
        public string emID { get; set; }

        public ProfileEmployee(string emID) : this()
        {
            this.emID = emID;
        }
        public ProfileEmployee()
        {
            InitializeComponent();
        }
        public void Load()
        {
            var ctInfo = MiYuContext.INSTANCE.Accounts.FirstOrDefault(x => x.Id == this.emID);
            EmId.Content = "ID : " +ctInfo.Id;
            EmName.Content = "NAME : " +ctInfo.Name;
            emDate.Content = "DATE OF BIRTH : " + ctInfo.Dob.ToString("dd/MM/yyyy");
            EmGender.Content = "GENDER : " + ((bool)ctInfo.Gender ? "Male" : "Female");
            EmPhone.Content ="Phone : " + ctInfo.Phone;
            EmMail.Content = "MAIL : " +ctInfo.Mail;
            EmAddress.Content = "ADDRESS : " + ctInfo.Address;
            EmPosition.Content = "POSITION : " +( ctInfo.RoleId == 1 ? "Employee" : "None");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
