using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhRol
    {


        public static List<VCFramework.Entidad.RrhhRol> ListarRoles()
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhRol> lista2 = new List<VCFramework.Entidad.RrhhRol>();


                //creamos los filtros
                FiltroGenerico filtroActivo = new FiltroGenerico();
                filtroActivo.Campo = "ROL_ESTADO";
                filtroActivo.TipoDato = TipoDatoGeneral.Entero;
                filtroActivo.Valor = "1";

                FiltroGenerico filtroEliminado = new FiltroGenerico();
                filtroEliminado.Campo = "ROL_ELIMINADO";
                filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
                filtroEliminado.Valor = "0";

                //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
                List<FiltroGenerico> filtros = new List<FiltroGenerico>();
                //agregamos los filtros a la lista
                filtros.Add(filtroActivo);
                filtros.Add(filtroEliminado);
                //ahora leemos
                List<object> lista = fac.Leer<VCFramework.Entidad.RrhhRol>(filtros);
                if (lista != null)
                {
                    lista2 = lista.Cast<VCFramework.Entidad.RrhhRol>().ToList();
                }


            
            return lista2;
        }
        //son tan pocos los roles que vamos a ocupar generic para sacar el que necesitamos
        public static VCFramework.Entidad.RrhhRol DevuelveRolPorId(int id)
        {
            return ListarRoles().Find(p => p.RolId == id);
        }

        public static void Insertar(int RolId, string RolDescripcion, int RolEstado, int RolEliminado)
        {
            //creamos la entidad
            VCFramework.Entidad.RrhhRol nuevoRol = new Entidad.RrhhRol();
            nuevoRol.RolDescripcion = RolDescripcion;
            nuevoRol.RolEliminado = 0;
            nuevoRol.RolEstado = 1;
            NegocioMySql.Factory factory = new Factory();
            int nuevoId = factory.Insertar<VCFramework.Entidad.RrhhRol>(nuevoRol);
            if (nuevoId <= 0)
                throw new Exception("Error al crear el Rol");
        }
        public static void Modificar(int RolId, string RolDescripcion, int RolEstado, int RolEliminado)
        {
            //creamos la entidad
            VCFramework.Entidad.RrhhRol rolModificar = new Entidad.RrhhRol();
            rolModificar.RolDescripcion = RolDescripcion;
            rolModificar.RolEliminado = RolEliminado;
            rolModificar.RolEstado = RolEstado;
            rolModificar.RolId = RolId;
            NegocioMySql.Factory factory = new Factory();
            int nuevoId = factory.Update<VCFramework.Entidad.RrhhRol>(rolModificar);
            if (nuevoId < 0)
                throw new Exception("Error al Modificar el Rol");
        }
        public static void Eliminar(int RolId)
        {
            //creamos la entidad
            //nos traemos el elemento a Eliminar
            
            VCFramework.Entidad.RrhhRol rolModificar = DevuelveRolPorId(RolId);
            rolModificar.RolEliminado = 1;
            rolModificar.RolEstado = 0;
            //no se puede eliminart el Super Administrador
            if (RolId == 1)
                throw new Exception("Error al Eliminar el Rol");
            else
            {
                NegocioMySql.Factory factory = new Factory();
                int nuevoId = factory.Update<VCFramework.Entidad.RrhhRol>(rolModificar);
                if (nuevoId < 0)
                    throw new Exception("Error al Eliminar el Rol");
            }
        }

    }
}
