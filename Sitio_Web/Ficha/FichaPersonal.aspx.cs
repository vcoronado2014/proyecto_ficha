using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ficha_FichaPersonal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmbProvinciaPers_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idReg = int.Parse(e.Parameter.ToString());
            if (idReg > 0)
            {
                odsProvincia.SelectParameters[0].DefaultValue = idReg.ToString();
                odsProvincia.DataBind();
                cmbProvinciaPers.DataBind();
            }
        }
    }

    protected void cmbComunaPers_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idPrv = int.Parse(e.Parameter.ToString());
            if (idPrv > 0)
            {
                odsComuna.SelectParameters[0].DefaultValue = idPrv.ToString();
                odsComuna.DataBind();
                cmbComunaPers.DataBind();
            }
        }
    }

    protected void cmbEstCivil_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}