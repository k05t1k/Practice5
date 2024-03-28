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
    /// Логика взаимодействия для ModeratorModerator.xaml
    /// </summary>
    public partial class ModeratorModerator : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorModerator()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.Moderators.ToList();
            UserCbx.ItemsSource = context.UserTables.ToList();
            UserCbx.DisplayMemberPath = "LoginUser";
        }

        UserTable selected_user = new UserTable();

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserCbx.SelectedItem != null)
            {
                selected_user = UserCbx.SelectedItem as UserTable;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Moderator moderator = new Moderator();
            moderator.FirstName = FirstNameTbx.Text;
            moderator.SecondName = SecondNameTbx.Text;
            moderator.MiddleName = MiddleNameTbx.Text;
            moderator.UserID = selected_user.ID_User;

            context.Moderators.Add(moderator);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.Moderators.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.Moderators.Remove(ModeratorDgr.SelectedItem as Moderator);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Moderators.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as Moderator;
                selected.FirstName = FirstNameTbx.Text;
                selected.SecondName = SecondNameTbx.Text;
                selected.MiddleName = MiddleNameTbx.Text;
                selected.UserID = selected_user.ID_User;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Moderators.ToList();
            }
        }
    }
}
