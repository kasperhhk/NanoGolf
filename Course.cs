using Raylib_cs;
using System.Numerics;

namespace NanoGolf;
public class Course
{
    public Vector2[] Shape;

    public Course(Vector2[] shape)
    {
        Shape = shape;
    }

    public void Draw()
    {
        for (var i = 1; i < Shape.Length; i++)
        {
            Raylib.DrawLineEx(Shape[i - 1], Shape[i], 5, Color.Blue);
            Raylib.DrawCircleV(Shape[i], 2.5f, Color.Blue);
        }
    }

    public static Course Default => new Course([
        new Vector2(200, 200),
        new Vector2(800, 200),
        new Vector2(800, 500),
        new Vector2(500, 500),
        new Vector2(500, 800),
        new Vector2(200, 800),
        new Vector2(200, 200)
    ]);
}