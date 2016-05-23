using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    public class RrhhSubgrupoMenu
    {
        public int SgrpId { get; set; }
        public string SgrpItem { get; set; }
        public string SgrpUrl { get; set; }
        public int GrpId { get; set; }
        public int SgrpActivo { get; set; }
        public int SgrpEliminado { get; set; }
    }
}
