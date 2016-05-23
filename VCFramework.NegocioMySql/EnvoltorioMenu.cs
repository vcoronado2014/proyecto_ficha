using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VCFramework.NegocioMySql
{
    public class LogicMenu
    {
        public static List<ItemMenu> ArmarMenu(int rolId)
        {
            List<ItemMenu> listaDevolver = new List<ItemMenu>();
            //primero nos traemos todos los grupos
            List<Entidad.RrhhGrupoMenu> grupos = RrhhGrupoMenu.ListarGrupos();
            if (grupos != null)
            {
                //ahora recorremos los grupos y nos traemos los subgrupos
                foreach(Entidad.RrhhGrupoMenu grupo in grupos)
                {
                    //provechamos de agregar los item al envoltorio
                    ItemMenu envoltorio = new ItemMenu();
                    envoltorio.Name = grupo.GrpItem;
                    envoltorio.NavigateUrl = grupo.GrpUrl;
                    envoltorio.Text = grupo.GrpItem;
                    //por mientras visible siempre
                    envoltorio.Visible = true;
                    //ahora hacemos la llamada de negocio para traernos los subgrupos por grupo
                    List<Entidad.RrhhSubgrupoMenu> subgrupos = RrhhSubgrupoMenu.ListarSubGruposPorIdGrupo(grupo.GrpId);
                    //recorremos los subgrupos para asociarlos al menu
                    envoltorio.ItemsDelGrupo = new List<SubItemMenu>();
                    if (subgrupos != null && subgrupos.Count > 0)
                    {
                        foreach(Entidad.RrhhSubgrupoMenu subgrupo in subgrupos)
                        {
                            //si en ese subgrupo existe el rol lo agregamos, para eso verificamos la relacion
                            List<Entidad.RrhhRlRolMenu> listaRls = RrhhRlRolMenu.ListarRlPorRolId(rolId);
                            bool existeRol = false;
                            if (listaRls != null && listaRls.Count > 0)
                                existeRol = listaRls.Exists(p => p.RolId == rolId && p.SgrpId == subgrupo.SgrpId);

                            SubItemMenu items = new SubItemMenu();
                            items.Name = subgrupo.SgrpItem;
                            items.NavigateUrl = subgrupo.SgrpUrl;
                            items.Text = subgrupo.SgrpItem;
                            items.ToolTip = subgrupo.SgrpItem;



                            if (existeRol)
                            {
                                items.Visible = true;
                            }
                            else
                                items.Visible = false;

                            //los agregamos a la lista del envoltorio
                            envoltorio.ItemsDelGrupo.Add(items);


                        }
                    }
                    //acá debieramos agregar a la lista que devolvemos el elemento completo,
                    //pero antes evaluamos si tiene subitems visibles para mostrarlos
                    //entonces
                    int cantidadVisiblesSubItem = 0;
                    if (envoltorio.ItemsDelGrupo != null && envoltorio.ItemsDelGrupo.Count > 0)
                        cantidadVisiblesSubItem = envoltorio.ItemsDelGrupo.Count(p => p.Visible == true);

                    if (cantidadVisiblesSubItem == 0)
                    {
                        //el grupo queda no visible
                        envoltorio.Visible = false;
                    }

                    listaDevolver.Add(envoltorio);

                }
            }

            return listaDevolver;
        }

        public static List<TreeList> ListarEditar(int rolId)
        {
            List<TreeList> lista = new List<TreeList>();


            List<VCFramework.NegocioMySql.ItemMenu> items = VCFramework.NegocioMySql.LogicMenu.ArmarMenu(rolId);
            if (items != null && items.Count > 0)
            {
                foreach (VCFramework.NegocioMySql.ItemMenu grupo in items)
                {
                    TreeList item1 = new TreeList();
                    item1.Id = "G" + grupo.Name;
                    item1.ParentId = "G" + grupo.Name;
                    item1.Descripcion = grupo.Name;
                    item1.Check = grupo.Visible;

                    lista.Add(item1);

                    if (grupo.ItemsDelGrupo != null && grupo.ItemsDelGrupo.Count > 0)
                    {
                        foreach (VCFramework.NegocioMySql.SubItemMenu subItem in grupo.ItemsDelGrupo)
                        {
                            TreeList item2 = new TreeList();
                            item2.Id = "SG" + subItem.Name + grupo.Name;
                            item2.ParentId = "G" + grupo.Name;
                            item2.Descripcion = subItem.Name;
                            item2.Check = subItem.Visible;

                            lista.Add(item2);

                            List<Entidad.RrhhRol> roles1 = RrhhRol.ListarRoles();

                            if (roles1 != null && roles1.Count > 0)
                            {
                                foreach (Entidad.RrhhRol rol1 in roles1)
                                {
                                    TreeList item3 = new TreeList();
                                    item3.Id = rol1.RolId.ToString() + "_" + grupo.Name;
                                    item3.ParentId = "SG" + subItem.Name + grupo.Name;
                                    item3.Descripcion = rol1.RolDescripcion;
                                    if (rolId == rol1.RolId)
                                        item3.Check = subItem.Visible;
                                    else
                                        item3.Check = false;

                                    lista.Add(item3);
                                }
                            }


                        }
                    }


                }
            }




            return lista;
        }


    }
    public class ItemMenu : SubItemMenu
    {

        public List<SubItemMenu> ItemsDelGrupo { get; set; }
    }
    public class SubItemMenu
    {
        public string Name { get; set; }
        public string NavigateUrl { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
        public string ToolTip { get; set; }

    }

    public class TreeList
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        public string Descripcion { get; set; }
        public bool Check { get; set; }
    }
}
