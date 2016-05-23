using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    public class RrhhGrupoMenu
    {
        public int GrpId { get; set; }
        public string GrpItem { get; set; }
        public string GrpUrl { get; set; }
        public int GrpVisible { get; set; }
        public int GrpActivo { get; set; }
        public int GrpEliminado { get; set; }
    }
}
