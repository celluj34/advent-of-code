namespace AdventOfCode._06;

public class A
{
    public void Execute()
    {
        long total = 0;
        var lines = Input.Day6.Split(Environment.NewLine)
                         .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                         .ToList();

        var terms = Enumerable.Range(0, lines[0].Length).Select(x => (terms: new List<long>(), @operator: string.Empty)).ToList();

        for (var i = 0; i < lines.Count; i++)
        {
            if (i == lines.Count - 1)
            {
                var items = lines[i];

                for (var j = 0; j < items.Length; j++)
                {
                    terms[j] = (terms[j].terms, items[j]);

                    switch (items[j])
                    {
                        case "*":
                            total += terms[j].terms.Product();
                            break;

                        case "+":
                            total += terms[j].terms.Sum();
                            break;
                    }
                }
            }
            else
            {
                var items = lines[i];

                for (var j = 0; j < items.Length; j++)
                {
                    var item = items[j];
                    terms[j].terms.Add(long.Parse(item));
                }
            }
        }

        Console.WriteLine($"The total is: {total}");
    }
}