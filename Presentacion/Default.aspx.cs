using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["usuario"] = null;
    }

    protected void btnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario unUsu = LogicaUsuario.Logueo(txtNomUsu.Text.Trim(), txtPassUsu.Text.Trim());
            if (unUsu != null)
            {
                if (unUsu is Empleado)
                {
                    Session["Empleado"] = unUsu;
                    Response.Redirect("PaginaBienvenidaEmpleado.aspx");
                }
                else
                {
                    Session["Cliente"] = unUsu;
                    Response.Redirect("RealizarPedido.aspx");
                }              
                   
            }
            else
                lblError.Text = "Datos ingresados no validos!";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}