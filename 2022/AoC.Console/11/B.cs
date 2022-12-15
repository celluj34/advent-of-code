using System.Numerics;
using System.Text.RegularExpressions;

namespace AoC.Console._11;

public class B
{
    private const string Input = @"Monkey 0:
  Starting items: 97, 81, 57, 57, 91, 61
  Operation: new = old * 7
  Test: divisible by 11
    If true: throw to monkey 5
    If false: throw to monkey 6

Monkey 1:
  Starting items: 88, 62, 68, 90
  Operation: new = old * 17
  Test: divisible by 19
    If true: throw to monkey 4
    If false: throw to monkey 2

Monkey 2:
  Starting items: 74, 87
  Operation: new = old + 2
  Test: divisible by 5
    If true: throw to monkey 7
    If false: throw to monkey 4

Monkey 3:
  Starting items: 53, 81, 60, 87, 90, 99, 75
  Operation: new = old + 1
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 1

Monkey 4:
  Starting items: 57
  Operation: new = old + 6
  Test: divisible by 13
    If true: throw to monkey 7
    If false: throw to monkey 0

Monkey 5:
  Starting items: 54, 84, 91, 55, 59, 72, 75, 70
  Operation: new = old * old
  Test: divisible by 7
    If true: throw to monkey 6
    If false: throw to monkey 3

Monkey 6:
  Starting items: 95, 79, 79, 68, 78
  Operation: new = old + 3
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 7:
  Starting items: 61, 97, 67
  Operation: new = old + 4
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 5
";

    public async Task Execute()
    {
        var monkeyIdPattern = new Regex("^Monkey (?<id>\\d+):$", RegexOptions.Compiled);
        var startingItemsPattern = new Regex("^Starting items: (?<items>.*)$", RegexOptions.Compiled);
        var operationPattern = new Regex("^Operation: new = old (?<operator>[+*]) (?<parameter>old|\\d+)$", RegexOptions.Compiled);
        var testPattern = new Regex("^Test: divisible by (?<divisor>\\d+)$", RegexOptions.Compiled);
        var trueActionPattern = new Regex("^If true: throw to monkey (?<id>\\d+)$", RegexOptions.Compiled);
        var falseActionPattern = new Regex("^If false: throw to monkey (?<id>\\d+)$", RegexOptions.Compiled);

        var monkeys = Input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                           .Select(x =>
                           {
                               var lines = x.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                               var monkeyId = int.Parse(monkeyIdPattern.Match(lines[0]).Groups["id"].Value);
                               var startingItems = startingItemsPattern.Match(lines[1])
                                                                       .Groups["items"]
                                                                       .Value.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                                       .Select(BigInteger.Parse)
                                                                       .ToList();

                               var match = operationPattern.Match(lines[2]);
                               var @operator = match.Groups["operator"].Value;
                               var parameter = match.Groups["parameter"].Value;

                               int? parameterValue;
                               if (int.TryParse(parameter, out var parameterIntValue))
                               {
                                   parameterValue = parameterIntValue;
                               }
                               else
                               {
                                   parameterValue = null;
                               }

                               var test = int.Parse(testPattern.Match(lines[3]).Groups["divisor"].Value);
                               var trueActionMonkey = int.Parse(trueActionPattern.Match(lines[4]).Groups["id"].Value);
                               var falseActionMonkey = int.Parse(falseActionPattern.Match(lines[5]).Groups["id"].Value);

                               return new Monkey(monkeyId, startingItems, @operator, parameterValue, test, trueActionMonkey, falseActionMonkey);
                           })
                           .ToArray();

        for (var i = 0; i < 10000; i++)
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    var newValue = DoMath(monkey, item);

                    var targetMonkey = newValue % monkey.Test == 0 ? monkey.TrueActionMonkey : monkey.FalseActionMonkey;

                    monkeys[targetMonkey].Items.Add(newValue);

                    monkey.ItemsInspected++;
                }

                monkey.Items.Clear();
            }
        }

        var monkeyBusiness = monkeys.Select(x => x.ItemsInspected).OrderByDescending(x => x).Take(2).ToArray();

        System.Console.WriteLine(monkeyBusiness[0] * monkeyBusiness[1]);
    }

    private BigInteger DoMath(Monkey monkey, BigInteger item)
    {
        var secondParam = monkey.Value ?? item;

        if (monkey.Operator == "+")
        {
            return item + secondParam;
        }

        return item * secondParam;
    }

    private record Monkey(int Id, List<BigInteger> Items, string Operator, int? Value, int Test, int TrueActionMonkey, int FalseActionMonkey)
    {
        public int ItemsInspected { get; set; }
    }
}