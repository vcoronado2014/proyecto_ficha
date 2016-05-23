using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.Entidad
{
    class RrhhEmpresa
    {
        public int EmpId { get; set; }
        public int EmpRut { get; set; }
        public string EmpDv { get; set; }
        public string EmpRazonsocial { get; set; }
        public string EmpGiro { get; set; }
        public String EmpDireccion { get; set; }
        public int RegId { get; set; }
        public int ComId { get; set; }
        public String EmpTelefono1 { get; set; }
        public String EmpTelefono2 { get; set; }
        public String EmpTelefono3 { get; set; }
        public int EmopEstado { get; set; }
        public int EmpEliminado { get; set; }
    }
}
