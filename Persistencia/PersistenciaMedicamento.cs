using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaMedicamento
    {
        public static void Agregar(Medicamento pMed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@RUC", pMed.Farm.RUC);//ruc debe existir para poder agregar
            oComando.Parameters.AddWithValue("@codigo", pMed.Codigo);
            oComando.Parameters.AddWithValue("@NomMed", pMed.NombreMed);
            oComando.Parameters.AddWithValue("@Descripcion", pMed.Descripcion);
            oComando.Parameters.AddWithValue("@Precio", pMed.Precio);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                if ((int)oRetorno.Value == 0)
                    throw new Exception("RUC no encontrado!");
                else if ((int)oRetorno.Value == -1)
                    throw new Exception("Codigo ya existe!");
                else if ((int)oRetorno.Value == -2)
                    throw new Exception("Error al agregar medicamento!");

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

        public static void Modificar(Medicamento pMed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ModificarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@RUC", pMed.Farm.RUC);//ruc debe existir para poder agregar
            oComando.Parameters.AddWithValue("@codigo", pMed.Codigo);
            oComando.Parameters.AddWithValue("@NomMed", pMed.NombreMed);
            oComando.Parameters.AddWithValue("@Descripcion", pMed.Descripcion);
            oComando.Parameters.AddWithValue("@Precio", pMed.Precio);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                if ((int)oRetorno.Value == 0)
                    throw new Exception("RUC no existe - no se modifica");
                if ((int)oRetorno.Value == -1)
                    throw new Exception("Codigo no existe - no se modifica");
                if ((int)oRetorno.Value == -2)
                    throw new Exception("Error al modificar medicamento");

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

        public static Medicamento Buscar (int pCod, Farmaceutica pRUC) 
        {
            string oNomMed;
            string oDescripcion;
            double oPrecio;

            Medicamento m = null;
            SqlDataReader oReader;

            

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec sp_BuscoMedicamento " + pCod + "," + pRUC.RUC, oConexion);

                                 
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    oReader.Read();
                    oNomMed = (string)oReader["NomMed"];
                    oDescripcion = (string)oReader["Descripcion"];
                    oPrecio = Convert.ToDouble((double)oReader["Precio"]);
                    m = new Medicamento(pCod, pRUC, oNomMed, oDescripcion, oPrecio);
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
            return m;

        }

        public static void Eliminar(Medicamento pMed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_EliminarMedicamento", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter oRUC = new SqlParameter("@RUC", pMed.Farm.RUC);
            SqlParameter oCodigo = new SqlParameter("@codigo", pMed.Codigo);
            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(oRUC);
            oComando.Parameters.Add(oCodigo);
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                    throw new Exception("Error al eliminar pedido!");
                else if (oAfectados == -2)
                    throw new Exception("Error al eliminar medicamento");


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

        public static List<Medicamento> ListadoMedicamentosXFarmaceutica (Farmaceutica oRuc)
        {
            
            int oCodigo;
            string oNomMed;
            string oDescripcion;
            double oPrecio;
             

            List<Medicamento> oListarMedicamentosXFarmaceutica = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);

            //
            SqlCommand oComando = new SqlCommand("exec sp_ListarMedicamentosXFarmaceutica " + oRuc.RUC, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                while(oReader.Read())
                {
                    oCodigo = Convert.ToInt32((int)oReader["Codigo"]);
                    oNomMed = (string)oReader["NomMed"];
                    oDescripcion = (string)oReader["Descripcion"];
                    oPrecio = Convert.ToDouble((double)oReader["Precio"]);


                    Medicamento m = new Medicamento(oCodigo, oRuc, oNomMed, oDescripcion, oPrecio);
                    oListarMedicamentosXFarmaceutica.Add(m);

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
            return oListarMedicamentosXFarmaceutica;


        }

        public static List<Medicamento> ListarMedicamentos()
        {
            int codigo;
            string nomMed;
            Farmaceutica ruc;
            string descripcion;
            double precio;

            Medicamento m;

            List<Medicamento> ListadoMedicamentos = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ListarMedicamentos", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigo = Convert.ToInt32((int)oReader["Codigo"]);
                        ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                        nomMed = (string)oReader["NomMed"];
                        descripcion = (string)oReader["Descripcion"];
                        precio = Convert.ToDouble((double)oReader["Precio"]);


                        m = new Medicamento(codigo, ruc, nomMed, descripcion, precio);

                        ListadoMedicamentos.Add(m);
                    }

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

            return ListadoMedicamentos;
        }

        public static List<Medicamento> ListarMedicamentoSeleccionado(int pCod, Farmaceutica pRUC)
        {
            Medicamento m;
            List<Medicamento> ListarMedicamentoSeleccionado = new List<Medicamento>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ListarMedicamentoSeleccionado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@ruc", pRUC.RUC);
            oComando.Parameters.AddWithValue("@codigo", pCod);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    oReader.Read();

                    int codigo = Convert.ToInt32((int)oReader["Codigo"]);
                    Farmaceutica ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                    string nomMed = (string)oReader["NomMed"];
                    string descripcion = (string)oReader["Descripcion"];
                    double precio = Convert.ToDouble((double)oReader["Precio"]);

                    m = new Medicamento(codigo, ruc, nomMed, descripcion, precio);

                    ListarMedicamentoSeleccionado.Add(m);
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

            return ListarMedicamentoSeleccionado;
        }


    }
}





