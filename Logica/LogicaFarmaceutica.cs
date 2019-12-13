using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaFarmaceutica
    {
        public static void Agregar (Farmaceutica pFarm)
        {
            PersistenciaFarmaceutica.Agregar((Farmaceutica)pFarm);

        }

        public static Farmaceutica Buscar (int pRUC)
        {
            Farmaceutica f = PersistenciaFarmaceutica.Buscar(pRUC);

            return f;
        }

        public static void Modificar (Farmaceutica pFarm)
        {
            PersistenciaFarmaceutica.Modificar((Farmaceutica)pFarm);

        }

        public static void Eliminar (Farmaceutica pFarm)
        {
            PersistenciaFarmaceutica.Eliminar(pFarm);

        }

        public static List<Farmaceutica> ListarFarmaceuticas()
        {
            return PersistenciaFarmaceutica.ListarFarmaceuticas();

        }


    }
}
