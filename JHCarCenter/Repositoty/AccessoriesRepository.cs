using JHCarCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Repositoty
{
    public class AccessoriesRepository : IAccessoriesRepo
    {
        private readonly ApplicationDBContext _context;

        public AccessoriesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
       
        public IEnumerable<Accessories> GetAccessories()
        {
           return _context.Accessories.ToList();
        }

        public Accessories GetAccessoriesById(int id)
        {
            return _context.Accessories.FirstOrDefault(o=>o.AccessoriesID == id);
        }

       
    }
}
