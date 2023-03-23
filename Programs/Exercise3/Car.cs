namespace ConsoleApp1.Exercise3;

public class Car
{
    private IEngine _engine;
    private ITireSystem _tireSystem;
    private ILights _lights;
    
    public bool OilDiode { get; private set; }
    public bool CoolantLevelDiode { get; private set; }
    public bool DpfDiode { get; private set; }
    public bool TirePressureDiode { get; private set; }
    public bool LightsDiode { get; private set; }

    public Car(IEngine engine, ITireSystem tireSystem, ILights lights)
    {
        _engine = engine;
        _tireSystem = tireSystem;
        _lights = lights;
        
        FrontDeskActive();
    }

    public void FrontDeskActive()
    {
        OilDiode = _engine.IsOilBelowMin();
        CoolantLevelDiode = _engine.IsCoolantBelowMin();
        DpfDiode = _engine.IsDpfFilterDirty();

        TirePressureDiode = !_tireSystem.EnoughPressure();
        LightsDiode = !_lights.FrontDayLightsWorking() || !_lights.RearStopLightWorking();
    }
}