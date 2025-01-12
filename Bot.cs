using Raylib_cs;
using System.Numerics;

namespace NanoGolf;
public class Bot
{
    public Texture2D Texture;
    public Vector2 Position;
    public Vector2 Velocity;
    public float Scale;
    public float Width;
    public float Height;

    public Bot(Texture2D texture)
    {
        Texture = texture;
        Scale = 5;
        Width = texture.Width * Scale;
        Height = texture.Height * Scale;
    }

    public void Init(Course course)
    {
        Position = course.Start;
        Velocity = new Vector2(0, -90);
    }

    public void Move(float frameTime)
    {
        Position.X += Velocity.X * frameTime;
        Position.Y += Velocity.Y * frameTime;
    }

    public static Bot GreenBot => new Bot(GetTexture("GreenBot.png"));

    private static Texture2D GetTexture(string file)
    {
        var bot = Raylib.LoadImage("Resources/Sprites/" + file);
        var botTexture = Raylib.LoadTextureFromImage(bot);
        Raylib.UnloadImage(bot);

        return botTexture;
    }
}
