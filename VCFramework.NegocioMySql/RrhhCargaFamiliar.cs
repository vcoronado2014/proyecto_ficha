using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhCargaFamiliar
    {
        public static void Insertar(int CarfId, int FipeId, string CarfNombres, int SexId, int VinId, int CarfEstado, int CarfEliminado, string CarFechaNacimiento)
        {
            if (FipeId > 0)
            {
                //creamos la entidad
                VCFramework.Entidad.RrhhCargaFamiliar nuevaCarga = new Entidad.RrhhCargaFamiliar();
                nuevaCarga.CarFechaNacimiento = Convert.ToDateTime(CarFechaNacimiento);
                nuevaCarga.CarfEliminado = 0;
                nuevaCarga.CarfEstado = 1;
                nuevaCarga.CarfNombres = CarfNombres;
                nuevaCarga.FipeId = FipeId;
                nuevaCarga.SexId = SexId;
                nuevaCarga.VinId = VinId;

                NegocioMySql.Factory factory = new Factory();
                int nuevoId = factory.Insertar<VCFramework.Entidad.RrhhCargaFamiliar>(nuevaCarga);
                if (nuevoId <= 0)
                    throw new Exception("Error al crear la carga familiar");
            }
            else
                throw new Exception("Debe Guardar la Ficha del Trabajador antes de Agregar una Carga");
        }
        public static void Modificar(int CarfId, int FipeId, string CarfNombres, int SexId, int VinId, int CarfEstado, int CarfEliminado, string CarFechaNacimiento)
        {
            if (FipeId > 0)
            {
                VCFramework.Entidad.RrhhCargaFamiliar nuevaCarga = new Entidad.RrhhCargaFamiliar();
                nuevaCarga.CarFechaNacimiento = Convert.ToDateTime(CarFechaNacimiento);
                nuevaCarga.CarfEliminado = CarfEliminado;
                nuevaCarga.CarfEstado = CarfEstado;
                nuevaCarga.CarfNombres = CarfNombres;
                nuevaCarga.FipeId = FipeId;
                nuevaCarga.SexId = SexId;
                nuevaCarga.VinId = VinId;
                nuevaCarga.CarfId = CarfId;

                NegocioMySql.Factory factory = new Factory();
                int nuevoId = factory.Update<VCFramework.Entidad.RrhhCargaFamiliar>(nuevaCarga, "CARF_ID");
                if (nuevoId <= 0)
                    throw new Exception("Error al modificar la carga familiar");
            }
            else
                throw new Exception("Debe Guardar la Ficha del Trabajador antes de Modificar una Carga");
        }
        public static List<VCFramework.Entidad.RrhhCargaFamiliar> ListarCargasPorId(int id)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhCargaFamiliar> lista2 = new List<VCFramework.Entidad.RrhhCargaFamiliar>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "CARF_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "CARF_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";

            FiltroGenerico filtroFipe = new FiltroGenerico();
            filtroFipe.Campo = "CARF_ID";
            filtroFipe.TipoDato = TipoDatoGeneral.Entero;
            filtroFipe.Valor = id.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroFipe);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhCargaFamiliar>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhCargaFamiliar>().ToList();
            }



            return lista2;
        }
        public static List<VCFramework.Entidad.RrhhCargaFamiliar> ListarCargasPorFipeId(int fipeId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhCargaFamiliar> lista2 = new List<VCFramework.Entidad.RrhhCargaFamiliar>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "CARF_ESTADO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "CARF_ELIMINADO";
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
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhCargaFamiliar>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhCargaFamiliar>().ToList();
            }



            return lista2;
        }
        public static void Eliminar(int CarfId)
        {
            //creamos la entidad
            //nos traemos el elemento a Eliminar

            List<VCFramework.Entidad.RrhhCargaFamiliar> rolModificar = ListarCargasPorId(CarfId);
            rolModificar[0].CarfEliminado = 1;
            rolModificar[0].CarfEstado = 0;
            //no se puede eliminart el Super Administrador
            if (CarfId == 1)
                throw new Exception("Error al Eliminar el Rol");
            else
            {
                NegocioMySql.Factory factory = new Factory();
                int nuevoId = factory.Update<VCFramework.Entidad.RrhhCargaFamiliar>(rolModificar[0]);
                if (nuevoId < 0)
                    throw new Exception("Error al Eliminar la carga familiar.");
            }
        }
    }
}
