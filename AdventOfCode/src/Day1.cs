namespace AdventOfCode.Days;

using AdventOfCode.Functional;

public class Day1(string _input) : IDay
{
    public string Input { get; } = _input;

    public string Part1()
    {
        string[] lines = Input.Split('\n');

        List<int> l1, l2;
        (l1, l2) = D1.getNumLists(lines);

        IEnumerable<int> zipped = l1.OrderBy(x => x)
            .Zip(l2.OrderBy(x => x), Lib.difference);

        return zipped.Sum().ToString();
    }

    public string Part2()
    {
        string[] lines = Input.Split('\n');

        List<int> l1, l2;
        (l1, l2) = D1.getNumLists(lines);

        IEnumerable<int> instances = l1.Select(x1 => l2.Where(x2 => x2 == x1).Count() * x1);

        return instances.Sum().ToString();
    }
}