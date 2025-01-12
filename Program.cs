using NanoGolf;
using Raylib_cs;
using System.Numerics;

var screenWidth = 1000;
var screenHeight = 1000;

Raylib.InitWindow(screenWidth, screenHeight, "NanoGolf");

var canvas = Raylib.LoadRenderTexture(screenWidth, screenHeight);

var course = Course.Default;

Raylib.BeginTextureMode(canvas);
Raylib.ClearBackground(Color.RayWhite);
course.Draw();
Raylib.EndTextureMode();

var bot = Raylib.LoadImage("Resources/Sprites/GreenBot.png");
var botTexture = Raylib.LoadTextureFromImage(bot);
Raylib.UnloadImage(bot);

Vector2? prevMousePos = null;

while (!Raylib.WindowShouldClose())
{
    var frameTime = Raylib.GetFrameTime();
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

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.RayWhite);

    Raylib.DrawTextureRec(canvas.Texture, new Rectangle(0, 0, canvas.Texture.Width, -canvas.Texture.Height), new Vector2(0, 0), Color.White);
    Raylib.DrawTextureEx(botTexture, course.Start, 0, 5, Color.White);

    Raylib.DrawFPS(0, 0);
    Raylib.EndDrawing();

    prevMousePos = mousePos;
}

Raylib.UnloadTexture(botTexture);
Raylib.UnloadRenderTexture(canvas);
Raylib.CloseWindow();