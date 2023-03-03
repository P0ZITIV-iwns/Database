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

namespace ЛР6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Phone tempPhone;
        public MainWindow()
        {
            InitializeComponent();
            EndEditing();
            mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
            companyView.ItemsSource = DatabaseControl.GetCompanies();

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            tempPhone = mainListBox.SelectedItem as Phone;
            if (tempPhone != null)
            {
                titleView.Text = tempPhone.Title;
                companyView.SelectedIndex = tempPhone.CompanyId - 1;
                priceView.Text = tempPhone.Price.ToString();

                mainListBox.IsEnabled = false;
                addButtonView.IsEnabled = false;
                editButtonView.IsEnabled = false;
                removeButtonView.IsEnabled = false;

                saveEditButtonView.Visibility = Visibility.Visible;
                cancelEditButtonView.Visibility = Visibility.Visible;
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (priceView.Text != "" && companyView.Text != "" && titleView.Text != "")
            {
                if (decimal.TryParse(priceView.Text, out decimal price))
                {
                    if (decimal.Parse(priceView.Text) > 0)
                    {
                        DatabaseControl.AddPhone(new Phone
                        {
                            Title = titleView.Text,
                            CompanyId = (companyView.SelectedItem as Company).Id,
                            Price = Convert.ToDecimal(priceView.Text)
                        });
                        mainListBox.ItemsSource = null;
                        mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
                        titleView.Text = String.Empty;
                        companyView.Text = String.Empty;
                        priceView.Text = String.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Цена не может быть меньше или равна нулю!", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Цена должна принимать числа!", "Ошибка");
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
                DatabaseControl.RemovePhone(mainListBox.SelectedItem as Phone);
                mainListBox.ItemsSource = null;
                mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();
            }
            else
            {
                MessageBox.Show("Для удаления модели необходимо её выбрать", "Ошибка");
            }
        }

        private void EndEditing()
        {
            titleView.Text = String.Empty;
            companyView.Text = String.Empty;
            priceView.Text = String.Empty;

            mainListBox.IsEnabled = true;
            addButtonView.IsEnabled = true;
            editButtonView.IsEnabled = true;
            removeButtonView.IsEnabled = true;

            saveEditButtonView.Visibility = Visibility.Hidden;
            cancelEditButtonView.Visibility = Visibility.Hidden;
        }

        private void cancelEditButtonView_Click(object sender, RoutedEventArgs e) =>
            EndEditing();


        private void saveEditButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (priceView.Text != "" && companyView.Text != "" && titleView.Text != "")
            {
                if (decimal.TryParse(priceView.Text, out decimal price))
                {
                    if (decimal.Parse(priceView.Text) > 0)
                    {
                        tempPhone.Title = titleView.Text;
                        tempPhone.CompanyId = companyView.SelectedIndex + 1;
                        tempPhone.Price = Convert.ToDecimal(priceView.Text);


                        DatabaseControl.UpdatePhone(mainListBox.SelectedItem as Phone);
                        mainListBox.ItemsSource = null;
                        mainListBox.ItemsSource = DatabaseControl.GetPhonesForView();

                        EndEditing();
                    }
                    else
                    {
                        MessageBox.Show("Цена не может быть меньше или равна нулю!", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Цена должна принимать числа!", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Поле для ввода не может быть пустым!", "Ошибка");
            }
        }        
    }
}
