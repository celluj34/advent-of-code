using AdventOfCode.Extensions;

namespace AdventOfCode._02;

public class A
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    public void Execute()
    {
        var total = Input.Day2.Split(Environment.NewLine)
                         .Select(line =>
                         {
                             var items = line.Split(": ");

                             var gameId = int.Parse(items[0].Split(" ")[1]);
                             var draws = items[1].Split("; ").Select(ConvertToDictionary).ToList();

                             return new
                             {
                                 gameId,
                                 draws
                             };
                         })
                         .Where(x => x.draws.All(y => y[Color.Red] <= MaxRed && y[Color.Green] <= MaxGreen && y[Color.Blue] <= MaxBlue))
                         .Sum(x => x.gameId);

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