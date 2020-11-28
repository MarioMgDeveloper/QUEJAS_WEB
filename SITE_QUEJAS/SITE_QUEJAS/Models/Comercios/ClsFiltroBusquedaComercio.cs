using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Comercios
{
    public class ClsFiltroBusquedaComercio
    {
        public int IdDepto { get; set; }
        public int IdMuni { get; set; }
        public string Nombre { get; set; }
        public int PaginaActual { get; set; }
        public int SizePagina { get; set; }
    }
}
