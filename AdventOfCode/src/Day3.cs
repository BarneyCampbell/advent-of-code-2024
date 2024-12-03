namespace AdventOfCode.Days;

using System.Text.RegularExpressions;
using AdventOfCode.Functional;
using Microsoft.FSharp.Core.CompilerServices;

public partial class Day3(string _input) : IDay
{
    public string Input { get; } = _input;

    [GeneratedRegex(@"mul\((?<num1>\d+),(?<num2>\d+)\)")]
    private static partial Regex NumsRegex();

    [GeneratedRegex(@"(don't\(\))|(do\(\))")]
    private static partial Regex DoDontRegex();


    public static int GetScoreForGroup(string group)
    {
        Regex rgx = NumsRegex();
        MatchCollection mulMatches = rgx.Matches(group);

        return mulMatches.Select(match => {
            GroupCollection groups = match.Groups;
            int num1 = int.Parse(groups["num1"].Value);
            int num2 = int.Parse(groups["num2"].Value);

            return num1 * num2;
        })
        .Sum();
    }

    public string Part1()
    {
        return GetScoreForGroup(Input).ToString();
    }

    public string Part2()
    {
        Regex dos = DoDontRegex();

        MatchCollection instructionMatches = dos.Matches(Input);

        List<string> groups = new();
        int startIndex = 0;
        bool inDo = true;
        foreach (Match match in instructionMatches.Cast<Match>())
        {
            if (inDo)
            {
                groups.Add(Input[startIndex..match.Index]);
            }
            inDo = match.Value == "do()";
            startIndex = match.Index;
        }
        
        // Last group
        if (inDo)
        {
            groups.Add(Input[startIndex..]);
        }

        return groups.Select(s => GetScoreForGroup(s)).Sum().ToString();
    }

}