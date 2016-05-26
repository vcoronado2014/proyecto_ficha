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

                    //armamos el detalle

                    detalle.AppendFormat("Rut: {0}, Fecha Nacimiento: {1}, Teléfono Celular: {2}, Teléfono Casa: {3}, Email: {4}", ficha.FipeRut.ToString() + ficha.FipeDv.ToString().ToUpper(), ficha.FipeFechaNacimiento.ToShortDateString(), ficha.FipeTelefonocel, ficha.FipeTelefonoCasa, ficha.FipeEMail);
                    fic.Detalle = detalle.ToString();
                    lista.Add(fic);
                }
            }

            return lista;
        }
        
    }
    public class FichaLiviana
    {
        public int FipeId { get; set; }
        public string NombreCompleto { get; set; }
        public int Estado { get; set; }
        public string Detalle { get; set; }
    }
}
