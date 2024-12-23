using FluentAssertions;

namespace Day4;

public class Day4
{
    [Theory]
    [InlineData("example.txt", 18)]
    [InlineData("input.txt", 2613)]
    public void Part1(string fileName, int expectedResult)
    {
        var result = Part1Execute(fileName);

        result.Should().Be(expectedResult);
    }

    private int Part1Execute(string fileName)
    {
        var lines = File.ReadLines(fileName);

        var twoDArray = lines.Select(x => x.ToArray()).ToArray();

        var countXmas = 0;
        // is it right
        for (int i = 0; i < twoDArray.Length; i++)
        {
            for (int j = 0; j < twoDArray[i].Length - 3; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i][j+1] == 'M' && twoDArray[i][j+2] == 'A' && twoDArray[i][j+3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        //is it backwards
        for (int i = 0; i < twoDArray.Length; i++)
        {
            for (int j = 3; j < twoDArray[i].Length ; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i][j-1] == 'M' && twoDArray[i][j-2] == 'A' && twoDArray[i][j-3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        //is it down
        for (int i = 0; i < twoDArray.Length - 3; i++)
        {
            for (int j = 0; j < twoDArray[i].Length ; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i+1][j] == 'M' && twoDArray[i+2][j] == 'A' && twoDArray[i+3][j] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        //is it up
        for (int i = 3; i < twoDArray.Length; i++)
        {
            for (int j = 0; j < twoDArray[i].Length ; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i-1][j] == 'M' && twoDArray[i-2][j] == 'A' && twoDArray[i-3][j] == 'S')
                {
                    countXmas++;
                }
            }
        }
        //is it up diagnol right
        
        for (int i = 3; i < twoDArray.Length; i++)
        {
            for (int j = 0; j < twoDArray[i].Length - 3 ; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i-1][j+1] == 'M' && twoDArray[i-2][j+2] == 'A' && twoDArray[i-3][j+3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        // is it up diagnol left
        //is it up diagnol right
        
        for (int i = 3; i < twoDArray.Length; i++)
        {
            for (int j = 3; j < twoDArray[i].Length; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i-1][j-1] == 'M' && twoDArray[i-2][j-2] == 'A' && twoDArray[i-3][j-3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        // is it down diagnoal right
        for (int i = 0; i < twoDArray.Length - 3; i++)
        {
            for (int j = 0; j < twoDArray[i].Length - 3 ; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i+1][j+1] == 'M' && twoDArray[i+2][j+2] == 'A' && twoDArray[i+3][j+3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        // is it down diagonal left
        
        for (int i = 0; i < twoDArray.Length - 3; i++)
        {
            for (int j = 3; j < twoDArray[i].Length; j++)
            {
                if(twoDArray[i][j] == 'X' && twoDArray[i+1][j-1] == 'M' && twoDArray[i+2][j-2] == 'A' && twoDArray[i+3][j-3] == 'S')
                {
                    countXmas++;
                }
            }
        }
        
        return countXmas;
    }


    // [Theory]
    // [InlineData("example2.txt", 48)]
    // [InlineData("input.txt", 80747545)]
    // public void Part2(string fileName, int expectedResult)
    // {
    //     var result = Part2Execute(fileName);
    //
    //     result.Should().Be(expectedResult);
    // }
}