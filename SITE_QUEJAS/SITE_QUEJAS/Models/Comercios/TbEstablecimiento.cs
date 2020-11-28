using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Comercios
{
    public class TbEstablecimiento
    {
        public int IdEstablecimiento { get; set; }
        public int IdEmpresa { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre.")]
        [Display(Name = "Nombre")]
        public string NombreComplementario { get; set; }
        [Required(ErrorMessage = "Ingrese una dirección.")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Patente")]
        public string PatenteComercio { get; set; }
        [Display(Name = "Municipio")]
        public int IdMunicipio { get; set; }
        [Required(ErrorMessage = "Seleccione un estado")]
        [Range(1, 1000, ErrorMessage = "Seleccione un estado")]
        [Display(Name = "Estado")]
        public int? IdEstado { get; set; }
    }
}
