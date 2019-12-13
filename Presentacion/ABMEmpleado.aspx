<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMEmpleado.aspx.cs" Inherits="ABMEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style10 {
        width: 57%;
        height: 175px;
    }
    .auto-style9 {
            width: 128px;
        }
    .auto-style20 {
        width: 128px;
        height: 22px;
    }
    .auto-style16 {
        width: 128px;
        height: 5px;
    }
    .auto-style12 {
        width: 128px;
        height: 3px;
    }
    .auto-style29 {
        width: 128px;
        height: 23px;
    }
    .auto-style30 {
        width: 248px;
        text-align: center;
        height: 23px;
    }
        .auto-style34 {
            width: 109px;
            text-align: center;
        }
        .auto-style36 {
            width: 248px;
            height: 22px;
            text-align: center;
        }
        .auto-style37 {
            width: 248px;
            height: 5px;
            text-align: center;
        }
        .auto-style38 {
            width: 248px;
            height: 3px;
            text-align: center;
        }
        .auto-style40 {
            width: 248px;
            text-align: center;
        }
        .auto-style41 {
            width: 248px;
        }
        .auto-style42 {
            width: 109px;
        }
        .auto-style43 {
            width: 109px;
            height: 22px;
        }
        .auto-style44 {
            width: 109px;
            height: 5px;
        }
        .auto-style45 {
            width: 109px;
            height: 3px;
        }
        .auto-style46 {
            width: 109px;
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style10">
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style41">&nbsp;</td>
        <td class="auto-style42">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">Nombre de usuario</td>
        <td class="auto-style40">
            &nbsp;&nbsp;
            <asp:TextBox ID="txtNomUsu" runat="server" Width="193px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomUsu" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
        <td class="auto-style34">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="114px" OnClick="btnBuscar_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">Contraseña</td>
        <td class="auto-style40">
            <asp:TextBox ID="txtPassUsu" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style42">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style9">Nombre</td>
        <td class="auto-style40">
            <asp:TextBox ID="txtNombre" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style42">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">Apellido</td>
        <td class="auto-style36">
            <asp:TextBox ID="txtApellido" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style43">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style16">Horario de entrada</td>
        <td class="auto-style37">
            <asp:TextBox ID="txtHorEnt" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style44"></td>
    </tr>
    <tr>
        <td class="auto-style12">Horario de salida</td>
        <td class="auto-style38">
            <asp:TextBox ID="txtHorSal" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style45"></td>
    </tr>
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style40">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CausesValidation="False" />
&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CausesValidation="False" />
&nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
        </td>
        <td class="auto-style34">
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td class="auto-style29">
            &nbsp;</td>
        <td class="auto-style30">
            <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
        </td>
        <td class="auto-style46"></td>
    </tr>
    <tr>
        <td class="auto-style29">
            &nbsp;</td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style46"></td>
    </tr>
    <tr>
        <td class="auto-style29">
            <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style46">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style29">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="False">Logout</asp:LinkButton>
        </td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style46">&nbsp;</td>
    </tr>
</table>
</asp:Content>

