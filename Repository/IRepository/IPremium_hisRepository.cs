using BussinessObject.Models;
using System.Collections.Generic;

namespace EXE02_EFood_API.Repository.IRepository
{
    public interface IPremium_hisRepository
    {
        public List<PremiumHi> GetAll();
        public PremiumHi FindById(int id);
        public void Add(PremiumHi e);
        public void Update(PremiumHi e);
        public void Remove(int id);
    }
}
