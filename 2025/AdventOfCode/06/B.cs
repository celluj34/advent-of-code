using System.Text;

namespace AdventOfCode._06;

public class B
{
    public void Execute()
    {
        long total = 0;
        var lines = Input.Day6.Split(Environment.NewLine).Select(x => x.Reverse().ToList()).ToList();

        var currentTerms = new List<long>();

        for (var columnIndex = 0; columnIndex < lines[0].Count; columnIndex++)
        {
            var str = new StringBuilder(lines.Count - 1);

            int rowIndex;
            for (rowIndex = 0; rowIndex < lines.Count - 1; rowIndex++)
            {
                str.Append(lines[rowIndex][columnIndex]);
            }

            if (long.TryParse(str.ToString().Trim(), out var t))
            {
                currentTerms.Add(t);
            }

            switch (lines[rowIndex][columnIndex])
            {
                case '*':
                    total += currentTerms.Product();
                    currentTerms.Clear();
                    break;

                case '+':
                    total += currentTerms.Sum();
                    currentTerms.Clear();
                    break;
            }
        }

        Console.WriteLine($"The total is: {total}");
    }
}