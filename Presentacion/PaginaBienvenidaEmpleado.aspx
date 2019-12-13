<%@ Page Title="" Language="C#" MasterPageFile="~/MPEmpleado.master" AutoEventWireup="true" CodeFile="PaginaBienvenidaEmpleado.aspx.cs" Inherits="PaginaBienvenidaEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style5 {
        text-align: center;
    }
        .auto-style6 {
            width: 248px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">Bienvenido<br />
            Empleado</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Label ID="lblLogueado" runat="server" Text="lblLogueado"></asp:Label>
        </td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Logout</asp:LinkButton>
                </td>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style5">&nbsp;</td>
    </tr>
</table>
</asp:Content>

