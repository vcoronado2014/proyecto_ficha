using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhSexo
    {
        public static List<VCFramework.Entidad.RrhhSexo> ListarSexo()
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhSexo> lista2 = new List<VCFramework.Entidad.RrhhSexo>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "SEXO_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "SEXO_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhSexo>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhSexo>().ToList();
            }



            return lista2;
        }
    }
}
