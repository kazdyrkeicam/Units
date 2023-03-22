using ConsoleApp1;

namespace TestProject1.Exercise1;

public class TriangleTests
{
    [Test]
    public void simple()
    {
        // Given
        var t = new Triangle(10, 5, 7);
        
        // When
        var result = t.Area();
        
        // Then
        Assert.That(result, Is.EqualTo(16.25));
    }
    
    [Test]
    public void TriangleHasNotCreated()
    {
        // Given
        var e = Assert.Throws<Exception>(() =>
        {
            var t = new Triangle(20, 5, 7);
        });
        
        Assert.That(e.Message, Is.EqualTo("Cannot create triangle"));
    }
}