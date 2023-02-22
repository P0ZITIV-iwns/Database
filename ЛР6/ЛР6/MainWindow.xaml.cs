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
        List<Phone> phones;
        private Phone tempPhone;
        public MainWindow()
        {
            InitializeComponent();
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


                        mainListBox.ItemsSource = null;
                        mainListBox.ItemsSource = phones;

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
        public class Phone
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int CompanyId { get; set; }
            public decimal Price { get; set; }
            public Company CompanyEntity { get; set; }
        }
        public class Company
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string CEO { get; set; }
            public double Capital { get; set; }
            public List<Phone> PhoneEntities { get; set; }
        }
        public class DbAppContext : DbContext
        {
            public DbSet<Phone> Phones { get; set; }
            public DbSet<Company> Company { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseNpgsql(
                    "Host=localhost;Username=postgres;Password=root;Database=PhonesDatabase");
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Phone>().HasOne(p => p.CompanyEntity)
                                            .WithMany(p => p.PhoneEntities);
            }
        }
        public static class DatabaseControl
        {
            public static List<Company> GetCompanies()
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    return ctx.Company.Include(p => p.PhoneEntities).ToList();
                }
            }
            public static List<Phone> GetPhonesForView()
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    return ctx.Phones.Include(p => p.CompanyEntity).ToList();
                }
            }
            public static void AddPhone(Phone phone)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    ctx.Phones.Add(phone);
                    ctx.SaveChanges();
                }
            }
            public static void UpdatePhone(Phone phone)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    Phone _phone = ctx.Phones.FirstOrDefault(p => p.Id == phone.Id);

                    _phone.Title = phone.Title;
                    _phone.Price = phone.Price;
                    _phone.CompanyId = phone.CompanyId;

                    ctx.SaveChanges();
                }
            }
            public static void RemovePhone(Phone phone)
            {
                using (DbAppContext ctx = new DbAppContext())
                {
                    ctx.Phones.Remove(phone);
                    ctx.SaveChanges();
                }
            }
        }
    }
}