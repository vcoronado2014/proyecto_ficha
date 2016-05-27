using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhComuna
    {
        public static List<VCFramework.Entidad.RrhhComuna> ListarComunasPorProvincia(int idProv)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhComuna> lista2 = new List<VCFramework.Entidad.RrhhComuna>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "COM_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "COM_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            FiltroGenerico filtroRegion = new FiltroGenerico();
            filtroRegion.Campo = "PRV_ID";
            filtroRegion.TipoDato = TipoDatoGeneral.Entero;
            filtroRegion.Valor = idProv.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroRegion);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhComuna>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhComuna>().ToList();
            }

            if (lista2 != null && lista2.Count > 0)
            {
                Entidad.RrhhComuna ent = new Entidad.RrhhComuna();
                ent.ComDescripcion = "Seleccione";
                ent.ComId = 0;
                lista2.Insert(0, ent);
            }

            return lista2;
        }
    }
}
