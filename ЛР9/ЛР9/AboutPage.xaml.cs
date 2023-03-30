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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ЛР9
{
    /// <summary>
    /// Логика взаимодействия для AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage(Phone _phone)
        {
            InitializeComponent();

            titlePageView.Text = _phone.title;
            definitionPageView.Text = _phone.definition;
            companyPageView.Text = _phone.CompanyEntity.title;
            pricePageView.Text = _phone.price.ToString();
            BitmapImage _bitmapImage = new BitmapImage();
            using (Stream stream = File.OpenRead(_phone.imagesource))
            {
                _bitmapImage.BeginInit();
                _bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                _bitmapImage.StreamSource = stream;
                _bitmapImage.EndInit();
            }
            imagePageView.Source = _bitmapImage;
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(null);
        }

    }
}
