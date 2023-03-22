using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР8
{
    public class Company
    {
        public int id { get; set; }
        public string title { get; set; }
        public string ceo { get; set; }
        public double capital { get; set; }
        public List<Phone> PhoneEntities { get; set; }
    }
}