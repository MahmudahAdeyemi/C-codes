
using BasicCalculator;

namespace CalculatorTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        //Arrange
        var a = 12;
        var b = 4;
        var expectedResult = 3;
        var calculator = new Calculator();

        //Act
        var actualResult = calculator.Division(a,b);

        //Asert
        Assert.Equal(expectedResult,actualResult);


    }
}