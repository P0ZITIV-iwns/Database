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

namespace ЛР7
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            companyView.ItemsSource = DatabaseControl.GetCompanies();
        }
        private void AddPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                DatabaseControl.AddPhone(new Phone
                {
                    title = titleView.Text,
                    companyid = (int)companyView.SelectedValue,
                    price = Convert.ToDecimal(priceView.Text)
                });
                (this.Owner as MainWindow).RefreshTable();
                this.Close();
            }
        }
        private bool Check()
        {
            if (priceView.Text != "" && companyView.Text != "" && titleView.Text != "")
            {
                if (decimal.TryParse(priceView.Text, out decimal price))
                {
                    if (decimal.Parse(priceView.Text) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Цена не может быть меньше или равна нулю!", "Ошибка");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Цена должна принимать числа!", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Поле для ввода не может быть пустым!", "Ошибка");
                return false;
            }
        }
    }
}