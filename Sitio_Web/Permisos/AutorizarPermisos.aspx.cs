using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Permisos_AutorizarPermisos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //acá siempre debemos validaar el rol para entrar a esta página
        VCFramework.Entidad.RrhhFichaPersonal usu = new VCFramework.Entidad.RrhhFichaPersonal();
        if (Session["USUARIO_AUTENTICADO"] != null)
        {
            usu = Session["USUARIO_AUTENTICADO"] as VCFramework.Entidad.RrhhFichaPersonal;
            if (usu != null && usu.FipeId > 0)
            {
                Session["FIPE_ID"] = usu.FipeId;
            }
        }
        else
            Response.Redirect("~/default.aspx");
    }

    protected void grillaRoles_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
    {

    }

    protected void grillaRoles_CustomErrorText(object sender, DevExpress.Web.ASPxGridViewCustomErrorTextEventArgs e)
    {
        if (e.Exception.InnerException != null)
            e.ErrorText = e.Exception.InnerException.Message;
    }
}