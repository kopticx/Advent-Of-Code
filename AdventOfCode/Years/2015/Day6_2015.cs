namespace AdventOfCode.Years._2015;

public class Day6_2015
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al terminar presiona 0");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "0") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
  {
    var luces = new bool[1000, 1000];

    foreach (var item in rompecabezas)
    {
      var parts = item.Split(' ');
      var coords = GetCoords(parts);

      if (item.StartsWith("turn on"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            luces[i, j] = true;
          }
        }
      }

      if (item.StartsWith("toggle"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            luces[i, j] = !luces[i, j];
          }
        }
      }

      if (item.StartsWith("turn off"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            luces[i, j] = false;
          }
        }
      }
    }

    var encendidas = luces.Cast<bool>().Count(light => light);

    Console.WriteLine("\nResultado Parte 1:");
    Console.WriteLine(encendidas);
  }

  private static void Parte2(List<string> rompecabezas)
  {
    var luces = new int[1000, 1000];

    foreach (var item in rompecabezas)
    {
      var parts = item.Split(' ');
      var coords = GetCoords(parts);

      if (item.StartsWith("turn on"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            luces[i, j]++;
          }
        }
      }

      if (item.StartsWith("toggle"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            luces[i, j] += 2;
          }
        }
      }

      if (item.StartsWith("turn off"))
      {
        for (var i = coords.coordsStart[0]; i <= coords.coordsEnd[0]; i++)
        {
          for (var j = coords.coordsStart[1]; j <= coords.coordsEnd[1]; j++)
          {
            if (luces[i, j] > 0) luces[i, j]--;
          }
        }
      }
    }

    var brillo = luces.Cast<int>().Sum();

    Console.WriteLine("\nResultado Parte 2:");
    Console.WriteLine(brillo);
  }

  private static (int[] coordsStart, int[] coordsEnd) GetCoords(string[] parts)
  {
    var coordsStart = parts[^3].Split(',').Select(int.Parse).ToArray();
    var coordsEnd = parts[^1].Split(',').Select(int.Parse).ToArray();

    return (coordsStart, coordsEnd);
  }
}