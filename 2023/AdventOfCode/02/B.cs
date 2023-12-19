using AdventOfCode.Extensions;

namespace AdventOfCode._02;

public class B
{
    public void Execute()
    {
        var total = Input.Day2.Split(Environment.NewLine)
                         .Select(line =>
                         {
                             var items = line.Split(": ");

                             var draws = items[1].Split("; ").Select(ConvertToDictionary).ToList();

                             var maxRed = draws.Max(x => x[Color.Red]);
                             var maxGreen = draws.Max(x => x[Color.Green]);
                             var maxBlue = draws.Max(x => x[Color.Blue]);
                             return maxRed * maxGreen * maxBlue;
                         })
                         .Sum();

        Console.WriteLine(total);
    }

    private static Dictionary<Color, int> ConvertToDictionary(string items)
    {
        var dictionary = items.Split(", ")
                              .Select(y =>
                              {
                                  var u = y.Split(" ");
                                  return new
                                  {
                                      Color = u[1].ToEnum<Color>(),
                                      Count = int.Parse(u[0])
                                  };
                              })
                              .ToDictionary(x => x.Color, y => y.Count);

        dictionary.TryAdd(Color.Red, 0);
        dictionary.TryAdd(Color.Green, 0);
        dictionary.TryAdd(Color.Blue, 0);

        return dictionary;
    }

    private enum Color
    {
        Red,
        Green,
        Blue
    }
}