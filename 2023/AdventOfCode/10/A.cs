namespace AdventOfCode._10;

public class A
{
    public void Execute()
    {
        var (map, row, column) = GetMapAndStartingPosition();

        var depth = GetMaximumDepthUsingBFS(map, row, column);

        Console.WriteLine(depth);
    }

    private static (Direction[][] map, int row, int column) GetMapAndStartingPosition()
    {
        var map = Input.Day10.Split(Environment.NewLine).Select(x => x.Select(ConvertToDirection).ToArray()).ToArray();

        var startingPosition = map.SelectMany((x, row) => x.Select((y, column) => new
                                  {
                                      direction = y,
                                      row,
                                      column
                                  }))
                                  .Where(x => x.direction is Direction.Start)
                                  .Select(x => new
                                  {
                                      x.row,
                                      x.column
                                  })
                                  .Single();

        var directions = new Dictionary<Direction, Direction>
        {
            {
                Direction.East, map[startingPosition.row][startingPosition.column - 1]
            },
            {
                Direction.West, map[startingPosition.row][startingPosition.column + 1]
            },
            {
                Direction.South, map[startingPosition.row - 1][startingPosition.column]
            },
            {
                Direction.North, map[startingPosition.row + 1][startingPosition.column]
            }
        };

        var actualDirection = directions.Where(x => x.Value.HasFlag(x.Key))
                                        .Select(x => GetOpposite(x.Key))
                                        .Aggregate(Direction.None, (current, direction) => current | direction);

        map[startingPosition.row][startingPosition.column] = actualDirection;

        return (map, startingPosition.row, startingPosition.column);
    }

    private static Direction ConvertToDirection(char character)
    {
        return character switch
        {
            '|' => Direction.North | Direction.South,
            '-' => Direction.East | Direction.West,
            'L' => Direction.North | Direction.East,
            'J' => Direction.North | Direction.West,
            '7' => Direction.South | Direction.West,
            'F' => Direction.South | Direction.East,
            '.' => Direction.None,
            'S' => Direction.Start,
            _ => throw new ArgumentOutOfRangeException(character.ToString())
        };
    }

    private static Direction GetOpposite(Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    private int GetMaximumDepthUsingBFS(IReadOnlyList<Direction[]> map, int startingRow, int startingColumn)
    {
        var queue = new Queue<(int row, int column, int depth)>();
        queue.Enqueue((startingRow, startingColumn, 0));

        var visited = new HashSet<(int row, int column)>();

        var maxDepth = 0;

        while (queue.Count != 0)
        {
            var (row, column, depth) = queue.Dequeue();

            if (!visited.Add((row, column)))
            {
                continue;
            }

            var directions = map[row][column];

            if (directions.HasFlag(Direction.North))
            {
                queue.Enqueue((row - 1, column, depth + 1));
            }

            if (directions.HasFlag(Direction.South))
            {
                queue.Enqueue((row + 1, column, depth + 1));
            }

            if (directions.HasFlag(Direction.East))
            {
                queue.Enqueue((row, column + 1, depth + 1));
            }

            if (directions.HasFlag(Direction.West))
            {
                queue.Enqueue((row, column - 1, depth + 1));
            }

            maxDepth = Math.Max(maxDepth, depth);
        }

        return maxDepth;
    }

    [Flags]
    private enum Direction
    {
        None = 0,
        North = 1 << 0,
        South = 1 << 1,
        East = 1 << 2,
        West = 1 << 3,
        Start = 1 << 4
    }
}