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
        var expected = "4";
        var result = d2.Part2();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day2_Part2_SingleRecords()
    {
        int[] input = [ 7, 6, 4, 2, 1 ];
        var result = D2.worksWithRemovalRunner(input);

        Assert.True(result);

        input = [1, 2, 7, 8, 9];
        result = D2.worksWithRemovalRunner(input);
        
        Assert.False(result);
        
        input = [9, 7, 6, 2, 1];
        result = D2.worksWithRemovalRunner(input);
        
        Assert.False(result);

        input = [1, 3, 2, 4, 5];
        result = D2.worksWithRemovalRunner(input);
        
        Assert.True(result);

        input = [8, 6, 4, 4, 1];
        result = D2.worksWithRemovalRunner(input);
        
        Assert.True(result);

        input = [1, 3, 6, 7, 9];
        result = D2.worksWithRemovalRunner(input);
        
        Assert.True(result);
    }

    [Test]
    public void Day2_Part1()
    {
        var expected = "2";
        var result = d2.Part1();

        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region Day 1
    [Test]
    public void Day1_Part2()
    {
        var expected = "31";
        var result = d1.Part2();

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Day1_Part1()
    {
        var expected = "11";
        var result = d1.Part1();

        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion
}