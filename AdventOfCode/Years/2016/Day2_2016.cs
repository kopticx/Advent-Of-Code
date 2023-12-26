namespace AdventOfCode.Years._2016;

public class Day2_2016
{
  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = new List<string>();
    string input;

    while (true)
    {
      input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }
  }

  public static void Parte1(List<string> rompecabezas)
  {
    int x = 0, y = 0;
    var respuesta = "";

    foreach (var item in rompecabezas)
    {
      foreach (var item2 in item)
      {
        switch (item2)
        {
          case 'U':
            if(y < 1) y++;
            break;

          case 'D':
            if (y > -1) y--;
            break;

          case 'R':
            if (x < 1) x++;
            break;

          case 'L':
            if (x > -1) x--;
            break;
        }
      }

      switch ($"{x} {y}")
      {
        case "0 0":
          respuesta += "5";
          break;

        case "1 0":
          respuesta += "6";
          break;

        case "-1 0":
          respuesta += "4";
          break;

        case "0 1":
          respuesta += "2";
          break;

        case "1 1":
          respuesta += "3";
          break;

        case "-1 1":
          respuesta += "1";
          break;

        case "0 -1":
          respuesta += "8";
          break;

        case "1 -1":
          respuesta += "9";
          break;

        case "-1 -1":
          respuesta += "7";
          break;
      }
    }

    Console.WriteLine("\nRespuesta: ");
    Console.WriteLine(respuesta);
  }
}