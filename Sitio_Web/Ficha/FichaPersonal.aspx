<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FichaPersonal.aspx.cs" Inherits="Ficha_FichaPersonal" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../css/metro.css" rel="stylesheet"/>
    <link href="../css/metro-icons.css" rel="stylesheet"/>
    <link href="../css/metro-responsive.css" rel="stylesheet"/>
    <link href="../css/metro-schemes.css" rel="stylesheet"/>

    <link href="../css/docs.css" rel="stylesheet"/>

    <script src="../js/jquery-2.1.3.min.js"></script>
    <script src="../js/metro.js"></script>
    <script src="../js/docs.js"></script>
    <script src="../js/prettify/run_prettify.js"></script>
    <script src="../js/ga.js"></script>
    <style type="text/css">
        .topRow{
            padding-top:5px;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">

        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" Theme="Mulberry" Width="100%">
            <TabPages>
                <dx:TabPage Text="Datos Personales">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <!-- aca van los datos personales -->
                            <div class="row cells12">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="RUN">
                                    </dx:ASPxLabel>

                                </div>
                                <div class="cell colspan3">
                                    <dx:ASPxTextBox ID="txtRun" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="DV" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan1">
                                    <dx:ASPxTextBox ID="txtDv" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1" style="padding-left:5px;">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Nombres" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtNombres" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>

                            </div>
                            <!-- ACA VAN LOS APELLIDOSs -->
                            <div class="row cells12 topRow" >
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="P. Apellido">
                                    </dx:ASPxLabel>

                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtPApellido" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="S. Apellido" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>


                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtSApellido" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>

                               <!-- ACA VAN LOS fecha, sexo, e civil -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Fecha Nac.">
                                    </dx:ASPxLabel>

                                </div>
                                <div class="cell colspan2">
                                    
                                    <dx:ASPxDateEdit ID="dtFechaNac" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                                </div>
                                <div class="cell colspan2" >
                                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Sexo" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan2">
                                    <dx:ASPxComboBox ID="cmbSexo" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan2" style="padding-left:5px;">
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Estado Civil" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan3">
                                    <dx:ASPxComboBox ID="cmbEstCivil" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                         <!-- ACA VAN la nacionalidad, nivel educacional -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Nacionalidad">
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbNacionalidad" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan2" >
                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Nivel Educacional" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan4">
                                    <dx:ASPxComboBox ID="cmbNEducacional" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                         <!-- ACA VAN la Afp e Isapre -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="AFP">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbAfp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Isapre" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbIsapre" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                         <!-- ACA VAN la caja, N cargas -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan2">
                                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Caja Compensacion">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbCaja" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan2" >
                                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Numero Cargas" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan1">
                                    <dx:ASPxComboBox ID="cmbNCargas" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                         <!-- cargas Familiares -->
                            <div class="row cells12 topRow"> 
                                  
                            </div>
                            <!-- ACA VAN los botones -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan8">

                                 </div>
                                <div class="cell colspan2">
                                     <button type="submit">Guardar</button>
                                </div>
                                <div class="cell colspan2">
                                     <button type="submit">Cancelar</button>
                                </div>
                            </div>


                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Datos Contacto">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <!-- aca van los datos contacto -->
                            <div class="row cells12">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Direccion">  
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan11">
                                    <dx:ASPxTextBox ID="txtDireccionPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                              <!-- ACA VAN Region, provincia -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Region">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbRegionPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Provincia" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbProvinciaPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                               <!-- ACA VAN Comuna, Imail -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="Comuna">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbComunaPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="E-Mail" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtEMailPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN Celular, Casa -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="Celular">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                     <dx:ASPxTextBox ID="txtCelularPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="Casa" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtCasaPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN Nombre contacto -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan2">
                                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="Nombre Contacto">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan10">
                                    
                                     <dx:ASPxTextBox ID="txtNombreContacto" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN telefono contacto -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan2">
                                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="Telefono Contacto">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan4">
                                    
                                     <dx:ASPxTextBox ID="txtTelefContacto" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN los botones -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan8">

                                 </div>
                                <div class="cell colspan2">
                                     <button type="submit">Guardar</button>
                                </div>
                                <div class="cell colspan2">
                                     <button type="submit">Cancelar</button>
                                </div>
                            </div>

                           
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                <dx:TabPage Text="Datos Laborales">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
                            <!-- aca van los datos laborales -->
                            <div class="row  cells12">
                                 <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="Empresa">  
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                   <dx:ASPxComboBox ID="cmbEmpresa" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Direccion" style="FLOAT:right;PADDING-RIGHT: 5PX;">  
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtDirecEmpresa" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>

                            </div>
                              <!-- ACA VAN Region, provincia -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="Region">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbRegionEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="Provincia" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbProvEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                               <!-- ACA VAN Comuna, Imail -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="Comuna">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbComunaEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Text="Telefono" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtTelefonoEmp" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                             <!-- ACA VAN tipo Contrato, Fecha ingreso, fecha fin -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1" style="padding-left:5px;">
                                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Text="T. Contrato">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan3">
                                    <dx:ASPxComboBox ID="cmbTContrato" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan2">
                                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="Fecha Ingreso" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan2">
                                    <dx:ASPxDateEdit ID="dateFIngreso" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                                </div>
                                <div class="cell colspan2">
                                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Text="Fecha Fin" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan2">
                                     <dx:ASPxDateEdit ID="dateFFin" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                                </div>
                            </div>
                              <!-- ACA VAN Area, Centro Costo -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Text="Area">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbArea" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Text="C. Costo" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbCCosto" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                              <!-- ACA VAN Cargo, Forma Pago -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="Cargo">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                    <dx:ASPxComboBox ID="cmbCargo" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Text="F. Pago" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbFormaPago" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                </div>
                            </div>
                            <!-- ACA VAN N Cta, Banco -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Text="N. Cuenta">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                     <dx:ASPxTextBox ID="txtNCta" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Text="Banco" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtBanco" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN Rol -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Text="ROL">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    <dx:ASPxComboBox ID="cmbRol" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>       
                                </div>
                            </div>
                            <!-- ACA VAN Usuario, contraseña -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan1">
                                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Text="Usuario">  
                                    </dx:ASPxLabel>
                                 </div>
                                <div class="cell colspan5">
                                    
                                     <dx:ASPxTextBox ID="txtUsuario" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                                <div class="cell colspan1" >
                                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="Login" style="FLOAT:right;PADDING-RIGHT: 5PX;">
                                    </dx:ASPxLabel>
                                </div>
                                <div class="cell colspan5">
                                    <dx:ASPxTextBox ID="txtLogin" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                    </dx:ASPxTextBox>
                                </div>
                            </div>
                            <!-- ACA VAN los botones -->
                            <div class="row cells12 topRow">
                                <div class="cell colspan8">

                                 </div>
                                <div class="cell colspan2">
                                     <button type="submit">Guardar</button>
                                </div>
                                <div class="cell colspan2">
                                     <button type="submit">Cancelar</button>
                                </div>
                            </div>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
            </TabPages>
        </dx:ASPxPageControl>

    </div>
</asp:Content>

