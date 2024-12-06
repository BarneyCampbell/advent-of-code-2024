
using AdventOfCode.Days;

public class Aoc
{
    static void Main(string[] args)
    {
        string? day = args?.FirstOrDefault();
        if (string.IsNullOrEmpty(day)) 
        {
            Console.WriteLine($"{day} is not a valid day");
            return;
        }

        string input;
        try
        {
            input = File.ReadAllText($"./data/day{day}.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file\n{ex.Message}");
            return;
        }

        IDay dayRunner = day switch
        {
            "1" => new Day1(input),
            "2" => new Day2(input),
            "3" => new Day3(input),
            "4" => new Day4(input),
            "6" => new Day6(input),
            _   => new Day1(input)
        };

        Console.WriteLine($"Running Day {day}");
        Console.WriteLine(dayRunner.Part1());
        Console.WriteLine(dayRunner.Part2());
    }
}