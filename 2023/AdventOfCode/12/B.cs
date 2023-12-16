using AdventOfCode.Extensions;

namespace AdventOfCode._12;

public class B
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

    private record Map
    {
        public Map(string damagedMap, string contiguousRanges)
        {
            DamagedMap = string.Join("?", Enumerable.Repeat(damagedMap, 5));
            ContiguousRanges = contiguousRanges.Split(",").Select(int.Parse).Repeat(5).ToList();
        }

        private string DamagedMap { get; }
        private List<int> ContiguousRanges { get; }

        public IEnumerable<string> GetPotentialFixedMaps()
        {
            return GetAllPossibleMaps(DamagedMap);
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
                    if (MapFitsRange(map))
                    {
                        yield return map;
                    }

                    yield break;
                }

                var left = map[..index];
                var right = map[(index + 1)..];

                foreach (var possibleMap in GetAllPossibleMaps($"{left}.{right}"))
                {
                    if (MapFitsRange(possibleMap))
                    {
                        yield return possibleMap;
                    }
                }

                map = $"{left}#{right}";
            }
        }

        private bool MapFitsRange(string map)
        {
            var damagedRanges = map.Split(".").Select(x => x.Length).Where(x => x > 0).ToList();

            return damagedRanges.Count == ContiguousRanges.Count && damagedRanges.All((t, i) => t == ContiguousRanges[i]);
        }
    }
}