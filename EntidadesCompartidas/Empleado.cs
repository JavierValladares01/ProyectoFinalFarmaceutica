using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado : Usuario
    {

        private string horarioEntrada; 
        private string horarioSalida;


        public string HorarioEntrada
        {
            get { return horarioEntrada;}
            set { horarioEntrada = value; }
        }

        public string HorarioSalida
        {
            get { return horarioSalida; }
            set { horarioSalida = value; }
        }

        public Empleado (string pNomusu, string pPassusu, string pNombre, string pApellido, string pHorarioEntrada, string pHorarioSalida)
                    : base (pNomusu, pPassusu, pNombre, pApellido)
        {
            HorarioEntrada = pHorarioEntrada;
            HorarioSalida = pHorarioSalida;

        }


        // falta definir el ToString!!!

        public override string ToString()
        {
            return NomUsu;
        }
    }
}
