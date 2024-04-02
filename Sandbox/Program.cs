using Raylib_cs;
using static Raylib_cs.Raylib;

const int screenWidth = 200 * 10;
const int screenHeight = 100 * 10;

InitWindow(screenWidth, screenHeight, "Hello World");

var sandbox = new Sandbox.Sandbox(200, 100);
var view = new Sandbox.Sandbox_View(sandbox, 10);

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.RayWhite);

    var x = GetMouseX() / 10;
    var y = GetMouseY() / 10;
    if(IsMouseButtonDown(MouseButton.Left))
    {
        if(IsKeyDown(KeyboardKey.LeftShift))
            sandbox.AddRockPixel(x, y, 3);
        else 
            sandbox.AddSandPixel(x, y, 3);
    }

    if (IsMouseButtonDown(MouseButton.Right))
    {
        sandbox.RemovePixel(x, y, 3);
    }
    view.Draw();
    
    sandbox.NextStep();
    
    EndDrawing();
}

CloseWindow();