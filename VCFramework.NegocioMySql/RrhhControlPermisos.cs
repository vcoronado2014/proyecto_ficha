using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhControlPermisos
    {

        public static VCFramework.Entidad.RrhhControlPermisos DevuelveCnpeId(int cnpeId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhControlPermisos> lista2 = new List<VCFramework.Entidad.RrhhControlPermisos>();

            VCFramework.Entidad.RrhhControlPermisos retorno = new Entidad.RrhhControlPermisos();

            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "CNPE_ID";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = cnpeId.ToString();

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "CNPE_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhControlPermisos>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhControlPermisos>().ToList();
            }
            if (lista2 != null && lista2.Count == 1)
                retorno = lista2[0];


            return retorno;
        }
        public static List<VCFramework.Entidad.RrhhControlPermisos> ListarPerisosFipeId(int fipeId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhControlPermisos> lista2 = new List<VCFramework.Entidad.RrhhControlPermisos>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "FIPE_ID";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = fipeId.ToString();

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "CNPE_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhControlPermisos>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhControlPermisos>().ToList();
            }



            return lista2;
        }

        public static void Insertar(int CnpeId, int FipeId, int DtpeId, DateTime CnpeFechaInicio, DateTime CnpeFechaFin,
            int CnpeDiasHabiles, string CnpeObservacion, int EstadoId, int CnpeEliminado, int FipeIdAsignado)
        {
            //creamos la entidad
            VCFramework.Entidad.RrhhControlPermisos nuevoPermiso = new Entidad.RrhhControlPermisos();
            //esto hay que mejorarlo para calcular solo los dias habiles
            //nuevoPermiso.CnpeDiasHabiles = CnpeDiasHabiles;
            nuevoPermiso.CnpeDiasHabiles = Entidad.Utiles.DiferenciaDias(CnpeFechaInicio, CnpeFechaFin);
            nuevoPermiso.CnpeEliminado = 0;
            nuevoPermiso.EstadoId = 1; // lo dejamos en duro como solicitado
            nuevoPermiso.CnpeFechaFin = CnpeFechaFin;
            nuevoPermiso.CnpeFechaInicio = CnpeFechaInicio;
            nuevoPermiso.CnpeObservacion = CnpeObservacion;
            nuevoPermiso.DtpeId = DtpeId;
            nuevoPermiso.FipeId = FipeId;
            nuevoPermiso.FipeIdAsignado = FipeIdAsignado;
            nuevoPermiso.ObservacionJefe = "";
            nuevoPermiso.FechaObsJefe = DateTime.MinValue;

            if (CnpeFechaInicio <= DateTime.Now)
                throw new Exception("La fecha de Inicio del permiso debe ser superior a la actual");
            if (CnpeFechaFin <= DateTime.Now)
                throw new Exception("La fecha de termino del permiso debe ser superior a la actual");
            if (CnpeFechaInicio > CnpeFechaFin)
                throw new Exception("La fecha de Inicio no puede ser superior a la fecha de Término.");

            NegocioMySql.Factory factory = new Factory();
            int nuevoId = factory.Insertar<VCFramework.Entidad.RrhhControlPermisos>(nuevoPermiso);
            if (nuevoId <= 0)
                throw new Exception("Error al crear el Permiso.");
        }
        public static void Modificar(int CnpeId, int FipeId, int DtpeId, DateTime CnpeFechaInicio, DateTime CnpeFechaFin,
            int CnpeDiasHabiles, string CnpeObservacion, int EstadoId, int CnpeEliminado, int FipeIdAsignado)
        {
            //creamos la entidad
            VCFramework.Entidad.RrhhControlPermisos nuevoPermiso = new Entidad.RrhhControlPermisos();
            nuevoPermiso.CnpeDiasHabiles = CnpeDiasHabiles;
            nuevoPermiso.CnpeEliminado = 0;
            nuevoPermiso.EstadoId = EstadoId;
            nuevoPermiso.CnpeFechaFin = CnpeFechaFin;
            nuevoPermiso.CnpeFechaInicio = CnpeFechaInicio;
            nuevoPermiso.CnpeObservacion = CnpeObservacion;
            nuevoPermiso.DtpeId = DtpeId;
            nuevoPermiso.FipeId = FipeId;
            nuevoPermiso.CnpeId = CnpeId;
            nuevoPermiso.FipeIdAsignado = FipeIdAsignado;

            Exception ex = null;

            try
            {
                if (CnpeFechaInicio <= DateTime.Now)
                {
                    ex = new Exception("La fecha de Inicio del permiso debe ser superior a la actual");
                    throw new Exception("La fecha de Inicio del permiso debe ser superior a la actual");
                }
                if (CnpeFechaFin <= DateTime.Now)
                {
                    ex = new Exception("La fecha de termino del permiso debe ser superior a la actual");
                    throw new Exception("La fecha de termino del permiso debe ser superior a la actual");
                    
                }
                if (CnpeFechaInicio > CnpeFechaFin)
                {
                    ex = new Exception("La fecha de Inicio no puede ser superior a la fecha de Término.");
                    throw new Exception("La fecha de Inicio no puede ser superior a la fecha de Término.");
                    
                }
                if (EstadoId != 1)
                {
                    ex = new Exception("El permiso no se puede eliminar ya que está siendo procesado.");
                    throw new Exception("El permiso no se puede eliminar ya que está siendo procesado.");
                    
                }
                NegocioMySql.Factory factory = new Factory();
                int nuevoId = factory.Update<VCFramework.Entidad.RrhhControlPermisos>(nuevoPermiso, "CNPE_ID");
                if (nuevoId < 0)
                {
                    ex = new Exception("Error al Modificar el Permiso.");
                    throw new Exception("Error al Modificar el Permiso.");
                    
                }
            }
            catch
            {
                throw ex;
            }
        }
        public static void Eliminar(int CnpeId)
        {
            //creamos la entidad
            //nos traemos el elemento a Eliminar

            VCFramework.Entidad.RrhhControlPermisos permisoModificar = DevuelveCnpeId(CnpeId);
            if (permisoModificar.EstadoId != 1)
                throw new Exception("El permiso no se puede eliminar ya que está siendo procesado.");
            permisoModificar.CnpeEliminado = 1;
            permisoModificar.EstadoId = 0;
            //no se puede eliminart el Super Administrador

            NegocioMySql.Factory factory = new Factory();
            int nuevoId = factory.Update<VCFramework.Entidad.RrhhControlPermisos>(permisoModificar, "CNPE_ID");
            if (nuevoId < 0)
                throw new Exception("Error al Eliminar el Permiso.");

        }
    }
}
