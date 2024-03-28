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
    /// Логика взаимодействия для OrdersFreelancer.xaml
    /// </summary>
    public partial class OrdersFreelancer : Page
    {
        FreelancingEntities context = new FreelancingEntities();

        public OrdersFreelancer()
        {
            InitializeComponent();
            FreelancerDgr.ItemsSource = context.Orders.ToList();
            NameOrderCbx.ItemsSource = context.Orders.ToList();
            NameOrderCbx.DisplayMemberPath = "NameOrder";
        }

        public Order SelectedItem { get; set; }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameOrderCbx.SelectedItem != null)
            {
                SelectedItem = NameOrderCbx.SelectedItem as Order;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                var freelancer_data = context.Freelancers.ToList();
                for (int i = 0; i < freelancer_data.Count; i++)
                {
                    if (freelancer_data[i].UserID == GlobalInfo.user_id)
                    {
                        if (freelancer_data[i].UserID == GlobalInfo.user_id &&
                            SelectedItem.Freelancer_ID == freelancer_data[i].ID_Freelancer ||
                            SelectedItem.Freelancer_ID == null)
                        {
                            SelectedItem.Freelancer_ID = freelancer_data[i].ID_Freelancer;
                            context.SaveChanges();
                            FreelancerDgr.ItemsSource = context.Orders.ToList();
                            return;
                        }
                    }
                }
                MessageBox.Show("Данный заказ занят!");
            }
            MessageBox.Show("Вы не выбрали данные");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (SelectedItem != null)
            {
                var freelancer_data = context.Freelancers.ToList();
                for (int i = 0; i < freelancer_data.Count; i++)
                {
                    if (freelancer_data[i].UserID == GlobalInfo.user_id &&
                        SelectedItem.Freelancer_ID == freelancer_data[i].ID_Freelancer)
                    {
                        SelectedItem.Freelancer_ID = null;
                        SelectedItem.StatusService_ID = 1;
                        context.SaveChanges();
                        FreelancerDgr.ItemsSource = context.Orders.ToList();
                        return;
                    }
                }
                MessageBox.Show("Вы не принимали данный заказ");
            }
            MessageBox.Show("Вы не выбрали данные");
        }
    }
}
