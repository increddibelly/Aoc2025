using NUnit.Framework;

namespace Aoc2025.Day03;

internal class Day03Test
{
    [Test]
    public void RunSample1() 
    {
        // arrange
        var day = new Day03(Day03Input.Sample);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 357);
    }

    [Test]
    public void RunActual1()
    {
        // arrange
        var day = new Day03(Day03Input.Actual);

        // act
        var result = day.Run();

        // assert
        Assert.That(result == 17193);
    }

    [Test]
    public void RunSample2()
    {
        // arrange
        var day = new Day03(Day03Input.Sample);

        // act
        var result = day.Run(false);

        // assert
        // The total output joltage is now much larger: 987654321111 + 811111111119 + 434234234278 + 888911112111 = 3121910778619.
        Assert.That(result == 3121910778619);
    }

    [Test]
    public void RunActual2()
    {
        // arrange
        var day = new Day03(Day03Input.Actual);

        // act
        var result = day.Run(false);

        // assert
        Assert.That(result == 171297349921310);
    }
}
