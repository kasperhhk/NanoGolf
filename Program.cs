using Raylib_cs;
using System.Numerics;

var screenWidth = 1000;
var screenHeight = 1000;

Raylib.InitWindow(screenWidth, screenHeight, "NanoGolf");

var target = Raylib.LoadRenderTexture(screenWidth, screenHeight);

Raylib.BeginTextureMode(target);
Raylib.ClearBackground(Color.RayWhite);
Raylib.EndTextureMode();

Vector2? prevMousePos = null;

while (!Raylib.WindowShouldClose())
{
    var frameTime = Raylib.GetFrameTime();
    var mousePos = Raylib.GetMousePosition();

    if (Raylib.IsMouseButtonDown(MouseButton.Left))
    {
        Raylib.BeginTextureMode(target);
        if (prevMousePos != null) 
        {
            Raylib.DrawLineEx(prevMousePos.Value, mousePos, 10, Color.Black);
        }
        Raylib.DrawCircleV(mousePos, 5, Color.Black);
        Raylib.EndTextureMode();
    }

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.RayWhite);

    Raylib.DrawTextureRec(target.Texture, new Rectangle(0, 0, target.Texture.Width, -target.Texture.Height), new Vector2(0, 0), Color.White);


    Raylib.DrawFPS(0, 0);
    Raylib.EndDrawing();

    prevMousePos = mousePos;
}

Raylib.UnloadRenderTexture(target);
Raylib.CloseWindow();