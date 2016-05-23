using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    class RrhhFpagoDeposito
    {
        public int FpdeId { get; set; }
        public int ForpId { get; set; }
        public string FpdeBanco { get; set; }
        public string FpdeNCuenta { get; set; }
        public int FpdeEstado { get; set; }
        public int FpdeEliminado { get; set; }
    }
}
