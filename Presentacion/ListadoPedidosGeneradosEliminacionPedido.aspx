<%@ Page Title="" Language="C#" MasterPageFile="~/MPCliente.master" AutoEventWireup="true" CodeFile="ListadoPedidosGeneradosEliminacionPedido.aspx.cs" Inherits="ListadoPedidosGeneradosEliminacionPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style5 {
        width: 100%;
    }
        .auto-style6 {
            font-size: medium;
        }
        .auto-style7 {
            font-size: medium;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            font-size: medium;
            height: 23px;
            width: 387px;
            text-align: left;
        }
        .auto-style11 {
            font-size: medium;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style5">
    <tr class="auto-style6">
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvGenerados" runat="server" OnSelectedIndexChanged="gvGenerados_SelectedIndexChanged" CssClass="auto-style6">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </td>
        <td>
            <asp:GridView ID="gvSeleccionado" runat="server" CssClass="auto-style6">
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7"><span class="auto-style6"></td>
        <td class="auto-style8"></span></td>
        <td class="auto-style7"></td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="auto-style6" Font-Size="Small" />
        </td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lblError" runat="server" Text="[lblError]" CssClass="auto-style6"></asp:Label>
        </td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10">
            <asp:Label ID="lblLogueado" runat="server" CssClass="auto-style9" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style8">
            &nbsp;</td>
        <td class="auto-style7">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Logout</asp:LinkButton>
        </td>
        <td>
            &nbsp;</td>
        <td class="auto-style6">&nbsp;</td>
    </tr>
</table>
</asp:Content>

