using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhFPagoVista
    {
        public static List<VCFramework.Entidad.RrhhFpagoVista> ObtenerFormaPagoVistaFipeId(int fipeId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhFpagoVista> lista2 = new List<VCFramework.Entidad.RrhhFpagoVista>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "FPVI_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "FPVI_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            FiltroGenerico filtroFipe = new FiltroGenerico();
            filtroFipe.Campo = "FIPE_ID";
            filtroFipe.TipoDato = TipoDatoGeneral.Entero;
            filtroFipe.Valor = fipeId.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroFipe);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFpagoVista>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFpagoVista>().ToList();
            }

            return lista2;
        }
    }
}
