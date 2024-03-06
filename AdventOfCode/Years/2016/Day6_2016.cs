namespace AdventOfCode.Years._2016;

public class Day6_2016
{
  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
  {
    var mensaje = "";

    for (var i = 0; i < 8; i++)
    {
      var letra = rompecabezas.GroupBy(x => x[i]).OrderByDescending(x => x.Count()).Select(x => x.Key).ToList()[0];
      mensaje += letra;
    }

    Console.WriteLine("\nRespuesta Parte 1: ");
    Console.WriteLine(mensaje);
  }

  private static void Parte2(List<string> rompecabezas)
  {
    var mensaje = "";

    for (var i = 0; i < 8; i++)
    {
      var letra = rompecabezas.GroupBy(x => x[i]).OrderBy(x => x.Count()).Select(x => x.Key).ToList()[0];
      mensaje += letra;
    }

    Console.WriteLine("\nRespuesta:");
    Console.WriteLine(mensaje);
  }
}