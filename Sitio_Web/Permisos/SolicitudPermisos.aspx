<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitudPermisos.aspx.cs" Inherits="Permisos_SolicitudPermisos" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/metro.css" rel="stylesheet" />

    <link href="../css/metro-responsive.css" rel="stylesheet" />
    <link href="../css/metro-schemes.css" rel="stylesheet" />

    <link href="../css/docs.css" rel="stylesheet" />
    <link href="../css/metro-icons.css" rel="stylesheet" />

    <script src="../js/jquery-2.1.3.min.js"></script>
    <script src="../js/metro.js"></script>
    <script src="../js/docs.js"></script>
    <script src="../js/prettify/run_prettify.js"></script>
    <script src="../js/ga.js"></script>



    <style type="text/css">
        .topRow {
            padding-top: 5px;
        }

        .font-xx-large {
            font-size: xx-large;
        }

        .font-x-large {
            font-size: x-large;
        }

        .bg-red {
            background-color: red;
        }

        .bg-blue {
            background-color: darkblue;
        }

        .padding-10px {
            padding: 10px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="heading">
            <span class="title">Solicitu de Permisos</span>
        </div>
        <div class="content padding-5">
            <!-- aca van los datos de la solicitud de Permisos -->
            <div class="row cells12 topRow">
                <div class="cell colspan1">
                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="RUN">
                    </dx:ASPxLabel>
                </div>
                <div class="cell colspan3">
                    <dx:ASPxTextBox ID="txtRun" runat="server" Native="True" Theme="iOS" Width="100%" ClientInstanceName="txtRun">
                    </dx:ASPxTextBox>
                </div>
                <div class="cell colspan1">
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="DV" Style="float: right; padding-right: 5PX;">
                    </dx:ASPxLabel>
                </div>
                <div class="cell colspan1">
                    <dx:ASPxTextBox ID="txtDv" runat="server" Native="True" Theme="Mulberry" Width="100%" ClientInstanceName="txtDv" MaxLength="1">
                        <ClientSideEvents KeyUp="function(s, e) {
                                                            //alert('ajax');	
                                                            }"
                            LostFocus="function(s, e) {
	                                                            //alert('ajax');
	                                                            if (s.GetText() != '' &amp;&amp; txtRun.GetText() != '')
	                                                            pnlPrincipal.PerformCallback('BUSCAR|' + txtRun.GetText() + '|' + s.GetText());
                                                            }" />
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
        <!--ACA VA EL TIPO PERMISO Y EL JEFE -->
        <div class="row cells12 topRow">
            <div class="cell colsspan1">
                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="T. Permiso">
                </dx:ASPxLabel>
            </div>
            <div class="cell colspan4">
                <dx:ASPxComboBox ID="cmbTpermiso" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
            </div>
            <div class="cell colsspan1">
                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="jefatura" Style="float: right; padding-right: 5PX;">
                </dx:ASPxLabel>
            </div>
            <div class="cell colspan6">
                <dx:ASPxComboBox ID="cmbJefatura" runat="server" ValueType="System.String" Width="100%" Theme="Mulberry"></dx:ASPxComboBox>
            </div>
        </div>
        <!-- ACA VAN LOS fecha Inicio, Hora Inicio -->
        <div class="row cells12 topRow">
            <div class="cell colspan2">
                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Fecha Inicio">
                </dx:ASPxLabel>

            </div>
            <div class="cell colspan4">

                <dx:ASPxDateEdit ID="dtFechaInicio" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
            </div>
            <div class="cell colspan2">
                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Hora Inicio" Style="float: right; padding-right: 5PX;">
                </dx:ASPxLabel>

            </div>
            <div class="cell colspan4">

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
        </div>
        <!-- ACA VAN LOS fecha Fin, Hora Fin -->
        <div class="row cells12 topRow">
            <div class="cell colspan2">
                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Fecha Termino">
                </dx:ASPxLabel>

            </div>
            <div class="cell colspan4">

                <dx:ASPxDateEdit ID="dtFechaFin" runat="server" Theme="Mulberry" Width="100%"></dx:ASPxDateEdit>
            </div>
            <div class="cell colspan2">
                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Hora Termino" Style="float: right; padding-right: 5PX;">
                </dx:ASPxLabel>

            </div>
            <div class="cell colspan4">

                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </div>
        </div>
        <!-- ACA VA la observacion -->
        <div class="row cells1 topRow">
            <div class="cell colspan1">
                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Observacion"></dx:ASPxLabel>
            </div>
        </div>
        <div class="row cells12 topRow">
            <div class="cell colspan12">
                <asp:TextBox ID="TxObservacion" runat="server" Height="101px" Width="860px"></asp:TextBox>
            </div>
        </div>
        <div class="row cells12 topRow">
            <div class="cell colspan2">
                <dx:ASPxButton ID="btnVolver" CssClass="button alert" runat="server" Text="Salir" Native="true" Width="100%" PostBackUrl="~/Ficha/default.aspx" OnClick="btnVolver_Click"></dx:ASPxButton>
            </div>
            <div class="cell colspan8">
            </div>

            <div class="cell colspan2">
                <dx:ASPxButton ID="btnGuardar" CssClass="button success" runat="server" Text="Guardar" Native="true" Width="100%" AutoPostBack="false">
                </dx:ASPxButton>
            </div>
        </div>
</asp:Content>
