using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MasterPage : System.Web.UI.MasterPage
{
    #region load de la pagina
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion

    #region init de la pagina
    protected void Page_Init(object sender, EventArgs e)
    { 
        if (Request.Form["usuario"] != null)
        {
            //en este request viene el hash en string
            //entonces nos traemos el registro directamente
            string hashUser = Request.Form["usuario"].ToString().Trim();
            VCFramework.Entidad.RrhhFichaPersonal usuario = VCFramework.NegocioMySql.RrhhFichaPersonal.Validar(hashUser);
            if (usuario.FipeId > 0)
            {
                Session["USUARIO_AUTENTICADO"] = usuario;
            }
        }

        VCFramework.Entidad.RrhhFichaPersonal usu = new VCFramework.Entidad.RrhhFichaPersonal();
        pnlDatos.Visible = true;
        if (Session["USUARIO_AUTENTICADO"] != null)
        {
            usu = Session["USUARIO_AUTENTICADO"] as VCFramework.Entidad.RrhhFichaPersonal;
            if (usu != null && usu.FipeId > 0)
            {
                //acciones

                //literalMenu.Text = RolesPermisos.RetornaMenu(usu.Rol.Id.ToString());

                //***************************************
                //setear todos los valores y ocultar los menus.
                
                ActivarInicioSesion();
                litUsuario.Text = usu.FipeNombres + " " + usu.FipeApellidoPaterno + " " + usu.FipeApellidoMaterno;
                lblIdInstGlobal.Text = usu.EmpId.ToString();
                //ahora buscamos el rol, usamos llamada directa a nuestro negocio
                VCFramework.Entidad.RrhhRol rol = VCFramework.NegocioMySql.RrhhRol.DevuelveRolPorId(usu.RolId);
                //controlamos
                if (rol.RolId > 0)
                {
                    CargarMenu(rol.RolId);
                    //carga de rol dinamica
                    CargarMenuDinamico(rol.RolId);
                    litRol.Text = rol.RolDescripcion;
                }
            }
            else
            {

                //***************************************
                //quitar los valores
                DesactivarInicioSesion();
            }
        }
        else
        {

            //***************************************
            //quitar los valores
            DesactivarInicioSesion();
        }
    }
    #endregion
    private void DesactivarInicioSesion()
    {
        //0 iniciar sesion 1 cerrar
        nvInicio.Items[0].Visible = true;
        nvInicio.Items[1].Visible = false;
        litRol.Text = "No Registrado";
        litUsuario.Text = "No Registrado";
    }
    private void CargarMenuDinamico(int rolId)
    {
        List<VCFramework.NegocioMySql.ItemMenu> items = VCFramework.NegocioMySql.LogicMenu.ArmarMenu(rolId);
        if (items != null && items.Count > 0)
        {
            foreach(VCFramework.NegocioMySql.ItemMenu grupo in items)
            {
                if (grupo.Visible)
                {
                    DevExpress.Web.NavBarGroup nGroup = new DevExpress.Web.NavBarGroup();
                    nGroup.Name = grupo.Name;
                    nGroup.Text = grupo.Text;
                    nGroup.ToolTip = grupo.ToolTip;
                    nGroup.NavigateUrl = grupo.NavigateUrl;
                    nGroup.Visible = grupo.Visible;
                    //ahora recorremos los items del grupo y los agregamos al navbar
                    if (grupo.ItemsDelGrupo != null && grupo.ItemsDelGrupo.Count > 0)
                    {
                        foreach (VCFramework.NegocioMySql.SubItemMenu subItem in grupo.ItemsDelGrupo)
                        {
                            DevExpress.Web.NavBarItem nItem = new DevExpress.Web.NavBarItem();
                            nItem.Text = subItem.Text;
                            nItem.ToolTip = subItem.ToolTip;
                            nItem.Name = subItem.Name;
                            nItem.Visible = subItem.Visible;
                            nItem.NavigateUrl = subItem.NavigateUrl;
                            //lo agregamos a la coleccion
                            nGroup.Items.Add(nItem);
                        }

                    }
                    //agregamnos el grupo al control
                    nvMenu.Groups.Add(nGroup);
                }
            }
        }
    }
    private void CargarMenu(int rolId)
    {
        //if (rolId > 0)
        //    nvInicio.Items[2].Visible = true;

        #region comentado
        //switch (rolId)
        //{

        //    //Super Administrador
        //    #region SUPER ADMINISTRADOR
        //    case 1:
        //        nvInicio.Groups[1].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[1].Items != null && nvInicio.Groups[1].Items.Count > 0)
        //        {
        //            foreach(DevExpress.Web.NavBarItem item in nvInicio.Groups[1].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Items[2].Visible = true;

        //        nvInicio.Groups[2].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[2].Items != null && nvInicio.Groups[2].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[2].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[3].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[3].Items != null && nvInicio.Groups[3].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[3].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[4].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[4].Items != null && nvInicio.Groups[4].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[4].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[5].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[5].Items != null && nvInicio.Groups[5].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[5].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[6].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[6].Items != null && nvInicio.Groups[6].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[6].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        break;
        //    #endregion

        //    #region Trabajador
        //    case 2:

        //        nvInicio.Items[2].Visible = true;

        //        nvInicio.Groups[3].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[3].Items != null && nvInicio.Groups[3].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[3].Items)
        //            {
        //                //solo solicitar
        //                if (item.Name == "solicitar")
        //                {
        //                    item.Visible = true;
        //                }
        //            }
        //        }
        //        nvInicio.Groups[4].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[4].Items != null && nvInicio.Groups[4].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[4].Items)
        //            {
        //                //solo solicitar
        //                if (item.Name == "solicitar")
        //                {
        //                    item.Visible = true;
        //                }
        //            }
        //        }
        //        nvInicio.Groups[5].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[5].Items != null && nvInicio.Groups[5].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[5].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[6].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[6].Items != null && nvInicio.Groups[6].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[6].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        break;
        //    #endregion

        //    #region jefatura
        //    case 3:

        //        nvInicio.Items[2].Visible = true;

        //        nvInicio.Groups[3].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[3].Items != null && nvInicio.Groups[3].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[3].Items)
        //            {
        //                //solo solicitar
        //                if (item.Name == "solicitar")
        //                {
        //                    item.Visible = true;
        //                }
        //            }
        //        }
        //        nvInicio.Groups[4].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[4].Items != null && nvInicio.Groups[4].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[4].Items)
        //            {

        //                    item.Visible = true;

        //            }
        //        }
        //        nvInicio.Groups[5].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[5].Items != null && nvInicio.Groups[5].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[5].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[6].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[6].Items != null && nvInicio.Groups[6].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[6].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        break;
        //    #endregion

        //    #region Administrativo
        //    case 4:
        //        nvInicio.Groups[2].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[2].Items != null && nvInicio.Groups[2].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[2].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Items[2].Visible = true;


        //        nvInicio.Groups[3].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[3].Items != null && nvInicio.Groups[3].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[3].Items)
        //            {

        //                    item.Visible = true;

        //            }
        //        }
        //        nvInicio.Groups[4].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[4].Items != null && nvInicio.Groups[4].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[4].Items)
        //            {

        //                item.Visible = true;

        //            }
        //        }
        //        nvInicio.Groups[5].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[5].Items != null && nvInicio.Groups[5].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[5].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        nvInicio.Groups[6].Visible = true;
        //        //TODOS LOS SUBMENUS ACTIVOS
        //        if (nvInicio.Groups[6].Items != null && nvInicio.Groups[6].Items.Count > 0)
        //        {
        //            foreach (DevExpress.Web.NavBarItem item in nvInicio.Groups[6].Items)
        //            {
        //                item.Visible = true;
        //            }
        //        }
        //        break;
        //        #endregion
        //}
        #endregion
    }
    private void ActivarInicioSesion()
    {
        //0 iniciar sesion 1 cerrar
        nvInicio.Items[0].Visible = false;
        nvInicio.Items[1].Visible = true;

    }



    protected void nvInicio_ItemClick(object source, DevExpress.Web.NavBarItemEventArgs e)
    {
        switch (e.Item.Index)
        {
            case 0:
                //iniciar sesion

                break;
            case 1:
                //cerrar sesion
                Session["USUARIO_AUTENTICADO"] = null;
                DesactivarInicioSesion();
                Response.Redirect("~/default.aspx");
                break;
        }
    }

    protected void nvInicio_ItemCommand(object source, DevExpress.Web.NavBarItemCommandEventArgs e)
    {

    }
}
