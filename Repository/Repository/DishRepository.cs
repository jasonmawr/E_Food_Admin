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
    public class DishRepository : IDishRepository
    {
        public void Add(Dish e) => DishDAO.Add(e);

        public Dish FindById(int id) => DishDAO.FindById(id);

        public List<Dish> GetAll() => DishDAO.GetAll();

        public List<Dish> GetById(int id) => DishDAO.GetById(id);

        public void Remove(int id) => DishDAO.Remove(id);

        public void Update(Dish e) => DishDAO.Update(e);
    }
}
