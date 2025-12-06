using NUnit.Framework;

namespace Aoc2025.Day01;

internal class Day01Test
{
    [Test]
    public void RunSample1() 
    {
        // arrange
        var day = new Day01(Day01Input.Sample);

        // act
        var result = day.Run();

        // assert
        Assert.That(day.CountZeroStops == 3);
        Assert.That(result == 32);
    }

    [Test]
    public void RunActual1()
    {
        // arrange
        var day = new Day01(Day01Input.Actual);

        // act
        var result = day.Run();

        // assert
        Assert.That(day.CountZeroStops == 1191); // 529, 250
        Assert.That(result == 52);
    }

    [Test]
    public void RunSample2()
    {
        // arrange
        var day = new Day01(Day01Input.Sample);

        // act
        var result = day.Run();

        // assert
        Assert.That(day.CountZeroCrossings == 6);
        Assert.That(result == 32);
    }

    [Test]
    public void RunActual2()
    {
        // arrange
        var day = new Day01(Day01Input.Actual);

        // act
        var result = day.Run();

        // assert
        Assert.That(day.CountZeroCrossings == 6858); // 7656, 6199, 5734
        Assert.That(result == 52);
    }
}
