using JHCarCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Repositoty
{
    public class QuatationRepository : IQutationRepository
    {
        private readonly ApplicationDBContext _context;

        public QuatationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Quatation> GetAll()
        {
            List<Quatation> q = _context.Quatations.Include("Customer").Include("Vehicle").ToList();
            return q;
        }

        public Quatation GetQuatationById(int id)
        {
            Quatation q = _context.Quatations.Include("Customer").Include("Vehicle").FirstOrDefault(x => x.QuatationID == id);
            return q;

        }
    }
}
