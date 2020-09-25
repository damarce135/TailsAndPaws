using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly BDContext Context;
        public IDALGenerico<T> genericDAL;

        public UnidadDeTrabajo(BDContext context)
        {
            Context = context;
            genericDAL = new DALGenericoImpl<T>(Context);
        }

        public bool Complete()
        {
            try
            {
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
}
