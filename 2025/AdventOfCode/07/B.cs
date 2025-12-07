namespace AdventOfCode._07;

public class B
{
    public void Execute()
    {
        var lines = Input.Day7.Split(Environment.NewLine).Select(x => x.ToList()).ToList();

        for (var i = 1; i < lines.Count; i++)
        {
            var rowAbove = lines[i - 1];
            var row = lines[i];

            for (var j = 0; j < row.Count; j++)
            {
                if (row[j] is '^')
                {
                    row[j - 1] = '|';
                    row[j + 1] = '|';
                }
                else if (rowAbove[j] is 'S' or '|')
                {
                    row[j] = '|';
                }
            }
        }

        var pathCounts = lines.Select(x => Enumerable.Repeat(0L, x.Count).ToList()).ToList();

        pathCounts[0][lines[0].IndexOf('S')] = 1;

        for (var i = 1; i < lines.Count; i++)
        {
            var rowAbove = lines[i - 1];
            var row = lines[i];

            var pathCountAbove = pathCounts[i - 1];
            var pathCount = pathCounts[i];

            for (var j = 0; j < row.Count; j++)
            {
                var l = pathCountAbove[j];
                pathCount[j] += l;

                if (row[j] is '^' && rowAbove[j] is '|')
                {
                    pathCount[j - 1] += l;
                    pathCount[j] = 0;
                    pathCount[j + 1] += l;
                }
            }
        }

        var total = pathCounts.Last().Sum();

        Console.WriteLine($"The total is: {total}");
    }
}