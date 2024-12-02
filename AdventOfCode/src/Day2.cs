namespace AdventOfCode.Days;

using AdventOfCode.Functional;
using Microsoft.FSharp.Core;

public class Day2(string _input) : IDay
{
    public string Input { get; } = _input;

    public string Part1()
    {
        IEnumerable<string> records = Input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int result = 0;
        foreach (string record in records)
        {
            List<int> values = record.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => int.Parse(v))
                .ToList();

                int increases = 0;
                int decreases = 0;
                int i = 0;
                bool valid = true;
                while (valid && i+1 < values.Count())
                {
                    var diff = Lib.difference(values[i], values[i+1]);
                    var increase = Lib.incOrDec(values[i], values[i+1]);
                    if (increase > 0)
                    {
                        increases++;
                    }
                    else if (increase < 0)
                    {
                        decreases++;
                    }
                    valid &= diff >= 1 && diff <= 3;
                    i++;
                }

                valid &= (increases != 0 && decreases == 0) || (increases == 0 && decreases != 0);
                result += valid ? 1 : 0;

        }

        return result.ToString();
    }

    public string Part2()
    {
        IEnumerable<string> records = Input.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int result = 0;
        foreach (string record in records)
        {
            List<int> values = record.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => int.Parse(v))
                .ToList();

                int increases = 0;
                int decreases = 0;
                int i = 0;
                bool valid = true;
                while (valid && i+1 < values.Count())
                {
                    var diff = Lib.difference(values[i], values[i+1]);
                    var increase = Lib.incOrDec(values[i], values[i+1]);
                    if (increase > 0)
                    {
                        increases++;
                    }
                    else if (increase < 0)
                    {
                        decreases++;
                    }
                    valid &= diff >= 1 && diff <= 3;
                    i++;
                }

                valid &= (increases != 0 && decreases == 0) || (increases == 0 && decreases != 0);
                result += valid ? 1 : 0;

        }

        return result.ToString();
    }
}