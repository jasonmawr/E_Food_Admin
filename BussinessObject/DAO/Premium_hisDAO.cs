using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class Premium_hisDAO
    {
        public static List<PremiumHi> GetAll()
        {
            var result = new List<PremiumHi>();
            using (var context = new E_FoodContext())
            {
                result = context.PremiumHis.ToList();
            }
            return result;
        }

        public static PremiumHi FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.PremiumHis.FirstOrDefault(a => a.PremiumId == id);
            }
        }

        public static void Add(PremiumHi e)
        {
            using (var context = new E_FoodContext())
            {
                context.PremiumHis.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(PremiumHi e)
        {
            using (var context = new E_FoodContext())
            {
                context.PremiumHis.Update(e);
                context.SaveChanges();
            }
        }

        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.PremiumHis.FirstOrDefault(e => e.PremiumId == id);
                if (e == null)
                {
                    return;
                }
                context.PremiumHis.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
