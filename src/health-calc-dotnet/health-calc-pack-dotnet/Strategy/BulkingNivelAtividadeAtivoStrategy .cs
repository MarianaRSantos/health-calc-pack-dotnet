using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy.Base;

namespace health_calc_pack_dotnet.Strategy
{
    public class BulkingNivelAtividadeAtivoStrategy : MacronutrienteBase, IMacronutrienteStrategy
    {
        const int PROTEINA = 2;
        const int GORDURA = 2;
        const int CARBOIDRATO = 7;

        public BulkingNivelAtividadeAtivoStrategy(SexoEnum Sexo) : base(Sexo)
        {
        }

        public MacroNutrienteModel Calc(double Weight){


            var Result = new MacroNutrienteModel()
            {
                Proteinas = PROTEINA * (int)Weight * GENDER_MULTIPLIER,
                Carboidratos = CARBOIDRATO * (int)Weight * GENDER_MULTIPLIER,
                Gorduras = GORDURA * (int)Weight * GENDER_MULTIPLIER
        };

            return Result;
        }
    }
    
}
