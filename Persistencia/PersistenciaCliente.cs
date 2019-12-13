using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaCliente
    {
        public static Cliente Logueo(string pNomUsu, string pPass)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);

            SqlCommand oComando = new SqlCommand("LogueoCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Cliente unCli = null;

            oComando.Parameters.AddWithValue("@NomUsu", pNomUsu);
            oComando.Parameters.AddWithValue("@PassUsu", pPass);

            try
            {
                oConexion.Open();
                SqlDataReader lector = oComando.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();

                    string nomusu = (string)lector["NomUsu"];
                    string passusu = (string)lector["PassUsu"];
                    string nombre = (string)lector["Nombre"];
                    string apellido = (string)lector["Apellido"];
                    int telefono = Convert.ToInt32((int)lector["NumTelefono"]);
                    string direccion = (string)lector["DirEntrega"];

                    unCli = new Cliente(nomusu, passusu, nombre, apellido, direccion, telefono);

                }

                lector.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return unCli;

        }

        public static Cliente Buscar(string pNomusu)
        {
            string passUsu;
            string nombre;
            string apellido;
            int telefono;
            string direccion;

            Cliente c = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec sp_BuscarCliente " + pNomusu, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    oReader.Read();
                    passUsu = (string)oReader["PassUsu"];
                    nombre = (string)oReader["Nombre"];
                    apellido = (string)oReader["Apellido"];
                    telefono = Convert.ToInt32((int)oReader["NumTelefono"]);
                    direccion = (string)oReader["DirEntrega"];

                    c = new Cliente(pNomusu, passUsu, nombre, apellido, direccion, telefono);


                }

                oReader.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return c;




        }

        public static void Agregar(Cliente unCli)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarCliente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NomUsu", unCli.NomUsu);
            oComando.Parameters.AddWithValue("@PassUsu", unCli.PassUsu);
            oComando.Parameters.AddWithValue("@Nombre", unCli.Nombre);
            oComando.Parameters.AddWithValue("@Apellido", unCli.Apellido);
            oComando.Parameters.AddWithValue("@dirEntrega", unCli.DirEntrega);
            oComando.Parameters.AddWithValue("@telefono", unCli.Telefono);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                if (oRetorno == 1)
                    throw new Exception("Cliente agregado exitosamente!");
                if (oRetorno == -1)
                    throw new Exception("Error al agregar!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }




        }



    }
}

