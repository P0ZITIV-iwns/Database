using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7
{
    public static class DatabaseControl
    {
        public static List<Company> GetCompanies()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.company.Include(p => p.PhoneEntities).ToList();
            }
        }
        public static List<Phone> GetPhonesForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.phones.Include(p => p.CompanyEntity).ToList();
            }
        }
        public static void AddPhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.phones.Add(phone);
                ctx.SaveChanges();
            }
        }
        public static void UpdatePhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                Phone _phone = ctx.phones.FirstOrDefault(p => p.id == phone.id);

                if (_phone == null)
                {
                    return;
                }

                _phone.title = phone.title;
                _phone.price = phone.price;
                _phone.companyid = phone.companyid;

                ctx.SaveChanges();
            }
        }
        public static void RemovePhone(Phone phone)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.phones.Remove(phone);
                ctx.SaveChanges();
            }
        }
    }
}