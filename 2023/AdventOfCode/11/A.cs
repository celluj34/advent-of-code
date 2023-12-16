namespace AdventOfCode._11;

public class A
{
    public void Execute()
    {
        var input = GetInput();

        var galaxyCoordinates = input.SelectMany(GetCoordinates).ToList();

        var total = galaxyCoordinates.SelectMany(_ => galaxyCoordinates, (x, y) => new CoordinatePair(x, y))
                                     .Where(x => x.Left != x.Right)
                                     .Distinct()
                                     .GroupBy(x => x, (x, y) => y.Min(y => Math.Abs(x.Left.X - y.Right.X) + Math.Abs(x.Left.Y - y.Right.Y)))
                                     .Sum();

        Console.WriteLine(total);
    }

    private static List<string> GetInput()
    {
        var input = Input.Day11.Split(Environment.NewLine).ToList();

        var rowsToWiden = Enumerable.Range(0, input.Count).Where(x => input[x].All(z => z is '.')).Reverse().ToList();

        var columnsToWiden = Enumerable.Range(0, input[0].Length).Where(x => input.All(z => z[x] is '.')).Reverse().ToList();

        foreach (var row in rowsToWiden)
        {
            input.Insert(row, string.Join("", Enumerable.Repeat('.', input[0].Length)));
        }

        for (var index = 0; index < input.Count; ++index)
        {
            foreach (var column in columnsToWiden)
            {
                input[index] = input[index].Insert(column, ".");
            }
        }

        return input;
    }

    private IEnumerable<Coordinate> GetCoordinates(string s, int i)
    {
        for (var index = 0; index < s.Length; index++)
        {
            var character = s[index];
            if (character is '#')
            {
                yield return new Coordinate(index, i);
            }
        }
    }

    private record Coordinate(int X, int Y);

    private record CoordinatePair(Coordinate Left, Coordinate Right)
    {
        public virtual bool Equals(CoordinatePair? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return (Left == other.Left && Right == other.Right) || (Left == other.Right && Right == other.Left);
        }

        public override int GetHashCode()
        {
            return Math.Min(HashCode.Combine(Left, Right), HashCode.Combine(Right, Left));
        }
    }
}