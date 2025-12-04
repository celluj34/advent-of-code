namespace AdventOfCode._04;

public class B
{
    public void Execute()
    {
        var map = Input.Day4.Split(Environment.NewLine).Select(x => x.ToCharArray().ToList()).ToList();

        var reachableIndexes = 0;
        var foundNew = true;
        while (foundNew)
        {
            foundNew = false;

            for (var columnIndex = 0; columnIndex < map.Count; columnIndex++)
            {
                var column = map[columnIndex];

                for (var rowIndex = 0; rowIndex < column.Count; rowIndex++)
                {
                    var cell = column[rowIndex];

                    if (cell is not '@')
                    {
                        continue;
                    }

                    var localColumnIndex = columnIndex;

                    var reachableCellCount = new List<Direction>
                        {
                            Direction.UpLeft,
                            Direction.Up,
                            Direction.UpRight,
                            Direction.Right,
                            Direction.DownRight,
                            Direction.Down,
                            Direction.DownLeft,
                            Direction.Left
                        }.Where(x =>
                         {
                             if (localColumnIndex is 0 && x is Direction.UpLeft or Direction.Left or Direction.DownLeft)
                             {
                                 return false;
                             }

                             if (localColumnIndex == map.Count - 1 && x is Direction.UpRight or Direction.Right or Direction.DownRight)
                             {
                                 return false;
                             }

                             if (rowIndex is 0 && x is Direction.UpLeft or Direction.Up or Direction.UpRight)
                             {
                                 return false;
                             }

                             if (rowIndex == column.Count - 1 && x is Direction.DownLeft or Direction.Down or Direction.DownRight)
                             {
                                 return false;
                             }

                             return true;
                         })
                         .Select(reachableCell => IsCellReachable(reachableCell, map, columnIndex, rowIndex))
                         .Count(c => c is '@' or 'x');

                    if (reachableCellCount >= 4)
                    {
                        continue;
                    }

                    reachableIndexes++;
                    foundNew = true;
                    column[rowIndex] = 'x';
                }
            }

            foreach (var column in map)
            {
                for (var rowIndex = 0; rowIndex < column.Count; rowIndex++)
                {
                    if (column[rowIndex] is 'x')
                    {
                        column[rowIndex] = '.';
                    }
                }
            }
        }

        Console.WriteLine($"The total is: {reachableIndexes}");
    }

    private static char IsCellReachable(Direction reachableCell, List<List<char>> map, int columnIndex, int rowIndex)
    {
        return reachableCell switch
        {
            Direction.UpLeft => map[columnIndex - 1][rowIndex - 1],
            Direction.Up => map[columnIndex][rowIndex - 1],
            Direction.UpRight => map[columnIndex + 1][rowIndex - 1],
            Direction.Left => map[columnIndex - 1][rowIndex],
            Direction.Right => map[columnIndex + 1][rowIndex],
            Direction.DownLeft => map[columnIndex - 1][rowIndex + 1],
            Direction.Down => map[columnIndex][rowIndex + 1],
            Direction.DownRight => map[columnIndex + 1][rowIndex + 1],
            _ => '\0'
        };
    }

    private enum Direction
    {
        UpLeft,
        Up,
        UpRight,
        Left,
        Right,
        DownLeft,
        Down,
        DownRight
    }
}