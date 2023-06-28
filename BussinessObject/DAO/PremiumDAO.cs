using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class PremiumDAO
    {
        public static List<Premium> GetAll()
        {
            var result = new List<Premium>();
            using (var context = new E_FoodContext())
            {
                result = context.Premia.ToList();
            }
            return result;
        }

        public static Premium FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Premia.FirstOrDefault(a => a.PremiumId == id);
            }
        }

        public static void Add(Premium e)
        {
            using (var context = new E_FoodContext())
            {
                context.Premia.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(Premium e)
        {
            using (var context = new E_FoodContext())
            {
                context.Premia.Update(e);
                context.SaveChanges();
            }
        }

        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.Premia.FirstOrDefault(e => e.PremiumId == id);
                if (e == null)
                {
                    return;
                }
                context.Premia.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
