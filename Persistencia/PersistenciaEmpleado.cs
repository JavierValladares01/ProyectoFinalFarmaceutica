using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaEmpleado
    {
        public static Empleado Logueo(string pNomUsu, string pPass)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);

            SqlCommand oComando = new SqlCommand("LogueoEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            Empleado unEmp = null;

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
                    string horaEntrada = (string)lector["HorarioEntrada"];
                    string horaSalida = (string)lector["HorarioSalida"];

                    unEmp = new Empleado(nomusu, passusu, nombre, apellido, horaEntrada, horaSalida);

                }

                lector.Close();
                oConexion.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }

            return unEmp;
        }

        public static void Agregar(Empleado unEmp)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NomUsu", unEmp.NomUsu);
            oComando.Parameters.AddWithValue("@PassUsu", unEmp.PassUsu);
            oComando.Parameters.AddWithValue("@Nombre", unEmp.Nombre);
            oComando.Parameters.AddWithValue("@Apellido", unEmp.Apellido);
            oComando.Parameters.AddWithValue("@HorarioEntrada", unEmp.HorarioEntrada);
            oComando.Parameters.AddWithValue("@HorarioSalida", unEmp.HorarioSalida);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                //pendiente con los retornos1!!
                if (oRetorno == 1)
                    throw new Exception("Empleado agregado exitosamente!");
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

        public static void Modificar(Empleado unEmp)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ModificarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NomUsu", unEmp.NomUsu);
            oComando.Parameters.AddWithValue("@PassUsu", unEmp.PassUsu);
            oComando.Parameters.AddWithValue("@Nombre", unEmp.Nombre);
            oComando.Parameters.AddWithValue("@Apellido", unEmp.Apellido);
            oComando.Parameters.AddWithValue("@HorarioEntrada", unEmp.HorarioEntrada);
            oComando.Parameters.AddWithValue("@HorarioSalida", unEmp.HorarioSalida);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                if (oRetorno == 1)
                    throw new Exception("Modificacion exitosa!");
                else if (oRetorno == -1)
                    throw new Exception("Error al intentar modificar");
                else if (oRetorno == -2)
                    throw new Exception("Error - Nombre de usuario corresponde a cliente!");
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

        public static void Eliminar(string nomUsu)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_EliminarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NomUsu", nomUsu);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                if (oRetorno == 1)
                    throw new Exception("Eliminacion exitosa!");
                else if (oRetorno == -1)
                    throw new Exception("Error al intentar eliminar");
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

        public static Empleado Buscar(string nomUsu)
        {
            string passUsu, nombre, apellido, horaEntrada, horaSalida;

            Empleado unEmp = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec sp_BuscarEmpleado " + nomUsu, oConexion);
                       

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.Read())
                {
                    passUsu = (string)oReader["PassUsu"];
                    nombre = (string)oReader["Nombre"];
                    apellido = (string)oReader["Apellido"];
                    horaEntrada = (string)oReader["HorarioEntrada"];
                    horaSalida = (string)oReader["HorarioSalida"];

                    unEmp = new Empleado(nomUsu, passUsu, nombre, apellido, horaEntrada, horaSalida);
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

            return unEmp;
        }
    }


    }
