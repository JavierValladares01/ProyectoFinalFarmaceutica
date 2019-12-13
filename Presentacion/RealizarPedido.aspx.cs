using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;

public partial class RealizarPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Cliente cli = (Cliente)Session["Cliente"];
            lblLogueado.Text = cli.NomUsu.ToString();

            try
            {
                Session["_listaC"] = LogicaMedicamento.ListarMedicamentos();
                Session["_listaS"] = new List<Medicamento>();

                gvMedicamentos.DataSource = (List<Medicamento>)Session["_listaC"];
                gvMedicamentos.DataBind();
                gvSeleccionado.DataSource = (List<Medicamento>)Session["_listaS"];
                gvSeleccionado.DataBind();

                txtCantidad.Enabled = false;

                
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
    }

    protected void gvMedicamentos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow R = gvMedicamentos.SelectedRow;
        R.BackColor = System.Drawing.Color.Aqua;

        
        try
        {
            Farmaceutica ruc = LogicaFarmaceutica.Buscar(Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim()));
            int codigo = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[1].Text.Trim());

            gvSeleccionado.DataSource = LogicaMedicamento.ListarMedicamentoSeleccionado(codigo, ruc);
            gvSeleccionado.DataBind();

            CalcularCostoPedido();

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

        protected void CalcularCostoPedido()
        {
            txtCantidad.Enabled = true;
            btnCalcularCosto.Enabled = true;
        }

    protected void btnCalcularCosto_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";

            int precio = Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[4].Text.Trim());            
            int costoTotal = Convert.ToInt32(txtCantidad.Text.Trim()) * precio;

            if (costoTotal > 0)
            {
                lblCosto.Text = "Costo del Pedido: $" + costoTotal;
                btnConfirmar.Enabled = true;

            }
            else
            {
                lblCosto.Text = "No puede ingresar un valor negativo!";
                btnConfirmar.Enabled = false;
            }
           
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            int numPed = 0;
            Farmaceutica ruc;
            Medicamento codigo;            
            int cantidad;
            Cliente cli;
            string estado = "Generado";

            cli = (Cliente)Session["Cliente"];
            


            

            ruc = LogicaFarmaceutica.Buscar(Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[5].Text.Trim()));
            codigo = LogicaMedicamento.Buscar(Convert.ToInt32(gvMedicamentos.SelectedRow.Cells[1].Text.Trim()), ruc);
            cantidad = Convert.ToInt32(txtCantidad.Text.Trim());

            Pedido p = new Pedido(numPed, cli, codigo, ruc, cantidad, estado);

            LogicaPedido.AgregarPedido(p);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}

