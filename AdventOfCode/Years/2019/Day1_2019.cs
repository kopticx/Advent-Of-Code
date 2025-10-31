namespace AdventOfCode.Years._2019;

public static class Day1_2019
{
  public static void Start()
  {
    Console.WriteLine("Enter your puzzle");
    var puzzle = new List<double>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK")
      {
        puzzle.Add(int.Parse(input));
      }
      else break;
    }
    
    Parte1(puzzle);
    Parte2(puzzle);
  }

  private static void Parte1(List<double> puzzle)
  {
    var result = puzzle.Sum(item => Math.Floor(item / 3) - 2);

    Console.WriteLine($"\nResult 1: \n{result}");
  }
  
  private static void Parte2(List<double> puzzle)
  {
    var result = 0d;
    
    foreach (var item in puzzle)
    {
      var operation = item;
      var divitions = 0d;

      do
      {
        operation = Math.Floor(operation / 3) - 2;

        if (operation > 0) divitions += operation;

      } 
      while (operation >= 0);

      result += divitions;
    }
    
    Console.WriteLine($"\nResult 2: \n{result}");
  }
}