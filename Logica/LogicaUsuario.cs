using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
   public class LogicaUsuario
    {
        public static Usuario Logueo (string pNomUsu, string pPass)
        {
            Usuario unUsu = null;

            //verifico si es empleado
            unUsu = PersistenciaEmpleado.Logueo(pNomUsu, pPass);

            //verifico si es cliente

            if (unUsu == null)
            {
                unUsu = PersistenciaCliente.Logueo(pNomUsu, pPass);
            }               

            //luego retorna lo que encuentra
            return unUsu;
                        
        }

        public static Cliente BuscarCliente(string pNomUsu)
        {
            Cliente c = PersistenciaCliente.Buscar(pNomUsu);

            return c;
        }

        public static void AgregarCliente(Cliente unCli)
        {
            PersistenciaCliente.Agregar(unCli);
        }

        public static void AgregarEmpleado(Empleado unEmp)
        {
            PersistenciaEmpleado.Agregar(unEmp);
        }

        public static void ModificarEmpleado(Empleado unEmp)
        {
            PersistenciaEmpleado.Modificar(unEmp);
        }

        public static void EliminarEmpleado(string nomUsu)
        {
            PersistenciaEmpleado.Eliminar(nomUsu);
        }

        public static Empleado BuscarEmpleado(string nomUsu)
        {
            Empleado unEmp = PersistenciaEmpleado.Buscar(nomUsu);
            return unEmp;
        }


    }
}
