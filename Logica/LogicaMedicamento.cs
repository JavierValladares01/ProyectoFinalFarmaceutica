using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMedicamento
    {
        public static void Agregar(Medicamento pMed)
        {
            PersistenciaMedicamento.Agregar((Medicamento)pMed);

        }

        public static Medicamento Buscar(int pCod, Farmaceutica pRUC)
        {
            Medicamento m = PersistenciaMedicamento.Buscar(pCod, pRUC);

            return m;
        }

        public static void Modificar(Medicamento pMed)
        {
            PersistenciaMedicamento.Modificar((Medicamento)pMed);

        }

        public static void Eliminar(Medicamento pMed)
        {
            PersistenciaMedicamento.Eliminar(pMed);

        }

        public static List<Medicamento> ListarMedicamentosXFarmaceutica(Farmaceutica oRuc)
        {
            List<Medicamento> oAux = PersistenciaMedicamento.ListadoMedicamentosXFarmaceutica(oRuc);

            return oAux;
        }

        public static List<Medicamento> ListarMedicamentos()
        {
            return PersistenciaMedicamento.ListarMedicamentos();
        }

        public static List<Medicamento> ListarMedicamentoSeleccionado(int pCod, Farmaceutica pRUC)
        {
            return PersistenciaMedicamento.ListarMedicamentoSeleccionado(pCod, pRUC);
        }

    }
}
