namespace AdventOfCode._01;

public class A
{
    private const string obstacle = "#";
    private const string visited = "X";
    private const string up = "^";
    private const string down = "v";
    private const string left = "<";
    private const string right = ">";

    public void Execute()
    {
        var map = Input.Day1.Split(Environment.NewLine).Select(line => line.Select(x => x.ToString()).ToArray()).ToArray();
        var direction = up;
        var row = Array.IndexOf(map, map.Single(x => x.Contains(direction)));
        var column = Array.IndexOf(map[row], direction);

        var rowMax = map.Length - 1;
        var colMax = map[0].Length - 1;

        while (true)
        {
            //Console.Clear();

            //foreach (var t in map)
            //{
            //    Console.Write(string.Join(string.Empty, t));
            //    Console.WriteLine();
            //}

            switch (direction)
            {
                case up:
                    if (row is 0)
                    {
                        map[row][column] = visited;
                        goto done;
                    }

                    if (map[row - 1][column] is obstacle)
                    {
                        direction = right;
                    }
                    else
                    {
                        map[row][column] = visited;
                        row--;
                        map[row][column] = direction;
                    }

                    break;

                case down:
                    if (row == rowMax)
                    {
                        map[row][column] = visited;
                        goto done;
                    }

                    if (map[row + 1][column] is obstacle)
                    {
                        direction = left;
                    }
                    else
                    {
                        map[row][column] = visited;
                        row++;
                        map[row][column] = direction;
                    }

                    break;

                case left:
                    if (column is 0)
                    {
                        map[row][column] = visited;
                        goto done;
                    }

                    if (map[row][column - 1] is obstacle)
                    {
                        direction = up;
                    }
                    else
                    {
                        map[row][column] = visited;
                        column--;
                        map[row][column] = direction;
                    }

                    break;

                case right:
                    if (column == colMax)
                    {
                        map[row][column] = visited;
                        goto done;
                    }

                    if (map[row][column + 1] is obstacle)
                    {
                        direction = down;
                    }
                    else
                    {
                        map[row][column] = visited;
                        column++;
                        map[row][column] = direction;
                    }

                    break;
            }
        }

        done:
        Console.WriteLine(map.SelectMany(x => x).Count(x => x == visited));
    }
}