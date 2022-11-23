using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;
using System;
using Xunit;

namespace health_calc_test_xunit
{
    public class MacroNutrienteTest
    {
        [Fact]
        public void When_RequestMacronutrientesCalcWithValidDataForCutting_ThenReturnResult()
        {
            //Arrange
            var MacronutrienteObj = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Cutting;
           

            var Expected = new MacroNutrienteModel()
            {
                Carboidratos = 170,
                Proteinas = 170,
                Gorduras = 85

            };

            ;//Act
            var result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Carboidratos, result.Carboidratos);
            Assert.Equal(Expected.Proteinas, result.Proteinas);
            Assert.Equal(Expected.Gorduras, result.Gorduras);   
                
        }

        [Theory]
        [InlineData(NivelAtividadeFisicaEnum.Sedentario, 340, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.ModeradamenteAtivo, 340, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 595, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 595, 170, 170, SexoEnum.Masculino)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 476, 136, 136, SexoEnum.Feminino)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 476, 136, 136, SexoEnum.Feminino)]
        public void When_RequestMacronutrientesCalcWithValidDataForBulking_ThenReturnResult(
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            double Carboidratos,
            double Proteinas,
            double Gorduras,
            SexoEnum Sexo)
        {
            //Arrange
            var MacronutrienteObj = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var ObjetivoFisico = ObjetivoFisicoEnum.Bulking;


            var Expected = new MacroNutrienteModel()
            {
                Carboidratos = Carboidratos,
                Proteinas = Proteinas,
                Gorduras = Gorduras

            };

            ;//Act
            var Result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Carboidratos, Result.Carboidratos);
            Assert.Equal(Expected.Proteinas, Result.Proteinas);
            Assert.Equal(Expected.Gorduras, Result.Gorduras);

        }
        [Fact]
        public void When_RequestMacronutrientesCalcWithValidDataForMaintenance_ThenReturnResult()
        {
            //Arrange
            var MacronutrienteObj = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Maintenance;


            var Expected = new MacroNutrienteModel()
            {
                Carboidratos = 425,
                Proteinas = 170,
                Gorduras = 85

            };

            //Act
            var result = MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico);

            //Assert
            Assert.Equal(Expected.Carboidratos, result.Carboidratos);
            Assert.Equal(Expected.Proteinas, result.Proteinas);
            Assert.Equal(Expected.Gorduras, result.Gorduras);

        }
        [Fact]
        public void When_RequestMacronutrientesCalcWithValidData_ThenThrowException()
        {
            //Arrange
            var MacronutrienteObj = new Macronutriente();
            var Height = 1.68;
            var Weight = 34;
            var Sexo = SexoEnum.Masculino;
            var NivelAtividadeFisica = NivelAtividadeFisicaEnum.Sedentario;
            var ObjetivoFisico = ObjetivoFisicoEnum.Maintenance;

            //Act & Assrt
            Assert.Throws<Exception>(() => MacronutrienteObj.Calc(
                Sexo,
                Height,
                Weight,
                NivelAtividadeFisica,
                ObjetivoFisico));
                     
                
        }
    }
}
