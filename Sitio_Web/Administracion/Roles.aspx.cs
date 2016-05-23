using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Roles : System.Web.UI.Page
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
                if (usu.RolId != 1)//Super Administrador
                    Response.Redirect("~/default.aspx");
            }
        }
        else
            Response.Redirect("~/default.aspx");
    }
}