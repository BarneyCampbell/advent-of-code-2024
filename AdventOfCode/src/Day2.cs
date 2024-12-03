namespace AdventOfCode.Days;

using AdventOfCode.Functional;
using AdventOfCode.Lib;

public class Day2(string _input) : IDay
{
    public string Input { get; } = _input;

    private static readonly char[] newlineSeparator = ['\n'];
    private static readonly char[] spaceSeparator = [' '];

    public string Part1()
    {
        IEnumerable<string> records = Input.Split(newlineSeparator, StringSplitOptions.RemoveEmptyEntries);

        int result = 0;
        foreach (string record in records)
        {
            List<int> values = record.Split(spaceSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => int.Parse(v))
                .ToList();

                result += CheckValidity(values) ? 1 : 0;
        }

        return result.ToString();
    }

    private static bool CheckValidity(IEnumerable<int> list)
    {
        bool inc = true;
        bool dec = true;
        // Check increase
        int i = 0;
        while (i+1 < list.Count())
        {
            var increase = 0;
            if (list.ElementAt(i) > list.ElementAt(i+1))
            {
                increase = -1;
            }
            else if (list.ElementAt(i) < list.ElementAt(i+1))
            {
                increase = 1;
            }

            var diff = Lib.difference(list.ElementAt(i), list.ElementAt(i+1));
            if (increase > 0 && diff >= 1 && diff <= 3)
            {
                i++;
                continue;
            }
            inc = false;
            break;
        }
        if (inc) return true;

        i = 0;
        while (i+1 < list.Count())
        {
            var increase = 0;
            if (list.ElementAt(i) > list.ElementAt(i+1))
            {
                increase = -1;
            }
            else if (list.ElementAt(i) < list.ElementAt(i+1))
            {
                increase = 1;
            }

            var diff = Lib.difference(list.ElementAt(i), list.ElementAt(i+1));
            if (increase < 0 && diff >= 1 && diff <= 3)
            {
                i++;
                continue;
            }
            dec = false;
            break;
        }

        return dec;
    }

    public string Part2()
    {
        IEnumerable<string> records = Input.Split(newlineSeparator, StringSplitOptions.RemoveEmptyEntries);

        int result = 0;
        foreach (string record in records)
        {
            List<int> values = record.Split(spaceSeparator, StringSplitOptions.RemoveEmptyEntries)
                .Select(v => int.Parse(v))
                .ToList();

            if (CheckValidity(values))
            {
                result += 1;
                continue;
            }
            else
            {
                SkipList<int> skipList = new(values, -1);

                int i = 0;
                while (i < values.Count)
                {
                    skipList.UpdateSkipIndex(i);

                    if (CheckValidity(skipList))
                    {
                        result += 1;
                        i++;
                        break;
                    }
                    
                    i++;
                }
            }
        }

        return result.ToString();
    }
}