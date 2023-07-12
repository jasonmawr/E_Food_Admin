using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IDishRepository
    {
        public List<Dish> GetAll();
        public Dish FindById(int id);
        public void Add(Dish e);
        public void Update(Dish e);
        public void Remove(int id);
        public List<Dish> GetById(int id);
    }
}
