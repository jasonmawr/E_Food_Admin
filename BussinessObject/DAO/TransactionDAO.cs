using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = BussinessObject.Models.Transaction;

namespace BussinessObject.DAO
{
    public class TransactionDAO
    {
        public static List<Transaction> GetAll()
        {
            var result = new List<Transaction>();
            using (var context = new E_FoodContext())
            {
                result = context.Transactions.ToList();
            }
            return result;
        }

        public static Transaction FindById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Transactions.FirstOrDefault(a => a.TransactionId == id);
            }
        }

        public static List<Transaction> GetById(int id)
        {
            using (var context = new E_FoodContext())
            {
                return context.Transactions.Where(a => a.TransactionId == id).ToList();
            }
        }

        

        public static void Add(Transaction e)
        {
            using (var context = new E_FoodContext())
            {
                context.Transactions.Add(e);
                context.SaveChanges();
            }
        }
        public static void Update(Transaction e)
        {
            using (var context = new E_FoodContext())
            {
                context.Transactions.Update(e);
                context.SaveChanges();
            }
        }

        public static void Remove(int id)
        {
            using (var context = new E_FoodContext())
            {
                var e = context.Transactions.FirstOrDefault(e => e.TransactionId == id);
                if (e == null)
                {
                    return;
                }
                context.Transactions.Remove(e);
                context.SaveChanges();
            }
        }
    }
}
