namespace Sandbox;

public partial class Sandbox
{
    private Pixel[,] pixels;
    private readonly int width;
    private readonly int height;
    public int Width => width;
    public int Height => height;
    public Sandbox(int width, int height)
    {
        this.width = width;
        this.height = height;
        pixels = new Pixel[width, height];
    }
    
    public void AddSandPixel(int x, int y)
    {
        AddPixel(x, y, Pixel.Sand);
    }

    public void AddSandPixel(int x, int y, int radius)
    {
        AddPixel(x, y, Pixel.Sand, radius);
    }
    
    public void AddRockPixel(int x, int y, int radius)
    {
        AddPixel(x, y, Pixel.Rock, radius);
    }
    
    public void AddRockPixel(int x, int y)
    {
        AddPixel(x, y, Pixel.Rock);
    }

    private void AddPixel(int x, int y, Pixel pixel)
    {
        if (InBounds(x, y) && GetPixel(x,y) == Pixel.Empty)
            pixels[x, y] = pixel;
    }

    private void AddPixel(int x, int y, Pixel pixel, int radius)
    {
        for(int i = -radius; i <= radius; i++)
        {
            for(int j = -radius; j <= radius; j++)
            {
                AddPixel(x + i, y + j, pixel);
            }
        }
    }
    
    public void RemovePixel(int x, int y, int radius)
    {
        for(int i = -radius; i <= radius; i++)
        {
            for(int j = -radius; j <= radius; j++)
            {
                RemovePixel(x + i, y + j);
            }
        }
    }

    private void RemovePixel(int x, int y)
    {
        if (InBounds(x, y))
            pixels[x, y] = Pixel.Empty;
    }

    public Pixel GetPixel(int x, int y)
    {
        return pixels[x,y];
    }
    
    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

    public void NextStep()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                switch(pixels[i,j])
                {
                    case Pixel.Sand:
                        SandStep(i, j);
                        break;
                    case Pixel.Rock:
                        break;
                    default:
                        break;
                }
            }
        }
        
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(pixels[i,j] == Pixel.ToSand)
                {
                    pixels[i,j] = Pixel.Sand;
                }
            }
        }
    }

    private void SandStep(int x, int y)
    {
        if(PixelCanFall(x, y))
        {
            pixels[x,y] = Pixel.Empty;
            pixels[x,y+1] = Pixel.ToSand;
        }
        else
        {
            var slide = PixelCanSlide(x, y);
            if(slide != 0)
            {
                pixels[x,y] = Pixel.Empty;
                pixels[x+slide,y+1] = Pixel.ToSand;
            }
        }
    }

    private bool PixelCanFall(int i, int j)
    {
        return InBounds(i, j + 1) && pixels[i,j+1] == Pixel.Empty;
    }

    private int PixelCanSlide(int i, int j)
    {
        bool mandatory = InBounds(i, j + 1) && IsHard(i,j+1);
        bool left = InBounds(i - 1, j + 1) && pixels[i - 1, j + 1] == Pixel.Empty && !IsHard(i - 1, j);
        bool right = InBounds(i + 1, j + 1) && pixels[i + 1, j + 1] == Pixel.Empty && !IsHard(i + 1, j);

        if (!mandatory)
            return 0;
        if (left && right)
        {
            var r = new Random();
            return r.Next(2) == 0 ? -1 : 1;
        }
        if (left)
            return -1;
        if (right)
            return 1;
        return 0;
    }

    public bool IsHard(int x, int y)
    {
        return GetPixel(x,y) == Pixel.Rock || GetPixel(x,y) == Pixel.Sand;
    }
}
