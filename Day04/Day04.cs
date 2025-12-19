using Aoc2025.Utils;

namespace Aoc2025.Day04;

internal class Day04
{
    private const char Crate = '@';
    private const char EmptySpace = '_';
    private const int NotACrate = 0;

    private readonly CharMap Warehouse;

    public Day04(string input)
    {
        Warehouse = CharMap.Parse(input.Replace('.', EmptySpace));
        Warehouse.OutOfRangeValue = ' ';
    }

    public int Run(bool secondMethod = false)
    {
        var result = Warehouse.RunForMap(CountCratesAroundCrate);
        var count = result.CountAll(val => val > 0 && val < 4);
        return count;
    }

    private int CountCratesAroundCrate(int x, int y, char theValue)
    {
        if (theValue != Crate)
            return NotACrate;

        var count = Warehouse.CountAdjacent(x, y, Crate);
        return count;
    }
}
