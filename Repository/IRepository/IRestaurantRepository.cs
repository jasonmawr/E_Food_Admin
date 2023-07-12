using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IRestaurantRepository
    {
        public List<Restaurant> GetAll();
        public Restaurant FindById(int id);
        public void Add(Restaurant e);
        public void Update(Restaurant e);
        public void Remove(int id);
        public List<Restaurant> GetById(int id);
    }
}
