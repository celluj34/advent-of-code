namespace AdventOfCode._02;

public class B
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
        var maxChunkLength = value.Length / 2;

        for (var chunkLength = 1; chunkLength <= maxChunkLength; chunkLength++)
        {
            if (value.Chunk(chunkLength).Select(x => new string(x)).Distinct().Count() == 1)
            {
                return true;
            }
        }

        return false;
    }
}