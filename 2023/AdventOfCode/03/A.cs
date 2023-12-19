using System.Text;

namespace AdventOfCode._03;

public class A
{
    public void Execute()
    {
        var charArray = Input.Day3.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToList();
        var numbers = new List<int>();

        for (var currentRow = 0; currentRow < charArray.Count; currentRow++)
        {
            var startColumn = 0;
            var chars = charArray[currentRow];
            var numberBuilder = new StringBuilder();

            for (var currentColumn = 0; currentColumn < chars.Length; currentColumn++)
            {
                var character = chars[currentColumn];

                if (char.IsDigit(character))
                {
                    if (numberBuilder.Length == 0)
                    {
                        startColumn = currentColumn;
                    }

                    numberBuilder.Append(character);
                }
                else
                {
                    if (numberBuilder.Length is 0)
                    {
                        continue;
                    }

                    if (IsAdjacentToSymbol(charArray, currentRow, startColumn, currentColumn - 1))
                    {
                        numbers.Add(int.Parse(numberBuilder.ToString()));
                    }

                    numberBuilder.Clear();
                }
            }

            if (numberBuilder.Length is 0)
            {
                continue;
            }

            if (IsAdjacentToSymbol(charArray, currentRow, startColumn, chars.Length))
            {
                numbers.Add(int.Parse(numberBuilder.ToString()));
            }

            numberBuilder.Clear();
        }

        Console.WriteLine(numbers.Sum());
    }

    private bool IsAdjacentToSymbol(IReadOnlyList<char[]> charArray, int row, int startColumn, int endingColumn)
    {
        return GetAdjacentSymbols(charArray, row, startColumn, endingColumn).Any(x => !char.IsDigit(x) && x is not '.');
    }

    private IEnumerable<char> GetAdjacentSymbols(IReadOnlyList<char[]> charArray, int startingRow, int startingColumn, int endingColumn)
    {
        for (var row = startingRow - 1; row <= startingRow + 1; row++)
        {
            for (var column = startingColumn - 1; column <= endingColumn + 1; column++)
            {
                if (0 <= row && row < charArray.Count && 0 <= column && column < charArray[row].Length)
                {
                    yield return charArray[row][column];
                }
            }
        }
    }
}