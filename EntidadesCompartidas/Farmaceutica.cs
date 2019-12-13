using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Farmaceutica
    {
        //atributos

        private int ruc;
        private string nombreFarm;
        private string email;
        private string direccion;

        //propiedades

        public int RUC
        {
            set
            {
                if ((value > 99999) && (value <= 999999999))
                    ruc = value;
                else
                    throw new Exception("RUC no debe exceder los 8 caracteres!");
            }
            get { return ruc; }

        }

        public string NombreFarm
        {
            set
            {
                if (value.Length <= 20)
                    nombreFarm = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return nombreFarm; }

        }

        public string Email
        {
            set
            {
                if (value.Length <= 30)
                    email = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return email; }

        }

        public string Direccion
        {
            set
            {
                if (value.Length <= 30)
                    direccion = value;
                else
                    throw new Exception("Exceso de caracteres en el campo!");
            }
            get { return direccion; }

        }

        //constructor
        public Farmaceutica (int pRuc, string pNombreFarm, string pEmail, string pDireccion)
        {
            RUC = pRuc;
            NombreFarm = pNombreFarm;
            Email = pEmail;
            Direccion = pDireccion;
        }


        //operaciones
        public override string ToString()
        {
            return ruc + " - " + nombreFarm + " - " + email + " - " + direccion;
        }

    }
}
