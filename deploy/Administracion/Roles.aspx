<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Administracion_Roles" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row">
        <ul class="simple-list">
            <li>
                <h4>Administración de Roles del Sistema</h4>
                <hr class="bg-blue" />
            </li>
        </ul>
        <blockquote>
                <p>En esta página Usted podrá crear, modificar y eliminar los Roles del Sistema</p>
                <small>Consideración: <cite title="Source Title">Debe contar con privilegios de Super Administrador</cite></small>
        </blockquote>
    </div>
    <div class="row">

        <dx:ASPxGridView ID="grillaRoles" runat="server" AutoGenerateColumns="False" DataSourceID="odsRoles" KeyFieldName="RolId" Theme="Mulberry" Width="100%">
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <SettingsText ConfirmDelete="¿Está seguro de Eliminar este Rol?" />
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" Width="20%">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="RolId" Visible="False" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RolDescripcion" VisibleIndex="2" Width="80%">
                    <PropertiesTextEdit>
                        <ValidationSettings>
                            <RequiredField ErrorText="Requerido" IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RolEstado" Visible="False" VisibleIndex="3">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="RolEliminado" Visible="False" VisibleIndex="4">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListarRoles" TypeName="VCFramework.NegocioMySql.RrhhRol" DeleteMethod="Eliminar" InsertMethod="Insertar" UpdateMethod="Modificar">
            <DeleteParameters>
                <asp:Parameter Name="RolId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="RolId" Type="Int32" />
                <asp:Parameter Name="RolDescripcion" Type="String" />
                <asp:Parameter Name="RolEstado" Type="Int32" />
                <asp:Parameter Name="RolEliminado" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="RolId" Type="Int32" />
                <asp:Parameter Name="RolDescripcion" Type="String" />
                <asp:Parameter Name="RolEstado" Type="Int32" />
                <asp:Parameter Name="RolEliminado" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

