using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Catalogos
{
    public class TbDepartamento
    {
        public int IdDepartamento { get; set; }
        public string CodigoDepartamento { get; set; }
        public int IdRegion { get; set; }
        public string NombreDepartamento { get; set; }
    }
}
