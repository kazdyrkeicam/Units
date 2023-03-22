using ConsoleApp1;

namespace TestProject1.Exercise1;

public class CalculatorTests
{
    [Test]
    public void SimpleAdd()
    {
        // Given
        var calc = new Calculator();
        var x = 12;
        var y = 150.2;
        
        // When
        var result = calc.Add(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(162.2));
    }
    
    [Test]
    public void Sub_positiveResult()
    {
        // Given
        var calc = new Calculator();
        var x = 150.4;
        var y = 150.2;
        
        // When
        var result = calc.Sub(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(.2));
    }
    
    [Test]
    public void Sub_negativeResult()
    {
        // Given
        var calc = new Calculator();
        var x = 50;
        var y = 150.2;
        
        // When
        var result = calc.Sub(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(-100.2));
    }
    
    [Test]
    public void SimpleMultiplication()
    {
        // Given
        var calc = new Calculator();
        var x = 5;
        var y = 3;
        
        // When
        var result = calc.Multiple(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void SimpleDivision()
    {
        // Given
        var calc = new Calculator();
        var x = 15;
        var y = 3;
        
        // When
        var result = calc.Divide(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(5));
    }
    
    [Test]
    public void Division_fractionalResult()
    {
        // Given
        var calc = new Calculator();
        var x = 3;
        var y = 5;
        
        // When
        var result = calc.Divide(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(0.6));
    }
    
    [Test]
    public void Division_overZero()
    {
        // Given
        var calc = new Calculator();
        var x = 15;
        var y = 0;
        
        // When
        var result = calc.Divide(x, y);
        
        // Then
        Assert.That(result, Is.EqualTo(double.PositiveInfinity));
    }
}