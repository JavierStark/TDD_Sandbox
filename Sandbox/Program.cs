// See https://aka.ms/new-console-template for more information

using Raylib_cs;
using static Raylib_cs.Raylib;

const int screenWidth = 800;
const int screenHeight = 450;

InitWindow(screenWidth, screenHeight, "Hello World");

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.RayWhite);
    
    

    DrawText("Congrats! You created your first window!", 190, 200, 20, Color.Maroon);

    EndDrawing();
}

CloseWindow();