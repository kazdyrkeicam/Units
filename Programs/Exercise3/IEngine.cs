namespace ConsoleApp1.Exercise3;

public interface IEngine
{
    public bool IsOilBelowMin();
    public bool IsCoolantBelowMin();
    public bool IsDpfFilterDirty();
}