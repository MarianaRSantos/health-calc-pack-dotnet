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
                Proteínas = 170,
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
            Assert.Equal(Expected.Proteínas, result.Proteínas);
            Assert.Equal(Expected.Gorduras, result.Gorduras);   
                
        }

        [Theory]
        [InlineData(NivelAtividadeFisicaEnum.Sedentario, 340)]
        [InlineData(NivelAtividadeFisicaEnum.ModeradamenteAtivo, 340)]
        [InlineData(NivelAtividadeFisicaEnum.BastanteAtivo, 595)]
        [InlineData(NivelAtividadeFisicaEnum.ExtremamenteAtivo, 595)]
        public void When_RequestMacronutrientesCalcWithValidDataForBulking_ThenReturnResult(
            NivelAtividadeFisicaEnum NivelAtividadeFisica,
            int Carboidratos)
        {
            //Arrange
            var MacronutrienteObj = new Macronutriente();
            var Height = 1.68;
            var Weight = 85;
            var Sexo = SexoEnum.Masculino;
            var ObjetivoFisico = ObjetivoFisicoEnum.Bulking;


            var Expected = new MacroNutrienteModel()
            {
                Carboidratos = Carboidratos,
                Proteínas = 170,
                Gorduras = 170

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
            Assert.Equal(Expected.Proteínas, result.Proteínas);
            Assert.Equal(Expected.Gorduras, result.Gorduras);

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
                Proteínas = 170,
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
            Assert.Equal(Expected.Proteínas, result.Proteínas);
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
