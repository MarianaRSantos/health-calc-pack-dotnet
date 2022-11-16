// See https://aka.ms/new-console-template for more information
using health_calc_pack_dotnet;

Console.WriteLine("Entre com sua altura e peso para calcular seu IMC");

Console.Write("Altura: ");
var Height = Console.ReadLine();

Console.Write("Peso: ");
var Weight = Console.ReadLine();

IMC objIMC = new IMC();

double Result = objIMC.Calc(double.Parse(Height),double.Parse(Weight));
String Category = objIMC.GetIMCCategory(Result);

Console.WriteLine("O resultado do seu IMC foi : " + Category);

Console.ReadKey();
