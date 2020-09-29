using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class OrganizacionDALImpl : IOrganizacionDAL
    {
        private BDContext context;
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<organizacion> GetOrganizaciones(string name)
        {
            throw new NotImplementedException();
        }
    }
}
