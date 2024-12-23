using System.Text.RegularExpressions;
using FluentAssertions;

namespace Day3;

public class Day3
{
    [Theory]
    [InlineData("example.txt", 161)]
    [InlineData("input.txt", 182619815)]
    public void Part1(string fileName, int expectedResult)
    {
        var result = Part1Execute(fileName);

        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("example2.txt", 48)]
    [InlineData("input.txt", 80747545)]
    public void Part2(string fileName, int expectedResult)
    {
        var result = Part2Execute(fileName);
    
        result.Should().Be(expectedResult);
    }

    private int Part1Execute(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        var regex = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";

        Regex rg = new Regex(regex);

        var ret = 0;

        var enabled = true;

        foreach (var line in lines)
        {
            var matches = rg.Matches(line);

            var strings = matches.Select(x => x.Value);

            foreach (var str in strings)
            {
                var splitStrings = str.Split(",");

                var firstNumber = splitStrings.First().Replace("mul", "").Replace("(", "");
                var lastNumber = splitStrings.Last().Replace(")", "");

                var value = int.Parse(firstNumber) * int.Parse(lastNumber);

                ret += value;
            }
        }

        return ret;
    }
    
    private int Part2Execute(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        var regex = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";

        Regex rg = new Regex(regex);

        var ret = 0;

        var enabled = true;

        foreach (var line in lines)
        {
            var matches = rg.Matches(line);

            var strings = matches.Select(x => x.Value);

            foreach (var str in strings)
            {
                if (str == "do()" || str == "don't()")
                {
                    enabled = str switch
                    {
                        "do()" => true,
                        "don't()" => false,
                        _ => enabled
                    };
                    continue;   
                }

                if (enabled)
                {
                    var splitStrings = str.Split(",");

                    var firstNumber = splitStrings.First().Replace("mul", "").Replace("(", "");
                    var lastNumber = splitStrings.Last().Replace(")", "");

                    var value = int.Parse(firstNumber) * int.Parse(lastNumber);

                    ret += value;
                }
            }
        }

        return ret;
    }
}