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

        <dx:ASPxCallbackPanel ID="pnlPrincipal" runat="server" ClientInstanceName="pnlPrincipal" Width="100%">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="2" Theme="Mulberry" Width="100%" OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged">
                        <TabPages>
                            <dx:TabPage Text="Datos Personales">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Datos Personales</span>
                                            </div>
                                            <div class="content padding-5">
                                                <!-- aca van los datos personales -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="RUN">
                                                        </dx:ASPxLabel>

                                                    </div>
                                                    <div class="cell colspan3">
                                                        <dx:ASPxTextBox ID="txtRun" runat="server" Native="True" Theme="iOS" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="DV" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxTextBox ID="txtDv" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                    <div class="cell colspan1" style="padding-left: 5px;">
                                                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Nombres" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtNombres" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>

                                                </div>
                                                <!-- ACA VAN LOS APELLIDOS -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="P. Apellido">
                                                        </dx:ASPxLabel>

                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtPApellido" runat="server" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="S. Apellido" Style="float: right; padding-right: 5PX;">
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
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Sexo" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxComboBox ID="cmbSexo" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsSexo" TextField="SexoDescripcion" ValueField="SexoId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsSexo" runat="server" SelectMethod="ListarSexo" TypeName="VCFramework.NegocioMySql.RrhhSexo"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan2" style="padding-left: 5px;">
                                                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Estado Civil" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan3">
                                                        <dx:ASPxComboBox ID="cmbEstCivil" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsEstCivil" OnSelectedIndexChanged="cmbEstCivil_SelectedIndexChanged" TextField="EstcDescripcion" ValueField="EstcId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsEstCivil" runat="server" SelectMethod="ListarEstCivil" TypeName="VCFramework.NegocioMySql.RrhhEstadoCivil"></asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN la nacionalidad, nivel educacional -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Nacionalidad">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbNacionalidad" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsNacionalidad" TextField="NacDescripcion" ValueField="NacId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsNacionalidad" runat="server" SelectMethod="ListarNacionalidad" TypeName="VCFramework.NegocioMySql.RrhhNacionalidad"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Nivel Educacional" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan4">
                                                        <dx:ASPxComboBox ID="cmbNEducacional" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsNivelEstudio" TextField="NiveDescripcion" ValueField="NiveId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsNivelEstudio" runat="server" SelectMethod="ListarNivelEstudio" TypeName="VCFramework.NegocioMySql.RrhhNivelEstudios"></asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN la Afp e Isapre -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="AFP">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbAfp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsAfp" TextField="AfpDescripcion" ValueField="AfpId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsAfp" runat="server" SelectMethod="ListarAfp" TypeName="VCFramework.NegocioMySql.RrhhAfp"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Isapre" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbIsapre" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsIsapre" TextField="IsapDescripcion" ValueField="IsapId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsIsapre" runat="server" SelectMethod="ListarIsapre" TypeName="VCFramework.NegocioMySql.RrhhIsapre"></asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN la caja, N cargas -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Caja Compensacion">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbCaja" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsCajaCompensacion" TextField="CjacDescripcion" ValueField="CjacId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsCajaCompensacion" runat="server" SelectMethod="ListarCajaCompensacion" TypeName="VCFramework.NegocioMySql.RrhhCajaCompensacion"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Numero Cargas" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxComboBox ID="cmbNCargas" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
                                                    </div>
                                                </div>
                                                <!-- cargas Familiares -->
                                                <div class="row cells12 topRow panel">
                                                    <div class="heading bg-lighterBlue">
                                                        <span class="title font-size-08">Cargas Familiares</span>
                                                    </div>
                                                    <div class="content padding-5">
                                                        <!-- grilla -->
                                                        <dx:ASPxGridView ID="grillaCargas" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxGridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Datos Contacto">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Dirección</span>
                                            </div>
                                            <div class="content padding-5">

                                                <!-- aca van los datos contacto -->
                                                <div class="row cells12">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Direccion">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan11">
                                                        <dx:ASPxTextBox ID="txtDireccionPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                            <ValidationSettings ValidationGroup="frm">
                                                                <RegularExpression ErrorText="" />
                                                                <RequiredField ErrorText="Requerido" />
                                                            </ValidationSettings>
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

                                                        <dx:ASPxComboBox ID="cmbRegionPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" CssClass="select2-results__option--highlighted" DataSourceID="odsRegion" TextField="RegDescripcion" ValueField="RegId" DropDownStyle="DropDown" Native="True" SelectedIndex="0">
                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbProvinciaPers.PerformCallback(s.GetValue());
	cmbComunaPers.PerformCallback('0');
}" />
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsRegion" runat="server" SelectMethod="ListarRegion" TypeName="VCFramework.NegocioMySql.RrhhRegion"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Provincia" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbProvinciaPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" ClientInstanceName="cmbProvinciaPers" DataSourceID="odsProvincia" OnCallback="cmbProvinciaPers_Callback" TextField="ProvDescripcion" ValueField="ProvId" DropDownStyle="DropDown" Native="True">
                                                            <ClientSideEvents KeyDown="function(s, e) {
	//alert(s.GetValue());
}" SelectedIndexChanged="function(s, e) {
	//alert('index');
}" TextChanged="function(s, e) {
	//alert('text');
}" ValueChanged="function(s, e) {
	//alert(s.GetValue());
cmbComunaPers.PerformCallback(s.GetValue());
}" />
                                                            <ButtonStyle CssClass="dxeButton dxeButtonEditButton_Mulberry">
                                                            </ButtonStyle>
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsProvincia" runat="server" SelectMethod="ListarProvinciasPorRegion" TypeName="VCFramework.NegocioMySql.RrhhProvincia">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="cmbRegionPers" DefaultValue="0" Name="idReg" PropertyName="Value" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN Comuna, Imail -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="Comuna">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbComunaPers" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" ClientInstanceName="cmbComunaPers" DataSourceID="odsComuna" Native="True" OnCallback="cmbComunaPers_Callback" TextField="ComDescripcion" ValueField="ComId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsComuna" runat="server" SelectMethod="ListarComunasPorProvincia" TypeName="VCFramework.NegocioMySql.RrhhComuna">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="cmbProvinciaPers" DefaultValue="0" Name="idProv" PropertyName="Value" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="E-Mail" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtEMailPers" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Teléfono</span>
                                            </div>
                                            <div class="content padding-5">
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
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="Casa" Style="float: right; padding-right: 5PX;">
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

                                            </div>
                                        </div>



                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                            <dx:TabPage Text="Datos Laborales">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Datos Empresa</span>
                                            </div>
                                            <div class="content padding-5">
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
                                                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Direccion" Style="float: right; padding-right: 5PX;">
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

                                                        <dx:ASPxComboBox ID="cmbRegionEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" Native="True" ClientInstanceName="cmbRegionEmp" DataSourceID="odsRegionEmp" SelectedIndex="0" TextField="RegDescripcion" ValueField="RegId">
                                                            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	cmbProvEmp.PerformCallback(s.GetValue());
	cmbComEmp.PerformCallback('0');

}" />
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsRegionEmp" runat="server" SelectMethod="ListarRegion" TypeName="VCFramework.NegocioMySql.RrhhRegion"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel27" runat="server" Text="Provincia" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbProvEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" Native="True" ClientInstanceName="cmbProvEmp" DataSourceID="odsProvEmp" OnCallback="cmbProvEmp_Callback" TextField="ProvDescripcion" ValueField="ProvId">
                                                            <ClientSideEvents ValueChanged="function(s, e) {
	cmbComEmp.PerformCallback(s.GetValue());

}" />
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsProvEmp" runat="server" SelectMethod="ListarProvinciasPorRegion" TypeName="VCFramework.NegocioMySql.RrhhProvincia">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="cmbRegionEmp" DefaultValue="0" Name="idReg" PropertyName="Value" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN Comuna, Imail -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="Comuna">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbComunaEmp" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" Native="True" ClientInstanceName="cmbComEmp" DataSourceID="odsComEmp" OnCallback="cmbComunaEmp_Callback" TextField="ComDescripcion" ValueField="ComId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsComEmp" runat="server" SelectMethod="ListarComunasPorProvincia" TypeName="VCFramework.NegocioMySql.RrhhComuna">
                                                            <SelectParameters>
                                                                <asp:ControlParameter ControlID="cmbProvEmp" DefaultValue="0" Name="idProv" PropertyName="Value" Type="Int32" />
                                                            </SelectParameters>
                                                        </asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel29" runat="server" Text="Telefono" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtTelefonoEmp" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Datos Cargo</span>
                                            </div>
                                            <div class="content padding-5">
                                                <!-- ACA VAN tipo Contrato, Fecha ingreso, fecha fin -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1" style="padding-left: 5px;">
                                                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Text="T. Contrato">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan3">
                                                        <dx:ASPxComboBox ID="cmbTContrato" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsTipoContrato" Native="True" TextField="TicoDescripcion" ValueField="TicoId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsTipoContrato" runat="server" SelectMethod="ListarTipoContrato" TypeName="VCFramework.NegocioMySql.RrhhTipoContrato"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="Fecha Ingreso" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxDateEdit ID="dateFIngreso" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
                                                    </div>
                                                    <div class="cell colspan2">
                                                        <dx:ASPxLabel ID="ASPxLabel31" runat="server" Text="Fecha Fin" Style="float: right; padding-right: 5PX;">
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

                                                        <dx:ASPxComboBox ID="cmbArea" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsAreaNegocio" Native="True" TextField="ArenDescripcion" ValueField="ArenId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsAreaNegocio" runat="server" SelectMethod="ListarAreaNegocio" TypeName="VCFramework.NegocioMySql.RrhhAreaNegocio"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel34" runat="server" Text="C. Costo" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbCCosto" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsCentroCosto" Native="True" TextField="CencDescripcion" ValueField="CencId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsCentroCosto" runat="server" SelectMethod="ListarCentroCosto" TypeName="VCFramework.NegocioMySql.RrhhCentroCosto"></asp:ObjectDataSource>
                                                    </div>
                                                </div>
                                                <!-- ACA VAN Cargo, Forma Pago -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="Cargo">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">

                                                        <dx:ASPxComboBox ID="cmbCargo" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsCargo" Native="True" TextField="CargDescripcion" ValueField="CargId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsCargo" runat="server" SelectMethod="ListarCargo" TypeName="VCFramework.NegocioMySql.RrhhCargo"></asp:ObjectDataSource>
                                                    </div>
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Text="F. Pago" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbFormaPago" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsFPago" Native="True" TextField="ForpDescripcion" ValueField="ForpId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsFPago" runat="server" SelectMethod="ListarFPago" TypeName="VCFramework.NegocioMySql.RrhhFormaPago"></asp:ObjectDataSource>
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
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Text="Banco" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtBanco" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row panel">
                                            <div class="heading">
                                                <span class="title">Acceso</span>
                                            </div>
                                            <div class="content padding-5">
                                                <!-- ACA VAN Rol -->
                                                <div class="row cells12 topRow">
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel39" runat="server" Text="ROL">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxComboBox ID="cmbRol" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry" DataSourceID="odsRol" Native="True" TextField="RolDescripcion" ValueField="RolId"></dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="odsRol" runat="server" SelectMethod="ListarRoles" TypeName="VCFramework.NegocioMySql.RrhhRol"></asp:ObjectDataSource>
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
                                                    <div class="cell colspan1">
                                                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="Login" Style="float: right; padding-right: 5PX;">
                                                        </dx:ASPxLabel>
                                                    </div>
                                                    <div class="cell colspan5">
                                                        <dx:ASPxTextBox ID="txtLogin" runat="server" Native="True" Theme="Mulberry" Width="100%">
                                                        </dx:ASPxTextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>
                        </TabPages>
                    </dx:ASPxPageControl>
                    <!-- ACA VAN los botones -->
                    <div class="row cells12 topRow">
                        <div class="cell colspan8">
                        </div>
                        <div class="cell colspan2">
                            <dx:ASPxButton ID="btnVolver" CssClass="button alert" runat="server" Text="Volver" Native="true" Width="100%"></dx:ASPxButton>
                        </div>
                        <div class="cell colspan2">
                            <dx:ASPxButton ID="btnGuardar" CssClass="button success" runat="server" Text="Guardar" Native="true" Width="100%" AutoPostBack="false"></dx:ASPxButton>
                        </div>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>



    </div>
</asp:Content>

