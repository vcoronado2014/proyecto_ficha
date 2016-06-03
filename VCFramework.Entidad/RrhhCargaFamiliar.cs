using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    public class RrhhCargaFamiliar
    {
        public int CarfId { get; set; }
        public string CarfNombres { get; set; }
        public DateTime CarFechaNacimiento { get; set; }
        public int SexId { get; set; }
        public int VinId { get; set; }
        public int FipeId { get; set; }
        public int CarfEstado { get; set; }
        public int CarfEliminado { get; set; }
    }
}
