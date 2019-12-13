using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using System.Drawing;

public partial class RegistroCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LimpioFormulario();
        }


    }
    protected void LimpioFormulario()
    {
        btnBuscar.Enabled = true;
        txtNomUsu.Enabled = true;

        txtNomUsu.Text = "";
        txtPassUsu.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
        lblError.Text = "";
    }

    protected void ActivoBotonesA()
    {
        btnAgregar.Enabled = true;
        btnBuscar.Enabled = false;

        txtNomUsu.Enabled = false;

        txtPassUsu.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
    }

    protected void ActivoBotonesBM()
    {
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtNomUsu.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        
        try
        {
            string nomUsu = txtNomUsu.Text.Trim();

            Empleado unEmp = LogicaUsuario.BuscarEmpleado(nomUsu);


            if (unEmp == null)
            {

                Cliente unCli = LogicaUsuario.BuscarCliente(nomUsu);

                if (unCli != null)
                {
                    this.ActivoBotonesBM();

                    txtNomUsu.Text = unCli.NomUsu;
                    txtPassUsu.Text = unCli.PassUsu;
                    txtNombre.Text = unCli.Nombre;
                    txtApellido.Text = unCli.Apellido;
                    txtDireccion.Text = unCli.DirEntrega;
                    txtTelefono.Text = Convert.ToString(unCli.Telefono);

                    lblError.Text = "El Cliente ya existe";
                }
                else
                {
                    lblError.Text = "Cliente no encontrado";
                    this.ActivoBotonesA();
                }
            }
            else
            {
                lblError.Text = "Nombre de usuario ya existe!";

            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Debe ingresar nombre de usuario!";
        }
    }



    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPassUsu.Text != "")
            {
                Cliente unCli = new Cliente(txtNomUsu.Text.Trim(), txtPassUsu.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtDireccion.Text.Trim(), Convert.ToInt32(txtTelefono.Text.Trim()));

                LogicaUsuario.AgregarCliente(unCli);

                lblError.Text = "Cliente agregado!";

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

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}