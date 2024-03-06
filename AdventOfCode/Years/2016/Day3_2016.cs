namespace AdventOfCode.Years._2016;

public class Day3_2016
{
  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input!.Remove(0, 2));
      else break;
    }

    Parte1(rompecabezas);
  }

  private static void Parte1(IEnumerable<string> rompecabezas)
  {
    var validTriangles = 0;
    var rompecabezasNumbers = new List<int[]>();

    foreach (var item in rompecabezas)
    {
      var a = int.Parse(item[..3].Trim());
      var b = int.Parse(item.Substring(5, 3).Trim());
      var c = int.Parse(item.Substring(10, 3).Trim());

      rompecabezasNumbers.Add([a, b, c]);

      if (a + b > c && a + c > b && b + c > a) validTriangles++;
    }

    Console.WriteLine("\nRespuesta Parte 1: ");
    Console.WriteLine(validTriangles);

    Parte2(rompecabezasNumbers);
  }

  private static void Parte2(IList<int[]> rompecabezas)
  {
    for (var row = 0; row < rompecabezas.Count; row += 3)
    {
      var colum1 = rompecabezas.Select(x => x[0]).Skip(row).Take(3).ToArray();
      var colum2 = rompecabezas.Select(x => x[1]).Skip(row).Take(3).ToArray();
      var colum3 = rompecabezas.Select(x => x[2]).Skip(row).Take(3).ToArray();

      rompecabezas[row] = colum1;
      rompecabezas[row + 1] = colum2;
      rompecabezas[row + 2] = colum3;
    }

    var response = rompecabezas.Count(x => x[0] + x[1] > x[2] && x[0] + x[2] > x[1] && x[1] + x[2] > x[0]);
    Console.WriteLine("\nRespuesta Parte 2: ");
    Console.WriteLine(response);
  }
}