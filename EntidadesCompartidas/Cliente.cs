using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Cliente : Usuario
    {

        //atributos
        private int telefono;
        private string dirEntrega;


        //propiedades
        public string DirEntrega
        {
            set
            {
                if (value.Length <= 30)
                    dirEntrega = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return dirEntrega; }
        }

        public int Telefono
        {
            set
            {
                if ((value > 99999) && (value <= 999999999))
                    telefono = value;
                else
                    throw new Exception("Debe ingresar un numero de telefono valido!");
            }
            get { return telefono; }
        }


        //constructor
        public Cliente (string pNomusu, string pPassusu, string pNombre, string pApellido, string pDirEntrega, int pTelefono)
                : base (pNomusu, pPassusu, pNombre, pApellido)
        {
            DirEntrega = pDirEntrega;
            Telefono = pTelefono;
        }


        //operaciones

        public override string ToString()
        {
            return NomUsu;
        }



    }
}
