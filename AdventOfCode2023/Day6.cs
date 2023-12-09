using System.Collections;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal static class Day6
    {
        public static void Solve()
        {
            StreamReader reader = new StreamReader("InputFiles\\AOC_input_2023-06.txt");
            int result1 = Part1(ref reader);
            int result2 = Part2(ref reader);

            Console.WriteLine("Day six:\n");
            Console.WriteLine("Puzzle 1 = " + result1);
            Console.WriteLine("Puzzle 2 = " + result2);
        }

        private static int Part1(ref StreamReader reader)
        {
            string[] input = reader.ReadToEnd().Split(':');
            Regex numbers = new Regex(@"([0-9]+)");
            List<int> times = numbers.Matches(input[1]).Select(item => Int32.Parse(item.Value)).ToList();
            List<int> recordDistances = numbers.Matches(input[2]).Select(item => Int32.Parse(item.Value)).ToList();
            
            int gameCount = recordDistances.Count;
            int[] wins = new int[gameCount];

            int margin = 1;
            for (int i = 0; i < gameCount; i++)
            {
                for (int speed =  0; speed < times[i]; speed++)
                {
                    int timeLeft = times[i] - speed;
                    int distance = timeLeft * speed;

                    if (distance > recordDistances[i])
                    {
                        wins[i]++;
                    }
                }
                margin *= wins[i];
            }


            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return margin;
        }

        private static int Part2(ref StreamReader reader)
        {
            string[] input = reader.ReadToEnd().Split(':');
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            Regex numbers = new Regex(@"([0-9]+)");
            return -1;
        }
    }
}
