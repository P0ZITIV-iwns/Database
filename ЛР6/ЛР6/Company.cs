using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CEO { get; set; }
        public double Capital { get; set; }
        public List<Phone> PhoneEntities { get; set; }
    }
}
