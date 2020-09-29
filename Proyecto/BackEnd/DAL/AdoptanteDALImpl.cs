using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class AdoptanteDALImpl : IAdoptanteDAL
    {
        private BDContext context;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<adoptante> GetAdoptantes(string name)
        {
            throw new NotImplementedException();
        }
    }
}
