using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Ficha_FichaPersonal : System.Web.UI.Page
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
        //todos los tabs bloqueados
        if (!Page.IsPostBack)
        {
            Session["FipeId"] = null;
            if (Request.QueryString["editar"] != null && Request.QueryString["eliminar"] != null && Request.QueryString["nuevo"] != null)
            {
                if (Request.QueryString["editar"] == "true")
                {
                    //estamos editando un registro
                    if (Request.QueryString["id"] != null)
                    {
                        lblEstado.Text = "MODIFICAR";
                        //viene un id válido
                        int id = int.Parse(Request.QueryString["id"]);
                        Session["FipeId"] = id;
                        txtRun.ClientEnabled = false;
                        txtDv.ClientEnabled = false;
                        Recuperar(id);
                    }
                    else
                        BloquearTodo();

                }
                else if (Request.QueryString["nuevo"] == "true")
                {
                    //estamos creando
                    lblEstado.Text = "CREAR";

                }
                else if (Request.QueryString["eliminar"] == "true")
                {
                    //estamos eliminando
                    lblEstado.Text = "ELIMINAR";

                }
                else
                    BloquearTodo();
            }
            else
            {
                BloquearTodo();
            }
        }

    }
    private bool ValidaRequeridos()
    {
        bool retorno = true;

        StringBuilder mensaje = new StringBuilder();

        mensaje.Append("<div class='row cells12 topRow bg-red padding-10px'>");

        if (txtRun.Text == string.Empty || txtDv.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Rut Requerido."));
            retorno = false;
        }
        if (txtNombres.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Nombres Requerido."));
            retorno = false;
        }
        if (txtPApellido.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Apellido Paterno Requerido."));
            retorno = false;
        }
        if (dtFechaNac.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Fecha de Nac. Requerida."));
            retorno = false;
        }
        if (cmbSexo.Value == null)
        {
            mensaje.Append(LineaMensaje(" Sexo Requerido."));
            retorno = false;
        }
        if (cmbNacionalidad.Value == null)
        {
            mensaje.Append(LineaMensaje(" Nacionalidad Requerido."));
            retorno = false;
        }
        if (cmbNEducacional.Value == null)
        {
            mensaje.Append(LineaMensaje(" Nivel educacional Requerido."));
            retorno = false;
        }
        if (cmbAfp.Value == null)
        {
            mensaje.Append(LineaMensaje(" afp Requerido."));
            retorno = false;
        }
        if (cmbIsapre.Value == null)
        {
            mensaje.Append(LineaMensaje(" Isapre Requerido."));
            retorno = false;
        }
        if (cmbCaja.Value == null)
        {
            mensaje.Append(LineaMensaje(" Caja Requerido."));
            retorno = false;
        }
        if (txtDireccionPers.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Dirección persona Requerido."));
            retorno = false;
        }
        if (cmbRegionPers.Value == null)
        {
            mensaje.Append(LineaMensaje(" Región Requerido."));
            retorno = false;
        }
        if (cmbProvinciaPers.Value == null)
        {
            mensaje.Append(LineaMensaje(" Provincia Requerido."));
            retorno = false;
        }
        if (cmbComunaPers.Value == null)
        {
            mensaje.Append(LineaMensaje(" Comuna Requerido."));
            retorno = false;
        }
        if (cmbCargo.Value == null)
        {
            mensaje.Append(LineaMensaje(" Cargo Requerido."));
            retorno = false;
        }
        if (dateFIngreso.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Fecha Ingreso Requerido."));
            retorno = false;
        }
        if (txtUsuario.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Usuario Requerido."));
            retorno = false;
        }
        if (txtLogin.Text == string.Empty)
        {
            mensaje.Append(LineaMensaje(" Login Ingreso Requerido."));
            retorno = false;
        }


        mensaje.Append("</div>");

        if (!retorno)
            lblMensaje.Text = mensaje.ToString();

        return retorno;
    }
    private void Guardar()
    {

        if (ValidaRequeridos())
        {
            VCFramework.Entidad.RrhhFichaPersonal fipe = new VCFramework.Entidad.RrhhFichaPersonal();

            try
            {
                fipe.AfpId = cmbAfp.Value == null ? 0 : int.Parse(cmbAfp.Value.ToString());
                fipe.ArenId = cmbArea.Value == null ? 0 : int.Parse(cmbArea.Value.ToString());
                //fipe.CafaId = cmbNCargas.Value == null ? 0 : int.Parse(cmbNCargas.Value.ToString());
                fipe.CargId = cmbCargo.Value == null ? 0 : int.Parse(cmbCargo.Value.ToString());
                fipe.CencId = cmbCCosto.Value == null ? 0 : int.Parse(cmbCCosto.Value.ToString());
                fipe.CjacId = cmbCaja.Value == null ? 0 : int.Parse(cmbCaja.Value.ToString());
                //fipe.CnpeId = cmbc.Value == null ? 0 : int.Parse(cmbArea.Value.ToString());
                fipe.ComId = cmbComunaPers.Value == null ? 0 : int.Parse(cmbComunaPers.Value.ToString());
                fipe.EmpId = cmbEmpresa.Value == null ? 0 : int.Parse(cmbEmpresa.Value.ToString());
                fipe.EstcId = cmbEstCivil.Value == null ? 0 : int.Parse(cmbEstCivil.Value.ToString());
                fipe.FipeApellidoMaterno = txtSApellido.Text == string.Empty ? " " : txtSApellido.Text;
                fipe.FipeApellidoPaterno = txtPApellido.Text == string.Empty ? " " : txtPApellido.Text;
                fipe.FipeDireccion = txtDireccionPers.Text == string.Empty ? " " : txtDireccionPers.Text;
                fipe.FipeDv = txtDv.Text == string.Empty ? " " : txtDv.Text;
                fipe.FipeEliminado = 0;
                fipe.FipeEMail = txtEMailPers.Text == string.Empty ? " " : txtEMailPers.Text;
                fipe.FipeEstado = 1;
                //fipe.FipeFechaContratoVigente = Convert.ToDateTime(dateFIngreso.Text);
                fipe.FipeFechaIngreso = dateFIngreso.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dateFIngreso.Text);
                fipe.FipeFechaNacimiento = dtFechaNac.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dtFechaNac.Text);
                fipe.FipeFechaTerminoContrato = dateFFin.Text == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dateFFin.Text);
                if (Session["FipeId"] != null)
                    fipe.FipeId = int.Parse(Session["FipeId"].ToString());
                else
                    fipe.FipeId = 0;
                fipe.FipeLogin = txtLogin.Text == string.Empty ? txtRun.Text : txtLogin.Text;
                fipe.FipeNombreContacto = txtNombreContacto.Text == string.Empty ? txtNombreContacto.Text : txtNombreContacto.Text;
                fipe.FipeNombres = txtNombres.Text == string.Empty ? txtNombres.Text : txtNombres.Text;
                //fipe.FipeNumeroDiasVacaciones = cmbd.Value == null ? 0 : int.Parse(cmbCaja.Value.ToString());
                fipe.FipeRut = txtRun.Text == string.Empty ? 0 : int.Parse(txtRun.Text);
                fipe.FipeTelefonoCasa = txtCasaPers.Text == string.Empty ? txtCasaPers.Text : txtCasaPers.Text;
                fipe.FipeTelefonocel = txtCelularPers.Text == string.Empty ? txtCelularPers.Text : txtCelularPers.Text;
                fipe.FipeTelefonoContacto = txtTelefContacto.Text == string.Empty ? txtTelefContacto.Text : txtTelefContacto.Text;
                fipe.FipeUsuario = txtUsuario.Text == string.Empty ? txtRun.Text : txtUsuario.Text;

                fipe.IsapId = cmbIsapre.Value == null ? 0 : int.Parse(cmbIsapre.Value.ToString());
                fipe.NacId = cmbNacionalidad.Value == null ? 0 : int.Parse(cmbNacionalidad.Value.ToString());
                fipe.NiveId = cmbNEducacional.Value == null ? 0 : int.Parse(cmbNEducacional.Value.ToString());
                fipe.ProvId = cmbProvinciaPers.Value == null ? 0 : int.Parse(cmbProvinciaPers.Value.ToString());
                fipe.RegId = cmbRegionPers.Value == null ? 0 : int.Parse(cmbRegionPers.Value.ToString());
                fipe.RolId = cmbRol.Value == null ? 0 : int.Parse(cmbRol.Value.ToString());
                fipe.SexoId = cmbSexo.Value == null ? 0 : int.Parse(cmbSexo.Value.ToString());
                fipe.TicoId = cmbTContrato.Value == null ? 0 : int.Parse(cmbTContrato.Value.ToString());
                //datos de la empresa solo se recuperan, no se modifican
                //VCFramework.Entidad.RrhhEmpresa empresa = new VCFramework.Entidad.RrhhEmpresa();
                //empresa.ComId = cmbComunaEmp.Value == null ? 0 : int.Parse(cmbComunaEmp.Value.ToString());
                //empresa.EmpDireccion = txtDirecEmpresa.Text == string.Empty ? txtDirecEmpresa.Text : txtDirecEmpresa.Text;
                //empresa.EmpDv
                //el numero de cargas es la cantidad de registros
                int numeroCargas = 0;
                List<VCFramework.Entidad.RrhhCargaFamiliar> listaCargas = VCFramework.NegocioMySql.RrhhCargaFamiliar.ListarCargasPorFipeId(fipe.FipeId);
                if (listaCargas != null && listaCargas.Count > 0)
                    numeroCargas = listaCargas.Count();


                fipe.ForpId = cmbFormaPago.Value == null ? 0 : int.Parse(cmbFormaPago.Value.ToString());
                VCFramework.NegocioMySql.Factory fac = new VCFramework.NegocioMySql.Factory();

                int idDevuelto = 0;
                if (fipe.FipeId > 0)
                {
                    idDevuelto = fac.Update<VCFramework.Entidad.RrhhFichaPersonal>(fipe, "FIPE_ID");
                }
                else
                {
                    idDevuelto = fac.Insertar<VCFramework.Entidad.RrhhFichaPersonal>(fipe);
                    fipe.FipeId = idDevuelto;
                    Session["FipeId"] = idDevuelto;
                }
                VCFramework.Entidad.RrhhFpagoVista fpagoVista = new VCFramework.Entidad.RrhhFpagoVista();
                VCFramework.Entidad.RrhhFpagoDeposito fpagoDeposito = new VCFramework.Entidad.RrhhFpagoDeposito();


                switch (fipe.ForpId)
                {
                    //vale vista
                    case 1:
                        List<VCFramework.Entidad.RrhhFpagoVista> pagoVista = VCFramework.NegocioMySql.RrhhFPagoVista.ObtenerFormaPagoVistaFipeId(fipe.FipeId);
                        if (pagoVista != null && pagoVista.Count == 1)
                        {
                            //ya existe
                            pagoVista[0].FpviNroCuenta = txtNCta.Text;
                            pagoVista[0].FpviBanco = txtBanco.Text;
                            fac.Update<VCFramework.Entidad.RrhhFpagoVista>(pagoVista[0], "FPVI_ID");

                        }
                        else
                        {
                            fpagoVista.FipeId = fipe.FipeId;
                            fpagoVista.ForpId = 1;
                            fpagoVista.FpviBanco = txtBanco.Text;
                            fpagoVista.FpviEliminado = 0;
                            fpagoVista.FpviEstado = 1;
                            fpagoVista.FpviNroCuenta = txtNCta.Text;
                            fpagoVista.FpviSucursal = string.Empty;
                            //fpagoVista.FpviSucursal 
                            fac.Insertar<VCFramework.Entidad.RrhhFpagoVista>(fpagoVista, "FPVI_ID");

                        }
                        break;

                    case 2:
                        List<VCFramework.Entidad.RrhhFpagoDeposito> pagoDeposito = VCFramework.NegocioMySql.RrhhFPagoDeposito.ObtenerFormaPagoDepositoFipeId(fipe.FipeId);
                        if (pagoDeposito != null && pagoDeposito.Count == 1)
                        {
                            //ya existe
                            pagoDeposito[0].FpdeNCuenta = txtNCta.Text;
                            pagoDeposito[0].FpdeBanco = txtBanco.Text;
                            fac.Update<VCFramework.Entidad.RrhhFpagoDeposito>(pagoDeposito[0], "FPDE_ID");

                        }
                        else
                        {
                            fpagoDeposito.FipeId = fipe.FipeId;
                            fpagoDeposito.ForpId = 1;
                            fpagoDeposito.FpdeBanco = txtBanco.Text;
                            fpagoDeposito.FpdeEliminado = 0;
                            fpagoDeposito.FpdeEstado = 1;
                            fpagoDeposito.FpdeNCuenta = txtNCta.Text;
                            //fpagoVista.FpviSucursal 
                            fac.Insertar<VCFramework.Entidad.RrhhFpagoDeposito>(fpagoDeposito, "FPDE_ID");

                        }
                        break;
                    //efectivo
                    case 3:
                        break;
                }



                if (idDevuelto > 0)
                {
                    Recuperar(int.Parse(Session["FipeId"].ToString()));
                    lblMensaje.Text = ConstruyeMensaje(false, "Guardado correctamente.");
                }
                else
                {
                    lblMensaje.Text = ConstruyeMensaje(true, "Error al Guardar");
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ConstruyeMensaje(true, ex.Message);
            }

        }
    }
    private void Recuperar(int id)
    {
        VCFramework.Entidad.RrhhFichaPersonal ficha = VCFramework.NegocioMySql.RrhhFichaPersonal.ObtenerFichaPorId(id);
        try
        {
            if (ficha != null && ficha.FipeId > 0)
            {
                //ahora tenemos la ficha supuestamente, vamos a ir seteando los campos
                #region datos personales
                txtRun.Text = ficha.FipeRut.ToString();
                txtDv.Text = ficha.FipeDv;
                txtNombres.Text = ficha.FipeNombres;
                txtPApellido.Text = ficha.FipeApellidoPaterno;
                txtSApellido.Text = ficha.FipeApellidoMaterno;
                dtFechaNac.Text = ficha.FipeFechaNacimiento.ToShortDateString();
                cmbSexo.Value = ficha.SexoId.ToString();
                cmbEstCivil.Value = ficha.EstcId.ToString();
                cmbNacionalidad.Value = ficha.NacId.ToString();
                cmbNEducacional.Value = ficha.NiveId.ToString();
                cmbAfp.Value = ficha.AfpId.ToString();
                cmbIsapre.Value = ficha.IsapId.ToString();
                cmbCaja.Value = ficha.CjacId.ToString();
                //el numero de cargas es la cantidad de registros
                int numeroCargas = 0;
                List<VCFramework.Entidad.RrhhCargaFamiliar> listaCargas = VCFramework.NegocioMySql.RrhhCargaFamiliar.ListarCargasPorFipeId(ficha.FipeId);
                if (listaCargas != null && listaCargas.Count > 0)
                    numeroCargas = listaCargas.Count();
                cmbNCargas.Value = numeroCargas.ToString();
                
                #endregion
                //aca agregar el manejo de la grilla
                #region datos contacto
                txtDireccionPers.Text = ficha.FipeDireccion;
                CargarRegionesPersona();
                //region
                cmbRegionPers.Value = ficha.RegId.ToString();
                //las provincias de la region
                CargarProvinciasPersona(ficha.RegId);
                cmbProvinciaPers.Value = ficha.ProvId.ToString();
                //las comunas
                CargarComunasPersona(ficha.ProvId);
                cmbComunaPers.Value = ficha.ComId.ToString();

                txtEMailPers.Text = ficha.FipeEMail;
                txtCelularPers.Text = ficha.FipeTelefonocel;
                txtCasaPers.Text = ficha.FipeTelefonoCasa;
                txtNombreContacto.Text = ficha.FipeNombreContacto;
                txtTelefContacto.Text = ficha.FipeTelefonoContacto;

                #endregion

                #region datos laborales y cargo
                //nos traemos a la empresa
                CargarRegionesEmpleado();
                VCFramework.Entidad.RrhhEmpresa empresa = VCFramework.NegocioMySql.RrhhEmpresa.ObtenerEmpresa(ficha.EmpId);

                if (empresa != null && empresa.EmpId > 0)
                {
                    //seteamos los valores de la empresa
                    cmbRegionEmp.Value = empresa.RegId.ToString();
                    CargarProvinciasEmpleado(empresa.RegId);
                    cmbProvEmp.Value = empresa.ProvId.ToString();
                    CargarComunasEmpleado(empresa.ProvId);
                    cmbComunaEmp.Value = empresa.ComId.ToString();
                    txtDirecEmpresa.Text = empresa.EmpDireccion;
                    txtTelefonoEmp.Text = empresa.EmpTelefono1;
                }
                cmbTContrato.Value = ficha.TicoId.ToString();
                dateFIngreso.Text = ficha.FipeFechaIngreso.ToShortDateString();
                if (ficha.FipeFechaTerminoContrato.ToShortDateString() != "01-01-1900")
                    dateFFin.Text = ficha.FipeFechaTerminoContrato.ToShortDateString();
                cmbArea.Value = ficha.ArenId.ToString();
                cmbCCosto.Value = ficha.CencId.ToString();
                cmbFormaPago.Value = ficha.ForpId.ToString();
                switch(ficha.ForpId)
                {
                    //vale vista
                    case 1:
                        List<VCFramework.Entidad.RrhhFpagoVista> pagoVista = VCFramework.NegocioMySql.RrhhFPagoVista.ObtenerFormaPagoVistaFipeId(ficha.FipeId);
                        if (pagoVista != null && pagoVista.Count == 1)
                        {
                            txtNCta.Text = pagoVista[0].FpviNroCuenta;
                            txtBanco.Text = pagoVista[0].FpviBanco;

                        }
                        break;

                    case 2:
                        List<VCFramework.Entidad.RrhhFpagoDeposito> pagoDeposito = VCFramework.NegocioMySql.RrhhFPagoDeposito.ObtenerFormaPagoDepositoFipeId(ficha.FipeId);
                        if (pagoDeposito != null && pagoDeposito.Count == 1)
                        {
                            txtNCta.Text = pagoDeposito[0].FpdeNCuenta;
                            txtBanco.Text = pagoDeposito[0].FpdeBanco;

                        }
                        break;
                        //efectivo
                    case 3:
                        break;
                }

                cmbCargo.Value = ficha.CargId.ToString();
                //txtNCta.Text = ficha
                #endregion

                //acceso
                cmbRol.Value = ficha.RolId.ToString();
                txtUsuario.Text = ficha.FipeUsuario; 
                txtLogin.Text = ficha.FipeLogin;

            }
            else
            {
                lblMensaje.Text = ConstruyeMensaje(true, "Error al recuperar la ficha");
                BloquearTodo();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ConstruyeMensaje(true, ex.Message);
            BloquearTodo();
        }
    }

    private string LineaMensaje(string texto)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<i class='{0}'>", "fg-white mif-info font-x-large");
        sb.AppendFormat("{0}", texto);
        sb.Append("</i>");
        sb.Append("</br>");

        return sb.ToString();
    }

    private string ConstruyeMensaje(bool esError, string mensaje)
    {
        StringBuilder sb = new StringBuilder();


        if (esError)
        {
            sb.Append("<div class='row cells12 topRow bg-red padding-10px'>");
            sb.AppendFormat("<i class='{0}'>", "fg-white mif-info font-x-large");
        }
        else
        {
            sb.Append("<div class='row cells12 topRow bg-blue padding-10px'>");
            sb.AppendFormat("<i class='{0}'>", "fg-white mif-checkmark font-x-large");
        }

        sb.AppendFormat("  {0}</i>", mensaje);

        sb.Append("</div>");

        return sb.ToString();
    }
    private void BloquearTodo()
    {
        ASPxPageControl1.TabPages[0].ClientEnabled = false;
        ASPxPageControl1.TabPages[1].ClientEnabled = false;
        ASPxPageControl1.TabPages[2].ClientEnabled = false;
    }
    private void CargarRegionesPersona()
    {
        odsProvincia.SelectParameters[0].DefaultValue = "0";
        odsRegion.DataBind();
        cmbRegionPers.DataBind();
    }
    private void CargarRegionesEmpleado()
    {
        // odsRegionEmp.SelectParameters[0].DefaultValue = "0";
        odsRegionEmp.DataBind();
        cmbRegionEmp.DataBind();
    }
    private void CargarProvinciasPersona(int idReg)
    {
        odsProvincia.SelectParameters[0].DefaultValue = idReg.ToString();
        odsProvincia.DataBind();
        cmbProvinciaPers.DataBind();
    }
    private void CargarComunasPersona(int idPrv)
    {
        odsComuna.SelectParameters[0].DefaultValue = idPrv.ToString();
        odsComuna.DataBind();
        cmbComunaPers.DataBind();
    }
    private void CargarProvinciasEmpleado(int idReg)
    {
        odsProvEmp.SelectParameters[0].DefaultValue = idReg.ToString();
        odsProvEmp.DataBind();
        cmbProvEmp.DataBind();
    }
    protected void cmbProvinciaPers_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idReg = int.Parse(e.Parameter.ToString());
            if (idReg > 0)
            {
                CargarProvinciasPersona(idReg);
                cmbProvinciaPers.SelectedIndex = 0;
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
                CargarComunasPersona(idPrv);
                cmbComunaPers.SelectedIndex = 0;
            }
        }
    }
    private void CargarComunasEmpleado(int idPrv)
    {
        odsComEmp.SelectParameters[0].DefaultValue = idPrv.ToString();
        odsComEmp.DataBind();
        cmbComunaEmp.DataBind();
    }

    protected void cmbEstCivil_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cmbProvEmp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idReg = int.Parse(e.Parameter.ToString());
            if (idReg > 0)
            {
                CargarProvinciasEmpleado(idReg);
                cmbProvEmp.SelectedIndex = 0;
            }
        }
    }

    protected void cmbComunaEmp_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            int idPrv = int.Parse(e.Parameter.ToString());
            if (idPrv > 0)
            {
                CargarComunasEmpleado(idPrv);
                cmbComunaEmp.SelectedIndex = 0;
            }
        }
    }

    protected void ASPxPageControl1_ActiveTabChanged(object source, DevExpress.Web.TabControlEventArgs e)
    {

    }

    protected void pnlPrincipal_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        if (e.Parameter != null)
        {
            string param = e.Parameter;
            if (param.Contains("BUSCAR"))
            {
                string[] parametros = param.Split('|');
                string rut = parametros[1];
                string dv = parametros[2];

                VCFramework.Entidad.RrhhFichaPersonal ficha = VCFramework.NegocioMySql.RrhhFichaPersonal.ObtenerUsuarioPorRut(int.Parse(rut), dv);
                if (ficha.FipeId > 0)
                {
                    Session["FipeId"] = ficha.FipeId;
                    txtRun.ClientEnabled = false;
                    txtDv.ClientEnabled = false;
                    lblEstado.Text = "MODIFICAR";
                    Recuperar(ficha.FipeId);
                }

            }
            else
            {
                switch (param)
                {
                    case "MODIFICAR":
                        Guardar();
                        break;
                    case "CREAR":
                        Guardar();
                        
                        break;
                    case "ELIMINAR":
                        break;
                }
            }
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListadoFicha.aspx");
    }
}