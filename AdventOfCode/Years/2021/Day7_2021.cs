namespace AdventOfCode.Years._2021;

public class Day7_2021
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas");
    var input = new List<int>();

    while (true)
    {
      var linea = Console.ReadLine();
      if (string.IsNullOrEmpty(linea))
      {
        break;
      }

      var nums = linea.Split(',').Select(int.Parse).ToList();
      input = nums;
    }

    Part1(input);
    Part2(input);
  }

  private static void Part1(List<int> rompecabezas)
  {
    var fuelCost = new List<int>();

    for (int i = 1; i <= rompecabezas.Count; i++)
    {
      var costPerPosition = 0;

      foreach (var item in rompecabezas)
      {
        costPerPosition += Math.Abs(item - i);
      }

      fuelCost.Add(costPerPosition);
    }

    Console.WriteLine("\nResultado 1:");
    Console.WriteLine(fuelCost.Min());
  }

  private static void Part2(List<int> rompecabezas)
  {
    var fuelCost = new List<int>();

    for (var i = 1; i <= rompecabezas.Count; i++)
    {
      var costPerPosition = 0;

      foreach (var item in rompecabezas)
      {
        var distance = Math.Abs(item - i);

        var costThisStep = (distance * (distance + 1)) / 2;

        costPerPosition += costThisStep;
      }

      fuelCost.Add(costPerPosition);
    }

    Console.WriteLine("\nResultado 2:");
    Console.WriteLine(fuelCost.Min());
  }
}