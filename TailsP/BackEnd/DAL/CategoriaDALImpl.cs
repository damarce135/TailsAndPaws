using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CategoriaDALImpl : ICategoriaDAL
    {
        private TPEntities context;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<categoria> GetCategorias(string name)
        {
            throw new NotImplementedException();
        }
    }
}
