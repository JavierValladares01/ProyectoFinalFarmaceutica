using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Empleado emp = (Empleado)Session["Empleado"];
            lblLogueado.Text = emp.NomUsu.ToString();
            this.LimpioFormulario();
            
        }

   

    }

    protected void ActivoBotonesBM()
    {
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;

        btnAgregar.Enabled = false;
        btnBuscar.Enabled = false;

        txtNomUsu.Enabled = false;
        txtPassUsu.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtHorEnt.Enabled = true;
        txtHorSal.Enabled = true;
    }

    protected void ActivoBotonesA()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        btnAgregar.Enabled = true;
        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = false;
        txtPassUsu.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtHorEnt.Enabled = true;
        txtHorSal.Enabled = true;
    }

    protected void LimpioFormulario()
    {
        btnAgregar.Enabled = false;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;

        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = true;

        txtNomUsu.Text = "";
        txtPassUsu.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtHorEnt.Text = "";
        txtHorSal.Text = "";

        lblError.Text = "";
    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string nomUsu = txtNomUsu.Text.Trim();

            Cliente unCli = LogicaUsuario.BuscarCliente(nomUsu);

            if (unCli == null)
            {
                Empleado unEmp = LogicaUsuario.BuscarEmpleado(nomUsu);

                if (unEmp != null)
                {
                    this.ActivoBotonesBM();

                    txtNomUsu.Text = unEmp.NomUsu;
                    txtPassUsu.Text = unEmp.PassUsu;
                    txtNombre.Text = unEmp.Nombre;
                    txtApellido.Text = unEmp.Apellido;
                    txtHorEnt.Text = unEmp.HorarioEntrada;
                    txtHorSal.Text = unEmp.HorarioSalida;

                    Session["unEmpleado"] = unEmp;
                }
                else
                {
                    lblError.Text = "Empleado no encontrado";
                    this.ActivoBotonesA();
                    Session["unEmpleado"] = null;
                }

            }
            else
            {
                lblError.Text = "El nombre de usuario pertenece a un cliente!";
            }

            
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
            if (txtPassUsu.Text != "")
            {

                Empleado unEmp = new Empleado(txtNomUsu.Text.Trim(), txtPassUsu.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtHorEnt.Text.Trim(), txtHorSal.Text.Trim());

                LogicaUsuario.AgregarEmpleado(unEmp);

                lblError.Text = "Empleado agregado exitosamente!";

            }
            else
            {
                lblError.Text = "Debe ingresar una contraseña";
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

            
            if (txtPassUsu.Text != "")
            {
                Empleado unEmp = (Empleado)Session["unEmpleado"];


                unEmp.PassUsu = txtPassUsu.Text.Trim();
                unEmp.Nombre = txtNombre.Text.Trim();
                unEmp.Apellido = txtApellido.Text.Trim();
                unEmp.HorarioEntrada = txtHorEnt.Text.Trim();
                unEmp.HorarioSalida = txtHorSal.Text.Trim();

                LogicaUsuario.ModificarEmpleado(unEmp);

                this.LimpioFormulario();
                lblError.Text = "Modificacion exitosa";

            }
            else
            {
                lblError.Text = "Debe ingresar una contraseña!";
            }
      
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            
            Empleado unEmp = (Empleado)Session["Empleado"];

            if (unEmp.NomUsu != txtNomUsu.Text)
            {
                Empleado otroEmp = LogicaUsuario.BuscarEmpleado(txtNomUsu.Text);

                LogicaUsuario.EliminarEmpleado(otroEmp.NomUsu);

                this.LimpioFormulario();
                lblError.Text = "Eliminacion exitosa!";

            }

            else
            {
                lblError.Text = "No puede eliminar al empleado actualmente loggeado!";

            }         
                
          

            
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}