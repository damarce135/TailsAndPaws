﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class AdopcionDALImpl : IAdopcionDAL
    {
        private BDContext context;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<adopcion> GetAdopciones(string name)
        {
            throw new NotImplementedException();
        }
    }
}