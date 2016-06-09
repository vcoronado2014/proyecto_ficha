using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ingreso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {

        //obtenemos al usuario mediante una llamada directa a nuestro negocio
        VCFramework.Entidad.RrhhFichaPersonal usuario = VCFramework.NegocioMySql.RrhhFichaPersonal.Validar(user_login.Text, user_password.Text);
        //entonces, si el usuario tiene un id > 0 es un usuario válido, de lo contrario no lo es

        if (usuario.FipeId > 0)
        {
            //tiene un id > 0 por lo tanto lo asignamos a la variable de session
            Session["USUARIO_AUTENTICADO"] = usuario;
            //redirigimos a la página principal
            Response.Redirect("~/default.aspx");

        }
        else
        {
            //lo mandamos a la página de Ingreso nuevamente
            Response.Redirect("~/Ingreso.aspx");
        }
    }
}