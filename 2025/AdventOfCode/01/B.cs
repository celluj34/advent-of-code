namespace AdventOfCode._01;

public class B
{
    public void Execute()
    {
        var password = 0;
        var position = 50;
        var input = Input.Day1.Split(Environment.NewLine)
                         .Select(x =>
                         {
                             var value = int.Parse(x[1..]) * (x[0] == 'L' ? -1 : 1);

                             return new
                             {
                                 Value = value % 100,
                                 Excess = Math.Abs(value) / 100
                             };
                         });

        foreach (var item in input)
        {
            var previousPosition = position;
            position += item.Value;

            if (position == 0 || position == 100 || (position < 0 && 0 < previousPosition) || (previousPosition < 100 && 100 < position))
            {
                password++;
            }

            switch (position)
            {
                case < 0:
                    position += 100;
                    break;

                case >= 100:
                    position -= 100;
                    break;
            }

            password += item.Excess;
        }

        Console.WriteLine($"The password is: {password}");
    }
}