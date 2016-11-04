<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AutorizarPermisos.aspx.cs" Inherits="Permisos_AutorizarPermisos" %>

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
                <p>En esta página Usted podrá Autorizar/Rechazar permisos solicitados por el Trabajador.</p>
                <small>Consideración: <cite title="Source Title">Debe contar con privilegios de Trabajador.</cite></small>
        </blockquote>
    </div>
    <div class="row">

        <dx:ASPxGridView ID="grillaRoles" runat="server" AutoGenerateColumns="False" DataSourceID="odsRoles" KeyFieldName="CnpeId" Theme="Mulberry" Width="100%" OnCustomErrorText="grillaRoles_CustomErrorText" OnRowUpdated="grillaRoles_RowUpdated">
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <SettingsDataSecurity AllowDelete="False" />
            <SettingsText ConfirmDelete="¿Está seguro de Eliminar este Rol?" />
            <Columns>
                <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeId" Visible="False" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="FipeId" Visible="False" VisibleIndex="6">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Fecha Inicio" FieldName="CnpeFechaInicio" VisibleIndex="7" ReadOnly="True">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataDateColumn Caption="Fecha Término" FieldName="CnpeFechaFin" VisibleIndex="8" ReadOnly="True">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeDiasHabiles" Visible="False" VisibleIndex="9" Caption="Cantidad Días">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Observación" FieldName="CnpeObservacion" VisibleIndex="4" ReadOnly="True">
                    <PropertiesTextEdit>
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="CnpeEliminado" VisibleIndex="10" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataComboBoxColumn Caption="Estado" FieldName="EstadoId" VisibleIndex="2">
                    <PropertiesComboBox DataSourceID="odsEstados" TextField="Nombre" ValueField="Id">
                    </PropertiesComboBox>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Motivo" FieldName="DtpeId" VisibleIndex="3" ReadOnly="True">
                    <PropertiesComboBox DataSourceID="odsMotivos" TextField="DtpeNombre" ValueField="DtpeId">
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Asignado" FieldName="FipeIdAsignado" VisibleIndex="11" Visible="False">
                    <PropertiesComboBox DataSourceID="odsJefes" TextField="Nombre" ValueField="Id">
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataTextColumn FieldName="NombreTrabajador" Name="Nombre" ReadOnly="True" VisibleIndex="1">
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Respuesta" FieldName="ObservacionJefe" VisibleIndex="12">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListaEnvoltorioPermisosJefe" TypeName="VCFramework.NegocioMySql.EnvoltorioPermisosJefe" UpdateMethod="Modificar">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="fipeIdJefe" SessionField="FIPE_ID" Type="Int32" />
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
                <asp:Parameter Name="ObservacionJefe" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEstados" runat="server" SelectMethod="ObtenerEstados" TypeName="VCFramework.NegocioMySql.EstadoPermiso"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsMotivos" runat="server" SelectMethod="ListarMotivos" TypeName="VCFramework.NegocioMySql.RrhhDetallePermiso"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsJefes" runat="server" SelectMethod="ListarJefesGrilla" TypeName="VCFramework.NegocioMySql.RrhhFichaPersonal"></asp:ObjectDataSource>
    </div>
</asp:Content>

