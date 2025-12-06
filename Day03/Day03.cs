using System.Text;

namespace Aoc2025.Day03;

internal class Day03
{
    List<string> BatteryBanks = [];

    public Day03(string input)
    {
        // 987654321111111 98
        // 811111111111119 89
        // 234234234234278 78
        // 818181911112111 92

        BatteryBanks = input.Split(Environment.NewLine).ToList();
    }

    public Int128 Run(bool simpleMethod = true)
    {
        if (!simpleMethod)
            return RunHard();

        var scores = BatteryBanks
            .Select(FindHigestJolt)
            .ToArray();

        return scores.Sum();
    }

    private Int128 RunHard()
    {
        var scores = BatteryBanks
            .Select(Find12HigestJolts)
            .ToArray();

        return scores.Sum();
    }

    private static long FindHigestJolt(string input)
    {
        var leading = FindHighestJoltFrom(input, 0, 1);
        var second = FindHighestJoltFrom(input, leading.Index + 1, 0);

        return long.Parse($"{leading.Value}{second.Value}");
    }

    private static long Find12HigestJolts(string input)
    {
        int index = -1;
        char value = '0';

        var number = new StringBuilder();

        for (var i = 0; i < 12; i++)
        {
            (index, value) = FindHighestJoltFrom(input, index + 1, 11-i);
            number.Append(value);
        }
        return long.Parse(number.ToString());
    }

    private static (int Index, char Value) FindHighestJoltFrom(string input, int startIndex, int endCutoff) 
    {
        // for the first decimal, we cannot use the last character. cut off the last character, we could end up with 90
        var removedFront = input.Substring(0, startIndex);
        var selection = input.Substring(startIndex, input.Length - startIndex - endCutoff);
        var maximum = selection.Length - 1;

        var highestPosition = startIndex;
        var highest = input[startIndex];

        for (var index = startIndex; index <= startIndex + maximum; index++)
        {
            if (highest == '9')
            {
                break; // no polong in finding anything higher than the maximum
            }
            if (input[index] > highest)
            {
                highest = input[index];
                highestPosition = index;
            }
        }

        return (highestPosition, highest); 
    }
}
