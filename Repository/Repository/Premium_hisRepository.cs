using BussinessObject.DAO;
using BussinessObject.Models;
using EXE02_EFood_API.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace EXE02_EFood_API.Repository
{
    public class Premium_hisRepository : IPremium_hisRepository
    {
        public void Add(PremiumHi e) => Premium_hisDAO.Add(e);

        public PremiumHi FindById(int id) => Premium_hisDAO.FindById(id);

        public List<PremiumHi> GetAll() => Premium_hisDAO.GetAll();

        public void Remove(int id) => Premium_hisDAO.Remove(id);

        public void Update(PremiumHi e) => Premium_hisDAO.Update(e);
    }

}
