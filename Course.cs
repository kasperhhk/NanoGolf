using Raylib_cs;
using System.Numerics;

namespace NanoGolf;
public class Course
{
    public Vector2[] Shape;
    public Vector2 Start;
    public Vector2 Goal;

    public Course(Vector2[] shape, Vector2 start, Vector2 goal)
    {
        Shape = shape;
        Start = start;
        Goal = goal;
    }

    public void Draw()
    {
        for (var i = 1; i < Shape.Length; i++)
        {
            Raylib.DrawLineEx(Shape[i - 1], Shape[i], 5, Color.Blue);
            Raylib.DrawCircleV(Shape[i], 2.5f, Color.Blue);
        }

        Raylib.DrawCircleV(Start, 10, Color.Green);
        Raylib.DrawCircleV(Goal, 10, Color.Magenta);
    }

    public static Course Default => new Course([
        new Vector2(200, 200),
        new Vector2(800, 200),
        new Vector2(800, 500),
        new Vector2(500, 500),
        new Vector2(500, 800),
        new Vector2(200, 800),
        new Vector2(200, 200)
    ], new Vector2(350, 700), new Vector2(700, 350));
}