using NanoGolf;
using Raylib_cs;
using System.Numerics;
using Box2D.NET.Bindings;

var screenWidth = 1000;
var screenHeight = 1000;

Raylib.InitWindow(screenWidth, screenHeight, "NanoGolf");

var canvas = Raylib.LoadRenderTexture(screenWidth, screenHeight);

var course = Course.Default;

Raylib.BeginTextureMode(canvas);
Raylib.ClearBackground(Color.RayWhite);
course.Draw();
Raylib.EndTextureMode();

var bot = Bot.GreenBot;
bot.Init(course);

Vector2? prevMousePos = null;

var pause = false;

while (!Raylib.WindowShouldClose())
{
    B2

    if (!pause)
    {
        var frameTime = Raylib.GetFrameTime();
        bot.Move(frameTime);

        var mousePos = Raylib.GetMousePosition();
        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            Raylib.BeginTextureMode(canvas);
            if (prevMousePos != null)
            {
                Raylib.DrawLineEx(prevMousePos.Value, mousePos, 10, Color.Black);
            }
            Raylib.DrawCircleV(mousePos, 5, Color.Black);
            Raylib.EndTextureMode();
        }

        prevMousePos = mousePos;
    }

    if (Raylib.IsMouseButtonPressed(MouseButton.Right))
    {
        pause = !pause;
    }

    if (Raylib.IsKeyPressed(KeyboardKey.D))
    {
        Debug.ShowDebug = !Debug.ShowDebug;
    }

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.RayWhite);

    Raylib.DrawTextureRec(canvas.Texture, new Rectangle(0, 0, canvas.Texture.Width, -canvas.Texture.Height), new Vector2(0, 0), Color.White);
    bot.Draw();

    Raylib.DrawFPS(0, 0);
    Raylib.EndDrawing();
}

Raylib.UnloadTexture(bot.Texture);
Raylib.UnloadRenderTexture(canvas);
Raylib.CloseWindow();

public static class Debug
{
    public static bool ShowDebug = false;
}