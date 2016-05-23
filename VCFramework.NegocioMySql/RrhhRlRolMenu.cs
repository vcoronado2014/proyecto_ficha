using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhRlRolMenu
    {
        public static List<VCFramework.Entidad.RrhhRlRolMenu> ListarRlPorRolId(int rolId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhRlRolMenu> lista2 = new List<VCFramework.Entidad.RrhhRlRolMenu>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "RL_ACTIVO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "RL_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";


            FiltroGenerico filtroGrupoId = new FiltroGenerico();
            filtroGrupoId.Campo = "ROL_ID";
            filtroGrupoId.TipoDato = TipoDatoGeneral.Entero;
            filtroGrupoId.Valor = rolId.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroGrupoId);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhRlRolMenu>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhRlRolMenu>().ToList();
            }



            return lista2;
        }

        public static int Insertar(Entidad.RrhhRlRolMenu entidad)
        {
            int retorno = 0;

            NegocioMySql.Factory fac = new Factory();
            retorno = fac.Insertar<Entidad.RrhhRlRolMenu>(entidad);

            return retorno;
        }
        public static int Modificar(Entidad.RrhhRlRolMenu entidad)
        {
            int retorno = 0;

            NegocioMySql.Factory fac = new Factory();
            retorno = fac.Update<Entidad.RrhhRlRolMenu>(entidad);

            return retorno;
        }
    }
}
