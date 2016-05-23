<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Administracion_Menu" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <ul class="simple-list">
            <li>
                <h4>Administración del Menu</h4>
                <hr class="bg-blue" />
            </li>
        </ul>
        <blockquote>
            <p>En esta página Usted podrá Modificar los roles que tienen acceso al Menu</p>
            <small>Consideración: <cite title="Source Title">Debe contar con privilegios de Super Administrador</cite></small>
        </blockquote>
    </div>
    <hr />
    <div class="row cells12">
        <div class="cell colspan3">Seleccione el Rol a Configurar</div>
        <div class="cell colspan9"><dx:ASPxComboBox ID="cmbRoles" runat="server" Width="100%" DataSourceID="odsRoles" TextField="RolDescripcion" Theme="Mulberry" ValueField="RolId" ClientInstanceName="cmbRol">
            <ClientSideEvents SelectedIndexChanged="function(s, e) {
	lstGrupos.PerformCallback(s.GetValue());
	grillaSubgrupo.PerformCallback(s.GetValue()+ '|0');

}" />
            </dx:ASPxComboBox>
            <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListarRoles" TypeName="VCFramework.NegocioMySql.RrhhRol"></asp:ObjectDataSource>
        </div>
        
    </div>
    <hr />
    <div class="row cells12">
        <div class="cell colspan6">
            <dx:ASPxListBox ID="lstGrupos" runat="server" Caption="Grupos" DataSourceID="odsGrupo" TextField="GrpItem" Theme="Mulberry" ValueField="GrpId" Width="95%" ClientInstanceName="lstGrupos" OnCallback="lstGrupos_Callback" Height="250px">
                <ClientSideEvents ValueChanged="function(s, e) {
	var rol = cmbRol.GetValue();
	var grupo = lstGrupos.GetValue();
	grillaSubgrupo.PerformCallback(rol + '|' + grupo);
}" />
            </dx:ASPxListBox>

            <asp:ObjectDataSource ID="odsGrupo" runat="server" SelectMethod="ListarGruposPorRol" TypeName="VCFramework.NegocioMySql.RrhhGrupoMenu">
                <SelectParameters>
                    <asp:ControlParameter ControlID="cmbRoles" DefaultValue="0" Name="rolId" PropertyName="Value" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>

        </div>
        <div class="cell colspan6">

            <dx:ASPxGridView ID="grillaSubgrupo" runat="server" AutoGenerateColumns="False" ClientInstanceName="grillaSubgrupo" DataSourceID="odsGrilla" OnCustomCallback="grillaSubgrupo_CustomCallback" Width="95%" KeyFieldName="SgrpId">
                <SettingsEditing Mode="Inline">
                </SettingsEditing>
                <Settings ShowColumnHeaders="False" ShowTitlePanel="True" />
                <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
                <SettingsText Title="Sub Items del Grupo" />
                <Columns>
                    <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0" Width="10%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataCheckColumn FieldName="Checked" VisibleIndex="1" Width="10%">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataTextColumn FieldName="SgrpId" Visible="False" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SgrpItem" VisibleIndex="3" Width="80%" ReadOnly="True">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SgrpUrl" Visible="False" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="GrpId" Visible="False" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SgrpActivo" Visible="False" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="SgrpEliminado" Visible="False" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="RolId" Name="rol" Visible="False" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:ObjectDataSource ID="odsGrilla" runat="server" SelectMethod="ListarSubGruposPorIdGrupo" TypeName="VCFramework.NegocioMySql.RrhhSubgrupoMenu" UpdateMethod="GuardarRelacion">
                <SelectParameters>
                    <asp:ControlParameter ControlID="lstGrupos" DefaultValue="0" Name="grpId" PropertyName="Value" Type="Int32" />
                    <asp:ControlParameter ControlID="cmbRoles" DefaultValue="0" Name="rolId" PropertyName="Value" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SgrpId" Type="Int32" />
                    <asp:Parameter Name="SgrpItem" Type="String" />
                    <asp:Parameter Name="SgrpUrl" Type="String" />
                    <asp:Parameter Name="GrpId" Type="Int32" />
                    <asp:Parameter Name="SgrpActivo" Type="Int32" />
                    <asp:Parameter Name="SgrpEliminado" Type="Int32" />
                    <asp:Parameter Name="Checked" Type="Boolean" />
                    <asp:Parameter Name="RolId" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>


        </div>
</asp:Content>

