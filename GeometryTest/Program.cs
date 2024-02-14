using System;
using Geometry;

class Program
{
    static void Main()
    {
        Point point1 = new Point(2, 3);
        Console.WriteLine($"Point 1: {point1.X},{point1.Y}");
        Point point2 = new Point(5, 4);
        Console.WriteLine($"Point 2: {point2.X},{point2.Y}");

        point1.ReflectX();
        Console.WriteLine($"After reflecting X: {point1.X},{point1.Y}");
        point2.ReflectY();
        Console.WriteLine($"After reflecting Y: {point2.X},{point2.Y}");

        ColourfulPoint colorfulPoint = new ColourfulPoint(1, 1, PointColour.Red);
        Console.WriteLine($"Colorful Point: {colorfulPoint},{colorfulPoint.Colour}");
        colorfulPoint.ChangeColour(PointColour.Green);
        Console.WriteLine($"After changing colour to Green: {colorfulPoint},{colorfulPoint.Colour}");
        colorfulPoint.NextColour();
        Console.WriteLine($"After next colour: {colorfulPoint},{colorfulPoint.Colour}");
        colorfulPoint.Normalize();
        Console.WriteLine($"After normalization: {colorfulPoint},{colorfulPoint.Colour}");

        Point addedPoint = ColourfulPoint.Add(point1, point2);
        Console.WriteLine($"Added Point: {addedPoint.X},{addedPoint.Y}");
        colorfulPoint.Add(point1);
        Console.WriteLine($"After adding Point 1: {colorfulPoint},{colorfulPoint.Colour}");

        Console.WriteLine($"Is point1 on axis? {point1.IsOnAxis}");
        Console.WriteLine($"Is colorfulPoint on axis? {colorfulPoint.IsOnAxis}");
    }
}