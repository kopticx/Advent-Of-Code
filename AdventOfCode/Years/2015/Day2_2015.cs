namespace AdventOfCode.Years._2015;

public class Day2_2015
{
  public static void Start()
  {
    List<string> rompecabezas = new List<string>();

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
    var area = new int[3];
    int papelRegalo = 0, areaMinima = 1000;

    foreach (var item in rompecabezas)
    {
      var split = item.Split('x').Select(int.Parse).ToList();

      var l = split.First();
      var w = split.ElementAt(1);
      var h = split.Last();

      area[0] = l * w;
      area[1] = w * h;
      area[2] = h * l;

      areaMinima = area.Prepend(areaMinima).Min();

      papelRegalo += ((2 * area[0]) + (2 * area[1]) + (2 * area[2]));
      papelRegalo += areaMinima;

      areaMinima = 1000;
    }

    Console.WriteLine("\nParte 1");
    Console.WriteLine(papelRegalo);
  }

  private static void Parte2(List<string> rompecabezas)
  {
    var area = new int[3];
    int papelRegalo = 0, areaMinima = 1000, cinta = 0;

    foreach (var item in rompecabezas)
    {
      var split = item.Split('x').Select(int.Parse).ToList();

      var l = split.First();
      var w = split.ElementAt(1);
      var h = split.Last();

      int cintaEnvolver = l * w * h;

      area[0] = l * w;
      area[1] = w * h;
      area[2] = h * l;

      areaMinima = area.Prepend(areaMinima).Min();

      if (areaMinima == area[0]) cinta = l * 2 + w * 2 + cintaEnvolver;
      else if (areaMinima == area[1]) cinta = w * 2 + h * 2 + cintaEnvolver;
      else cinta = h * 2 + l * 2 + cintaEnvolver;

      papelRegalo += cinta;

      areaMinima = 1000;
    }

    Console.WriteLine("\nParte 2");
    Console.WriteLine(papelRegalo);
  }
}