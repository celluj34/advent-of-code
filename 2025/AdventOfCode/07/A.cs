namespace AdventOfCode._07;

public class A
{
    public void Execute()
    {
        long total = 0;
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

        for (var i = 1; i < lines.Count; i++)
        {
            var rowAbove = lines[i - 1];
            var row = lines[i];

            for (var j = 0; j < row.Count; j++)
            {
                if (row[j] is '^' && rowAbove[j] is '|')
                {
                    total++;
                }
            }
        }

        Console.WriteLine($"The total is: {total}");
    }
}