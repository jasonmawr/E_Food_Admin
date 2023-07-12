using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class DishDAO
    {
        public static List<Dish> GetAll()
        {
            var result = new List<Dish>();
            using (var context = new E_FoodContext())
            {
                result = context.Dishes.Where(a => a.Status != 0).ToList();
            }
            if (result == null) result = new List<Dish> { };
            return result;
        }
        public static Dish FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Dishes.FirstOrDefault(a => a.DishId == id);
            }
        }

        public static List<Dish> GetById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Dishes.Where(a => a.DishId == id).ToList();
            }
        }

        public static void Add(Dish e)
        {
            using (var context = new E_FoodContext())
            {
                context.Dishes.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(Dish e)
        {
            using (var context = new E_FoodContext())
            {
                context.Dishes.Update(e);
                context.SaveChanges();
            }
        }
        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.Dishes.FirstOrDefault(e => e.DishId == id);
                if (e == null)
                {
                    return;
                }
                context.Dishes.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
