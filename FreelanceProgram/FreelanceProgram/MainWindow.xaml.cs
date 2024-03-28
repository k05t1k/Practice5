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
    enum Roles_t
    {
        MODERATOR = 1,
        CUSTOMER,
        FREELANCER
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FreelancingEntities context = new FreelancingEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user_data = context.UserTables.ToList();
            for (int i = 0; i < user_data.Count; i++)
            {
                if (user_data[i].LoginUser.ToString() == LoginTbx.Text &&
                    user_data[i].PasswordUser.ToString() == PasswordBox.Password)
                {
                    Roles_t role_id = (Roles_t)user_data[i].UserRole_ID;
                    GlobalInfo.user_id = user_data[i].ID_User;
                    switch (role_id)
                    {
                        case Roles_t.MODERATOR:
                            ModeratorPanel mod_panel = new ModeratorPanel();
                            mod_panel.Show();
                            Close();
                            break;
                        case Roles_t.CUSTOMER:
                            CustomerPanel cust_panel = new CustomerPanel();
                            cust_panel.Show();
                            Close();
                            break;
                        case Roles_t.FREELANCER:
                            FreelancerPanel free_panel = new FreelancerPanel();
                            free_panel.Show();
                            Close();
                            break;
                    }
                    return;
                }
            }
            MessageBox.Show("Вы ввели неправильно логин или пароль!");
        }
    }
}
