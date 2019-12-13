using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMFarmaceutica : System.Web.UI.Page
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
        txtDir.Text = "";
        txtEmail.Text = "";
        txtNomFarm.Text = "";
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
        int RUC = 0;

        try
        {

            RUC = Convert.ToInt32(txtRUC.Text);

        }
        catch
        {
            lblError.Text = "El RUC debe ser un numero!";
        }

        try
        {
            Farmaceutica f = LogicaFarmaceutica.Buscar(RUC);

            if (f != null)
            {
                txtDir.Text = f.Direccion;
                txtEmail.Text = f.Email;
                txtNomFarm.Text = f.NombreFarm;

                Session["unaFarm"] = f;

                txtRUC.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

            }
            else
            {
                lblError.Text = "Farmaceutica no encontrada";
                btnAgregar.Enabled = true;

                Session["unaFarm"] = null;
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
            string nomFarm = txtNomFarm.Text;
            string email = txtEmail.Text;
            string direccion = txtDir.Text;

            if (txtNomFarm.Text != "")
            {
                Farmaceutica f = (Farmaceutica)Session["unaFarm"];
                f.NombreFarm = nomFarm;
                f.Email = email;
                f.Direccion = direccion;

                

                LogicaFarmaceutica.Modificar(f);
                lblError.Text = "Modificacion exitosa!";
                txtRUC.Enabled = true;
                this.LimpioFormulario();
                this.DesactivoBotones();

            }           

            else
            {
                lblError.Text = "Debe ingresar nombre de la farmaceutica!";
            }

          
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e) 
    {
        //ojo! si elimino medicamentos, se eliminan tambien pedidos, lo que significa que luego la farmaceutica
        //tambien podra eliminarse, no importa si agrego el medicamento de nuevo, los pedidos son identity!

        try
        {
            Farmaceutica f = (Farmaceutica)Session["unaFarm"];

            LogicaFarmaceutica.Eliminar(f);
            lblError.Text = "Eliminacion exitosa";
            txtRUC.Enabled = true;
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
            int ruc = Convert.ToInt32(txtRUC.Text);
            string nomFarm = txtNomFarm.Text;
            string email = txtRUC.Text;
            string direccion = txtDir.Text;

            if (txtNomFarm.Text != "")
            {
                Farmaceutica f = new Farmaceutica(ruc, nomFarm, email, direccion);

                LogicaFarmaceutica.Agregar(f);

                lblError.Text = "Farmaceutica agregada exitosamente!";
                txtRUC.Enabled = true;
                this.LimpioFormulario();
                this.DesactivoBotones();

            }
            else
            {
                lblError.Text = "Debe ingresar nombre de la Farmaceutica!";
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
        this.LimpioFormulario();
        this.DesactivoBotones();
        lblError.Text = "";
    }

}


