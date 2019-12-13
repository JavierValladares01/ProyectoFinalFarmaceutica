using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ConsultaEstadoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cliente unCli = (Cliente)Session["unCliente"];
        }
    }

    protected void btnConsultar_Click(object sender, EventArgs e)
    {
        try
        {
            int numPedido = Convert.ToInt32(txtNumPedido.Text.Trim());

            Pedido unPed = LogicaPedido.Buscar(numPedido);

            lblError.Text = unPed.ToString();
        }
        catch
        {
            lblError.Text = "Pedido no existe";
        }
        

        
    }
}