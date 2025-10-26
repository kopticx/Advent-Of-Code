namespace AdventOfCode.Years._2021;

public class Day6_2021
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu input");
    var input = new List<int>();
    
    input = Console.ReadLine().Split(',').Select(int.Parse).ToList();
    
    Parte1(input);
    Parte2(input);
  }

  private static void Parte1(List<int> rompecabezas)
  {
    var input = new List<int>(rompecabezas);
    
    for (var i = 0; i < 80; i++)
    {
      var conteoAnterior = input.Count;

      for (var j = 0; j < conteoAnterior; j++)
      {
        if (input[j] == 0)
        {
          input.Add(8);
          input[j] = 6;
        }
        else
        {
          input[j]--;
        }
      }
    }

    Console.WriteLine("\nResultado 1:");
    Console.WriteLine(input.Count);
  }

  private static void Parte2(List<int> rompecabezas)
  {
    var counts = new long[9];
    foreach (var v in rompecabezas)
      counts[v]++;

    for (var day = 0; day < 256; day++)
    {
      var zeros = counts[0];
      
      for (var t = 0; t < 8; t++)
        counts[t] = counts[t + 1];

      counts[6] += zeros;
      counts[8] = zeros;
    }

    var total = counts.Sum();

    Console.WriteLine("\nResultado 2:");
    Console.WriteLine(total);
  }
}