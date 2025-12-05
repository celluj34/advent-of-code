namespace AdventOfCode._05;

public class B
{
    public void Execute()
    {
        var lines = Input.Day5.Split(Environment.NewLine).ToList();

        var freshIngredientIdRanges = lines.TakeWhile(x => x != string.Empty)
                                           .Select(value =>
                                           {
                                               var parts = value.Split("-");
                                               var first = long.Parse(parts[0]);
                                               var last = long.Parse(parts[1]);

                                               return (min: first, max: last);
                                           })
                                           .OrderBy(x => x.min)
                                           .ThenBy(x => x.max)
                                           .ToList();

        var freshIngredientIds = new List<(long min, long max)>
        {
            freshIngredientIdRanges.First()
        };

        foreach (var (newMin, newMax) in freshIngredientIdRanges.Skip(1))
        {
            var (currentMin, currentMax) = freshIngredientIds.Last();

            if (IsAlreadyIncluded(currentMin, newMin, newMax, currentMax))
            {
                continue;
            }

            if (ShouldExtendCurrentRange(newMin, currentMax, newMax))
            {
                freshIngredientIds[^1] = (currentMin, newMax);
            }
            else
            {
                freshIngredientIds.Add((newMin, newMax));
            }
        }

        var freshIngredientIdCount = freshIngredientIds.Sum(x => x.max - x.min + 1);

        Console.WriteLine($"The total is: {freshIngredientIdCount}");
    }

    private static bool IsAlreadyIncluded(long currentMin, long newMin, long newMax, long currentMax)
    {
        return currentMin <= newMin && newMax <= currentMax;
    }

    private static bool ShouldExtendCurrentRange(long newMin, long currentMax, long newMax)
    {
        return newMin <= currentMax && currentMax < newMax;
    }
}