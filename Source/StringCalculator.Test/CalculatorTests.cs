using System;
using Xunit;

namespace StringCalculator.Test
{
    public class CalculatorTests
    {
        private Calculator _sut = new Calculator();

        [Theory]
        [InlineData("",0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void Add_AddsUpTwoNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1,3,9", 13)]
        [InlineData("1,2", 3)]
        [InlineData("10,20,30", 60)]
        public void Add_AddsUpTwoAnyNumbers_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n3\n9", 13)]
        [InlineData("1\n2", 3)]
        public void Add_AddsUpNumbersUsingNewLineDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;\n3;\n9", 13)]
        [InlineData("//;\n1;\n2;\n4", 7)]
        public void Add_AddsNumbersUsingCustomDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,3,-9", "-9")]
        [InlineData("//;\n-1;\n-2;\n-4", "-1,-2,-4")]
        public void Add_ShouldThrowException_AddsWithNegativeNumbers(string calculation, string negatives)
        {
            //Arrange
            

            //Act
            Action action = () => _sut.Add(calculation);

            //Assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal($"Negative numbers not allowed: {negatives}", caughtException.Message);
        }

        [Theory]
        [InlineData("10,3000,5", 15)]
        [InlineData("5,12,1001", 17)]
        public void Add_ShouldNotAddIfOver1000_AddsLessThan1000Numbers(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***]\n1***3***9", 13)]
        [InlineData("//[***]\n1***3***4", 8)]
        public void Add_AddsNumbersUsingMultiDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[*][%]\n1*3%9", 13)]
        [InlineData("//[*][%]\n1*3%4", 8)]
        public void Add_AddsNumbersUsingMultipleDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***][-%]\n1***3-%9", 13)]
        [InlineData("//[***][-%]\n1***3-%4", 8)]
        public void Add_AddsNumbersUsingMultiLengthDelimiter_WhenStringIsValid(string calculation, int expected)
        {
            //Arrange

            //Act
            var result = _sut.Add(calculation);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
