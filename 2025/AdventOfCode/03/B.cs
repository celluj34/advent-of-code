namespace AdventOfCode._03;

public class B
{
    public void Execute()
    {
        var power = Input.Day3.Split(Environment.NewLine).Select(x => x.Select(y => int.Parse(y.ToString())).ToList()).Select(items => GetMax(items)).Sum();

        Console.WriteLine($"The total is: {power}");
    }

    private static long GetMax(List<int> items)
    {
        const int numbersToGet = 12;

        var indexes = new List<int>();

        for (var i = 0; i < numbersToGet; i++)
        {
            var itemsToSkip = indexes.Any() ? indexes.Last() + 1 : 0;
            var itemsToTake = items.Count - itemsToSkip - (numbersToGet - 1) + indexes.Count;
            var itemsAfterSkippedItems = items.Skip(itemsToSkip);
            var itemsToSearch = itemsAfterSkippedItems.Take(itemsToTake);
            var itemsToSearchList = itemsToSearch.ToList();
            var max = itemsToSearchList.Max();
            var indexOfMax = itemsToSearchList.IndexOf(max);

            indexes.Add(indexOfMax + itemsToSkip);
        }

        return long.Parse(indexes.Select(x => items[x]).Select(x => x.ToString()).Join(""));
    }
}