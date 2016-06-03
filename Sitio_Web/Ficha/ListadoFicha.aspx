<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoFicha.aspx.cs" Inherits="Ficha_ListadoFicha" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .topRow {
            padding-top: 5px;
        }
    </style>
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
    <div class="row cells12 topRow">
        <div class="cell colspan10">
        </div>
        <div class="cell colspan2 left">
            <dx:ASPxButton ID="btnCrear" Native="true" CssClass="button alert" runat="server" Text="Nuevo Trabajador" OnClick="btnCrear_Click"></dx:ASPxButton>
        </div>
    </div>
    <div class="row topRow">

        <dx:ASPxGridView ID="grillaRoles" runat="server" AutoGenerateColumns="False" DataSourceID="odsRoles" KeyFieldName="FipeId" Theme="Mulberry" Width="100%" PreviewFieldName="Detalle">
            <SettingsPager NumericButtonCount="5">
            </SettingsPager>
            <Settings ShowFilterRow="True" />
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
            <SettingsText ConfirmDelete="¿Está seguro de Eliminar esta Ficha de Personal?" />
            <Columns>
                <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="0" Width="5%">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataTextColumn FieldName="FipeId" Visible="False" VisibleIndex="1">
                    <Settings AllowHeaderFilter="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="NombreCompleto" VisibleIndex="2" Width="75%">
                    <Settings AllowHeaderFilter="True" AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="EstadoString" VisibleIndex="4" Width="5%" Caption="Estado">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption=" " Name="control" VisibleIndex="5" Width="5%">
                    <DataItemTemplate>
                        
                        <asp:HyperLink ID="hlInicio" runat="server" CssClass="mif-eye fg-green" Text=" Ir..." NavigateUrl='<%# Eval("FipeId", "FichaPersonal.aspx?editar=true&eliminar=false&nuevo=false&id={0}")%>' >                                        <%--<span data-tooltip aria-haspopup="true" class="has-tip" title="Editar">
                                        <i class="foundicon-edit" ></i></span>--%>
                        </asp:HyperLink>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Rut" FieldName="Rut" VisibleIndex="3" Width="10%">
                    <Settings AutoFilterCondition="Contains" />
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="ListaUsuarios" TypeName="VCFramework.NegocioMySql.RrhhFichaPersonal" DeleteMethod="Eliminar">
            <DeleteParameters>
                <asp:Parameter Name="FipeId" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>

