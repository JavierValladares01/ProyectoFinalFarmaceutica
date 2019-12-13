using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;


public partial class ListadoMedicamentosYPedidos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Empleado emp = (Empleado)Session["Empleado"];
        lblLogueado.Text = emp.NomUsu.ToString();

        if (!IsPostBack)
        {
            List<Farmaceutica> oFarmaceuticas = LogicaFarmaceutica.ListarFarmaceuticas();

            if (oFarmaceuticas.Count > 0)
            {
                ddlFarmaceutica.DataSource = oFarmaceuticas;
                ddlFarmaceutica.DataTextField = "NombreFarm";
                ddlFarmaceutica.DataValueField = "RUC";
                ddlFarmaceutica.DataBind();

            }

        }
    }



    protected void btnListar_Click(object sender, EventArgs e)
    {
               


        //OJO ACA!!! 

        List<Medicamento> oMedicamento = LogicaMedicamento.ListarMedicamentosXFarmaceutica(LogicaFarmaceutica.Buscar(Convert.ToInt32(ddlFarmaceutica.Text)));
        GVMedicamento.DataSource = oMedicamento;
        GVMedicamento.DataBind();

        Session["_listaM"] = oMedicamento;

        Session["_listaP"] = new List<Pedido>();

      

    }

    protected void GVMedicamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow r = GVMedicamento.SelectedRow;
        r.BackColor = Color.DeepSkyBlue;

        List<Pedido> _listaP = (List<Pedido>)Session["_listaP"];

        Medicamento codigo = LogicaMedicamento.Buscar(Convert.ToInt32(GVMedicamento.SelectedRow.Cells[1].Text), LogicaFarmaceutica.Buscar(Convert.ToInt32(ddlFarmaceutica.Text)));


        string estado = ddlFiltrarPedidos.Text;

        if (estado == "Generado") 
        {
            _listaP = LogicaPedido.ListarPedidosXEstado(codigo, estado);

            GVPedidos.DataSource = _listaP;
            GVPedidos.DataBind();
        }
        else if (estado == "Entregado")
        {
            _listaP = LogicaPedido.ListarPedidosXEstado(codigo, estado);

            GVPedidos.DataSource = _listaP;
            GVPedidos.DataBind();
        }
        else
        {
            _listaP = LogicaPedido.ListarTodosPedidos(codigo);

            GVPedidos.DataSource = _listaP;
            GVPedidos.DataBind();
        }






    }
}