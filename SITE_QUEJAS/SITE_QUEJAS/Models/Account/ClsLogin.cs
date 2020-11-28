using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Account
{
    public class ClsLogin
    {
        [Required(ErrorMessage ="El correo es obligatorio.")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [Required (ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
