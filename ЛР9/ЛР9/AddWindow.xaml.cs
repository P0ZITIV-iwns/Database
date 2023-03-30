using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private const string _imageSource = "D:\\PhonePictures";
        private OpenFileDialog _img;
        public AddWindow()
        {
            InitializeComponent();
            companyView.ItemsSource = DatabaseControl.GetCompanies();
        }
        private void AddPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check())
            {
                string filePath;
                if (_img == null)
                {
                    filePath = "D:\\PhonePictures\\noImage.png";
                }
                else
                {
                    filePath = System.IO.Path.Combine(_imageSource, _img.SafeFileName);
                    File.Copy(_img.FileName, filePath, true);
                }
                DatabaseControl.AddPhone(new Phone
                {
                    title = titleView.Text,
                    companyid = (int)companyView.SelectedValue,
                    price = Convert.ToDecimal(priceView.Text),
                    imagesource = filePath,
                    definition = definitionView.Text
                });
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