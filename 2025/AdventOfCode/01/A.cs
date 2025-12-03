namespace AdventOfCode._01;

public class A
{
    public void Execute()
    {
        var password = 0;
        var position = 50;
        var input = Input.Day1.Split(Environment.NewLine).Select(x => int.Parse(x[1..]) * (x[0] == 'L' ? -1 : 1));

        foreach (var value in input)
        {
            position += value;

            while (position < 0)
            {
                position += 100;
            }

            while (position >= 100)
            {
                position -= 100;
            }

            if (position == 0)
            {
                password++;
            }
        }

        Console.WriteLine($"The password is: {password}");
    }
}