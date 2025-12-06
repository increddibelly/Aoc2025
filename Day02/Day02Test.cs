using NUnit.Framework;

namespace Aoc2025.Day02;

internal class Day02Test
{
    [Test]
    public void RunSample1() 
    {
        // arrange
        var day = new Day02(Day02Input.Sample);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 1227775554);
    }

    [Test]
    public void RunActual1()
    {
        // arrange
        var day = new Day02(Day02Input.Actual);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 43952536386);
    }

    [Test]
    public void RunSample2()
    {
        // arrange
        var day = new Day02(Day02Input.Sample);

        // act
        var result = day.Run(false);

        // assert
        Assert.That(result == 4174379265);
    }

    [Test]
    public void RunActual2()
    {
        // arrange
        var day = new Day02(Day02Input.Actual);

        // act
        var result = day.Run(false);

        // assert
        Assert.That(result == 54486209192);
    }
}
