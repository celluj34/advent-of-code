namespace AdventOfCode._01;

public class A
{
    private readonly char[] _digits =
    {
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9'
    };

    public void Execute()
    {
        var total = Input.Day1.Split(Environment.NewLine)
                         .Select(line =>
                         {
                             var firstInt = line.IndexOfAny(_digits);
                             var lastInt = line.LastIndexOfAny(_digits);

                             return int.Parse(Convert.ToString(line[firstInt]) + Convert.ToString(line[lastInt]));
                         })
                         .Sum();

        Console.WriteLine(total);
    }
}