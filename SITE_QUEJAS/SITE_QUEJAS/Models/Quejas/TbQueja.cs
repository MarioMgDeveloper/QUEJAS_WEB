using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Models.Quejas
{
    public class TbQueja
    {
        public int IdQueja { get; set; }
        public string Descripcion { get; set; }
        public int? IdCategoriaQueja { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdEstado { get; set; }
        public int? IdUsuarioResuleve { get; set; }
        public string DescripcionResuelve { get; set; }
        public int? IdEstablecimiento { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
