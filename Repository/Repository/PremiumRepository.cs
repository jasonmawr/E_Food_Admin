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
    public class PremiumRepository : IPremiumRepository
    {
        public void Add(Premium e) => PremiumDAO.Add(e);

        public Premium FindById(int id) => PremiumDAO.FindById(id);

        public List<Premium> GetAll() => PremiumDAO.GetAll();

        public void Remove(int id) => PremiumDAO.Remove(id);

        public void Update(Premium e) => PremiumDAO.Update(e);
    }
}
