using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhFPagoDeposito
    {
        public static List<VCFramework.Entidad.RrhhFpagoDeposito> ObtenerFormaPagoDepositoFipeId(int fipeId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhFpagoDeposito> lista2 = new List<VCFramework.Entidad.RrhhFpagoDeposito>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "FPDE_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "FPDE_ELIMINADO";
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
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFpagoDeposito>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFpagoDeposito>().ToList();
            }

            return lista2;
        }
    }
}
