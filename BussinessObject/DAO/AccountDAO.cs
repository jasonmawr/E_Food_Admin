using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DAO
{
    public class AccountDAO
    {
        public static List<Account> GetAll()
        {
            var result = new List<Account>();
            using (var context = new E_FoodContext())
            {
                result = context.Accounts.Where(a => a.Status != 0).ToList();
            }
            if (result == null) result = new List<Account> { };
            return result;
        }
        public static Account FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Accounts.FirstOrDefault(a => a.AccountId == id);
            }
        }

        public static List<Account> GetById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Accounts.Where(a => a.AccountId == id).ToList();
            }
        }

        public static Account GetByCredentials(string email, string pass)
        {
            using (var context = new E_FoodContext())
            {
                return context.Accounts.FirstOrDefault(a => a.Email.Equals(email) && a.Password.Equals(pass));
            }
        }
        public static void Add(Account e)
        {
            using (var context = new E_FoodContext())
            {
                context.Accounts.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(Account e)
        {
            using (var context = new E_FoodContext())
            {
                context.Accounts.Update(e);
                context.SaveChanges();
            }
        }
        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.Accounts.FirstOrDefault(e => e.AccountId == id);
                if (e == null)
                {
                    return;
                }
                context.Accounts.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
