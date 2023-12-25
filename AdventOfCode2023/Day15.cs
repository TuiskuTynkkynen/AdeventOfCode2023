using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
    internal static class Day15
    {
        public static void Solve()
        {
            StreamReader reader = new("InputFiles\\AOC_input_2023-15.txt");
            Console.WriteLine("Day fifteen:\n");
            int result1 = Part1(ref reader);
            int result2 = Part2(ref reader);

            Console.WriteLine("Puzzle 1 = " + result1);
            Console.WriteLine("Puzzle 2 = " + result2);
        }

        private static int Part1(ref StreamReader reader)
        {
            List<string> input = reader.ReadToEnd().Split(',').ToList() ?? throw new Exception("Error reading input file");
            Regex comma = new(@",");
            int sum = 0;
            int multiplier = 17;
            int devider = 256;
            
            while (input.Any())
            {
                string foo = comma.Replace(input.Last(), string.Empty);
                input.RemoveAt(input.Count - 1);
                int result = 0;
                foreach(char c in foo) { 
                    result += c;
                    result *= multiplier;
                    result %= devider;
                }

                sum += result;
            }

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return sum;
        }

        private static int Part2(ref StreamReader reader)
        {
            string input = reader.ReadToEnd() ?? throw new Exception("Error reading input file");

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            return -1;
        }
    }
}
