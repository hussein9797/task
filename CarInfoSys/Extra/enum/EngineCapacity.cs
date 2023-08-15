using System;

public enum EngineCapacity
{
    FourCylinder,
    SixCylinder,
    EightCylinder,
    TenCylinder,
    TwelveCylinder
}

public static class EngineCapacityExtensions
{
    public static EngineCapacity ToEngineCapacity(this string value)
    {
        if (Enum.TryParse<EngineCapacity>(value, true, out var engineCapacity))
        {
            return engineCapacity;
        }
        else
        {
            return EngineCapacity.FourCylinder;
        }
    }
}


