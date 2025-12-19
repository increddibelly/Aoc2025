using System.Text;

namespace Aoc2025.Utils;

internal class CharMap : Map<char>
{
    public CharMap(int width, int height) 
        : base(width, height) { }

    public Map<char> Adjacent(int centerX, int centerY)
    {
        var submap = new StringBuilder();
        for (var x = centerX - 1; x < centerX + 1; x++)
        {
            for (var y = centerY - 1; y < centerY + 1; y++)
            {
                submap.Append(this[x, y]);
            }
            submap.AppendLine();
        }
        return Parse(submap.ToString());
    }

    public static CharMap Parse(string input)
    {
        var rows = input.Split(Environment.NewLine);
        var map = new CharMap(rows[0].Length, rows.Length);

        map.RunForMap((x, y, theValue) => map[x, y] = rows[y][x]);

        return map;
    }
}
