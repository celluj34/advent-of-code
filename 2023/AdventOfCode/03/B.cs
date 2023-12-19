namespace AdventOfCode._03;

public class B
{
    public void Execute()
    {
        var charArray = Input.Day3.Split(Environment.NewLine).Select(x => x.ToCharArray()).ToList();

        var total = 0;

        for (var row = 0; row < charArray.Count; row++)
        {
            var chars = charArray[row];

            for (var column = 0; column < chars.Length; column++)
            {
                if (chars[column] is not '*')
                {
                    continue;
                }

                var numbers = GetAdjacentNumbers(charArray, row, column).Distinct().ToList();

                if (numbers.Count == 2)
                {
                    total += numbers[0] * numbers[1];
                }
            }
        }

        Console.WriteLine(total);
    }

    private IEnumerable<int> GetAdjacentNumbers(List<char[]> charArray, int startingRow, int startingColumn)
    {
        for (var row = startingRow - 1; row <= startingRow + 1; row++)
        {
            for (var column = startingColumn - 1; column <= startingColumn + 1; column++)
            {
                var characters = charArray[row];

                if (0 <= row && row < charArray.Count && 0 <= column && column < characters.Length)
                {
                    var adjacentCharacter = characters[column];

                    if (char.IsDigit(adjacentCharacter))
                    {
                        yield return GetNumbersToTheLeftAndRight(characters, column);
                    }
                }
            }
        }
    }

    private int GetNumbersToTheLeftAndRight(char[] characters, int column)
    {
        var takeWhile = characters.Skip(column).TakeWhile(char.IsDigit);
        var concat = characters.Take(column).Reverse().TakeWhile(char.IsDigit).Reverse().Concat(takeWhile);

        return int.Parse(new string(concat.ToArray()));
    }
}