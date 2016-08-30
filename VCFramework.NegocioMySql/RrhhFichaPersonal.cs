using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhFichaPersonal
    {
        public static Entidad.RrhhFichaPersonal Validar(string nombreUsuario, string password)
        {
            Entidad.RrhhFichaPersonal entidad = new Entidad.RrhhFichaPersonal();
            List<Entidad.RrhhFichaPersonal> entidades = ListarPersonalPorUsuarioYPasword(nombreUsuario, password);
            if (entidades != null && entidades.Count == 1)
                entidad = entidades[0];
            return entidad;
        }
        public static Entidad.RrhhFichaPersonal Validar(string nombreUsuario)
        {
            Entidad.RrhhFichaPersonal entidad = new Entidad.RrhhFichaPersonal();
            List<Entidad.RrhhFichaPersonal> entidades = ListarPersonalPorUsuario(nombreUsuario);
            if (entidades != null && entidades.Count == 1)
                entidad = entidades[0];
            return entidad;
        }
        public static List<VCFramework.Entidad.RrhhFichaPersonal> ListarPersonalPorUsuario(string usuario)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();

            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "FIPE_USUARIO";
            filtro.Valor = usuario.ToString();
            filtro.TipoDato = TipoDatoGeneral.Varchar;


            //agregamos al filtro
            filtros.Add(filtro);
 

            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFichaPersonal>(filtros);
            List<VCFramework.Entidad.RrhhFichaPersonal> lista2 = new List<VCFramework.Entidad.RrhhFichaPersonal>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFichaPersonal>().ToList();
            }
            return lista2;
        }
        public static List<VCFramework.Entidad.RrhhFichaPersonal> ListarPersonalPorUsuarioYPasword(string usuario, string password)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();

            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "FIPE_USUARIO";
            filtro.Valor = usuario.ToString();
            filtro.TipoDato = TipoDatoGeneral.Varchar;


            FiltroGenerico filtro1 = new FiltroGenerico();
            filtro1.Campo = "FIPE_LOGIN";
            filtro1.Valor = password.ToString();
            filtro1.TipoDato = TipoDatoGeneral.Varchar;
            //agregamos al filtro
            filtros.Add(filtro);
            filtros.Add(filtro1);

            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFichaPersonal>(filtros);
            List<VCFramework.Entidad.RrhhFichaPersonal> lista2 = new List<VCFramework.Entidad.RrhhFichaPersonal>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFichaPersonal>().ToList();
            }
            return lista2;
        }
        public static VCFramework.Entidad.RrhhFichaPersonal ObtenerFichaPorId(int id)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();

            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "FIPE_ID";
            filtro.Valor = id.ToString();
            filtro.TipoDato = TipoDatoGeneral.Varchar;

            //agregamos al filtro
            filtros.Add(filtro);
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFichaPersonal>(filtros);
            VCFramework.Entidad.RrhhFichaPersonal lista2 = new VCFramework.Entidad.RrhhFichaPersonal();
            try
            {
                
                if (lista != null)
                {
                    lista2 = lista.Cast<VCFramework.Entidad.RrhhFichaPersonal>().ToList()[0];
                }
            }
            catch(Exception EX)
            {
                throw EX;
            }

            return lista2;
        }

        public static List<VCFramework.Entidad.RrhhFichaPersonal> ListarPersonal()
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();

            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "FIPE_ELIMINADO";
            filtro.Valor = "0";
            filtro.TipoDato = TipoDatoGeneral.Entero;

            //agregamos al filtro
            filtros.Add(filtro);

            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFichaPersonal>(filtros);
            List<VCFramework.Entidad.RrhhFichaPersonal> lista2 = new List<VCFramework.Entidad.RrhhFichaPersonal>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFichaPersonal>().ToList();
            }
            return lista2;
        }

        public static List<FichaLiviana> ListaUsuarios()
        {
            List<FichaLiviana> lista = new List<FichaLiviana>();

            List<VCFramework.Entidad.RrhhFichaPersonal> ListarP = ListarPersonal();

            if (ListarP != null && ListarP.Count > 0)
            {
                foreach(Entidad.RrhhFichaPersonal ficha in ListarP)
                {
                    StringBuilder detalle = new StringBuilder();
                    FichaLiviana fic = new FichaLiviana();
                    fic.FipeId = ficha.FipeId;
                    fic.NombreCompleto = ficha.FipeNombres + " " + ficha.FipeApellidoPaterno + " " + ficha.FipeApellidoMaterno;
                    fic.Estado = ficha.FipeEstado;
                    fic.Rut = ficha.FipeRut.ToString() + "-" + ficha.FipeDv;

                    if (ficha.FipeFechaIngreso != null && (ficha.FipeFechaTerminoContrato == DateTime.MinValue || ficha.FipeFechaTerminoContrato == Convert.ToDateTime("01-01-1900")))
                    {
                        fic.EstadoString = "Vinculado";
                    }
                    if(ficha.FipeFechaIngreso != null && ficha.FipeFechaTerminoContrato >= ficha.FipeFechaIngreso)
                    {
                        fic.EstadoString = "Desvinculado";
                    }
                    if (ficha.FipeFechaIngreso == DateTime.MinValue && (ficha.FipeFechaTerminoContrato == DateTime.MinValue || ficha.FipeFechaTerminoContrato == Convert.ToDateTime("01-01-1900")))
                    {
                        fic.EstadoString = "Por Vincular";
                    }
                    //armamos el detalle

                    detalle.AppendFormat("Rut: {0}, Fecha Nacimiento: {1}, Teléfono Celular: {2}, Teléfono Casa: {3}, Email: {4}", ficha.FipeRut.ToString() + ficha.FipeDv.ToString().ToUpper(), ficha.FipeFechaNacimiento.ToShortDateString(), ficha.FipeTelefonocel, ficha.FipeTelefonoCasa, ficha.FipeEMail);
                    fic.Detalle = detalle.ToString();
                    fic.NombreCompleto = fic.NombreCompleto + ", " + fic.Rut;
                    lista.Add(fic);
                }
            }

            return lista;
        }

        public static int Eliminar(int FipeId)
        {
            int retorno = 0;

            try
            {
                if (FipeId > 0)
                {
                    VCFramework.Entidad.RrhhFichaPersonal ficha = ObtenerFichaPorId(FipeId);
                    if (ficha.FipeId > 0)
                    {
                        ficha.FipeEliminado = 1;
                        ficha.FipeEstado = 0;
                        Factory fac = new Factory();
                        fac.Update<Entidad.RrhhFichaPersonal>(ficha, "FIPE_ID");

                    }
                    else
                        throw new Exception("No hay ficha para eliminar.");
                }
                else
                    throw new Exception("No hay ficha para eliminar.");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return retorno;
        }

        public static VCFramework.Entidad.RrhhFichaPersonal ObtenerUsuarioPorRut(int rut, string dv)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            VCFramework.Entidad.RrhhFichaPersonal entidad = new Entidad.RrhhFichaPersonal();

            FiltroGenerico filtro = new FiltroGenerico();
            filtro.Campo = "FIPE_RUT";
            filtro.Valor = rut.ToString();
            filtro.TipoDato = TipoDatoGeneral.Entero;


            FiltroGenerico filtro1 = new FiltroGenerico();
            filtro1.Campo = "FIPE_DV";
            filtro1.Valor = dv.ToString();
            filtro1.TipoDato = TipoDatoGeneral.Varchar;

            FiltroGenerico filtro2 = new FiltroGenerico();
            filtro2.Campo = "FIPE_ELIMINADO";
            filtro2.Valor = "0";
            filtro2.TipoDato = TipoDatoGeneral.Entero;

            //agregamos al filtro
            filtros.Add(filtro);
            filtros.Add(filtro1);
            filtros.Add(filtro2);
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhFichaPersonal>(filtros);
            List<VCFramework.Entidad.RrhhFichaPersonal> lista2 = new List<VCFramework.Entidad.RrhhFichaPersonal>();
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhFichaPersonal>().ToList();
            }
            if (lista2 != null && lista2.Count == 1)
                entidad = lista2[0];
            return entidad;
        }

    }
    public class FichaLiviana
    {
        public int FipeId { get; set; }
        public string NombreCompleto { get; set; }
        public int Estado { get; set; }
        public string Detalle { get; set; }
        public string Rut { get; set; }
        public string EstadoString { get; set; }
    }
}
