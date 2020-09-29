using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class DonanteDALImpl : IDonanteDAL
    {
        private BDContext context;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<donante> GetDonantes(string name)
        {
            throw new NotImplementedException();
        }
    }
}
