using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PruebaEnvio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string valor = "363adcc558ce3394c598900d853fa019";
        Response.Redirect("http://localhost:26595/default.aspx?usuario=" + valor);
    }
}