// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var input = File.ReadLines("input.txt");

var first =
    input.Select(x => int.Parse(x.Split(" ")[0].Trim())).Order();

var second =
    input.Select(x => int.Parse(x.Split(" ").Last().Trim())).Order();


var together = first.Zip(second, (x, y) => Math.Abs(x - y));

Console.WriteLine(together.Sum());

var part2 = first.Select(x => x * second.Count(y => y == x));

Console.WriteLine(part2.Sum());

    
    
    