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
    /// Логика взаимодействия для ModeratorFreelancer.xaml
    /// </summary>
    public partial class ModeratorFreelancer : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorFreelancer()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.Freelancers.ToList();
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
            if (selected_user == null || string.IsNullOrEmpty(FirstNameTbx.Text) ||
                string.IsNullOrEmpty(SecondNameTbx.Text) || string.IsNullOrEmpty(MiddleNameTbx.Text) ||
                selected_user == null || string.IsNullOrEmpty(ExpWorkTbx.Text))
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }
            Freelancer freelancer = new Freelancer();
            freelancer.FirstName = FirstNameTbx.Text;
            freelancer.SecondName = SecondNameTbx.Text;
            freelancer.MiddleName = MiddleNameTbx.Text;
            if (int.TryParse(ExpWorkTbx.Text, out int result))
                freelancer.ExperienceWork = int.Parse(ExpWorkTbx.Text);
            else
            {
                MessageBox.Show("Некорректно введено число (ExperienceWork)");
                return;
            }
            freelancer.Service_ID = selected_service.ID_Service;
            freelancer.UserID = selected_user.ID_User;

            context.Freelancers.Add(freelancer);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.Freelancers.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.Freelancers.Remove(ModeratorDgr.SelectedItem as Freelancer);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Freelancers.ToList();
                return;
            }
            MessageBox.Show("Вы не выделили данные");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (selected_user == null || string.IsNullOrEmpty(FirstNameTbx.Text) ||
                string.IsNullOrEmpty(SecondNameTbx.Text) || string.IsNullOrEmpty(MiddleNameTbx.Text) ||
                selected_user == null || string.IsNullOrEmpty(ExpWorkTbx.Text))
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }
            if (ModeratorDgr.SelectedItem != null)
            {

                var selected = ModeratorDgr.SelectedItem as Freelancer;
                selected.FirstName = FirstNameTbx.Text;
                selected.SecondName = SecondNameTbx.Text;
                selected.MiddleName = MiddleNameTbx.Text;
                if (int.TryParse(ExpWorkTbx.Text, out int result))
                    selected.ExperienceWork = int.Parse(ExpWorkTbx.Text);
                else
                {
                    MessageBox.Show("Некорректно введено число (ExperienceWork)");
                    return;
                }
                selected.Service_ID = selected_service.ID_Service;
                selected.UserID = selected_user.ID_User;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Freelancers.ToList();
            }
        }
    }
}
