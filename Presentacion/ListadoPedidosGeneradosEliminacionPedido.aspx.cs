using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;

public partial class ListadoPedidosGeneradosEliminacionPedido : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //No puedes crear un objeto lista que apunte a una Session.
            //Tienes que crear la lista de forma convencional y luego guardarla en la variable Session.

            /*List<Pedido> ListadoGenerales = new List<Pedido>();
                ListadoGenerales = LogicaPedido.ListarPedidosGenerados(Cli);*/

            Cliente cli = (Cliente)Session["Cliente"];
            lblLogueado.Text = cli.NomUsu.ToString();

            try
            {

                Cliente Cli = (Cliente)Session["Cliente"];                

                Session["_listaC"] = LogicaPedido.ListarPedidosGenerados(Cli);
                Session["_listaS"] = new List<Pedido>();


                gvGenerados.DataSource = (List<Pedido>)Session["_listaC"];
                gvGenerados.DataBind();

              
                gvSeleccionado.DataSource = (List<Pedido>)Session["_listaS"];
                gvSeleccionado.DataBind();

                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
         
        }
    }

    protected void gvGenerados_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = gvGenerados.SelectedRow;
        r.BackColor = System.Drawing.Color.Aqua;

        try
        {
            //COMENTADO LA INSTANCIA POR SESION
            //Cliente oCli = (Cliente)Session["Cliente"];
            int numPedido = Convert.ToInt32(gvGenerados.SelectedRow.Cells[1].Text.Trim());

            List<Pedido> listaPedido = new List<Pedido>();
            listaPedido.Add(LogicaPedido.Buscar(numPedido));

            gvSeleccionado.DataSource = listaPedido;
            gvSeleccionado.DataBind();

           
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        int numPedido = 0;
        try
        {
            numPedido = Convert.ToInt32(gvGenerados.SelectedRow.Cells[1].Text.Trim());
     
        }
        catch
        {
            lblError.Text = "Debe seleccionar un pedido";
        }

        try
        {
            LogicaPedido.Eliminar(numPedido);
            lblError.Text = "Eliminacion exitosa";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }



    }
}