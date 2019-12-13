using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Medicamento
    {
        //atributos

        private int codigo;
        private Farmaceutica farm;
        private string nombreMed;
        private string descripcion;
        private double precio;

        //propiedades
        public int Codigo
        {
            set { codigo = value;}
            get { return codigo; }
        }


        public Farmaceutica Farm
        {
            get { return farm; }
            set { farm = value; }
        }

       
        public string NombreMed
        {
            set
            {
                if (value.Length <= 20)
                    nombreMed = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return nombreMed; }
        }

        public string Descripcion
        {
            set
            {
                if (value.Length <= 30)
                    descripcion = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return descripcion; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string RUCFarm
        {
            get { return Farm.RUC.ToString(); }
        }

        //constructor
        public Medicamento(int pCodigo, Farmaceutica pFarm, string pNombreMed, string pDescripcion, double pPrecio)
        {
            Codigo = pCodigo;
            Farm = pFarm;
            NombreMed = pNombreMed;
            Descripcion = pDescripcion;
            Precio = pPrecio;

        }

        //operaciones

      
            
     

    public override string ToString()
        {
            return codigo + " - " + Farm.ToString() + " - " + nombreMed + " - " + descripcion + " - " + precio;
        }


    }
}
