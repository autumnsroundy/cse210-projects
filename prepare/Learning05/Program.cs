using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of shapes
        Shape square = new Square("Red", 4);
        Shape rectangle = new Rectangle("Blue", 5, 10);
        Shape circle = new Circle("Green", 7);

        // Create a list to store shapes
        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        // Iterate through the list and display the color and area of each shape
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
