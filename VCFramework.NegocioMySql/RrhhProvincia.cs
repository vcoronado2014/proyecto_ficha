using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhProvincia
    {
        public static List<VCFramework.Entidad.RrhhProvincia> ListarProvinciasPorRegion(int idReg)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhProvincia> lista2 = new List<VCFramework.Entidad.RrhhProvincia>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "PROV_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "PROV_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            FiltroGenerico filtroRegion = new FiltroGenerico();
            filtroRegion.Campo = "REG_ID";
            filtroRegion.TipoDato = TipoDatoGeneral.Entero;
            filtroRegion.Valor = idReg.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroRegion);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhProvincia>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhProvincia>().ToList();
            }
            if (lista2 != null && lista2.Count > 0)
            {
                Entidad.RrhhProvincia ent = new Entidad.RrhhProvincia();
                ent.ProvDescripcion = "Seleccione";
                ent.ProvId = 0;
                lista2.Insert(0, ent);
            }


            return lista2;
        }
    }
}
