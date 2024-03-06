namespace AdventOfCode.Years._2016;

public class Day2_2016
{
  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input!);
      else break;
    }

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
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
            if (y < 1) y++;
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

  private static void Parte2(List<string> rompecabezas)
  {
    var respuesta = "";
    int x = 0, y = 0;

    foreach (var item in rompecabezas)
    {
      foreach (var item2 in item)
      {
        //    1
        //  2 3 4
        //5 6 7 8 9
        //  A B C
        //    D
        switch (item2)
        {
          case 'U':
            switch (y)
            {
              case 0 when x is >= 1 and <= 3:
              case 1 when x == 2:
              case -1 when x is >= 1 and <= 3:
              case -2 when x == 2:
                y++;
                break;
            }
            break;

          case 'D':
            switch (y)
            {
              case 0 when x is > 0 and < 4:
              case 1 when x is >= 1 and < 4:
              case -1 when x == 2:
              case 2 when x == 2:
                y--;
                break;
            }
            break;

          case 'R':
            switch (y)
            {
              case 0 when x is >= 0 and < 4:
              case 1 when x is >= 1 and < 3:
              case -1 when x is >= 1 and < 3:
                x++;
                break;
            }
            break;

          case 'L':
            switch (y)
            {
              case 0 when x is <= 4 and > 0:
              case 1 when x is <= 3 and > 1:
              case -1 when x is <= 3 and > 1:
                x--;
                break;
            }
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

        case "2 0":
          respuesta += "7";
          break;

        case "3 0":
          respuesta += "8";
          break;

        case "4 0":
          respuesta += "9";
          break;

        case "1 1":
          respuesta += "2";
          break;

        case "2 1":
          respuesta += "3";
          break;

        case "3 1":
          respuesta += "4";
          break;

        case "2 2":
          respuesta += "1";
          break;

        case "1 -1":
          respuesta += "A";
          break;

        case "2 -1":
          respuesta += "B";
          break;

        case "3 -1":
          respuesta += "C";
          break;

        case "2 -2":
          respuesta += "D";
          break;
      }
    }

    Console.WriteLine("\nRespuesta: ");
    Console.WriteLine(respuesta);
  }
}