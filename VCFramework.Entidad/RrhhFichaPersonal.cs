using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VCFramework.Entidad
{
    /// <summary>
    /// Summary description for RrhhFichaPersonal
    /// </summary>
    public class RrhhFichaPersonal
    {
        public RrhhFichaPersonal()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int FipeId { get; set; }
        public int FipeRut { get; set; }
        public string FipeNombres { get; set; }
        public string FipeApellidoPaterno { get; set; }
        public string FipeApellidoMaterno { get; set; }
        public DateTime FipeFechaNacimiento { get; set; }
        public int SexoId { get; set; }
        public int NacId { get; set; }
        public string FipeDireccion { get; set; }
        public int ComId { get; set; }
        public int RegId { get; set; }
        public int NiveId { get; set; }
        public int EstcId { get; set; }
        public string FipeTelefonocel { get; set; }
        public string FipeTelefonoCasa { get; set; }
        public string FipeEMail { get; set; }
        public int EmpId { get; set; }
        public int CargId { get; set; }
        public int ArenId { get; set; }
        public int CencId { get; set; }
        public int TicoId { get; set; }
        public DateTime FipeFechaIngreso { get; set; }
        public DateTime FipeFechaContratoVigente { get; set; }
        public DateTime FipeFechaTerminoContrato { get; set; }
        public int FipeNumeroDiasVacaciones { get; set; }
        public int RolId { get; set; }
        public int AfpId { get; set; }
        public int IsapId { get; set; }
        public int CjacId { get; set; }
        public int CafaId { get; set; }
        public int CnpeId { get; set; }
        public int FipeEstado { get; set; }
        public int FipeEliminado { get; set; }
        public string FipeUsuario { get; set; }
        public string FipeLogin { get; set; }
        public string FipeDv { get; set; }
        public string FipeNombreContacto { get; set; }

        public string FipeTelefonoContacto { get; set; }

    }
}