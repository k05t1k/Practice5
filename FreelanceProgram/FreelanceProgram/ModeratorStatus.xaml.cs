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
    /// Логика взаимодействия для ModeratorStatus.xaml
    /// </summary>
    public partial class ModeratorStatus : Page
    {
        FreelancingEntities context = new FreelancingEntities();

        public ModeratorStatus()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.StatusServices.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StatusService status = new StatusService();
            status.ServiceStatus = StatusTbx.Text;

            context.StatusServices.Add(status);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.StatusServices.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.StatusServices.Remove(ModeratorDgr.SelectedItem as StatusService);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.StatusServices.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as StatusService;
                selected.ServiceStatus = StatusTbx.Text;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.StatusServices.ToList();
            }
        }
    }
}
