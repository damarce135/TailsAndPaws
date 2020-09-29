﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class AdopcionViewModel
    {
        [Key]
        [Display(Name = "Identificador")]
        public int idAdopcion { get; set; }

        [Display(Name = "Animal")]
        public int idAnimal { get; set; }
        public IEnumerable<animal> animales { get; set; }
        public animal animal { get; set; }

        [Display(Name = "Adoptante")]
        public int idAdoptante { get; set; }
        public IEnumerable<adoptante> adoptantes { get; set; }
        public adoptante adoptante { get; set; }

        [Display(Name = "Fecha de Adopción")]
        public Nullable<System.DateTime> fechaAdopcion { get; set; }

        [Display(Name = "Fecha de Seguimiento")]
        public Nullable<System.DateTime> fechaSeguimiento { get; set; }

        [Display(Name = "Estado")]
        public Nullable<bool> habilitado { get; set; }
    }

}