using System;

public enum carType
{
    Sedan,
    SUV,
    Hatchback,
    Minivan,
    PickupTruck,
    SportsCar,
    Electric,
    Luxury,
    None
}

public static class CarTypeExtensions
{
    public static carType ToCarType(this string value)
    {
        if (Enum.TryParse<carType>(value, true, out var carType))
        {
            return carType;
        }
        else
        {
            return carType.None; 
        }
    }
}


