using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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

namespace ЛР9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameContext.MainWindowFrame = mainFrame;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
            //companyView.ItemsSource = DatabaseControl.GetCompanies();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow win = new AddWindow();
            win.Owner = this;
            win.ShowDialog();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Phone p = mainDataGridView.SelectedItem as Phone;
            if (p != null)
            {
                EditWindow win = new EditWindow(p);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }

        }
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainDataGridView.SelectedItem as Phone != null)
            {
                DatabaseControl.RemovePhone(mainDataGridView.SelectedItem as Phone);
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Для удаления модели необходимо её выбрать", "Ошибка");
            }
        }

        public void RefreshTable()
        {
            mainDataGridView.ItemsSource = null;
            mainDataGridView.ItemsSource = DatabaseControl.GetPhonesForView();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Phone phone = mainDataGridView.SelectedItem as Phone;
            if (phone != null)
            {
                FrameContext.MainWindowFrame.Navigate(new AboutPage(phone));
            }
        }
    }
}