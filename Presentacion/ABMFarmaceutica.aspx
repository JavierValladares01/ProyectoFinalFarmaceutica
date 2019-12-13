<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMFarmaceutica.aspx.cs" Inherits="ABMFarmaceutica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style34 {
            height: 23px;
            width: 15px;
        }
        .auto-style35 {
            height: 23px;
            width: 218px;
        }
        .auto-style36 {
            width: 259px;
        }
        .auto-style37 {
            height: 23px;
            width: 259px;
            text-align: center;
        }
        .auto-style38 {
            width: 142px;
        }
        .auto-style40 {
            width: 617px;
        }
        .auto-style41 {
            height: 23px;
            width: 142px;
        }
        .auto-style42 {
            height: 23px;
            width: 142px;
            text-align: center;
        }
        .auto-style43 {
            width: 142px;
            text-align: center;
        }
        .auto-style44 {
            width: 259px;
            text-align: center;
        }
        .auto-style45 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style40">
    <tr>
        <td class="auto-style28"></td>
        <td class="auto-style36"></td>
        <td class="auto-style38"></td>
        <td class="auto-style35"></td>
    </tr>
    <tr>
        <td class="auto-style19">RUC</td>
        <td class="auto-style44">
            &nbsp;&nbsp;
            <asp:TextBox ID="txtRUC" runat="server" Width="194px" CssClass="auto-style45"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRUC" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
        <td class="auto-style43">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="114px" OnClick="btnBuscar_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style15">Nombre</td>
        <td class="auto-style44">
            <asp:TextBox ID="txtNomFarm" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style38"></td>
    </tr>
    <tr>
        <td class="auto-style11">Email</td>
        <td class="auto-style44">
            &nbsp;<asp:TextBox ID="txtEmail" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style38"></td>
    </tr>
    <tr>
        <td class="auto-style11">Direccion</td>
        <td class="auto-style44">
            <asp:TextBox ID="txtDir" runat="server" Width="194px"></asp:TextBox>
        </td>
        <td class="auto-style38"></td>
    </tr>
    <tr>
        <td class="auto-style34">&nbsp;</td>
        <td class="auto-style37">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CausesValidation="False" />
&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CausesValidation="False" />
&nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
        </td>
        <td class="auto-style42">&nbsp;<asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td class="auto-style28">
            &nbsp;</td>
        <td class="auto-style44">
            <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
        </td>
        <td class="auto-style41"></td>
    </tr>
    <tr>
        <td class="auto-style28">
            &nbsp;</td>
        <td class="auto-style36">
            &nbsp;</td>
        <td class="auto-style41">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style28">
            <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style36">
            &nbsp;</td>
        <td class="auto-style41">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style28">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="False">Logout</asp:LinkButton>
        </td>
        <td class="auto-style36">
            &nbsp;</td>
        <td class="auto-style41">&nbsp;</td>
    </tr>
</table>
</asp:Content>

