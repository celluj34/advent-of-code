namespace AdventOfCode._05;

public class B
{
    public void Execute()
    {
        var (seeds, seedToSoil, soilToFertilizer, fertilizerToWater, waterToLight, lightToTemperature, temperatureToHumidity, humidityToLocation) =
            GetInputData();

        var min = seeds.GetSeedIds()
                       .AsParallel()
                       .Min(x =>
                       {
                           var soilId = seedToSoil.GetDestinationId(x);
                           var fertilizerId = soilToFertilizer.GetDestinationId(soilId);
                           var waterId = fertilizerToWater.GetDestinationId(fertilizerId);
                           var lightId = waterToLight.GetDestinationId(waterId);
                           var temperatureId = lightToTemperature.GetDestinationId(lightId);
                           var humidityId = temperatureToHumidity.GetDestinationId(temperatureId);
                           return humidityToLocation.GetDestinationId(humidityId);
                       });

        Console.WriteLine(min);
    }

    private static (FarmSeeds seeds, FarmMaps seedToSoil, FarmMaps soilToFertilizer, FarmMaps fertilizerToWater, FarmMaps waterToLight, FarmMaps
        lightToTemperature, FarmMaps temperatureToHumidity, FarmMaps humidityToLocation) GetInputData()
    {
        var seeds = new FarmSeeds();
        var seedToSoil = new FarmMaps();
        var soilToFertilizer = new FarmMaps();
        var fertilizerToWater = new FarmMaps();
        var waterToLight = new FarmMaps();
        var lightToTemperature = new FarmMaps();
        var temperatureToHumidity = new FarmMaps();
        var humidityToLocation = new FarmMaps();

        var state = 0;
        var skip = false;
        foreach (var line in Input.Day5.Split(Environment.NewLine))
        {
            if (line.Length == 0)
            {
                skip = true;
                ++state;
                continue;
            }

            if (skip)
            {
                skip = false;
                continue;
            }

            switch (state)
            {
                case 0:
                    seeds.Add(line);

                    continue;

                case 1:
                    seedToSoil.Add(line);
                    continue;

                case 2:
                    soilToFertilizer.Add(line);
                    continue;

                case 3:
                    fertilizerToWater.Add(line);
                    continue;

                case 4:
                    waterToLight.Add(line);
                    continue;

                case 5:
                    lightToTemperature.Add(line);
                    continue;

                case 6:
                    temperatureToHumidity.Add(line);
                    continue;

                case 7:
                    humidityToLocation.Add(line);
                    continue;
            }
        }

        return (seeds, seedToSoil, soilToFertilizer, fertilizerToWater, waterToLight, lightToTemperature, temperatureToHumidity, humidityToLocation);
    }

    private record FarmSeeds
    {
        private List<(long start, long end)> _seedIds = new();

        public void Add(string line)
        {
            _seedIds = line[(line.IndexOf(" ") + 1)..]
                       .Split(" ")
                       .Select(long.Parse)
                       .Chunk(2)
                       .Select(x => (start: x[0], end: x[0] + x[1] - 1))
                       .OrderBy(x => x.start)
                       .ToList();
        }

        public IEnumerable<long> GetSeedIds()
        {
            var ranges = new List<(long start, long end)>
            {
                _seedIds[0]
            };

            foreach (var (seedStart, seedEnd) in _seedIds.Skip(1))
            {
                var (rangeStart, rangeEnd) = ranges.Last();

                if (rangeStart <= seedStart && seedStart <= rangeEnd)
                {
                    ranges[^1] = (rangeStart, Math.Max(rangeEnd, seedEnd));
                }
                else
                {
                    ranges.Add((seedStart, seedEnd));
                }
            }

            foreach (var (start, end) in ranges)
            {
                for (var i = start; i <= end; ++i)
                {
                    yield return i;
                }
            }
        }
    }

    private record FarmMaps
    {
        private readonly List<FarmMap> _maps = new();

        public void Add(string line)
        {
            _maps.Add(new FarmMap(line));
        }

        public long GetDestinationId(long source)
        {
            foreach (var farmMap in _maps)
            {
                if (farmMap.TryMap(source, out var destination))
                {
                    return destination;
                }
            }

            return source;
        }
    }

    private record FarmMap
    {
        public FarmMap(string line)
        {
            var parsed = line.Split(" ").Select(long.Parse).ToList();

            DestinationStartIndex = parsed[0];
            SourceStartIndex = parsed[1];
            RangeLength = parsed[2];
        }

        private long DestinationStartIndex { get; }
        private long SourceStartIndex { get; }
        private long RangeLength { get; }

        public bool TryMap(long source, out long value)
        {
            if (SourceStartIndex <= source && source < SourceStartIndex + RangeLength)
            {
                value = DestinationStartIndex + (source - SourceStartIndex);
                return true;
            }

            value = -1;
            return false;
        }
    }
}