using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class CambioEstadoPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Empleado emp = (Empleado)Session["Empleado"];
            lblLogueado.Text = emp.NomUsu.ToString();

            try
            {
                Session["listaC"] = LogicaPedido.ListarPedidosGeneradosYEnviados();

                gvPedidos.DataSource = (List<Pedido>)Session["listaC"];
                gvPedidos.DataBind();

                btnCambiarEstado.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow R = gvPedidos.SelectedRow;
        R.BackColor = System.Drawing.Color.Aqua;

        btnCambiarEstado.Enabled = true;
    }

    protected void btnCambiarEstado_Click(object sender, EventArgs e)
    {

        int numPedido = Convert.ToInt32(gvPedidos.SelectedRow.Cells[1].Text.Trim());

        try
        {
            LogicaPedido.CambiarEstadoPedido(numPedido);

            lblError.Text = "Cambio de Estado realizado exitosamente!";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            Session["listaC"] = LogicaPedido.ListarPedidosGeneradosYEnviados();

            gvPedidos.DataSource = (List<Pedido>)Session["listaC"];
            gvPedidos.DataBind();

            btnCambiarEstado.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}