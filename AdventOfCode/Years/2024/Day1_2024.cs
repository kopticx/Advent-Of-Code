namespace AdventOfCode.Years._2024;

public class Day1_2024
{
  public static void Start()
  {
    Console.WriteLine("Enter your puzzle:");
    var puzzle = new List<(int, int)>();
    
    while (true)
    {
      var input = Console.ReadLine();
      
      if (input != "BREAK")
      {
        var nums = input.Replace("   ", ",").Split(',').Select(int.Parse).ToArray();
        
        puzzle.Add((nums[0], nums[1]));
      }
      else break;
    }
    
    Parte1(puzzle);
    Parte2(puzzle);
  }

  private static void Parte1(List<(int, int)> puzzle)
  {
    var result = 0;
    
    var puzzleCopy = new List<(int left, int right)>(puzzle);
    
    var puzzleLeft = puzzleCopy.Select(x => x.left).OrderBy(x => x).ToList();
    var puzzleRight = puzzleCopy.Select(x => x.right).OrderBy(x => x).ToList();

    for (var i = 0; i < puzzleCopy.Count; i++)
    {
      var distance = Math.Abs(puzzleLeft[i] - puzzleRight[i]);
      
      result += distance;
    }
    
    Console.WriteLine("\nResult 1:");
    Console.WriteLine(result);
  }
  
  private static void Parte2(List<(int, int)> puzzle)
  {
    var puzzleCopy = new List<(int left, int right)>(puzzle);
    
    var puzzleRight = puzzleCopy.Select(x => x.right).ToList();
    var puzzleLeft = puzzleCopy.Select(x => x.left * puzzleRight.GroupBy(y => y).FirstOrDefault(y => y.Key == x.left)?.Count() ?? 0).ToList();

    Console.WriteLine("\nResult 2:");
    Console.WriteLine(puzzleLeft.Sum());
  }
}