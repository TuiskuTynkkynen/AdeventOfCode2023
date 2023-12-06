using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal static class Day5
    {
        public static void Solve()
        {
            StreamReader reader = new StreamReader("InputFiles\\AOC_input_2023-05.txt");
            uint result1 = Part1(ref reader);
            //int result2 = Part2(ref reader);

            Console.WriteLine("Day two:\n");
            Console.WriteLine("Puzzle 1 = " + result1);
            //Console.WriteLine("Puzzle 2 = " + result2);
        }

        private static uint Part1(ref StreamReader reader)
        {
            string[] input = reader.ReadToEnd().Split(':');
            Regex numbers = new Regex(@"([0-9]+)");
            
            MatchCollection seedMatches = numbers.Matches(input[1]);
            int seedCount = seedMatches.Count;
            uint[][] seeds = new uint[2][];
            seeds[0] = new uint[seedCount];
            seeds[1] = new uint[seedCount];

            for (int i = 0; i < seedCount; i++)
            {
                seeds[0][i] = UInt32.Parse(seedMatches[i].Value);
                seeds[1][i] = 0;
            }
            
            for (int i = 2; i < input.Length; i++)
            {
                string[] maps = input[i].Split("\n");
                for(int j = 1; j < maps.Length; j++)
                {
                    MatchCollection mapMatches = numbers.Matches(maps[j]);
                    if (mapMatches.Count == 0)
                    {
                        continue;
                    }
                    uint destinationRangeStart = UInt32.Parse(mapMatches[0].Value);
                    uint sourceRangeStart = UInt32.Parse(mapMatches[1].Value);
                    uint rangeLength = UInt32.Parse(mapMatches[2].Value);
                    uint offset = destinationRangeStart - sourceRangeStart;

                    for (int k = 0; k < seedCount; k++)
                    {
                        if (seeds[1][k] != i && sourceRangeStart <= seeds[0][k] && sourceRangeStart + rangeLength > seeds[0][k])
                        {
                            seeds[0][k] += offset;
                            seeds[1][k] = (uint)i;
                        }
                    }
                }
            }

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return seeds[0].Min();
        }
    }
}
