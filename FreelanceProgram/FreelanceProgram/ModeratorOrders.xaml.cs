using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для ModeratorOrders.xaml
    /// </summary>
    public partial class ModeratorOrders : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorOrders()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.Orders.ToList();
            FreeCbx.ItemsSource = context.Freelancers.ToList();
            CustCbx.ItemsSource = context.Customers.ToList();
            ServCbx.ItemsSource = context.ServiceTables.ToList();
            FreeCbx.DisplayMemberPath = "FirstName";
            CustCbx.DisplayMemberPath = "FirstName";
            ServCbx.DisplayMemberPath = "NameService";
        }

        public MainWindow main = new MainWindow();

        public Freelancer selected_freelancer = new Freelancer();
        public Customer selected_customer = new Customer();
        public ServiceTable selected_service = new ServiceTable();


        private void FreeCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FreeCbx.SelectedItem != null)
            {
                selected_freelancer = FreeCbx.SelectedItem as Freelancer;
            }
        }

        private void CustCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustCbx.SelectedItem != null)
            {
                selected_customer = CustCbx.SelectedItem as Customer;
            }
        }

        private void ServCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ServCbx.SelectedItem != null)
            {
                selected_service = ServCbx.SelectedItem as ServiceTable;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CustCbx.SelectedItem == null || ServCbx.SelectedItem == null ||
                string.IsNullOrWhiteSpace(NameOrderTbx.Text) || FreeCbx.SelectedItem == null ||
                string.IsNullOrWhiteSpace(DesiredPriceTbx.Text))
            {
                MessageBox.Show("Вы заполнили не все данные");
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
            order.Freelancer_ID = selected_freelancer.ID_Freelancer;
            order.Customer_ID = selected_customer.ID_Customer;
            var moderator_data = context.Moderators.ToList();
            for (int i = 0; i < moderator_data.Count; i++)
            {
                if (moderator_data[i].UserID == GlobalInfo.user_id)
                {
                    order.Moderator_ID = moderator_data[i].ID_Moderator;
                }
            }
            order.StatusService_ID = 1;
            order.Service_ID = selected_service.ID_Service;
            context.Orders.Add(order);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.Orders.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as Order;
                var moderator_data = context.Moderators.ToList();
                for (int i = 0; i < moderator_data.Count; i++)
                {
                    if (moderator_data[i].UserID == GlobalInfo.user_id &&
                        selected.Moderator_ID == moderator_data[i].ID_Moderator)
                    {
                        context.Orders.Remove(ModeratorDgr.SelectedItem as Order);
                        context.SaveChanges();
                        ModeratorDgr.ItemsSource = context.Orders.ToList();
                    }
                }
                MessageBox.Show("Вы не работаете с этим заказом");
                return;
            }
            MessageBox.Show("Вы не выделили данные");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CustCbx.SelectedItem == null || ServCbx.SelectedItem == null ||
               string.IsNullOrWhiteSpace(NameOrderTbx.Text) || FreeCbx.SelectedItem == null ||
               string.IsNullOrWhiteSpace(DesiredPriceTbx.Text))
            {
                MessageBox.Show("Вы заполнили не все данные");
                return;
            }
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as Order;
                var moderator_data = context.Moderators.ToList();
                for (int i = 0; i < moderator_data.Count; i++)
                {
                    if (moderator_data[i].UserID == GlobalInfo.user_id &&
                        selected.Moderator_ID == moderator_data[i].ID_Moderator)
                    {
                        selected.NameOrder = NameOrderTbx.Text;
                        if (decimal.TryParse(DesiredPriceTbx.Text, out decimal result) && Convert.ToDecimal(DesiredPriceTbx.Text) > 0)
                            selected.DesiredPrice = Convert.ToDecimal(DesiredPriceTbx.Text);
                        else
                        {
                            MessageBox.Show("Некорректно введено число");
                            return;
                        }
                        selected.Freelancer_ID = selected_freelancer.ID_Freelancer;
                        selected.Customer_ID = selected_customer.ID_Customer;
                        selected.Moderator_ID = moderator_data[i].ID_Moderator;
                        selected.StatusService_ID = 1;
                        selected.Service_ID = selected_service.ID_Service;
                        context.SaveChanges();
                        ModeratorDgr.ItemsSource = context.Orders.ToList();
                        return;
                    }
                }
                MessageBox.Show("Вы не работаете с этим заказом");
            }
        }
    }
}
