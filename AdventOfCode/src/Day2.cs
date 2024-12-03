namespace AdventOfCode.Days;

using AdventOfCode.Functional;

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

    private static bool CheckValidity(List<int> list)
    {
        bool inc = true;
        bool dec = true;
        // Check increase
        int i = 0;
        while (i+1 < list.Count)
        {
            var increase = 0;
            if (list[i] > list[i+1])
            {
                increase = -1;
            }
            else if (list[i] < list[i+1])
            {
                increase = 1;
            }
            var diff = Lib.difference(list[i], list[i+1]);
            if (increase > 0 && diff >= 1 && diff <= 3)
            {
                i++;
                continue;
            }
            inc = false;
            break;
        }

        i = 0;
        while (i+1 < list.Count)
        {
            var increase = 0;
            if (list[i] > list[i+1])
            {
                increase = -1;
            }
            else if (list[i] < list[i+1])
            {
                increase = 1;
            }
            var diff = Lib.difference(list[i], list[i+1]);
            if (increase < 0 && diff >= 1 && diff <= 3)
            {
                i++;
                continue;
            }
            dec = false;
            break;
        }

        return inc || dec;
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
                List<int> tempValues = new (values);
                int i = 0;
                while (i < tempValues.Count)
                {
                    tempValues.RemoveAt(i);

                    if (CheckValidity(tempValues))
                    {
                        result += 1;
                        i++;
                        tempValues = new (values);
                        break;
                    }
                    
                    i++;
                    tempValues = new (values);
                }
            }

            //result += D2.worksWithRemovalRunner(values) ? 1 : 0;
        }

        return result.ToString();
    }
}