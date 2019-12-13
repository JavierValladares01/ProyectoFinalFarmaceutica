<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="ABMMedicamento.aspx.cs" Inherits="ABMMedicamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style9 {
            width: 58px;
        }
    .auto-style20 {
        width: 58px;
        height: 22px;
    }
    .auto-style24 {
        width: 233px;
        height: 22px;
            text-align: center;
        }
    .auto-style22 {
        height: 22px;
            text-align: center;
            width: 205px;
        }
    .auto-style16 {
        width: 58px;
        height: 5px;
    }
    .auto-style12 {
            width: 58px;
            height: 3px;
        }
    .auto-style29 {
        width: 58px;
        height: 23px;
    }
    .auto-style30 {
        width: 233px;
        text-align: center;
        height: 23px;
    }
    .auto-style10 {
        width: 64%;
        height: 175px;
    }
    .auto-style33 {
        text-align: center;
            width: 205px;
            height: 34px;
        }
        .auto-style44 {
            width: 233px;
            height: 5px;
            text-align: center;
        }
        .auto-style46 {
            width: 233px;
            text-align: center;
            height: 34px;
        }
        .auto-style58 {
            width: 205px;
        }
        .auto-style59 {
            width: 205px;
            height: 5px;
        }
        .auto-style60 {
            width: 205px;
            height: 3px;
        }
        .auto-style61 {
            width: 205px;
            height: 23px;
        }
        .auto-style62 {
            width: 121px;
        }
        .auto-style63 {
            height: 22px;
            text-align: center;
            width: 121px;
        }
        .auto-style64 {
            width: 121px;
            height: 5px;
        }
        .auto-style65 {
            width: 121px;
            height: 3px;
        }
        .auto-style66 {
            text-align: center;
            width: 121px;
            height: 34px;
        }
        .auto-style67 {
            width: 121px;
            height: 23px;
        }
        .auto-style68 {
            width: 233px;
            height: 3px;
            text-align: center;
        }
        .auto-style69 {
            width: 233px;
        }
        .auto-style70 {
            width: 58px;
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style10">
    <tr>
        <td class="auto-style9">&nbsp;</td>
        <td class="auto-style69"></td>
        <td class="auto-style62">&nbsp;</td>
        <td class="auto-style58">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style20">Codigo</td>
        <td class="auto-style24">
            &nbsp;&nbsp;
            <asp:TextBox ID="txtCod" runat="server" Width="186px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCod" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
        <td class="auto-style63">
            &nbsp;
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="114px" OnClick="btnBuscar_Click" />
        </td>
        <td class="auto-style22">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style16">RUC</td>
        <td class="auto-style44">
            &nbsp;&nbsp;
            <asp:TextBox ID="txtRUC" runat="server" Width="190px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRUC" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
        </td>
        <td class="auto-style64"></td>
        <td class="auto-style59"></td>
    </tr>
    <tr>
        <td class="auto-style12">Nombre</td>
        <td class="auto-style68">
            <asp:TextBox ID="txtNombre" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style65"></td>
        <td class="auto-style60">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style12">Descripcion</td>
        <td class="auto-style68">
            <asp:TextBox ID="txtDescripcion" runat="server" Width="193px"></asp:TextBox>
        </td>
        <td class="auto-style65"></td>
        <td class="auto-style60"></td>
    </tr>
    <tr>
        <td class="auto-style12">Precio</td>
        <td class="auto-style68">
            <asp:TextBox ID="txtPrecio" runat="server" Width="194px"></asp:TextBox>
        </td>
        <td class="auto-style65"></td>
        <td class="auto-style60">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style70"></td>
        <td class="auto-style46">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CausesValidation="False" />
&nbsp;
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CausesValidation="False" />
&nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CausesValidation="False" />
        </td>
        <td class="auto-style66">
            <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
        </td>
        <td class="auto-style33">
            </td>
    </tr>
    <tr>
        <td class="auto-style29">
            &nbsp;</td>
        <td class="auto-style30">
            <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
        </td>
        <td class="auto-style67"></td>
        <td class="auto-style61">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style29">
            &nbsp;</td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style67">&nbsp;</td>
        <td class="auto-style61">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style29">
            <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style67">&nbsp;</td>
        <td class="auto-style61">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style29">
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx" CausesValidation="False">Logout</asp:LinkButton>
        </td>
        <td class="auto-style30">
            &nbsp;</td>
        <td class="auto-style67">&nbsp;</td>
        <td class="auto-style61">&nbsp;</td>
    </tr>
</table>
</asp:Content>

