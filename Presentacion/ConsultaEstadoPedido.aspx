<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaEstadoPedido.aspx.cs" Inherits="ConsultaEstadoPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style4 {
            width: 173px;
            height: 23px;
            text-align: right;
        }
        .auto-style5 {
            height: 23px;
        }
        .auto-style7 {
            width: 117px;
            height: 23px;
        }
        .auto-style8 {
            margin-left: 0px;
        }
        .auto-style9 {
            width: 173px;
        }
        .auto-style10 {
            width: 72px;
        }
        .auto-style11 {
            height: 23px;
            width: 72px;
        }
        .auto-style12 {
            width: 117px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style2">
            <tr>
                <td class="auto-style9">Consultar estado de pedido</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Numero de pedido</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtNumPedido" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style11">
                    <asp:Button ID="btnConsultar" runat="server" CssClass="auto-style8" OnClick="btnConsultar_Click" Text="Consultar" />
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style12">
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Text="[lblError]"></asp:Label>
                </td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
