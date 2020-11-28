using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Catalogos
{
    public class TbMunicipio
    {
        public int IdMunicipio { get; set; }
        public string CodigoMunicipio { get; set; }
        public int IdDepartamento { get; set; }
        public string NombreMunicipio { get; set; }
    }
}
