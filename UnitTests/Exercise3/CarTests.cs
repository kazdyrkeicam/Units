using ConsoleApp1.Exercise3;

namespace TestProject1.Exercise3;

public class CarTests
{
    private Mock<IEngine> _eng;
    private Mock<ITireSystem> _tir;
    private Mock<ILights> _lig;
    private Car _car;
    
    [OneTimeSetUp]
    public void setup()
    {
        _eng = new Mock<IEngine>();
        _lig = new Mock<ILights>();
        _tir = new Mock<ITireSystem>();
        _car = new Car(_eng.Object, _tir.Object, _lig.Object);
    }
    
    [Test]
    public void OilPressure_IS_BelowMin()
    {
        _eng.Setup(e => e.IsOilBelowMin()).Returns(true);
        _car.FrontDeskActive();
        
        Assert.That(_car.OilDiode, Is.True);
    }
    
    [Test]
    public void OilPressure_IS_OnProperLevel()
    {
        _eng.Setup(e => e.IsOilBelowMin()).Returns(false);
        _car.FrontDeskActive();
        
        Assert.That(_car.OilDiode, Is.False);
    }
    
    [Test]
    public void FrontLight_IS_NotWorking()
    {
        _lig.Setup(l => l.FrontDayLightsWorking()).Returns(false);
        _car.FrontDeskActive();
        
        Assert.That(_car.LightsDiode, Is.True);
    }
    
    [Test]
    public void RearLight_IS_NotWorking()
    {
        _lig.Setup(l => l.RearStopLightWorking()).Returns(false);
        _car.FrontDeskActive();
        
        Assert.That(_car.LightsDiode, Is.True);
    }

    [Test]
    public void DpfFilter_IS_Dirty()
    {
        _eng.Setup(e => e.IsDpfFilterDirty()).Returns(true);
        _car.FrontDeskActive();
        
        Assert.That(_car.DpfDiode, Is.True);
    }
    
    [Test]
    public void DpfFilter_IS_NotDirty()
    {
        _eng.Setup(e => e.IsDpfFilterDirty()).Returns(false);
        _car.FrontDeskActive();
        
        Assert.That(_car.DpfDiode, Is.False);
    }
    
    [Test]
    public void Coolant_IS_OnProperLevel()
    {
        _eng.Setup(e => e.IsCoolantBelowMin()).Returns(false);
        _car.FrontDeskActive();
        
        Assert.That(_car.CoolantLevelDiode, Is.False);
    }
    
    [Test]
    public void MultipleFaults()
    {
        _eng.Setup(e => e.IsCoolantBelowMin()).Returns(true);
        _eng.Setup(e => e.IsDpfFilterDirty()).Returns(true);
        _tir.Setup(t => t.EnoughPressure()).Returns(false);
        _lig.Setup(l => l.FrontDayLightsWorking()).Returns(true);
        _lig.Setup(l => l.RearStopLightWorking()).Returns(true);
        _car.FrontDeskActive();
        
        Assert.Multiple(() =>
        {
            Assert.That(_car.OilDiode, Is.False);
            Assert.That(_car.CoolantLevelDiode, Is.True);
            Assert.That(_car.DpfDiode, Is.True);
            Assert.That(_car.TirePressureDiode, Is.True);
            Assert.That(_car.LightsDiode, Is.False);
        });
    }
}