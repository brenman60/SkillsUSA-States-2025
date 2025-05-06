// Contestant Id: CP1408

using System;

public abstract class Shape
{
    protected int length { get; private set; }

    public Shape(int length)
    {
        this.length = length;
    }

    public abstract void Draw();
}

public class RightTriangle_A : Shape
{
    public RightTriangle_A(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Draws a triangle, i denotes the length of the triangle's current step.
        for (int i = 0; i < length + 1; i++)
        {
            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}

public class RightTriangle_B : Shape
{
    public RightTriangle_B(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Backwards functionality of triangle A, from length to 0.
        for (int i = length; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}

public class RightTriangle_C : Shape
{
    public RightTriangle_C(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Same logic as triangle B, while adding spaces.
        for (int i = length; i > 0; i--)
        {
            for (int j = 0; j < length - i; j++)
                Console.Write(" ");

            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}

public class RightTriangle_D : Shape
{
    public RightTriangle_D(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Same logic as triangle A, while adding spaces.
        for (int i = 0; i < length + 1; i++)
        {
            for (int j = 0; j < length - i; j++)
                Console.Write(" ");

            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}

public class Diamond : Shape
{
    public Diamond(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Loop over the first half of the diamond, i denotes the number of asterisks.
        int startingAsterisks = length % 2 == 0 ? 2 : 1;
        for (int i = startingAsterisks; i < length + 1; i += 2)
        {
            // Derives the needed spaces from the current amount of asterisks.
            int spaceLength = (length - i) / 2;

            for (int j = 0; j < spaceLength; j++)
                Console.Write(" ");

            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }

        // Loop back over to the first half of the diamond, backwards but with the same logic.
        for (int i = length; i > 0; i -= 2)
        {
            int spaceLength = (length - i) / 2;

            for (int j = 0; j < spaceLength; j++)
                Console.Write(" ");

            for (int j = 0; j < i; j++)
                Console.Write("*");

            Console.WriteLine("");
        }
    }
}

public class Pyramid : Shape
{
    public Pyramid(int length) : base(length)
    {

    }

    public override void Draw()
    {
        // Keeps track of the character lengths, loop determines when it is finished.
        int asteriskLength = length % 2 == 0 ? 2 : 1;
        int spaceLength = (length - asteriskLength) / 2;
        do
        {
            for (int i = 0; i < spaceLength; i++)
                Console.Write(" ");

            for (int i = 0; i < asteriskLength; i++)
                Console.Write("*");

            asteriskLength += 2;
            spaceLength--;
            Console.WriteLine("");
        }
        while (asteriskLength < length + 2);
    }
}

public class DisplaySystem
{
    private Shape shape;

    public DisplaySystem(Shape shape)
    {
        this.shape = shape;
    }

    public void SetShape(Shape shape)
    {
        this.shape = shape;
    }

    public void DrawShape() => shape.Draw();
}

public class ShapeProgram
{
    public static void Main(string[] args)
    {
        int length = 10;

        // Initialize the DisplaySystem with a RightTriangle_A.
        DisplaySystem displaySystem = new DisplaySystem(new RightTriangle_A(length));
        displaySystem.DrawShape();

        SeperateShape();

        // Set and draw each individual shape.

        displaySystem.SetShape(new RightTriangle_B(length));
        displaySystem.DrawShape();

        SeperateShape();

        displaySystem.SetShape(new RightTriangle_C(length));
        displaySystem.DrawShape();

        SeperateShape();

        displaySystem.SetShape(new RightTriangle_D(length));
        displaySystem.DrawShape();

        SeperateShape();

        displaySystem.SetShape(new Diamond(length - 1));
        displaySystem.DrawShape();

        SeperateShape();

        displaySystem.SetShape(new Pyramid(length + 1));
        displaySystem.DrawShape();

        // Keeps the console window alive.
        Console.ReadLine();
    }

    public static void SeperateShape()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
    }
}
