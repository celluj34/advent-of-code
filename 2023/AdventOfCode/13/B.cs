namespace AdventOfCode._13;

public class B
{
    public void Execute()
    {
        var total = GetMaps()
                    .Select(x =>
                    {
                        var originalTotal = GetMirrorValues(x).Single();

                        return GetSmudgedMaps(x).SelectMany(GetMirrorValues).Distinct().Where(z => z > 0).Single(z => z != originalTotal);
                    })
                    .Sum();
        
        Console.WriteLine(total);
    }

    private IEnumerable<List<string>> GetMaps()
    {
        var input = Input.Day13.Split(Environment.NewLine);
        var chunk = new List<string>();

        foreach (var line in input)
        {
            if (line is "")
            {
                yield return chunk;

                chunk = new List<string>();

                continue;
            }

            chunk.Add(line);
        }

        yield return chunk;
    }

    private IEnumerable<int> GetMirrorValues(List<string> map)
    {
        foreach (var indices in map.SelectMany(GetVerticalMirrorIndexes)
                                   .GroupBy(x => x,
                                       (x, y) => new
                                       {
                                           Index = x,
                                           Count = y.Count()
                                       })
                                   .Where(x => x.Count == map.Count)
                                   .Select(x => x.Index))
        {
            yield return indices;
        }

        foreach (var indices in ConvertRowsToColumns(map)
                                .SelectMany(GetHorizontalMirrorIndexes)
                                .GroupBy(x => x,
                                    (x, y) => new
                                    {
                                        Index = x,
                                        Count = y.Count()
                                    })
                                .Where(x => x.Count == map[0].Length)
                                .Select(x => x.Index))
        {
            yield return indices * 100;
        }
    }

    private IEnumerable<int> GetVerticalMirrorIndexes(string row)
    {
        for (var possibleMirrorIndex = 1; possibleMirrorIndex < row.Length; possibleMirrorIndex++)
        {
            var leftHalfLength = row.Length - possibleMirrorIndex;
            var leftHalf = row.Take(possibleMirrorIndex).Reverse().Take(leftHalfLength);
            var rightHalf = row.Skip(possibleMirrorIndex).Take(possibleMirrorIndex);

            if (leftHalf.SequenceEqual(rightHalf))
            {
                yield return possibleMirrorIndex;
            }
        }
    }

    private IEnumerable<string> ConvertRowsToColumns(IReadOnlyList<string> map)
    {
        var length = map[0].Length;
        for (var i = 0; i < length; i++)
        {
            yield return string.Join(string.Empty, map.Select(x => x[i]));
        }
    }

    private IEnumerable<int> GetHorizontalMirrorIndexes(string column)
    {
        for (var possibleMirrorIndex = 1; possibleMirrorIndex < column.Length; possibleMirrorIndex++)
        {
            var topHalfLength = column.Length - possibleMirrorIndex;
            var topHalf = column.Take(possibleMirrorIndex).Reverse().Take(topHalfLength);
            var bottomHalf = column.Skip(possibleMirrorIndex).Take(possibleMirrorIndex);

            if (topHalf.SequenceEqual(bottomHalf))
            {
                yield return possibleMirrorIndex;
            }
        }
    }

    private IEnumerable<List<string>> GetSmudgedMaps(List<string> list)
    {
        var newList = new List<string>(list);

        var rowCount = newList.Count;
        var columnCount = newList[0].Length;

        for (var i = 0; i < rowCount; i++)
        {
            var line = list[i];

            for (var j = 0; j < columnCount; j++)
            {
                newList[i] = line[..j] + (line[j] is '.' ? '#' : '.') + line[(j + 1)..];

                yield return newList;

                newList = new List<string>(list);
            }
        }
    }
}