
    using Mindbox;
    using MindboxGeometry;
    using MindboxGeometry.Interfaces;

    string? input = null;
    do
    {
        try
        {
            Console.Clear();
            Console.WriteLine("1.Circle");
            Console.WriteLine("2.Triangle");
            input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    Output(ReadCircle());
                    break;
                case "2":
                    Output(ReadTriangle());
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured:{ex.Message}");
        }
        Console.WriteLine();
        Console.WriteLine("Press key to continue...");
        Console.ReadKey();
    } while (input == null || !input.Contains('q', StringComparison.InvariantCultureIgnoreCase));
    
    
    
     static void Output(IShape? shape)
        => Console.WriteLine(shape == null ? "Shape not provided" : Description.DescriptionProvider.GetInfo(shape));

     static Circle? ReadCircle()
        => TryReadDouble("Radius:", out var radius)
            ? Shape.CircleFromRadius(radius)
            : null;
    
    static Triangle? ReadTriangle()
        => TryReadDouble("First side:", out var firstSide)
        && TryReadDouble("Second side:", out var secondSide)
        && TryReadDouble("Third side:", out var thirdSide)
            ? Shape.TriangleFromSides(firstSide, secondSide, thirdSide)
            : null;

    static bool TryReadDouble(string prompt, out double value)
    {
        Console.WriteLine(prompt);
        var stringValue = Console.ReadLine();
        if (Double.TryParse(stringValue, out value))
            return true;
        Console.WriteLine("Wrong number");
        return false;
    }