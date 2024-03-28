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
    /// Логика взаимодействия для CustomerOrders.xaml
    /// </summary>
    public partial class CustomerOrders : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public CustomerOrders()
        {
            InitializeComponent();
            CustomerDgr.ItemsSource = context.Orders.ToList();
            ServCbx.ItemsSource = context.ServiceTables.ToList();
            ServCbx.DisplayMemberPath = "NameService";
        }

        public ServiceTable selected_service = new ServiceTable();

        private void ServCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServCbx.SelectedItem != null)
            {
                selected_service = ServCbx.SelectedItem as ServiceTable;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selected_service == null || string.IsNullOrEmpty(NameOrderTbx.Text) ||
                 string.IsNullOrEmpty(DesiredPriceTbx.Text))
            {
                MessageBox.Show("Вы ввели не все данные!");
                return;
            }
            Order order = new Order();
            order.NameOrder = NameOrderTbx.Text;
            if (decimal.TryParse(DesiredPriceTbx.Text, out decimal result) && Convert.ToDecimal(DesiredPriceTbx.Text) > 0)
                order.DesiredPrice = Convert.ToDecimal(DesiredPriceTbx.Text);
            else
            {
                MessageBox.Show("Некорректно введено число (DesiredPrice)");
                return;
            }
            var customer_data = context.Customers.ToList();
            for (int i = 0; i < customer_data.Count; i++)
            {
                if (customer_data[i].UserID == GlobalInfo.user_id)
                {
                    order.Customer_ID = customer_data[i].ID_Customer;
                }
            }
            order.StatusService_ID = 1;
            order.Service_ID = selected_service.ID_Service;
            context.Orders.Add(order);
            context.SaveChanges();
            CustomerDgr.ItemsSource = context.Orders.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CustomerDgr.SelectedItem != null)
            {
                var selected = CustomerDgr.SelectedItem as Order;
                var customer_data = context.Customers.ToList();
                for (int i = 0; i < customer_data.Count; i++)
                {
                    if (customer_data[i].UserID == GlobalInfo.user_id &&
                        selected.Customer_ID == customer_data[i].ID_Customer)
                    {
                        context.Orders.Remove(CustomerDgr.SelectedItem as Order);
                        context.SaveChanges();
                        CustomerDgr.ItemsSource = context.Orders.ToList();
                        return;
                    }
                }
                MessageBox.Show("Вы не создатель данного заказа!");
                return;
            }
            MessageBox.Show("Вы не выделили данные");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CustomerDgr.SelectedItem != null)
            {
                if (selected_service == null || string.IsNullOrEmpty(NameOrderTbx.Text) ||
                    string.IsNullOrEmpty(DesiredPriceTbx.Text))
                {
                    MessageBox.Show("Вы ввели не все данные!");
                    return;
                }
                var selected = CustomerDgr.SelectedItem as Order;
                selected.NameOrder = NameOrderTbx.Text;
                if (decimal.TryParse(DesiredPriceTbx.Text, out decimal result))
                    selected.DesiredPrice = Convert.ToDecimal(DesiredPriceTbx.Text);
                else
                {
                    MessageBox.Show("Некорректно введено число (DesiredPrice)");
                    return;
                }
                selected.Service_ID = selected_service.ID_Service;
                var customer_data = context.Customers.ToList();
                for (int i = 0; i < customer_data.Count; i++)
                {
                    if (customer_data[i].UserID == GlobalInfo.user_id && 
                        selected.Customer_ID == customer_data[i].ID_Customer)
                    {
                        context.SaveChanges();
                        CustomerDgr.ItemsSource = context.Orders.ToList();
                        return;
                    }
                }
                MessageBox.Show("Вы не создатель данного заказа!");

            }
        }
    }
}
