<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PermisosUsuario.aspx.cs" Inherits="Permisos_PermisosUsuario" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <ul class="simple-list">
            <li>
                <h4>Solicitud de Permisos</h4>
                <hr class="bg-blue" />
            </li>
        </ul>
        <blockquote>
                <p>En esta página Usted podrá solicitar permisos al Administrador.</p>
                <small>Consideración: <cite title="Source Title">Debe contar con privilegios de Trabajador.</cite></small>
        </blockquote>
    </div>
    <div class="row">

        <dx:ASPxGridView ID="grillaRoles" runat="server" AutoGenerateColumns="False" DataSourceID="odsRoles" KeyFieldName="CnpeId" Theme="Mulberry" Width="100%" OnCustomErrorText="grillaRoles_CustomErrorText" OnRowUpdated="grillaRoles_RowUpdated">
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <SettingsText ConfirmDelete="¿Está seguro de Eliminar este Rol?" />
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeId" Visible="False" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="FipeId" Visible="False" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Fecha Inicio" FieldName="CnpeFechaInicio" VisibleIndex="3">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn Caption="Fecha Término" FieldName="CnpeFechaFin" VisibleIndex="4">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeDiasHabiles" Visible="False" VisibleIndex="5" Caption="Cantidad Días">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Observación" FieldName="CnpeObservacion" VisibleIndex="6">
                    <PropertiesTextEdit>
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeEliminado" VisibleIndex="7" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn Caption="Estado" FieldName="EstadoId" VisibleIndex="8">
                    <PropertiesComboBox DataSourceID="odsEstados" TextField="Nombre" ValueField="Id">
                    </PropertiesComboBox>
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Motivo" FieldName="DtpeId" VisibleIndex="9">
                    <PropertiesComboBox DataSourceID="odsMotivos" TextField="DtpeNombre" ValueField="DtpeId">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Asignado" FieldName="FipeIdAsignado" VisibleIndex="10">
                    <PropertiesComboBox DataSourceID="odsJefes" TextField="Nombre" ValueField="Id">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListarPerisosFipeId" TypeName="VCFramework.NegocioMySql.RrhhControlPermisos" DeleteMethod="Eliminar" InsertMethod="Insertar" UpdateMethod="Modificar">
            <DeleteParameters>
                <asp:Parameter Name="CnpeId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CnpeId" Type="Int32" />
                <asp:SessionParameter DefaultValue="0" Name="FipeId" SessionField="FIPE_ID" Type="Int32" />
                <asp:Parameter Name="DtpeId" Type="Int32" />
                <asp:Parameter Name="CnpeFechaInicio" Type="DateTime" />
                <asp:Parameter Name="CnpeFechaFin" Type="DateTime" />
                <asp:Parameter Name="CnpeDiasHabiles" Type="Int32" />
                <asp:Parameter Name="CnpeObservacion" Type="String" />
                <asp:Parameter Name="EstadoId" Type="Int32" />
                <asp:Parameter Name="CnpeEliminado" Type="Int32" />
                <asp:Parameter Name="FipeIdAsignado" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="fipeId" SessionField="FIPE_ID" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="CnpeId" Type="Int32" />
                <asp:Parameter Name="FipeId" Type="Int32" />
                <asp:Parameter Name="DtpeId" Type="Int32" />
                <asp:Parameter Name="CnpeFechaInicio" Type="DateTime" />
                <asp:Parameter Name="CnpeFechaFin" Type="DateTime" />
                <asp:Parameter Name="CnpeDiasHabiles" Type="Int32" />
                <asp:Parameter Name="CnpeObservacion" Type="String" />
                <asp:Parameter Name="EstadoId" Type="Int32" />
                <asp:Parameter Name="CnpeEliminado" Type="Int32" />
                <asp:Parameter Name="FipeIdAsignado" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstados" runat="server" SelectMethod="ObtenerEstados" TypeName="VCFramework.NegocioMySql.EstadoPermiso"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMotivos" runat="server" SelectMethod="ListarMotivos" TypeName="VCFramework.NegocioMySql.RrhhDetallePermiso"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsJefes" runat="server" SelectMethod="ListarJefesGrilla" TypeName="VCFramework.NegocioMySql.RrhhFichaPersonal"></asp:ObjectDataSource>
    </div>
</asp:Content>

