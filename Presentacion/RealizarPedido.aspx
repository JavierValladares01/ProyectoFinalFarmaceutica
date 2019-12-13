<%@ Page Title="" Language="C#" MasterPageFile="~/MPCliente.master" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RealizarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            width: 424px;
        }
        .auto-style7 {
            font-size: medium;
        }
        .auto-style8 {
            width: 424px;
            font-size: medium;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            width: 424px;
            font-size: medium;
            height: 34px;
        }
        .auto-style11 {
            height: 34px;
        }
        .auto-style12 {
            width: 424px;
            text-align: left;
        }
        .auto-style13 {
            width: 277px;
            height: 340px;
            font-size: x-large;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style13">
        <tr class="auto-style7">
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:GridView ID="gvMedicamentos" runat="server" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged" CssClass="auto-style7">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="gvSeleccionado" runat="server" CssClass="auto-style7">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"><span class="auto-style7">Cantidad:</span> <asp:TextBox ID="txtCantidad" runat="server" CssClass="auto-style9" Width="153px"></asp:TextBox>
                <span class="auto-style7">&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;</span><asp:Button ID="btnCalcularCosto" runat="server" Text="Calcular costo" OnClick="btnCalcularCosto_Click" CssClass="auto-style9" Font-Size="Small" Width="97px" CausesValidation="False" />
            </td>
            <td class="auto-style11">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lblCosto" runat="server" Text="[lblCosto]" CssClass="auto-style7"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar pedido" OnClick="btnConfirmar_Click" CssClass="auto-style9" Font-Size="Small" Width="116px" CausesValidation="False" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lblError" runat="server" Text="[lblError]" CssClass="auto-style7"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Label ID="lblLogueado" runat="server" CssClass="auto-style9" Text="lblLogueado"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="auto-style7" PostBackUrl="~/Default.aspx" CausesValidation="False">Logout</asp:LinkButton>
            </td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

