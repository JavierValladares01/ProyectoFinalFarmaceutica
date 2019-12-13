using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pedido
    {

        //atributos

        private int numPedido;
        private Cliente cli; // de este objeto se extraera nombre usuario que realiza pedido
        private Medicamento codigo;//de este objeto se extraera codigo del medicamento que se ha pedido  
        private Farmaceutica ruc;
        private int cantidad;
        private string estado;

        //propiedades
        public int NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        public Cliente Cli
        {
            get { return cli; }
            set { cli = value; }

        }

        public Medicamento Codigo
        {
            get { return codigo; }
            set { codigo = value; }

        }

        public Farmaceutica RUC
        {
            get { return ruc; }
            set { ruc = value; }

        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }

        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }

        }

        //constructor
        public Pedido(int pNumPedido, Cliente pCli, Medicamento pCodigo, Farmaceutica pRUC, int pCantidad, string pEstado)
        {
            NumPedido = pNumPedido;
            Cli = pCli;
            Codigo = pCodigo;
            RUC = pRUC;
            Cantidad = pCantidad;
            Estado = pEstado;

        }

        public string NomUsu
        {
            get { return Cli.NomUsu; }
        }

        public string CodigoMed
        {
            get { return Codigo.Codigo.ToString(); }
        }

        public string RUCFarm
        {
            get { return RUC.RUC.ToString(); }
        }




        //operaciones

        public override string ToString()
        {
            return "El pedido Nro: " + numPedido + " se encuentra en estado: " + estado;
        }
        

    
    }
}
