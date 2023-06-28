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
    public class UserRepository : IUserRepository
    {
        public void Add(User e) => UserDAO.Add(e);

        public User FindById(int id) => UserDAO.FindById(id);

        public List<User> GetAll() => UserDAO.GetAll();

        public void Remove(int id) => UserDAO.Remove(id);

        public void Update(User e) => UserDAO.Update(e);

        public List<User> GetById(int id) => UserDAO.GetById(id);
    }
}
