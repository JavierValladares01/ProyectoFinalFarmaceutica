using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    public class PersistenciaPedido
    {

        public static List<Pedido> ListarPedidosXEstado(Medicamento pCod, string pEstado)
        {

            int numPedido;
            Cliente cli;
            Farmaceutica ruc;
            int cantidad;

            List<Pedido> oListadoPedidosXEstado = new List<Pedido>();
            Pedido p;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("exec sp_ListarPedidosXEstado " + pEstado + "," + pCod.Codigo, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numPedido = Convert.ToInt32((int)oReader["NumPedido"]);
                        cli = PersistenciaCliente.Buscar((string)oReader["NomUsu"]);
                        ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                        cantidad = Convert.ToInt32((int)oReader["Cantidad"]);

                        p = new Pedido(numPedido, cli, pCod, ruc, cantidad, pEstado);
                        oListadoPedidosXEstado.Add(p);
                    }

                    oReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oListadoPedidosXEstado;

        }

        public static List<Pedido> ListarTodosPedidos(Medicamento pCod)
        {

            int numPedido;
            Cliente cli;
            Farmaceutica ruc;
            int cantidad;
            string estado;

            List<Pedido> oListarTodosPedidos = new List<Pedido>();
            Pedido p;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("exec sp_ListarTodosPedidos " + pCod.Codigo, oConexion);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        numPedido = Convert.ToInt32((int)oReader["NumPedido"]);
                        cli = PersistenciaCliente.Buscar((string)oReader["NomUsu"]);
                        ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                        cantidad = Convert.ToInt32((int)oReader["Cantidad"]);
                        estado = (string)oReader["Estado"];

                        p = new Pedido(numPedido, cli, pCod, ruc, cantidad, estado);
                        oListarTodosPedidos.Add(p);
                    }

                    oReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
            return oListarTodosPedidos;

        }

        public static Pedido Buscar(int oNumPedido)
        {

            Cliente nomUsu;
            Medicamento codigo;
            Farmaceutica ruc;
            int cantidad;
            string estado;

            Pedido p = null;
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_BuscarPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@NumPedido", oNumPedido);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();


                if (oReader.Read())
                {
                    nomUsu = PersistenciaCliente.Buscar((string)oReader["NomUsu"]);
                    codigo = PersistenciaMedicamento.Buscar(Convert.ToInt32((int)oReader["Codigo"]), PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"])));
                    ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                    cantidad = Convert.ToInt32((int)oReader["Cantidad"]);
                    estado = (string)oReader["Estado"];

                    p = new Pedido(oNumPedido, nomUsu, codigo, ruc, cantidad, estado);

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
            return p;


        }

        public static List<Pedido> ListarPedidosGenerados(Cliente cli)
        {
            Pedido p;

            int numPedido;

            Medicamento codigo;
            Farmaceutica ruc;
            int cantidad;
            string estado;


            List<Pedido> ListaPedidosGenerados = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ListarPedidosGenerados", oConexion);

            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", cli.NomUsu);


            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        numPedido = Convert.ToInt32((int)oReader["NumPedido"]);

                        codigo = PersistenciaMedicamento.Buscar(Convert.ToInt32((int)oReader["Codigo"]), PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"])));
                        ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                        cantidad = Convert.ToInt32((int)oReader["Cantidad"]);
                        estado = (string)oReader["Estado"];


                        p = new Pedido(numPedido, cli, codigo, ruc, cantidad, estado);


                        ListaPedidosGenerados.Add(p);
                    }

                    oReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return ListaPedidosGenerados;
        }

        public static void Eliminar(int numPed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("Exec sp_EliminarPedido " + numPed, oConexion);



            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int retorno = (int)oComando.Parameters["@Retorno"].Value;

                if (retorno == 1)
                    throw new Exception("Eliminacion exitosa");
                else if (retorno == -1)
                    throw new Exception("Error al eliminar pedido!");

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

        public static void Agregar(Pedido oPed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_AgregarPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nomUsu", oPed.NomUsu);
            oComando.Parameters.AddWithValue("@ruc", oPed.RUC.RUC);
            oComando.Parameters.AddWithValue("@cod", oPed.Codigo.Codigo);
            oComando.Parameters.AddWithValue("@cantidad", oPed.Cantidad);
            oComando.Parameters.AddWithValue("@estado", oPed.Estado);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                if (oRetorno == 1)
                    throw new Exception("Pedido realizado exitosamente");
                if (oRetorno == -1)
                    throw new Exception("Error al agregar pedido!");
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

        public static List<Pedido> ListarPedidosGeneradosYEnviados()
        {
            Pedido p;

            int numPedido;

            Medicamento codigo;
            Farmaceutica ruc;
            Cliente cli;
            int cantidad;
            string estado;


            List<Pedido> ListaPedidosGeneradosYEnviados = new List<Pedido>();
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_ListarPedidosGeneradosYEnviados", oConexion);

            oComando.CommandType = CommandType.StoredProcedure;

           
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        numPedido = Convert.ToInt32((int)oReader["NumPedido"]);

                        codigo = PersistenciaMedicamento.Buscar(Convert.ToInt32((int)oReader["Codigo"]), PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"])));
                        ruc = PersistenciaFarmaceutica.Buscar(Convert.ToInt32((int)oReader["RUC"]));
                        cli = PersistenciaCliente.Buscar((string)oReader["NomUsu"]);
                        cantidad = Convert.ToInt32((int)oReader["Cantidad"]);
                        estado = (string)oReader["Estado"];


                        p = new Pedido(numPedido, cli, codigo, ruc, cantidad, estado);


                        ListaPedidosGeneradosYEnviados.Add(p);
                    }

                    oReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }

            return ListaPedidosGeneradosYEnviados;
        }

        public static void CambiarEstadoPedido(int numPed)
        {
            SqlConnection oConexion = new SqlConnection(CONEXION.STR);
            SqlCommand oComando = new SqlCommand("sp_CambiarEstadoPedido", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@numPedido", numPed);

            SqlParameter oParametro = new SqlParameter("@Retorno", SqlDbType.Int);
            oParametro.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oParametro);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int oRetorno = (int)oComando.Parameters["@Retorno"].Value;

                if (oRetorno == 1)
                    throw new Exception("Cambio de estado realizado exitosamente!");
                else if (oRetorno == -1)
                    throw new Exception("Error al intentar cambiar de estado");
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

