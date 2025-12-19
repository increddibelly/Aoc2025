using System.Text;

namespace Aoc2025.Utils;

internal class Map<T>
{
    private readonly Dictionary<int, Dictionary<int, T>> _map = [];
    public int Width => _map.Count;
    public int Height => _map.Values.Max(row => row.Count);
    public T OutOfRangeValue = default!;

    public T this[int x, int y]
    {
        get
        {
            if (IsCoordinateInRange(x, y))
            {
                return _map[y][x];
            }
            return OutOfRangeValue;
        }
        set
        {
            if (IsCoordinateInRange(x, y))
            {
                _map[y][x] = value;
            }
            else
                throw new ArgumentException();
        }
    }

    private bool IsCoordinateInRange(int x, int y)
    {
        return
            x >= 0 && y >= 0 &&
            x < Width && y < Height;
    }

    public Map(int width, int height)
    {
        _map = [];

        for (var row = 0; row < height; row++)
        {
            _map.Add(row, []);
            for (var column = 0; column < width; column++)
            {
                _map[row][column] = default!;
            }
        }
    }

    protected void LoopAround(int centerX, int centerY, Action<T> action, bool excludeCenter = true)
    {
        var run = 0;
        for (var x = centerX - 1; x <= centerX + 1; x++)
        {
            for (var y = centerY - 1; y <= centerY + 1; y++)
            {
                if (excludeCenter && x == centerX && y == centerY)
                {
                    continue;
                }
                action(this[x, y]);
                run++;
            }
        }

        if (excludeCenter && run != 8) 
            throw new InvalidProgramException();
    }

    public int CountAdjacent(int x, int y, T needle)
    {
        var needlesFound = 0;
        
        LoopAround(x, y, valueAtPoint =>
        {
            if (valueAtPoint!.Equals(needle))
            {
                needlesFound++;
            }
        });

        return needlesFound;
    }

    public Map<TResult> RunForMap<TResult>(Func<int, int, T, TResult> action)
    {
        var output = new Map<TResult>(Width, Height);

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                output[x, y] = action(x, y, this[x, y]);
            }
        }
        return output;
    }

    public int CountAll(Func<T, bool> action)
    {
        var count = 0;
        var counted = RunForMap((x, y, theValue) =>
        {
            var result = action(theValue);
            if (result)
            {
                count++;
                return 'x';
            }
            return '_';
        });
        Console.WriteLine(counted.ToString());
        return count;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var row in _map)
        {
            foreach (var column in row.Value)
            {
                sb.Append(column.Value!.ToString());
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
