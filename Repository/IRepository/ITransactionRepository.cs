using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ITransactionRepository
    {
        public List<Transaction> GetAll();
        public Transaction FindById(int id);
        public void Add(Transaction e);
        public void Update(Transaction e);
        public void Remove(int id);
        public List<Transaction> GetById(int id);
    }
}
