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
    public class RestaurantRepository : IRestaurantRepository
    {
        public void Add(Restaurant e) => RestaurantDAO.Add(e);

        public Restaurant FindById(int id) => RestaurantDAO.FindById(id);

        public List<Restaurant> GetAll() => RestaurantDAO.GetAll();

        public void Remove(int id) => RestaurantDAO.Remove(id);

        public void Update(Restaurant e) => RestaurantDAO.Update(e);

        public List<Restaurant> GetById(int id) => RestaurantDAO.GetById(id);
    }
}
