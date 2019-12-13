<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ListadoMedicamentosYPedidos.aspx.cs" Inherits="ListadoMedicamentosYPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 363px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 363px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <table class="auto-style1">
        <tr>
            <td>
                &nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlFiltrarPedidos" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>Generado</asp:ListItem>
                    <asp:ListItem>Entregado</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlFarmaceutica" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style5">
                <asp:GridView ID="GVMedicamento" runat="server" OnSelectedIndexChanged="GVMedicamento_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="GVPedidos" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
            </td>
            <td class="auto-style7"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Logout</asp:LinkButton>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
</asp:Content>

