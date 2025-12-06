namespace Aoc2025.Day02;

internal class Day02
{
    // you can find the invalid IDs by looking for any ID which is made only of some sequence of digits repeated twice.
    // So, 55 (5 twice), 6464 (64 twice), and 123123 (123 twice) would all be invalid IDs.
    public ValueRange[] IdRanges { get; }

    public Day02(string sample)
    {
        var inputRanges = sample.Split(',');
        IdRanges = inputRanges.Select(ValueRange.Parse).ToArray();
    }

    public long Run(bool simpleMethod = true)
    {
        var badIds = new List<long>();
        foreach (var range in IdRanges)
        {
            badIds.AddRange(range.Filter(simpleMethod ? IsInvalidId : IsMoreInvalidId));
        }
        return badIds.Sum();
    }

    private bool IsInvalidId(long id)
    {
        var idString = id.ToString();

        // a bad ID consists of two identical halves. odd lengths cannot be identical
        if (idString.Length % 2 == 1)
        {
            return false;
        }

        var secondHalf = idString.Substring(idString.Length / 2);
        if (idString.StartsWith(secondHalf))
        {
            return true;
        }

        return false;
    }

    private bool IsMoreInvalidId(long id)
    {
        var idString = id.ToString();
        var target = idString.Length / 2;
        
        // an ID is invalid if it is made only of some sequence of digits repeated at least twice.
        // So, 12341234 (1234 two times), 123123123 (123 three times), 1212121212 (12 five times),
        // and 1111111 (1 seven times) are all invalid IDs.
        for (var length = 1; length <= target; length++)
        {
            var pattern = idString.Substring(0, length);
            if (!ContainsOtherCharacters(idString, pattern))
            {
                return true; // found an ID that contains no other characters than the search pattern
            }
        }

        return false;

        static bool ContainsOtherCharacters(string input, string pattern)
        {
            var haystack = new string(input);
            return haystack.Replace(pattern, string.Empty).Length > 0;
        }
    }
}
