using Raylib_cs;

namespace Sandbox;

public class Sandbox_View
{
    private readonly Sandbox sandbox;
    private readonly int resolution;

    public Sandbox_View(Sandbox sandbox, int resolution)
    {
        this.sandbox = sandbox;
        this.resolution = resolution;
    }
    
    public void Draw()
    {
        for (int i = 0; i < sandbox.Width; i++)
        {
            for (int j = 0; j < sandbox.Height; j++)
            {
                DrawPixel(i, j, GetColor(sandbox.GetPixel(i, j)));
            }
        }
    }

    private void DrawPixel(int x, int y, Color color)
    {
        x *= resolution;
        y *= resolution;
        Raylib.DrawRectangle(x, y, resolution, resolution, color);
    }

    private Color GetColor(Pixel pixel)
    {
        switch (pixel)
        {
            case Pixel.Sand:
                return Color.Gold;
            case Pixel.Empty:
                return Color.Gray;
            case Pixel.Rock:
                return Color.DarkGray;
        }
        return Color.Black;
    }
}