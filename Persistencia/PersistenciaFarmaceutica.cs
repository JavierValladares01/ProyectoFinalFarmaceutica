using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaFarmaceutica
    {
        public static void Agregar(Farmaceutica pFarm)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", pFarm.RUC);
            oComando.Parameters.AddWithValue("@nomFar", pFarm.NombreFarm);
            oComando.Parameters.AddWithValue("@email", pFarm.Email);
            oComando.Parameters.AddWithValue("@Dir", pFarm.Direccion);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                if ((int)oRetorno.Value == 0)
                    throw new Exception("Farmaceutica ya existe!");
                else if ((int)oRetorno.Value == -1)
                    throw new Exception("Error al agregar farmaceutica");

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

        public static void Modificar(Farmaceutica pFarm)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ModificarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", pFarm.RUC);
            oComando.Parameters.AddWithValue("@nomFar", pFarm.NombreFarm);
            oComando.Parameters.AddWithValue("@email", pFarm.Email);
            oComando.Parameters.AddWithValue("@Dir", pFarm.Direccion);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                if ((int)oRetorno.Value == 0)
                    throw new Exception("RUC no existe - No se modifica");
                if ((int)oRetorno.Value == -1)
                    throw new Exception("Error al modificar farmaceutica");

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

        public static Farmaceutica Buscar(int pRUC)
        {
            string oNomFarm;
            string oEmail;
            string oDir;

            Farmaceutica c = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec sp_BuscoFarmaceutica " + pRUC, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    oReader.Read();
                    oNomFarm = (string)oReader["NomFarm"];
                    oEmail = (string)oReader["Email"];
                    oDir = (string)oReader["Direccion"];
                    c = new Farmaceutica(pRUC, oNomFarm, oEmail, oDir);

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

        public static void Eliminar(Farmaceutica pFarm)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_EliminarFarmaceutica", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oRUC = new SqlParameter("@ruc", pFarm.RUC);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oRUC);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == 0)
                    throw new Exception("Hay pedidos asociados! - no se puede eliminar");
                else if (oAfectados == -1)
                    throw new Exception("Error al eliminar farmaceutica");


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

        public static List<Farmaceutica> ListarFarmaceuticas()
        {
            int oRuc;
            string oNomFarm;
            string oEmail;
            string oDireccion;

            List<Farmaceutica> oListarFarmaceuticas = new List<Farmaceutica>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ListarFarmaceuticas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while (oReader.Read())
                {
                    oRuc = Convert.ToInt32((int)oReader["RUC"]);
                    oNomFarm = (string)oReader["NomFarm"];
                    oEmail = (string)oReader["Email"];
                    oDireccion = (string)oReader["Direccion"];

                    Farmaceutica f = new Farmaceutica(oRuc, oNomFarm, oEmail, oDireccion);
                    oListarFarmaceuticas.Add(f);

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
            return oListarFarmaceuticas;


        }

    }
}
