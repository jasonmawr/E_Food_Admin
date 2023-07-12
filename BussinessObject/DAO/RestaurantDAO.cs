using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class RestaurantDAO
    {
            public static List<Restaurant> GetAll()
            {
                var result = new List<Restaurant>();
                using (var context = new E_FoodContext())
                {
                    result = context.Restaurants.ToList();
                }
                return result;
            }

            public static Restaurant FindById(int id)
            {
                using (var context = new E_FoodContext())
                {
                    return context.Restaurants.FirstOrDefault(a => a.ResId == id);
                }
            }

            public static List<Restaurant> GetById(int id)
            {
                using (var context = new E_FoodContext())
                {
                    return context.Restaurants.Where(a => a.ResId == id).ToList();
                }
            }



            public static void Add(Restaurant e)
            {
                using (var context = new E_FoodContext())
                {
                    context.Restaurants.Add(e);
                    context.SaveChanges();
                }
            }
            public static void Update(Restaurant e)
            {
                using (var context = new E_FoodContext())
                {
                    context.Restaurants.Update(e);
                    context.SaveChanges();
                }
            }

            public static void Remove(int id)
            {
                using (var context = new E_FoodContext())
                {
                    var e = context.Restaurants.FirstOrDefault(e => e.ResId == id);
                    if (e == null)
                    {
                        return;
                    }
                    context.Restaurants.Remove(e);
                    context.SaveChanges();
                }
            }       
    }
}
