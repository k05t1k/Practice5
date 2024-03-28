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
using System.Windows.Shapes;

namespace FreelanceProgram
{
    /// <summary>
    /// Логика взаимодействия для ModeratorPanel.xaml
    /// </summary>
    public partial class ModeratorPanel : Window
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorPanel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorOrders();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorUsers();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorStatus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorRole();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorCustomer();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorFreelancer();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorModerator();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModeratorSpecialization();
        }
    }
}
