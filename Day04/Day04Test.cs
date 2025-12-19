using NUnit.Framework;

namespace Aoc2025.Day04;

internal class Day04Test
{
    [Test]
    public void RunSample1() 
    {
        // arrange
        var day = new Day04(Day04Input.Sample);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 13);
    }

    [Test]
    public void RunActual1()
    {
        // arrange
        var day = new Day04(Day04Input.Actual);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 1411); // 1411 too low
    }

    [Test]
    public void RunSample2()
    {
        // arrange
        var day = new Day04(Day04Input.Sample);

        // act
        var result = day.Run(false);

        // assert
        Assert.That(result == 1337);
    }

    [Test]
    public void RunActual2()
    {
        // arrange
        var day = new Day04(Day04Input.Actual);

        // act
        var result = day.Run(false);

        // assert
        Assert.That(result == 1337);
    }
}
