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

namespace ЛР4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Phone> phones;
        public MainWindow()
        {
            InitializeComponent();
            phones = new List<Phone>
            {
                new Phone { Company = "Apple ", Title = "iPhone 10", Price = 58000},
                new Phone { Company = "Xiaomi ", Title = "Redmi Note 10S", Price = 28000},
                new Phone { Company = "Apple ", Title = "iPhone 12 Pro Max Super Idol", Price = 158000},
                new Phone { Company = "Nokia ", Title = "3310", Price = 800},
            };
            mainListBox.ItemsSource = phones;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (priceView.Text != "" && companyView.Text != "" && titleView.Text != "")
            {
                if (decimal.Parse(priceView.Text) > 0)
                {
                    phones.Add(new Phone
                    {
                        Company = companyView.Text,
                        Title = titleView.Text,
                        Price = Convert.ToDecimal(priceView.Text)
                    });
                    mainListBox.ItemsSource = null;
                    mainListBox.ItemsSource = phones;
                }
                else
                {
                    MessageBox.Show("Цена не может быть равна нулю!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Поле для ввода не может быть пустым!", "Ошибка");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainListBox.SelectedItem as Phone != null)
            {
                phones.Remove(mainListBox.SelectedItem as Phone);
                mainListBox.ItemsSource = null;
                mainListBox.ItemsSource = phones;
            }
            else
            {
                MessageBox.Show("Для удаления модели необходимо её выбрать", "Ошибка");
            }

        }
    }
}
