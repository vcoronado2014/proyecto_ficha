<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoFicha.aspx.cs" Inherits="Ficha_ListadoFicha" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="row">
        <ul class="simple-list">
            <li>
                <h4>Búsqueda de Usuarios</h4>
                <hr class="bg-blue" />
            </li>
        </ul>
        <blockquote>
                <p>En esta página Usted podrá Listar los Trabajadores del Sistema y acceder a sus Fichas para realizar distintas acciones</p>
                <%--<small>Consideración: <cite title="Source Title">Debe contar con privilegios de Super Administrador</cite></small>--%>
        </blockquote>
    </div>
    <div class="row">

        <dx:ASPxGridView ID="grillaRoles" runat="server" AutoGenerateColumns="False" DataSourceID="odsRoles" KeyFieldName="FipeId" Theme="Mulberry" Width="100%" PreviewFieldName="Detalle">
            <SettingsPager NumericButtonCount="5">
            </SettingsPager>
            <Settings ShowFilterRow="True" />
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <SettingsText ConfirmDelete="¿Está seguro de Eliminar este Rol?" />
            <Columns>
                <dx:GridViewDataTextColumn FieldName="FipeId" Visible="False" VisibleIndex="0">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="1" Width="85%">
                    <Settings AllowHeaderFilter="True" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Estado" VisibleIndex="2" Width="10%">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="3" Width="5%">
                    <DataItemTemplate>
                        
                        <asp:HyperLink ID="hlInicio" runat="server" CssClass="mif-eye fg-green" NavigateUrl='<%# Eval("FipeId", "FichaPersonal.aspx?editar=true&eliminar=false&nuevo=false&id={0}")%>' >                                        <%--<span data-tooltip aria-haspopup="true" class="has-tip" title="Editar">
                                        <i class="foundicon-edit" ></i></span>--%>
                        </asp:HyperLink>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListaUsuarios" TypeName="VCFramework.NegocioMySql.RrhhFichaPersonal">
        </asp:ObjectDataSource>
    </div>
</asp:Content>

