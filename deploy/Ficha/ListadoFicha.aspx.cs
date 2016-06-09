using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ficha_ListadoFicha : System.Web.UI.Page
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

            }
        }
        else
            Response.Redirect("~/default.aspx");
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        Response.Redirect("FichaPersonal.aspx?editar=false&eliminar=false&nuevo=true&id=0");
    }
}