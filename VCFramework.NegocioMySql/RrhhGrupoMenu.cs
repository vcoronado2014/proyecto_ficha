using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhGrupoMenu
    {
        public static List<VCFramework.Entidad.RrhhGrupoMenu> ListarGrupos()
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhGrupoMenu> lista2 = new List<VCFramework.Entidad.RrhhGrupoMenu>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "GRP_ACTIVO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "GRP_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhGrupoMenu>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhGrupoMenu>().ToList();
            }



            return lista2;
        }
        public static List<VCFramework.Entidad.RrhhGrupoMenu> ListarGruposPorRol(int rolId)
        {
            if (rolId == 0)
                return new List<Entidad.RrhhGrupoMenu>();
            else
                return ListarGrupos();
        }
        //son tan pocos los roles que vamos a ocupar generic para sacar el que necesitamos
        public static VCFramework.Entidad.RrhhGrupoMenu DevuelveGrupoPorId(int id)
        {
            return ListarGrupos().Find(p => p.GrpId == id);
        }

    }
}
