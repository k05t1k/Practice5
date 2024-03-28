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
    /// Логика взаимодействия для OrdersStatusFreelancer.xaml
    /// </summary>
    public partial class OrdersStatusFreelancer : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public OrdersStatusFreelancer()
        {
            InitializeComponent();
            FreelancerDgr.ItemsSource = context.Orders.ToList();
            NameOrderCbx.ItemsSource = context.Orders.ToList();
            NameOrderCbx.DisplayMemberPath = "NameOrder";
            StatusCbx.ItemsSource = context.StatusServices.ToList();
            StatusCbx.DisplayMemberPath = "ServiceStatus";
        }

        public Order SelectedItemOrder { get; set; }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameOrderCbx.SelectedItem != null)
            {
                SelectedItemOrder = NameOrderCbx.SelectedItem as Order;
            }
        }

        public StatusService SelectedItemStatus { get; set; }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (StatusCbx.SelectedItem != null)
            {
                SelectedItemStatus = StatusCbx.SelectedItem as StatusService;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItemOrder != null && SelectedItemStatus != null)
            {
                var freelancer_data = context.Freelancers.ToList();
                for (int i = 0; i < freelancer_data.Count; i++)
                {
                    if (freelancer_data[i].ID_Freelancer == SelectedItemOrder.Freelancer_ID &&
                        freelancer_data[i].UserID == GlobalInfo.user_id)
                    {
                        SelectedItemOrder.StatusService_ID = SelectedItemStatus.ID_StatusService;
                        context.SaveChanges();
                        FreelancerDgr.ItemsSource = context.Orders.ToList();
                        return;
                    }
                }
                MessageBox.Show("Вы не работаете с этим заказом!");
            }
            MessageBox.Show("Не все данные были введены");
        }
    }
}
