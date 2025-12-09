using System.Numerics;

namespace AdventOfCode._08;

public class B
{
    public void Execute()
    {
        var coordinates = Input.Day8.Split(Environment.NewLine)
                               .Select(line =>
                               {
                                   var list = line.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                  .Select(int.Parse)
                                                  .ToList();

                                   var (x, y, z) = (list[0], list[1], list[2]);

                                   return new Vector3(x, y, z);
                               })
                               .OrderBy(x => x.X)
                               .ThenBy(x => x.Y)
                               .ThenBy(x => x.Z)
                               .ToList();

        var coordinatesByDistance = coordinates.Join(coordinates, _ => true, _ => true, (from, to) => new Vector3Pair(from, to))
                                               .DistinctBy(x => x.GetHashCode())
                                               .Where(x => x.Distance != 0)
                                               .OrderBy(x => x.Distance)
                                               .ToList();

        var groupsOfCoordinates = new List<HashSet<Vector3>>();
        var lastFrom = Vector3.Zero;
        var lastTo = Vector3.Zero;

        foreach (var (from, to) in coordinatesByDistance)
        {
            var existingGroups = groupsOfCoordinates.Where(g => g.Contains(from) || g.Contains(to)).ToList();

            if (!existingGroups.Any())
            {
                groupsOfCoordinates.Add([
                    from,
                    to
                ]);
            }
            else if (existingGroups.Count is 1)
            {
                var existingGroup = existingGroups.Single();
                existingGroup.Add(from);
                existingGroup.Add(to);
            }
            else
            {
                var combinedGroup = new HashSet<Vector3>
                {
                    from,
                    to
                };

                foreach (var existingGroup in existingGroups)
                {
                    groupsOfCoordinates.Remove(existingGroup);

                    foreach (var coordinate in existingGroup)
                    {
                        combinedGroup.Add(coordinate);
                    }
                }

                groupsOfCoordinates.Add(combinedGroup);
            }

            if (groupsOfCoordinates.Count == 1 && groupsOfCoordinates[0].Count == coordinates.Count && lastFrom == Vector3.Zero && lastTo == Vector3.Zero)
            {
                lastFrom = from;
                lastTo = to;
            }
        }

        var total = lastTo.X * (double) lastFrom.X;

        Console.WriteLine($"The total is: {total}");
    }

    public readonly struct Vector3Pair : IEquatable<Vector3Pair>
    {
        private readonly int _hash;

        public Vector3Pair(Vector3 from, Vector3 to)
        {
            From = from;
            To = to;
            Distance = Vector3.Distance(from, to);

            var orderedPoints = new List<Vector3>
                {
                    From,
                    To
                }.OrderBy(x => Vector3.Distance(Vector3.Zero, x))
                 .ToList();

            _hash = HashCode.Combine(orderedPoints.First(), orderedPoints.Last());
        }

        public Vector3 From { get; }
        public Vector3 To { get; }
        public float Distance { get; }

        public override int GetHashCode()
        {
            return _hash;
        }

        public void Deconstruct(out Vector3 from, out Vector3 to)
        {
            from = From;
            to = To;
        }

        public bool Equals(Vector3Pair other)
        {
            return _hash == other._hash && From.Equals(other.From) && To.Equals(other.To) && Distance.Equals(other.Distance);
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector3Pair other && Equals(other);
        }
    }
}