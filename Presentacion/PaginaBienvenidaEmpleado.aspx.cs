using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class PaginaBienvenidaEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Empleado emp = (Empleado)Session["Empleado"];
        lblLogueado.Text = emp.NomUsu.ToString();
    }
}