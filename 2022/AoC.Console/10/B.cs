using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AoC.Console.Extensions;

namespace AoC.Console._10;

public class B
{
    private const string TempInput = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop
";

    private const string Input = @"noop
addx 22
addx -17
addx 1
addx 4
addx 17
addx -16
addx 4
addx 1
addx 21
addx -17
addx -10
noop
addx 17
addx -1
addx 5
addx -1
noop
addx 4
addx 1
noop
addx -37
addx 5
addx 27
addx -22
addx -2
addx 2
addx 5
addx 2
addx 5
noop
noop
addx -2
addx 5
addx 16
addx -11
addx -2
addx 2
addx 5
addx 2
addx -8
addx 9
addx -38
addx 5
addx 20
addx -16
addx 8
addx -5
addx 1
addx 4
noop
noop
addx 5
addx -2
noop
noop
addx 18
noop
addx -8
addx 2
addx 7
addx -2
noop
noop
noop
noop
noop
addx -35
noop
addx 32
addx -26
addx 12
addx -8
addx 3
noop
addx 2
addx 16
addx -24
addx 11
addx 3
addx -17
addx 17
addx 5
addx 2
addx -15
addx 22
addx 3
noop
addx -40
noop
addx 2
noop
addx 3
addx 13
addx -6
addx 10
addx -9
addx 2
addx 22
addx -15
addx 8
addx -7
addx 2
addx 5
addx 2
addx -32
addx 33
addx 2
addx 5
addx -39
addx -1
addx 3
addx 4
addx 1
addx 4
addx 21
addx -20
addx 2
addx 12
addx -4
noop
noop
noop
noop
noop
addx 4
noop
noop
noop
addx 6
addx -27
addx 31
noop
noop
noop
noop
noop
";

    public async Task Execute()
    {
        var pattern = new Regex("^(?<command>\\w+)( (?<parameter>-?\\d+))?$", RegexOptions.Compiled);

        var instructions = Input.Split(Environment.NewLine)
                                .Where(x => !string.IsNullOrEmpty(x))
                                .Select(x =>
                                {
                                    var match = pattern.Match(x);

                                    var parameter = match.Groups["parameter"];

                                    return new Instruction(match.Groups["command"].Value.ToEnum<Command>(), parameter.Success ? int.Parse(parameter.Value) : 0);
                                });

        var x = 1;
        var currentCycle = 0;

        var pixels = new List<char>();
        foreach (var instruction in instructions)
        {
            var wait = GetWait(instruction.Command);
            var pixelValue = new List<int>
            {
                x - 1,
                x,
                x + 1
            };

            for (var i = 0; i < wait; i++)
            {
                pixels.Add(pixelValue.Contains(currentCycle % 40) ? '#' : ' ');

                currentCycle++;
            }

            x += instruction.Value;
        }

        foreach (var scanLine in pixels.Chunk(40))
        {
            System.Console.WriteLine(scanLine);
        }
    }

    private int GetWait(Command direction)
    {
        return direction switch
        {
            Command.NoOp => 1,
            Command.AddX => 2,
            _ => throw new Exception("?")
        };
    }

    private enum Command
    {
        [Display(Name = "noop")]
        NoOp,

        [Display(Name = "addx")]
        AddX
    }

    private record Instruction(Command Command, int Value);
}