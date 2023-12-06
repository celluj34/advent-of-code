namespace AdventOfCode._01;

public class B
{
    private readonly Dictionary<string, int> _digits = new()
    {
        {
            "1", 1
        },
        {
            "2", 2
        },
        {
            "3", 3
        },
        {
            "4", 4
        },
        {
            "5", 5
        },
        {
            "6", 6
        },
        {
            "7", 7
        },
        {
            "8", 8
        },
        {
            "9", 9
        },
        {
            "one", 1
        },
        {
            "two", 2
        },
        {
            "three", 3
        },
        {
            "four", 4
        },
        {
            "five", 5
        },
        {
            "six", 6
        },
        {
            "seven", 7
        },
        {
            "eight", 8
        },
        {
            "nine", 9
        }
    };

    public async Task Execute()
    {
        var total = Input.Day1.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                         .Select(line =>
                         {
                             var keyValuePair = _digits.MinBy(x =>
                             {
                                 var indexOf = line.IndexOf(x.Key);
                                 return indexOf == -1 ? int.MaxValue : indexOf;
                             });

                             var firstInt = keyValuePair.Value;

                             var lastInt = _digits.MaxBy(x => line.LastIndexOf(x.Key)).Value;

                             return firstInt * 10 + lastInt;
                         })
                         .Sum();

        Console.WriteLine(total);
    }
}