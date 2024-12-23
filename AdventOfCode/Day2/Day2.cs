using FluentAssertions;

namespace Day2;

public class Day2
{
    [Theory]
    [InlineData("example.txt", 2)]
    [InlineData("input.txt", 631)]
    public void Part1(string fileName, int expectedResult)
    {
        var result = Part1Execute(fileName);

        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("example.txt", 4)]
    [InlineData("input.txt", 665)]
    public void Part2(string fileName, int expectedResult)
    {
        var result = Part2Execute(fileName);

        result.Should().Be(expectedResult);
    }
    
    private int Part1Execute(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        var numbers = lines.Select(x => x.Split(" ").Select(int.Parse));

        return numbers.Count(x => x.Zip(x.Skip(1), (prev, current) => current < prev && Math.Abs(current - prev) <=3).All(y => y)
        || x.Zip(x.Skip(1), (prev, current) => current > prev && Math.Abs(current - prev) <=3).All(y => y));
    }
    
    private int Part2Execute(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        var numbersList = lines.Select(x => x.Split(" ").Select(int.Parse));

        int countSafe = 0;
        
        foreach (var number in numbersList)
        {
            for (int i = 0; i < number.Count(); i++)
            {
                var toTest = new List<int>(number);
                toTest.RemoveAt(i);
                if (isSafe(toTest))
                {
                    countSafe++;
                    break;
                }
            }
        }
        
        return countSafe;
    }
    
    Func<IEnumerable<int>, bool> isSafe = x => 
        x.Zip(x.Skip(1), (prev, current) => current < prev && Math.Abs(current - prev) <=3).All(y => y) 
        || x.Zip(x.Skip(1), (prev, current) => current > prev && Math.Abs(current - prev) <=3).All(y => y);
}