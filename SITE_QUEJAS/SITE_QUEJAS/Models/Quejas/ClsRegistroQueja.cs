using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Quejas
{
    public class ClsRegistroQueja
    {

        public int? IdQueja { get; set; }
        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }
        [Display(Name = "Municipio")]
        public int? IdMunicipio { get; set; }
        [Display(Name = "Comercio")]
        [Required(ErrorMessage = "Elija un comercio")]
        [Range(1,10000,ErrorMessage ="Elija un comercio")]
        public int? IdComercio { get; set; }
        [Display(Name = "Tipo queja")]
        [Required(ErrorMessage = "Elija un tipo de queja")]
        [Range(1, 10000, ErrorMessage = "Elija un tipo de queja")]
        public int? IdTipoQueja { get; set; }
        [Display(Name = "Descripción")]
        [MaxLength(500,ErrorMessage = "No puede ingresar más de 500 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string DescripcionQueja { get; set; }


        //------------Campo para filtrar por nombre de comercio
        public string NombreBusqueda { get; set; }
        public string TextoComercioSeleccionado { get; set; }
    }
}
