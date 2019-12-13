<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 41%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-align: left;
            height: 26px;
        }
        .auto-style4 {
            width: 76px;
            height: 66px;
        }
        .auto-style5 {
            text-align: right;
        }
        .auto-style6 {
            text-align: right;
            height: 26px;
        }
        .auto-style7 {
            text-align: left;
        }
        .auto-style8 {
            text-align: center;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <br />
            <table align="center" class="auto-style1">
                <tr>
                    <td class="auto-style2" colspan="2">
                        <img alt="" class="auto-style4" src="Img/farmalogo.jpg" /></td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style8">Bienvenido</td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style5">Nombre de usuario:</td>
                    <td class="auto-style7">
                        <asp:TextBox ID="txtNomUsu" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomUsu" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Password:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtPassUsu" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassUsu" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLogueo" runat="server" OnClick="btnLogueo_Click" Text="Login" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/ConsultaEstadoPedido.aspx" CausesValidation="False">Consultar Estado de Pedido</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style2">
                        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/RegistroCliente.aspx" CausesValidation="False">Registrar Cliente</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
