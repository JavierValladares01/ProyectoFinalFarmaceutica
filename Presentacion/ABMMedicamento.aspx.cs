using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMMedicamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Empleado emp = (Empleado)Session["Empleado"];
            lblLogueado.Text = emp.NomUsu.ToString();

            this.LimpioFormulario();
            this.DesactivoBotones();
        }
    }

    private void LimpioFormulario()
    {
        txtCod.Text = "";
        txtDescripcion.Text = "";
        txtNombre.Text = "";
        txtPrecio.Text = "";
        txtRUC.Text = "";
            
    }

    private void DesactivoBotones()
    {
        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnBuscar.Enabled = true;
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        lblError.Text = "";

        Farmaceutica Farm = null; // de aca se va a sacar el RUC
        int Codigo = 0;       

      
        try
        {
            Farm = LogicaFarmaceutica.Buscar(Convert.ToInt32(txtRUC.Text));
            Codigo = Convert.ToInt32(txtCod.Text);
        }
        catch
        {
            lblError.Text = "Codigo/RUC deben ser valores numericos!";
        }
       
        try
        {
            if (Farm != null)
            {
                Medicamento m = LogicaMedicamento.Buscar(Codigo, Farm);

                if (m != null)
                {
                    txtDescripcion.Text = m.Descripcion;
                    txtNombre.Text = m.NombreMed;
                    txtPrecio.Text = m.Precio.ToString();



                    Session["unMed"] = m;

                    txtRUC.Enabled = false;
                    txtCod.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                }
                else
                {
                    lblError.Text = "Medicamento no encontrado";
                    txtRUC.Enabled = false;
                    txtCod.Enabled = false;
                    btnAgregar.Enabled = true;

                    Session["unMed"] = null;
                }
            }
            else
            {

                lblError.Text = "Farmaceutica no encontrada - verifique los datos";
            }
           
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }



    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            string nomMed = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);

            if (txtNombre.Text != "")
            {
                Medicamento m = (Medicamento)Session["unMed"];
                m.NombreMed = nomMed;
                m.Descripcion = descripcion;
                m.Precio = precio;

                LogicaMedicamento.Modificar(m);
                lblError.Text = "Modificacion exitosa!";
                txtRUC.Enabled = true;
                txtCod.Enabled = true;
                this.LimpioFormulario();
                this.DesactivoBotones();

            }
            else
            {
                lblError.Text = "Debe ingresar nombre del medicamento!";
            }
            


        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e) //a veces funciona a veces no ????
    {
        try
        {
            Medicamento m = (Medicamento)Session["unMed"];

            LogicaMedicamento.Eliminar(m);
            lblError.Text = "Eliminacion exitosa";
            txtRUC.Enabled = true;
            txtCod.Enabled = true;
            this.LimpioFormulario();
            this.DesactivoBotones();

        }
        catch (Exception ex)
        {

            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Farmaceutica Farm = LogicaFarmaceutica.Buscar(Convert.ToInt32(txtRUC.Text));
            int codigo = Convert.ToInt32(txtCod.Text);
            string descripcion = txtDescripcion.Text;
            string nomMed = txtNombre.Text;
            double precio = Convert.ToDouble(txtPrecio.Text);

            if (txtNombre.Text != "")
            {
                Medicamento m = new Medicamento(codigo, Farm, nomMed, descripcion, precio);

                LogicaMedicamento.Agregar(m);

                lblError.Text = "Medicamento agregado exitosamente!";
                txtRUC.Enabled = true;
                this.LimpioFormulario();
                this.DesactivoBotones();


            }
            else
            {
                lblError.Text = "Debe ingresar nombre del medicamento!";
            }

            
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
       
            txtRUC.Enabled = true;
            txtCod.Enabled = true;
            this.LimpioFormulario();
            this.DesactivoBotones();
            lblError.Text = "";
        
    }
}