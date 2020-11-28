using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Comercios
{
    public class TbEmpresa
    {
        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre")]
        [Display(Name = "Nombre")]
        public string NombreEmpresa { get; set; }
        [Display(Name = "Dirección fiscal")]
        public string DireccionFiscal { get; set; }
        [Required(ErrorMessage = "Ingrese un nit")]
        [Display(Name = "Nit")]
        public string Nit { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Elija un estado")]
        [Range(1,500,ErrorMessage = "Elija un estado")]
        public int? IdEstado { get; set; }
    }
}
