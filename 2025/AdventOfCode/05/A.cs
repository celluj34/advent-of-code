namespace AdventOfCode._05;

public class A
{
    public void Execute()
    {
        var lines = Input.Day5.Split(Environment.NewLine).ToList();

        var freshIngredientIds = lines.TakeWhile(x => x != string.Empty)
                                      .Select(value =>
                                      {
                                          var parts = value.Split("-");
                                          var first = long.Parse(parts[0]);
                                          var last = long.Parse(parts[1]);

                                          return (min: first, max: last);
                                      })
                                      .OrderBy(x => x.min)
                                      .ThenBy(x => x.max)
                                      .ToList();

        var allIngredients = lines.Skip(freshIngredientIds.Count + 1).Select(long.Parse).ToList();

        var freshIngredients = allIngredients.Count(x => freshIngredientIds.Any(tuple => tuple.min <= x && x <= tuple.max));

        Console.WriteLine($"The total is: {freshIngredients}");
    }
}