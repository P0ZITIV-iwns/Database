using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ЛР7.MainWindow;

namespace ЛР7
{
    public class Phone
    {
        public int id { get; set; }
        public string title { get; set; }
        public int companyid { get; set; }
        public decimal price { get; set; }
        public Company CompanyEntity { get; set; }
    }
}