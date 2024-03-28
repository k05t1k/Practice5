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
    /// Логика взаимодействия для ModeratorSpecialization.xaml
    /// </summary>
    public partial class ModeratorSpecialization : Page
    {
        FreelancingEntities context = new FreelancingEntities();
        public ModeratorSpecialization()
        {
            InitializeComponent();
            ModeratorDgr.ItemsSource = context.Specializations.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SpecTbx.Text))
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }
            Specialization specialization = new Specialization();
            specialization.NameSpecialization = SpecTbx.Text;
            context.Specializations.Add(specialization);
            context.SaveChanges();
            ModeratorDgr.ItemsSource = context.Specializations.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ModeratorDgr.SelectedItem != null)
            {
                context.Specializations.Remove(ModeratorDgr.SelectedItem as Specialization);
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Specializations.ToList();
                return;
            }
            MessageBox.Show("Вы не выделили данные");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SpecTbx.Text))
            {
                MessageBox.Show("Вы ввели не все данные");
                return;
            }
            if (ModeratorDgr.SelectedItem != null)
            {
                var selected = ModeratorDgr.SelectedItem as Specialization;
                selected.NameSpecialization = SpecTbx.Text;
                context.SaveChanges();
                ModeratorDgr.ItemsSource = context.Specializations.ToList();
            }
        }
    }
}
