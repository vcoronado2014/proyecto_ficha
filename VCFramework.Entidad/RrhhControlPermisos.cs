using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    class RrhhControlPermisos
    {
        public int CnpeId { get; set; }
        public int FipeId { get; set; }
        public int DtpeId { get; set; }
        public DateTime CnpeFechaInicio { get; set; }
        public DateTime CnpeFechaFin { get; set; }
        public int CnpeDiasHabiles { get; set; }
        public string CnpeObservacion { get; set; }
        public int CnpeEstado { get; set; }
        public int CnpeEliminado { get; set; }
    }
}
