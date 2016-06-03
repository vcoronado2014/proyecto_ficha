using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhFormaPago
    {
        public static List<VCFramework.Entidad.RrhhFormaPago> ListarFPago()
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhFormaPago> lista2 = new List<VCFramework.Entidad.RrhhFormaPago>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "FORP_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "FORP_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFormaPago>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFormaPago>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                Entidad.RrhhFormaPago ent = new Entidad.RrhhFormaPago();
                ent.ForpDescripcion = "Seleccione";
                ent.ForpId = 0;
                lista2.Insert(0, ent);
            }

            return lista2;
        }
    }
}
