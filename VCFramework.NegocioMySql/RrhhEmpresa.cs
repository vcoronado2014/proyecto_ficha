using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhEmpresa
    {
        public static VCFramework.Entidad.RrhhEmpresa ObtenerEmpresa(int id)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhEmpresa> lista2 = new List<VCFramework.Entidad.RrhhEmpresa>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "EMP_ID";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = id.ToString();

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "EMP_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhEmpresa>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhEmpresa>().ToList();
            }
            if (lista2 != null && lista2.Count == 1)
                return lista2[0];
            else
                return new Entidad.RrhhEmpresa();
        }
    }
}
