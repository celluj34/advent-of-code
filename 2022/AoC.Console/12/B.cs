namespace AoC.Console._12;

public class B
{
    private const string TestInput = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

    private const string Input = @"abaacccccccccccccaaaaaaaccccccccccccccccccccccccccccccccccaaaaaa
abaaccccccccccccccaaaaaaaaaaccccccccccccccccccccccccccccccccaaaa
abaaaaacccccccccaaaaaaaaaaaaccccccccccccccccccccccccccccccccaaaa
abaaaaaccccccccaaaaaaaaaaaaaacccccccccccccccccdcccccccccccccaaaa
abaaaccccccccccaaaaaaaaccacacccccccccccccccccdddcccccccccccaaaaa
abaaacccccccccaaaaaaaaaaccaaccccccccccccciiiiddddcccccccccccaccc
abcaaaccccccccaaaaaaaaaaaaaaccccccccccciiiiiijddddcccccccccccccc
abccaaccccccccaccaaaaaaaaaaaacccccccccciiiiiijjddddccccaaccccccc
abccccccccccccccaaacaaaaaaaaaaccccccciiiiippijjjddddccaaaccccccc
abccccccccccccccaacccccaaaaaaacccccciiiippppppjjjdddddaaaaaacccc
abccccccccccccccccccccaaaaaaccccccckiiippppppqqjjjdddeeeaaaacccc
abccccccccccccccccccccaaaaaaccccckkkiippppuupqqjjjjdeeeeeaaccccc
abccccccccccccccccccccccccaaccckkkkkkipppuuuuqqqjjjjjeeeeeaccccc
abccccccccccccccccccccccccccckkkkkkoppppuuuuuvqqqjjjjjkeeeeccccc
abcccccccccccccccccccccccccckkkkooooppppuuxuvvqqqqqqjkkkeeeecccc
abccaaccaccccccccccccccccccckkkoooooopuuuuxyvvvqqqqqqkkkkeeecccc
abccaaaaacccccaaccccccccccckkkoooouuuuuuuxxyyvvvvqqqqqkkkkeecccc
abcaaaaacccccaaaacccccccccckkkooouuuuxxxuxxyyvvvvvvvqqqkkkeeeccc
abcaaaaaaaaaaaaacccccccccccjjjooottuxxxxxxxyyyyyvvvvrrrkkkeecccc
abcccaaaacaaaaaaaaacaaccccccjjoootttxxxxxxxyyyyyyvvvrrkkkfffcccc
SbccaacccccaaaaaaaaaaaccccccjjjooottxxxxEzzzyyyyvvvrrrkkkfffcccc
abcccccccccaaaaaaaaaaaccccccjjjooootttxxxyyyyyvvvvrrrkkkfffccccc
abcaacccccaaaaaaaaaaaccccccccjjjooottttxxyyyyywwvrrrrkkkfffccccc
abaaacccccaaaaaaaaaaaaaacccccjjjjonnttxxyyyyyywwwrrlllkfffcccccc
abaaaaaaaaaaacaaaaaaaaaaccccccjjjnnnttxxyywwyyywwrrlllffffcccccc
abaaaaaaaaaaaaaaaaaaaaaaccccccjjjnntttxxwwwwwywwwrrlllfffccccccc
abaaccaaaaaaaaaaaaaaacccccccccjjjnntttxwwwsswwwwwrrlllfffccccccc
abaacccaaaaaaaacccaaacccccccccjjinnttttwwsssswwwsrrlllgffacccccc
abccccaaaaaaccccccaaaccccccccciiinnntttsssssssssssrlllggaacccccc
abccccaaaaaaaccccccccccaaccccciiinnntttsssmmssssssrlllggaacccccc
abccccaacaaaacccccccaacaaaccccciinnnnnnmmmmmmmsssslllgggaaaacccc
abccccccccaaacccccccaaaaacccccciiinnnnnmmmmmmmmmmllllgggaaaacccc
abaaaccccccccccccccccaaaaaacccciiiinnnmmmhhhmmmmmlllgggaaaaccccc
abaaaaacccccccccccaaaaaaaaaccccciiiiiiihhhhhhhhmmlgggggaaacccccc
abaaaaaccccaaccccaaaaaaacaacccccciiiiihhhhhhhhhhggggggcaaacccccc
abaaaaccccaaaccccaaaacaaaaacccccccciiihhaaaaahhhhggggccccccccccc
abaaaaaaacaaacccccaaaaaaaaaccccccccccccccaaaacccccccccccccccccaa
abaacaaaaaaaaaaaccaaaaaaaaccccccccccccccccaaaccccccccccccccccaaa
abcccccaaaaaaaaacccaaaaaaaccccccccccccccccaacccccccccccccccccaaa
abccccccaaaaaaaaaaaaaaaaacccccccccccccccccaaacccccccccccccaaaaaa
abcccccaaaaaaaaaaaaaaaaaaaaaccccccccccccccccccccccccccccccaaaaaa";

    public async Task Execute()
    {
        var startX = 20;
        var startY = 0;

        var bfs = new BFS(Input);
        var rounds = bfs.Search(startX, startY);

        System.Console.WriteLine(rounds);
    }

    private class BFS
    {
        private readonly char[][] _input;
        private readonly bool[,] _marked;

        public BFS(string input)
        {
            _input = input.Split(Environment.NewLine).Select(x => x.ToArray()).ToArray();
            _marked = new bool[Height, Width];
        }

        private int Height => _input.Length;
        private int Width => _input[0].Length;

        public int Search(int x, int y)
        {
            var queue = new Queue<(int x, int y)>();
            queue.Enqueue((x, y));
            _marked[x, y] = true;

            var rounds = 1;
            while (queue.Any())
            {
                var newQueue = new Queue<(int x, int y)>();

                foreach (var adjacent in queue)
                {
                    if (Complete(adjacent))
                    {
                        return rounds;
                    }

                    var t = GetAdjacentNodes(adjacent).Where(v => !_marked[v.x, v.y]).ToList();

                    foreach (var valueTuple in t)
                    {
                        _marked[valueTuple.x, valueTuple.y] = true;
                        newQueue.Enqueue(valueTuple);
                    }
                }

                queue = new Queue<(int x, int y)>(newQueue);

                ++rounds;
            }

            return -1;
        }

        private IEnumerable<(int x, int y)> GetAdjacentNodes((int x, int y) source)
        {
            var current = _input[source.x][source.y];

            return new List<(int x, int y)>
                {
                    (source.x, source.y - 1),
                    (source.x, source.y + 1),
                    (source.x - 1, source.y),
                    (source.x + 1, source.y)
                }.Where(node => node is { x: >= 0, y: >= 0 })
                 .Where(node => node.x < Height && node.y < Width)
                 .Where(node =>
                 {
                     try
                     {
                         var newNode = _input[node.x][node.y];

                         if ((current == 'S' && newNode == 'a') || (current == 'z' && newNode == 'E'))
                         {
                             return true;
                         }

                         var difference = newNode - current;

                         return difference <= 1;
                     }
                     catch (Exception e)
                     {
                         System.Console.WriteLine(e);
                         return false;
                     }
                 });
        }

        private bool Complete((int x, int y) target)
        {
            return _input[target.x][target.y] == 'E';
        }
    }
}