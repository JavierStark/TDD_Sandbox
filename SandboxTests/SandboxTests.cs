namespace SandboxTests;

public class SandboxTests
{
    [Test]
    public void PixelInPosition()
    {
        var sut = new Sandbox.Sandbox(50, 50);

        sut.SetPixel(10, 10);
        sut.GetPixel(10, 10).Should().BeTrue();
    }
}