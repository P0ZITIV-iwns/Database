using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static ЛР9.MainWindow;

namespace ЛР9
{
    public class Phone
    {
        public int id { get; set; }
        public string title { get; set; }
        public int companyid { get; set; }
        public decimal price { get; set; }
        public string definition { get; set; }
        public string imagesource { get; set; }
        public Company CompanyEntity { get; set; }
    }
}