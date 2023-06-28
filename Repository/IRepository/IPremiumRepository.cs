using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPremiumRepository
    {
        public List<Premium> GetAll();
        public Premium FindById(int id);
        public void Add(Premium e);
        public void Update(Premium e);
        public void Remove(int id);
    }
}
