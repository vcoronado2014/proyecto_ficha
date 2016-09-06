using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class EstadoPermiso
    {
        public static List<EstadosPermisos> ObtenerEstados()
        {
            List<EstadosPermisos> retorno = new List<EstadosPermisos>();
            EstadosPermisos estSin = new EstadosPermisos();
            estSin.Id = (int)Entidad.EstadoPermiso.Sin_Solicitar;
            estSin.Nombre = Entidad.EstadoPermiso.Sin_Solicitar.ToString().Replace("_", " ");
            retorno.Add(estSin);

            EstadosPermisos estCurso = new EstadosPermisos();
            estCurso.Id = (int)Entidad.EstadoPermiso.En_Curso;
            estCurso.Nombre = Entidad.EstadoPermiso.En_Curso.ToString().Replace("_", " ");
            retorno.Add(estCurso);

            EstadosPermisos estAu = new EstadosPermisos();
            estAu.Id = (int)Entidad.EstadoPermiso.Autorizado;
            estAu.Nombre = Entidad.EstadoPermiso.Autorizado.ToString().Replace("_", " ");
            retorno.Add(estAu);

            EstadosPermisos estRe = new EstadosPermisos();
            estRe.Id = (int)Entidad.EstadoPermiso.Rechazado;
            estRe.Nombre = Entidad.EstadoPermiso.Rechazado.ToString().Replace("_", " ");
            retorno.Add(estRe);


            return retorno;
        }
    }
    public class EstadosPermisos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
