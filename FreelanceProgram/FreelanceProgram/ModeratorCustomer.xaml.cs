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

namespace FreelanceProgram
{
    /// <summary>
    /// Логика взаимодействия для ModeratorCustomer.xaml
    /// </summary>
    public partial class ModeratorCustomer : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorCustomer()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.Customers.ToList();
            UserCbx.ItemsSource = context.UserTables.ToList();
            ServiceCbx.ItemsSource = context.ServiceTables.ToList();
            UserCbx.DisplayMemberPath = "LoginUser";
            ServiceCbx.DisplayMemberPath = "NameService";
        }

        UserTable selected_user = new UserTable();
        ServiceTable selected_service = new ServiceTable();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserCbx.SelectedItem != null)
            {
                selected_user = UserCbx.SelectedItem as UserTable;
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ServiceCbx.SelectedItem != null)
            {
                selected_service = ServiceCbx.SelectedItem as ServiceTable;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = FirstNameTbx.Text;
            customer.SecondName = SecondNameTbx.Text;
            customer.MiddleName = MiddleNameTbx.Text;
            customer.Service_ID = selected_service.ID_Service;
            customer.UserID = selected_user.ID_User;

            context.Customers.Add(customer);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.Customers.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.Customers.Remove(ModeratorDgr.SelectedItem as Customer);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Customers.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as Customer;
                selected.FirstName = FirstNameTbx.Text;
                selected.SecondName = SecondNameTbx.Text;
                selected.MiddleName = MiddleNameTbx.Text;
                selected.Service_ID = selected_service.ID_Service;
                selected.UserID = selected_user.ID_User;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Customers.ToList();
            }
        }
    }
}
