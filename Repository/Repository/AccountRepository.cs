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
    public class AccountRepository : IAccountRepository
    {
        public void Add(Account e) => AccountDAO.Add(e);

        public Account FindById(int id) => AccountDAO.FindById(id);

        public List<Account> GetAll() => AccountDAO.GetAll();

        public Account GetByCredentials(string email, string pass) => AccountDAO.GetByCredentials(email, pass);

        public void Remove(int id) => AccountDAO.Remove(id);

        public void Update(Account e) => AccountDAO.Update(e);

        public List<Account> GetById(int id) => AccountDAO.GetById(id);

    }
}
