using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ЛР9
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private const string _imageSource = "D:\\PhonePictures";
        private OpenFileDialog _img;
        private Phone _tempPhone;
        public EditWindow(Phone phone)
        {
            InitializeComponent();
            _tempPhone = phone;
            companyView.ItemsSource = DatabaseControl.GetCompanies();
            titleView.Text = phone.title;
            companyView.SelectedValue = phone.CompanyEntity.id;
            priceView.Text = phone.price.ToString();
            definitionView.Text = phone.definition;
        }
        private void saveEditButtonView_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                _tempPhone.title = titleView.Text;
                _tempPhone.companyid = (int)companyView.SelectedValue;
                _tempPhone.price = Convert.ToDecimal(priceView.Text);
                _tempPhone.definition = definitionView.Text;
                if (_tempPhone.imagesource != "D:\\PhonePictures\\noImage.png")
                {
                    File.Delete(_tempPhone.imagesource);   
                }
                if (_img != null)
                {
                    _tempPhone.imagesource = System.IO.Path.Combine(_imageSource, _img.SafeFileName);
                    File.Copy(_img.FileName, _tempPhone.imagesource, true);
                }
                DatabaseControl.UpdatePhone(_tempPhone);
                (this.Owner as MainWindow).RefreshTable();
                this.Close();
            }
        }
        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.jpg, *.png)|*.jpg;*.png;*.JPG;*.PNG";
            if (openFileDialog.ShowDialog() == true)
            {
                _img = openFileDialog;
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