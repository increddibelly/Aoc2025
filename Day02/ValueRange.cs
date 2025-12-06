namespace Aoc2025.Day02;

internal class ValueRange
{
    public long Start { get; private set; }
    public long End { get; private set; }

    public static ValueRange Parse (string input)
    {
        var items = input.Split ('-');
        return new ValueRange
        {
            Start = long.Parse(items[0]),
            End = long.Parse(items[1])
        };
    }

    public IEnumerable<long> Filter(Func<long, bool> action)
    {
        for (var i = Start; i <= End; i++)
        {
            if (action(i))
            {
                yield return i;
            }
        }
    }
}