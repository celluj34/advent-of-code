namespace AdventOfCode._03;

public class A
{
    public void Execute()
    {
        var power = Input.Day3.Split(Environment.NewLine).Select(x => x.Select(x => int.Parse(x.ToString())).ToList()).Select(items => GetMax(items)).Sum();

        Console.WriteLine($"The total is: {power}");
    }

    private static int GetMax(List<int> items)
    {
        var power = 0;

        for (var i = 0; i < items.Count - 1; i++)
        {
            var tensDigit = items[i];
            var onesDigit = items.Skip(i + 1).Max();

            var currentPower = tensDigit * 10 + onesDigit;

            power = Math.Max(power, currentPower);
        }

        return power;
    }
}