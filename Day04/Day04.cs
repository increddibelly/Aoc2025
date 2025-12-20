using Aoc2025.Utils;

namespace Aoc2025.Day04;

internal class Day04
{
    private const char Crate = '@';
    private const char EmptySpace = '_';

    private readonly CharMap Warehouse;

    public Day04(string input)
    {
        Warehouse = CharMap.Parse(input.Replace('.', EmptySpace));
        Warehouse.OutOfRangeValue = ' ';
    }

    public int Run(bool secondMethod = false)
    {
        var numberOfSurroundingCrates = Warehouse.RunForMap(CountSurroundingCrates);
        var cratesWithFewNeighbours = numberOfSurroundingCrates.RunForMap((x, y) => numberOfSurroundingCrates[x, y] > 0 && numberOfSurroundingCrates[x, y] < 4 ? numberOfSurroundingCrates[x, y].ToString() : "_");
        var numberOfAccessibleCrates = numberOfSurroundingCrates.CountWhen(cratesInArea => cratesInArea > 0 && cratesInArea < 4);

        return numberOfAccessibleCrates;
    }

    private int CountSurroundingCrates(int x, int y)
    {
        var theValue = Warehouse[x, y];
        if (theValue != Crate)
            return 0;

        var count = Warehouse.CountAdjacent(x, y, Crate);
        return count;
    }
}
