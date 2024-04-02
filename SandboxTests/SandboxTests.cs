using Sandbox;

namespace SandboxTests;

public class SandboxTests
{
    [Test]
    public void PixelInPosition()
    {
        var sut = new Sandbox.Sandbox(50, 50);

        sut.AddSandPixel(10, 10);
        sut.GetPixel(10, 10).Should().Be(Pixel.Sand);
    }
    
    [Test]
    public void PixelNotInPosition()
    {
        var sut = new Sandbox.Sandbox(50, 50);

        sut.GetPixel(10, 11).Should().Be(Sandbox.Pixel.Empty);
    }

    [Test]
    public void SandPixelFalls()
    {
        var sut = new Sandbox.Sandbox(50, 50);
        sut.AddSandPixel(10, 10);
        sut.NextStep();
        sut.GetPixel(10, 10).Should().Be(Pixel.Empty);
        sut.GetPixel(10, 11).Should().Be(Pixel.Sand);
    }

    [Test]
    public void SandInFloorKeepsInFloor()
    {
        var sut = new Sandbox.Sandbox(50, 50);
        sut.AddSandPixel(10, 49);
        sut.NextStep();
        sut.GetPixel(10, 49).Should().Be(Pixel.Sand);
    }

    [Test]
    public void SandSlides()
    {
        var sut = new Sandbox.Sandbox(5, 5);
        sut.AddSandPixel(0, 3);
        sut.AddSandPixel(0, 4);
        sut.NextStep();
        sut.GetPixel(0, 3).Should().Be(Pixel.Empty);
        sut.GetPixel(1, 4).Should().Be(Pixel.Sand);
    }
    
    [Test]
    public void RockDoesNotMove()
    {
        var sut = new Sandbox.Sandbox(50, 50);
        sut.AddRockPixel(10, 10);
        sut.NextStep();
        sut.GetPixel(10, 10).Should().Be(Pixel.Rock);
    }
    
    [Test]
    public void SandSlidesOnRock()
    {
        var sut = new Sandbox.Sandbox(50, 50);
        sut.AddSandPixel(0, 10);
        sut.AddRockPixel(0, 11);
        sut.NextStep();
        sut.GetPixel(0, 10).Should().Be(Pixel.Empty);
        sut.GetPixel(1, 11).Should().Be(Pixel.Sand);
    }

    [Test]
    public void SandCantTraverseRockSideways()
    {
        var sut = new Sandbox.Sandbox(5, 5);
        sut.AddRockPixel(0, 4);
        sut.AddRockPixel(1, 3);
        sut.AddSandPixel(0, 3);
        sut.NextStep();
        sut.GetPixel(0, 3).Should().Be(Pixel.Sand);
        sut.GetPixel(1, 4).Should().Be(Pixel.Empty);
    }
}