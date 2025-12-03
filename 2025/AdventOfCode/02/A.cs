namespace AdventOfCode._02;

public class A
{
    public void Execute()
    {
        var input = Input.Day2.Split(",")
                         .Select(x =>
                         {
                             var idPairs = x.Split("-");

                             var start = long.Parse(idPairs[0]);
                             var end = long.Parse(idPairs[1]);

                             return new
                             {
                                 Start = start,
                                 Count = end - start + 1
                             };
                         });

        var total = input.Sum(item =>
        {
            long sum = 0;
            for (var value = item.Start; value < item.Start + item.Count; value++)
            {
                var valueString = value.ToString();

                if (valueString.Length % 2 != 0)
                {
                    continue;
                }

                if (DigitRepeats(valueString))
                {
                    sum += value;
                }
            }

            return sum;
        });

        Console.WriteLine($"The total is: {total}");
    }

    private bool DigitRepeats(string value)
    {
        var valueLength = value.Length / 2;
        var lower = value.Take(valueLength);
        var upper = value.Skip(valueLength);

        return lower.SequenceEqual(upper);
    }
}