// See https://aka.ms/new-console-template for more information
using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Enums;

Console.WriteLine("Entre com sua altura e peso para calcular seu IMC");

Console.Write("Altura: ");
var Height = Console.ReadLine();

Console.Write("Peso: ");
var Weight = Console.ReadLine();

Console.Write("Sexo: ");
var Sexo = Console.ReadLine();

IMC objIMC = new IMC();
Macronutriente objMacronutriente = new Macronutriente();

double Result = objIMC.Calc(double.Parse(Height),double.Parse(Weight));
String Category = objIMC.GetIMCCategory(Result);

Console.WriteLine("O resultado do seu IMC foi : " + Category);

var SexoEnum = (Sexo == "F") ? health_calc_pack_dotnet.Enums.SexoEnum.Feminino : health_calc_pack_dotnet.Enums.SexoEnum.Masculino;

var ResultMacroNutrienteModel = objMacronutriente.Calc(SexoEnum,
   double.Parse(Height),
   double.Parse(Weight),
   health_calc_pack_dotnet.Enums.NivelAtividadeFisicaEnum.Sedentario,
   health_calc_pack_dotnet.Enums.ObjetivoFisicoEnum.Cutting);

Console.WriteLine("Seu consumo de Macronutriente deve ser => " +
    $"Proteínas:  { ResultMacroNutrienteModel.Proteinas} gramas, " +
    $"Carboidratos: { ResultMacroNutrienteModel.Carboidratos} gramas, " +
    $"Gorduras:  { ResultMacroNutrienteModel.Gorduras} gramas");

Console.ReadKey();
