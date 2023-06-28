using BussinessObject.DAO;
using BussinessObject.Models;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public void Add(Transaction e) => TransactionDAO.Add(e);

        public Transaction FindById(int id) => TransactionDAO.FindById(id);

        public List<Transaction> GetAll() => TransactionDAO.GetAll();

        public void Remove(int id) => TransactionDAO.Remove(id);

        public void Update(Transaction e) => TransactionDAO.Update(e);

        public List<Transaction> GetById(int id) => TransactionDAO.GetById(id);

    }
}
