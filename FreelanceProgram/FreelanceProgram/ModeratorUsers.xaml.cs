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
    /// Логика взаимодействия для ModeratorUsers.xaml
    /// </summary>
    public partial class ModeratorUsers : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorUsers()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.UserTables.ToList();
            RoleCbx.ItemsSource = context.UserRoles.ToList();
            RoleCbx.DisplayMemberPath = "RoleUser";
        }

        UserRole selected_role = new UserRole(); 

        private void RoleCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoleCbx.SelectedItem != null)
            {
                selected_role = RoleCbx.SelectedItem as UserRole;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserTable user = new UserTable();
            user.LoginUser = LoginTbx.Text;
            user.PasswordUser = PasswordTbx.Text;
            user.UserRole_ID = selected_role.ID_Role;

            context.UserTables.Add(user);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.UserTables.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.UserTables.Remove(ModeratorDgr.SelectedItem as UserTable);

                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.UserTables.ToList();
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as UserTable;
                selected.LoginUser = LoginTbx.Text;
                selected.PasswordUser = PasswordTbx.Text;
                selected.UserRole_ID = selected_role.ID_Role;

                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.UserTables.ToList();
            }
        }
    }
}
