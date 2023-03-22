using ConsoleApp1;

namespace TestProject1.Exercise1;

public class SquareEquationTests
{
    [Test]
    public void Delta_GreaterThanZero()
    {
        // Given
        var se = new SquareEquation(2, 3, -1);
        
        // When
        var delta = se.Delta();
        var result = se.Results(delta);
        
        // Then
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(-5));
            Assert.That(result[1], Is.EqualTo(3.5));
        });
    }

    [Test]
    public void Delta_EqualsToZero()
    {
        // Given
        var se = new SquareEquation(1, 2, 1);
        
        // When
        var delta = se.Delta();
        var result = se.Results(delta);
        
        // Then
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.EqualTo(-1));
    }
    
    [Test]
    public void Delta_LessThanZero()
    {
        // Given
        var se = new SquareEquation(5, 3, 6);
        
        // When
        var delta = se.Delta();
        var result = se.Results(delta);
        
        // Then
        Assert.That(result, Is.Empty);
    }
}