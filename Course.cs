using Raylib_cs;
using System.Numerics;

namespace NanoGolf;
public class Course
{
    public Rectangle[] Walls;
    public Vector2 Start;
    public Vector2 Goal;

    public Course(Rectangle[] walls, Vector2 start, Vector2 goal)
    {
        Walls = walls;
        Start = start;
        Goal = goal;
    }

    public void Draw()
    {
        foreach (var wall in Walls)
        {
            Raylib.DrawRectangleRec(wall, Color.Blue);
        }

        Raylib.DrawCircleV(Start, 10, Color.Green);
        Raylib.DrawCircleV(Goal, 10, Color.Magenta);
    }

    public static Course Default => new Course([
        new Rectangle(200, 200, 600, 5),
        new Rectangle(800, 200, 5, 300),
        new Rectangle(500, 500, 305, 5),
        new Rectangle(500, 500, 5, 300),
        new Rectangle(200, 800, 305, 5),
        new Rectangle(200, 200, 5, 600)
    ], new Vector2(350, 700), new Vector2(700, 350));
}