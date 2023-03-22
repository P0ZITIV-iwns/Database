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

namespace ЛР8
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
            imagePageView.Source = _phone.imagesource == null ? new BitmapImage(new Uri("/Images/noImage.png", UriKind.RelativeOrAbsolute)) : new BitmapImage(new Uri(_phone.imagesource, UriKind.RelativeOrAbsolute));
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            FrameContext.MainWindowFrame.Navigate(null);
        }

    }
}
