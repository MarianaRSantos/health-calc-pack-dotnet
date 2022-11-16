using health_calc_pack_dotnet;
using System;
using Xunit;

namespace health_calc_test_xunit
{
    public class UnitTest1
    {
        [Fact]
        public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndex()
        {
            //Arrange
            var IMC = new IMC();
            var Height = 1.68;
            var Weight = 85;
            var Expected = 30.12;

            //Act
            var result = IMC.Calc(Height, Weight);

            ;            //Assert
            Assert.Equal(Expected, result);
        }

        [Fact]
        public void When_RequestIMCCalcWithValidData_ThenReturnIMCIndexWithRangeAssert()
        {
            //Arrange
            var IMC = new IMC();
            var Height = 1.68;
            var Weight = 85;
            var ExpectedMin = 30.10;
            var ExpectedMax = 30.14;
            //Act
            var result = IMC.Calc(Height, Weight);

            //Assert
            Assert.InRange(result, ExpectedMin, ExpectedMax);
        }

        //[fact]
        //public void when_requestimccalcwithvaliddata_thenresultNaN()
        //{
        //    arrange
        //    var imc = new imc();
        //    var height = 0.0;
        //    var weight = 0.0;
        //    var expected = double.nan;

        //    act
        //    var result = imc.calc(height, weight);

        //    assert
        //    assert.equal(expected, result);

        //}

        [Fact]
        public void when_requestimccalcwithvaliddata_ThenThrowException()
        {
            //arrange
            var Imc = new IMC();
            var height = 0.0;
            var weight = 0.0;
            var expected = double.NaN;

            //act & Assert
            Assert.Throws<Exception>(() => Imc.Calc(height, weight));
        }
        [Fact]
        public void When_RequestIMCCalcWithValidData_ThenThrowException()
        {
            //Arrange
            var IMC = new IMC();
            var Height = 0;
            var Weight = 85;


            //Act & Assrt
            Assert.Throws<Exception>(() => IMC.Calc(Height, Weight));

        }
            //[Fact]
            //public void When_RequestIMCCalcWithValidData_ThenReturnInfinity()
            //{
            //    //Arrange
            //    var IMC = new IMC();
            //    var Height = 0;
            //    var Weight = 85;
            //    var Expected = double.PositiveInfinity;

            //    //Act
            //    var Result = IMC.Calc(Height, Weight);


            //    //Assert           
            //    Assert.Equal(Expected, Result);

            //}
            //[Theory]
            //[InlineData(17.5, "Abaixo do peso")]
            //[InlineData(18.49, "Abaixo do peso")]
            //[InlineData(18.50, "Peso normal")]
            //[InlineData(24.99, "Peso normal")]
            //[InlineData(25, "Pré-obesidade")]
            //[InlineData(29.99, "Pré-obesidade")]
            //[InlineData(30, "Obesidade grau 1")]
            //[InlineData(34.99, "Obesidade grau 1")]
            //[InlineData(35, "Obesidade grau 2")]
            //[InlineData(39.99, "Obesidade grau 2")]
            //[InlineData(40, "Obesidade grau 3")]
            //[InlineData(45, "Obesidade grau 3")]
            public void When_RequestIMCCategory_ThenReturnCategory(double IMC, string ExpectedResult)
        {
            //Arrange
            var Imc = new IMC();


            //Act
            var Result = Imc.GetIMCCategory(IMC);

            //Assert
            Assert.Equal(ExpectedResult, Result);
        }
        [Theory]
        [InlineData(0, 1.68)]
        [InlineData(85, 0)]
        [InlineData(0,0)]
        
        public void When_InvalidData_ThenReturnValidationResultFalse(double Height, double Weight)
        {
            //Arrange
            var Imc = new IMC();
            var _Height = Height;
            var _Weight = Weight;



            //Act
            var Result = Imc.IsValidData(_Height, _Weight);

            //Assert
            Assert.False(Result);
        }
    }
}
