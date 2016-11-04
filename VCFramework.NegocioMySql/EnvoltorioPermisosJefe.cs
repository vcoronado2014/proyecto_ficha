using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class EnvoltorioPermisosJefe
    {
        public static List<VCFramework.Entidad.RrhhControlPermisos> ListarPermisosJefe(int fipeIdJefe)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhControlPermisos> lista2 = new List<VCFramework.Entidad.RrhhControlPermisos>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "FIPE_ID_ASIGNADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = fipeIdJefe.ToString();

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

        public static List<Entidad.EnvoltorioPermisosJefe> ListaEnvoltorioPermisosJefe(int fipeIdJefe)
        {
            List<Entidad.EnvoltorioPermisosJefe> listaDevolver = new List<Entidad.EnvoltorioPermisosJefe>();

            List<Entidad.RrhhControlPermisos> lista = ListarPermisosJefe(fipeIdJefe);
            if (lista != null && lista.Count > 0)
            {
                foreach(Entidad.RrhhControlPermisos cnp in lista)
                {
                    Entidad.EnvoltorioPermisosJefe env = new Entidad.EnvoltorioPermisosJefe();
                    env.CnpeDiasHabiles = cnp.CnpeDiasHabiles;
                    env.CnpeEliminado = cnp.CnpeEliminado;
                    env.CnpeFechaFin = cnp.CnpeFechaFin;
                    env.CnpeFechaInicio = cnp.CnpeFechaInicio;
                    env.CnpeId = cnp.CnpeId;
                    env.CnpeObservacion = cnp.CnpeObservacion;
                    env.DtpeId = cnp.DtpeId;
                    env.EstadoId = cnp.EstadoId;
                    env.FechaObsJefe = cnp.FechaObsJefe;
                    env.FipeId = cnp.FipeId;
                    env.FipeIdAsignado = cnp.FipeIdAsignado;
                    env.ObservacionJefe = cnp.ObservacionJefe;

                    Entidad.RrhhFichaPersonal fic = NegocioMySql.RrhhFichaPersonal.ObtenerFichaPorId(cnp.FipeId);
                    if (fic != null && fic.FipeId > 0)
                        env.NombreTrabajador = fic.FipeNombres + " " + fic.FipeApellidoPaterno + " " + fic.FipeApellidoMaterno;

                    listaDevolver.Add(env);

                }
            }

            return listaDevolver;
        }

        public static void Modificar(int CnpeId, int FipeId, int DtpeId, DateTime CnpeFechaInicio, DateTime CnpeFechaFin,
    int CnpeDiasHabiles, string CnpeObservacion, int EstadoId, int CnpeEliminado, int FipeIdAsignado, string ObservacionJefe)
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
            nuevoPermiso.ObservacionJefe = ObservacionJefe;
            nuevoPermiso.FechaObsJefe = DateTime.Now;

            Exception ex = null;

            try
            {

                if (EstadoId == 0 || EstadoId == 1)
                {
                    ex = new Exception("Debe ingresar un estado válido para el permiso.");
                    throw new Exception("Debe ingresar un estado válido para el permiso.");
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
    }
}
