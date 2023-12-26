namespace AdventOfCode.Years._2017;

public class Day6_2017
{
  public static void Run()
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

      var nums = linea.Split('\t').Select(x => Int32.Parse(x)).ToList();
      input = nums;
    }

    Parte1(input);
  }

  private static void Parte1(List<int> rompecabezas)
  {
    var secuencias = new List<List<int>>();
    var copy = new List<int>(rompecabezas);

    var part1Response = false;

    while (true)
    {
      var maxNum = copy.Max();
      var maxIndex = copy.IndexOf(maxNum);

      copy[maxIndex] = 0;

      for (int i = maxIndex + 1; i <= copy.Count; i++)
      {
        if(maxNum == 0) break;
        if (i == copy.Count) i = 0;

        copy[i] += 1;
        maxNum -= 1;
      }

      if (secuencias.Any(x => x.SequenceEqual(copy)) && part1Response) break;

      if (secuencias.Any(x => x.SequenceEqual(copy)))
      {
        Console.WriteLine("\nRespuesta 1: ");
        Console.WriteLine(secuencias.Count + 1);
        part1Response = true;
        secuencias = new List<List<int>>();
      }

      secuencias.Add(new List<int>(copy));
    }

    Console.WriteLine("\nRespuesta 2: ");
    Console.WriteLine(secuencias.Count);
  }
}