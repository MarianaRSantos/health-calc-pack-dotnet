
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Strategy
{
    public class MaintenanceStrategy : IMacronutrienteStrategy
    {
        const int PROTEINA = 2;
        const int GORDURA = 1;        
        const int CARBOIDRATO = 5;

        public MacroNutrienteModel Calc(double Weight) {

            var Result = new MacroNutrienteModel(){            

            Proteinas = PROTEINA * (int)Weight,
            Carboidratos = CARBOIDRATO * (int)Weight,
            Gorduras = GORDURA * (int)Weight
        

        };
            return Result;
    }
}
}
