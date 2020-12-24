using JHCarCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JHCarCenter.Repositoty
{
    public interface IQutationRepository
    {
        Quatation GetQuatationById(int id);
    }
}
