namespace AdventOfCode.Years._2015;

public class Day5_2015
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al terminar presiona 0");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
  {
    var vocales = new List<char> { 'a', 'e', 'i', 'o', 'u' };
    var subcadenasDenegadas = new List<string> { "ab", "cd", "pq", "xy" };
    var cadenasBuenas = 0;

    foreach (var item in rompecabezas)
    {
      var contadorVocales = 0;
      bool letraSeguida = false, cadenaBuena = true;

      for (var i = 0; i < item.Length; i++)
      {
        if (i + 1 <= item.Length - 1)
        {
          if (item[i] == item[i + 1]) letraSeguida = true;

          if (subcadenasDenegadas.Any(x => x == item[i] + item[i + 1].ToString())) cadenaBuena = false;
        }

        if (vocales.Any(x => x == item[i])) contadorVocales++;
      }

      if (cadenaBuena && letraSeguida && contadorVocales >= 3) cadenasBuenas++;
    }

    Console.WriteLine("\nResultado:");
    Console.WriteLine(cadenasBuenas);
  }

  private static void Parte2(List<string> rompecabezas)
  {

  }
}