using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    class RrhhCargaFamiliar
    {
        public int CafaId { get; set; }
        public string CafaNombre { get; set; }
        public DateTime CafaFechaNacimiento { get; set; }
        public int SexId { get; set; }
        public int IdVin { get; set; }
        public int IdEst { get; set; }
        public int CafaEstado { get; set; }
        public int CafaEliminado { get; set; }
    }
}
