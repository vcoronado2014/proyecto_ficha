using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lstGrupos_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idRol = int.Parse(e.Parameter);
            odsGrupo.SelectParameters[0].DefaultValue = idRol.ToString();
            odsGrupo.DataBind();
            lstGrupos.DataBind();
        }
    }

    protected void grillaSubgrupo_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
    {
        if (e.Parameters != null)
        {
            string[] param = e.Parameters.Split('|');
            int rol = int.Parse(param[0]);
            int grpId = int.Parse(param[1]);

            odsGrilla.SelectParameters[0].DefaultValue = grpId.ToString();
            odsGrilla.SelectParameters[1].DefaultValue = rol.ToString();
            odsGrilla.DataBind();
            grillaSubgrupo.DataBind();


        }
    }
}