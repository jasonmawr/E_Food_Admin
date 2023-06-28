using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();
        public Account FindById(int id);
        public Account GetByCredentials(string email, string pass);
        public void Add(Account e);
        public void Update(Account e);
        public void Remove(int id);
        public List<Account> GetById(int id);
    }
}
