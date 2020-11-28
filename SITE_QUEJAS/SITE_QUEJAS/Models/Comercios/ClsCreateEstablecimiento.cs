using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Comercios
{
    public class ClsCreateEstablecimiento
    {
        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }
        public TbEstablecimiento Establecimiento { get; set; }
    }
}
