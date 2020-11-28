using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Comercios
{
    public class ClsCreateEmpresa
    {
        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }
        public TbEmpresa Empresa { get; set; }
    }
}
