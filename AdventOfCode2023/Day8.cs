using System.Collections;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal static class Day8
    {
        public static void Solve()
        {
            StreamReader reader = new StreamReader("InputFiles\\AOC_input_2023-08.txt");
            int result1 = Part1(ref reader);
            int result2 = Part2(ref reader);

            Console.WriteLine("Day eight:\n");
            Console.WriteLine("Puzzle 1 = " + result1);
            Console.WriteLine("Puzzle 2 = " + result2);
        }

        private static int Part1(ref StreamReader reader)
        {
            string? input = reader.ReadLine();
            string directions = input;
            int directionCount = directions.Length;
            Regex capitals = new Regex(@"([A-Z]+)");
            Dictionary<string, (string left, string right)> instructions = new Dictionary<string, (string left, string right)>();
            string start = "AAA";
            string end = "ZZZ";

            input = reader.ReadLine();
            while (input != null)
            {
                MatchCollection matches = capitals.Matches(input);
                if (matches.Count > 0) { 
                    string key = matches[0].Value;
                    string left = matches[1].Value;
                    string right = matches[2].Value;
                    instructions.Add(key, (left, right));
                }
                input = reader.ReadLine();
            }

            string currentElement = start;
            int steps = 0;
            while (currentElement != end) {
                int directionIndex = steps % directionCount;
                instructions.TryGetValue(currentElement, out (string left, string right) instruction);

                if (directions[directionIndex] == 'L')
                {
                    currentElement = instruction.left;
                }
                else
                {
                    currentElement = instruction.right;
                }
                steps++;
            }

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return steps;
        }
        
        private static int Part2(ref StreamReader reader)
        {
            return -1;
        }

    }
}
