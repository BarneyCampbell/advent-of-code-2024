namespace AdventOfCode.Tests;

using AdventOfCode.Days;
using AdventOfCode.Functional;

public class Tests
{
    private readonly Day1 d1 = new Day1(Inputs.Day1);
    private readonly Day2 d2 = new Day2(Inputs.Day2);

    [SetUp]
    public void Setup()
    {
    }

    #region Day 2
    [Test]
    public void Day2_Part2()
    {
        var expected = "";
        var result = d2.Part2();

        Assert.Pass();
    }

    [Test]
    public void Day2_Part1()
    {
        var expected = "";
        var result = d2.Part1();

        Assert.Pass();
    }
    #endregion

    #region Day 1
    [Test]
    public void Day1_Part2()
    {
        var expected = "31";
        var result = d1.Part2();

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Day1_Part1()
    {
        var expected = "11";
        var result = d1.Part1();

        Assert.That(expected, Is.EqualTo(result));
    }
    #endregion
}