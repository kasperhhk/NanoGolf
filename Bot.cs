using Raylib_cs;
using System.Numerics;

namespace NanoGolf;
public class Bot
{
    public Texture2D Texture;
    public Vector2 Position;
    public float Speed;
    public float Rotation;
    public float Scale;
    public float Width;
    public float Height;

    public Rectangle FrontHitbox;
    public Rectangle BackHitbox;
    public float HitboxWidth;
    public float HitboxMargin;

    public Bot(Texture2D texture)
    {
        Texture = texture;
        Scale = 5;
        Rotation = 45;
        Width = texture.Width * Scale;
        Height = texture.Height * Scale;

        HitboxMargin = 3;
        HitboxWidth = Width - HitboxMargin * 2;
        FrontHitbox = new Rectangle(0, 0, HitboxWidth, HitboxWidth);
        BackHitbox = new Rectangle(0, 0, HitboxWidth, HitboxWidth);
    }

    public void Init(Course course)
    {
        Position = course.Start;
        Speed = 20;
        FrontHitbox.X = Position.X;
        FrontHitbox.Y = Position.Y;
        BackHitbox.X = Position.X;
        BackHitbox.Y = Position.Y;
    }

    public void Move(float frameTime)
    {
        var rotationRadians = float.DegreesToRadians(Rotation);
        var deltaX = Speed * MathF.Cos(rotationRadians) * frameTime;
        var deltaY = Speed * MathF.Sin(rotationRadians) * frameTime;
        Position.X += deltaX;
        Position.Y -= deltaY;
        Rotation += 90 * frameTime;

        FrontHitbox.X = Position.X;
        FrontHitbox.Y = Position.Y;

        var rot = Matrix3x2.CreateRotation(rotationRadians);

        var frontCenter = new Vector2(Position.X + Width / 2, Position.Y + Width / 2) - Position;        
        var frontRotated = Vector2.Transform(frontCenter, rot);
        var newFront = Position + frontRotated;
        FrontHitbox.X = newFront.X - HitboxWidth / 2;
        FrontHitbox.Y = newFront.Y - HitboxWidth / 2;

        var botLeft = new Vector2(Position.X, Position.Y + Height);
        var backCenter = new Vector2(botLeft.X + Width / 2, botLeft.Y - Width / 2) - Position;
        var backRotated = Vector2.Transform(backCenter, rot);
        var newBack = Position + backRotated;
        BackHitbox.X = newBack.X - HitboxWidth / 2;
        BackHitbox.Y = newBack.Y - HitboxWidth / 2;
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(Texture, Position, Rotation, Scale, Color.White);
        if (Debug.ShowDebug)
        {
            Raylib.DrawRectangleLinesEx(FrontHitbox, 3, Color.Red);
            Raylib.DrawRectangleLinesEx(BackHitbox, 3, Color.Red);
        }
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
