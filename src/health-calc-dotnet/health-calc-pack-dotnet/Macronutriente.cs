using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_calc_pack_dotnet
{
    public class Macronutriente : IMacronutriente
    {
        const int PROTEINA = 2;
        const int GORDURA_BULKING = 2;
        const int GORDURA = 1;
        const int CARBOIDRATO_BULKING_T1 = 4;
        const int CARBOIDRATO_BULKING_T2 = 7;
        const int CARBOIDRATO_CUTTING = 2;
        const int CARBOIDRATO_MAINTENANCE = 5;
        const int MIN_WEIGHT = 35;

        public MacroNutrienteModel Calc(SexoEnum sexo,
        double Height,
        double Weight,
        NivelAtividadeFisicaEnum NivelAtividadeFisica,
        ObjetivoFisicoEnum ObjetivoFisico)

        {
            if (!IsValidData(Weight))
                throw new Exception("Invalid Parameters!");


            int Proteinas = 0;
            int Carboidratos = 0;
            int Gorduras = 0;

            if (ObjetivoFisico == ObjetivoFisicoEnum.Cutting)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_CUTTING * (int)Weight;
                Gorduras = GORDURA * (int)Weight;
            }
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Bulking)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_BULKING_T1 * (int)Weight;
                Gorduras = GORDURA_BULKING * (int)Weight;
            }
            if (NivelAtividadeFisica == NivelAtividadeFisicaEnum.BastanteAtivo ||
                NivelAtividadeFisica == NivelAtividadeFisicaEnum.ExtremamenteAtivo)
            {
                Carboidratos = CARBOIDRATO_BULKING_T2 * (int)Weight;
            }
            else if (ObjetivoFisico == ObjetivoFisicoEnum.Maintenance)
            {
                Proteinas = PROTEINA * (int)Weight;
                Carboidratos = CARBOIDRATO_MAINTENANCE * (int)Weight;
                Gorduras = GORDURA * (int)Weight;
            }


            var Result = new MacroNutrienteModel()
            {
                Proteínas = Proteinas,
                Carboidratos = Carboidratos,
                Gorduras = Gorduras,
            };

            return Result;
        }
        public bool IsValidData(double Weight)
        {
            if (Weight <= MIN_WEIGHT)
                return false;
            return true;

        }
    }
}

