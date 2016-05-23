using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class RrhhSubgrupoMenu
    {
        public static List<VCFramework.Entidad.RrhhSubgrupoMenu> ListarSubGruposPorIdGrupo(int grpId)
        {
            VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();
            List<VCFramework.Entidad.RrhhSubgrupoMenu> lista2 = new List<VCFramework.Entidad.RrhhSubgrupoMenu>();


            //creamos los filtros
            FiltroGenerico filtroActivo = new FiltroGenerico();
            filtroActivo.Campo = "SGRP_ACTIVO";
            filtroActivo.TipoDato = TipoDatoGeneral.Entero;
            filtroActivo.Valor = "1";

            FiltroGenerico filtroEliminado = new FiltroGenerico();
            filtroEliminado.Campo = "SGRP_ELIMINADO";
            filtroEliminado.TipoDato = TipoDatoGeneral.Entero;
            filtroEliminado.Valor = "0";


            FiltroGenerico filtroGrupoId = new FiltroGenerico();
            filtroGrupoId.Campo = "GRP_ID";
            filtroGrupoId.TipoDato = TipoDatoGeneral.Entero;
            filtroGrupoId.Valor = grpId.ToString();

            //CREAMOS UNA LISTA DE FILTROS PARA PASARLOS COMO PARAMETROS
            List<FiltroGenerico> filtros = new List<FiltroGenerico>();
            //agregamos los filtros a la lista
            filtros.Add(filtroActivo);
            filtros.Add(filtroEliminado);
            filtros.Add(filtroGrupoId);
            //ahora leemos
            List<object> lista = fac.Leer<VCFramework.Entidad.RrhhSubgrupoMenu>(filtros);
            if (lista != null)
            {
                lista2 = lista.Cast<VCFramework.Entidad.RrhhSubgrupoMenu>().ToList();
            }



            return lista2;
        }

        public static List<EnvoltorioSubGrupo> ListarSubGruposPorIdGrupo(int grpId, int rolId)
        {
            List<EnvoltorioSubGrupo> lista = new List<EnvoltorioSubGrupo>();
            List<VCFramework.Entidad.RrhhSubgrupoMenu> listaProcesar = ListarSubGruposPorIdGrupo(grpId);

            if (listaProcesar != null && listaProcesar.Count > 0)
            {
                foreach(Entidad.RrhhSubgrupoMenu subgrupo in listaProcesar)
                {
                    EnvoltorioSubGrupo env = new EnvoltorioSubGrupo();
                    env.GrpId = subgrupo.GrpId;
                    env.SgrpActivo = subgrupo.SgrpActivo;
                    env.SgrpEliminado = subgrupo.SgrpEliminado;
                    env.SgrpId = subgrupo.SgrpId;
                    env.SgrpItem = subgrupo.SgrpItem;
                    env.SgrpUrl = subgrupo.SgrpUrl;

                    List<VCFramework.Entidad.RrhhRlRolMenu> rls = RrhhRlRolMenu.ListarRlPorRolId(rolId);
                    bool chekeado = false;
                    if (rls != null && rls.Count > 0)
                        if (rls.Exists(p => p.SgrpId == subgrupo.SgrpId))
                            chekeado = true;

                    env.Checked = chekeado;
                    env.RolId = rolId;

                    lista.Add(env);
                }
            }


            return lista;
        }


        public static void GuardarRelacion(int SgrpId, string SgrpItem, string SgrpUrl, int GrpId, int SgrpActivo, int SgrpEliminado, bool Checked, int RolId)
        {
            //traemos la lista de relaciones por rol
            List<Entidad.RrhhRlRolMenu> rls = NegocioMySql.RrhhRlRolMenu.ListarRlPorRolId(RolId);
            Entidad.RrhhRlRolMenu rlModificar = new Entidad.RrhhRlRolMenu();

            if (rls != null && rls.Count > 0)
                rlModificar = rls.FirstOrDefault(p => p.SgrpId == SgrpId);

            if (Checked)
            {
                //checkeado significa que hay que agregar la relación
                //si no existe
                if (rlModificar == null)
                {

                    rlModificar = new Entidad.RrhhRlRolMenu();
                    //si no existe hay que crearla
                    rlModificar.RlActivo = 1;
                    rlModificar.RlEliminado = 0;
                    rlModificar.RolId = RolId;
                    rlModificar.SgrpId = SgrpId;
                    if (NegocioMySql.RrhhRlRolMenu.Insertar(rlModificar) <= 0)
                        throw new Exception("Error al Insertar Relación.");


                }
                
            }
            else
            {
                //significa que hay que eliminar la relación
                if (rlModificar.RlId > 0)
                {
                    //si no existe hay que crearla
                    rlModificar.RlActivo = 0;
                    rlModificar.RlEliminado = 1;
                    if (NegocioMySql.RrhhRlRolMenu.Modificar(rlModificar) <= 0)
                        throw new Exception("Error al Modificar Relación.");

                }
                else
                    throw new Exception("Error al Eliminar Relación.");
            }
        }

    }
    public class EnvoltorioSubGrupo : Entidad.RrhhSubgrupoMenu
    {
        public bool Checked { get; set; }
        public int RolId { get; set; }

    }
}
