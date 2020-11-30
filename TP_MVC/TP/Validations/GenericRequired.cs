using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Validations
{
    public class GenericRequired : RequiredAttribute
    {
        public GenericRequired()
        {
            ErrorMessage = "Este campo es obligatorio.";
        }
    }
}
