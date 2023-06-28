using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class UserDAO
    {
        public static List<User> GetAll()
        {
            var result = new List<User>();
            using (var context = new E_FoodContext())
            {
                result = context.Users.Where(a => a.Status != 0).ToList();
            }
            if (result == null) result = new List<User> { };
            return result;
        }
        public static User FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Users.FirstOrDefault(a => a.UserId == id);
            }
        }

        public static List<User> GetById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Users.Where(a => a.UserId == id).ToList();
            }
        }

        
        public static void Add(User e)
        {
            using (var context = new E_FoodContext())
            {
                context.Users.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(User e)
        {
            using (var context = new E_FoodContext())
            {
                context.Users.Update(e);
                context.SaveChanges();
            }
        }
        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.Users.FirstOrDefault(e => e.UserId == id);
                if (e == null)
                {
                    return;
                }
                context.Users.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
