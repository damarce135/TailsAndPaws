﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TP.Validations;

#nullable disable

namespace TP.Models
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            Animals = new HashSet<Animal>();
            ProdProveedors = new HashSet<ProdProveedor>();
        }

        [Key]
        [Display(Name ="Identificador")]
        [GenericRequired]
        public int IdOrganizacion { get; set; }

        [GenericRequired]
        public string? Tipo { get; set; }

        [GenericRequired]
        public string? Nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44,ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string? Apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage = "Apellido inválido, debe contener letras y la primera debe ser mayúscula.")]
        [StringLength(44, ErrorMessage = "El campo debe utilizar menos de 45 caracteres.")]
        public string? Apellido2 { get; set; }

        [GenericRequired]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "El teléfono debe ser válido.  Ingrese sólo valores númericos.")]
        [RegularExpression(@"^([0-9]{8})$", ErrorMessage = "El teléfono debe ser válido. Ingrese sólo valores númericos.")]
        public string? Telefono { get; set; }

        [GenericRequired]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El correo electrónico debe ser válido.")]
        public string? Email { get; set; }

        [GenericRequired]
        public string Descripcion { get; set; }

        [Display(Name = "Provincia")]
        [Required]
        public int IdProvincia { get; set; }

        //[Display(Name = "Cantón")]
        //[Required]
        //public int IdCanton { get; set; }

        //[Display(Name = "Distrito")]
        //[Required]
        //public int IdDistrito { get; set; }

        [Display(Name = "Dirección")]
        [GenericRequired]
        public string? DetalleDireccion { get; set; }

        //[Display(Name = "Estado")]
        //public bool Habilitado { get; set; }

        //[ForeignKey("IdCanton")]
        //public virtual Canton IdCantonNavigation { get; set; }

        //[ForeignKey("IdDistrito")]
        //public virtual Distrito IdDistritoNavigation { get; set; }

        [ForeignKey("IdProvincia")]
        [Display(Name = "Provincia")]
        public virtual Provincium IdProvinciaNavigation { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<ProdProveedor> ProdProveedors { get; set; }
    }
}
