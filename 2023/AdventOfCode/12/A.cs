using AdventOfCode.Extensions;

namespace AdventOfCode._12;

public class A
{
    public void Execute()
    {
        var total = Input.Day12.Split(Environment.NewLine)
                         .Select(x =>
                         {
                             var items = x.Split(" ");
                             return new Map(items[0], items[1]);
                         })
                         .SelectMany(x => x.GetPotentialFixedMaps())
                         .Count();

        Console.WriteLine(total);
    }

    private record Map(string damagedMap, string contiguousRanges)
    {
        public IEnumerable<string> GetPotentialFixedMaps()
        {
            var ranges = contiguousRanges.Split(",").Select(int.Parse).ToList();

            return GetAllPossibleMaps(damagedMap).Where(x => MapFitsRange(x, ranges));
        }

        private IEnumerable<string> GetAllPossibleMaps(string map)
        {
            while (true)
            {
                // get all possible combinations of string map with ? replaced with . or #
                // if there are no ? left, return the string
                // otherwise, replace the first ? with . and # and recurse

                var index = map.IndexOf('?');
                if (index < 0)
                {
                    yield return map;

                    yield break;
                }

                var left = map[..index];
                var right = map[(index + 1)..];

                foreach (var possibleMap in GetAllPossibleMaps($"{left}.{right}"))
                {
                    yield return possibleMap;
                }

                map = $"{left}#{right}";
            }
        }

        private bool MapFitsRange(string map, IReadOnlyList<int> ranges)
        {
            var damagedRanges = map.Split(".").Select(x => x.Length).Where(x => x > 0).ToList();

            return damagedRanges.Count == ranges.Count && damagedRanges.All((t, i) => t == ranges[i]);
        }
    }
}