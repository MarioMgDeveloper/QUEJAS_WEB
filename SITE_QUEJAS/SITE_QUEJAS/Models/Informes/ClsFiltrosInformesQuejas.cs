using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Informes
{
    public class ClsFiltrosInformesQuejas
    {
        [Display(Name="Region")]
        public int? IdRegion { get; set; }
        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }
        [Display(Name = "Municipio")]
        public int? IdMunicipio { get; set; }
        [Display(Name = "Estado")]
        public int? IdEstado { get; set; }
        public string Nombrecomercio { get; set; }
        [Display(Name = "Del")]
        [DataType(DataType.Date)]
        public DateTime? Del { get; set; }
        [Display(Name = "Al")]
        [DataType(DataType.Date)]
        public DateTime? Al { get; set; }
    }
}
