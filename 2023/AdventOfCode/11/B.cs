namespace AdventOfCode._11;

public class B
{
    public void Execute()
    {
        var galaxyCoordinates = GetCoordinates().ToList();

        var coordinatePairs = galaxyCoordinates.SelectMany(_ => galaxyCoordinates, (x, y) => new CoordinatePair(x, y))
                                               .Where(x => x.Left != x.Right)
                                               .Distinct()
                                               .ToList();

        var groupBy = coordinatePairs.GroupBy(x => x, (x, y) => (double)y.Min(y => Math.Abs(x.Left.X - y.Right.X) + Math.Abs(x.Left.Y - y.Right.Y)));

        var total = groupBy.Sum();

        Console.WriteLine(total);
    }

    private IEnumerable<Coordinate> GetCoordinates()
    {
        var input = Input.Day11.Split(Environment.NewLine).ToList();

        var rowsToWiden = Enumerable.Range(0, input.Count).Where(x => input[x].All(z => z is '.')).ToList();

        var columnsToWiden = Enumerable.Range(0, input[0].Length).Where(x => input.All(z => z[x] is '.')).ToList();

        for (var rowIndex = 0; rowIndex < input.Count; ++rowIndex)
        {
            var row = input[rowIndex];

            for (var columnIndex = 0; columnIndex < row.Length; ++columnIndex)
            {
                if (row[columnIndex] is '.')
                {
                    continue;
                }

                const int i1 = 1000000 - 1;
                var column = columnIndex + i1 * columnsToWiden.Count(x => x < columnIndex);
                var row2 = rowIndex + i1 * rowsToWiden.Count(x => x < rowIndex);

                yield return new Coordinate(column, row2);
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