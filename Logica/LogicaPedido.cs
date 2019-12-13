using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPedido
    {
        public static List<Pedido> ListarPedidosXEstado(Medicamento pCod, string pEstado )
        {
            List<Pedido> oAux = PersistenciaPedido.ListarPedidosXEstado(pCod, pEstado);

            return oAux;
        }

        public static List<Pedido> ListarTodosPedidos(Medicamento pCod)
        {
            List<Pedido> oAux = PersistenciaPedido.ListarTodosPedidos(pCod);

            return oAux;
        }

        public static Pedido Buscar(int oNumPedido)
        {
            Pedido p = PersistenciaPedido.Buscar(oNumPedido);
            return p;
        }

        public static List<Pedido> ListarPedidosGenerados(Cliente NomUsu)
        {
            return PersistenciaPedido.ListarPedidosGenerados(NomUsu);
        }

        public static void Eliminar(int numPed)
        {
            PersistenciaPedido.Eliminar(numPed);
        }

        public static void AgregarPedido(Pedido oPed)
        {
            PersistenciaPedido.Agregar(oPed);
        }

        public static void CambiarEstadoPedido(int numPed)
        {
            PersistenciaPedido.CambiarEstadoPedido(numPed);
        }

        public static List<Pedido> ListarPedidosGeneradosYEnviados()
        {
            return PersistenciaPedido.ListarPedidosGeneradosYEnviados();
        }

    }
}
