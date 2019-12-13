<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="CambioEstadoPedido.aspx.cs" Inherits="CambioEstadoPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style5 {
        width: 337px;
    }
    .auto-style6 {
        width: 263px;
    }
    .auto-style7 {
        width: 263px;
        text-align: center;
    }
    .auto-style8 {
        width: 337px;
        text-align: center;
    }
        .auto-style9 {
            width: 337px;
            height: 23px;
        }
        .auto-style10 {
            width: 263px;
            text-align: center;
            height: 23px;
        }
        .auto-style11 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style7">
            <asp:GridView ID="gvPedidos" runat="server" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="auto-style7">
            <asp:Button ID="btnCambiarEstado" runat="server" OnClick="btnCambiarEstado_Click" Text="Cambiar Estado" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">
            &nbsp;</td>
        <td class="auto-style7">
            <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">
            <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style10">
        </td>
        <td class="auto-style11"></td>
    </tr>
    <tr>
        <td class="auto-style5">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Logout</asp:LinkButton>
        </td>
        <td class="auto-style7">
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar listado" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

