using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public abstract class Usuario
    {
        //atributos
        private string nomusu;
        private string passusu;
        private string nombre;
        private string apellido;

        //propiedades 

        public string NomUsu
        {
            set
            {
                if (value.Length <= 20)
                    nomusu = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return nomusu; }

        }

        public string PassUsu
        {
            set
            {
                if (value.Length <= 20)
                    passusu = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return passusu; }

        }

        public string Nombre
        {
            set
            {
                if (value.Length <= 20)
                    nombre = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return nombre; }

        }

        public string Apellido
        {
            set
            {
                if (value.Length <= 20)
                    apellido = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return apellido; }

        }
        
        //constructor

        public Usuario (string pNomusu, string pPassusu, string pNombre, string pApellido)
        {
            NomUsu = pNomusu;
            PassUsu = pPassusu;
            Nombre = pNombre;
            Apellido = pApellido;

        }


        //operaciones

        public override string ToString()
        {
            return nomusu + " - " + nombre + " - " + apellido; 
        }


    }
}
