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
    /// Логика взаимодействия для ModeratorRole.xaml
    /// </summary>
    public partial class ModeratorRole : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorRole()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.UserRoles.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRole role = new UserRole();
            role.RoleUser = RoleTbx.Text;
            context.UserRoles.Add(role);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.UserRoles.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.UserRoles.Remove(ModeratorDgr.SelectedItem as UserRole);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.UserRoles.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as UserRole;
                selected.RoleUser = RoleTbx.Text;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.UserRoles.ToList();
            }
        }
    }
}
