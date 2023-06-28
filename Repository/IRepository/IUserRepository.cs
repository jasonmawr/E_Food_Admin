using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User FindById(int id);
        public void Add(User e);
        public void Update(User e);
        public void Remove(int id);
        public List<User> GetById(int id);
    }
}
