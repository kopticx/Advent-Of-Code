using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2023;

public partial class Day1_2023
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al terminar escribe BREAK");
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
    var cleanNumbers = CleanNumbers(rompecabezas);

    var result = cleanNumbers.Sum();

    Console.WriteLine($"Resultado 1: \n{result}");
  }

  private static void Parte2(List<string> rompecabezas)
  {
    
  }

  private static IEnumerable<int> CleanNumbers(IEnumerable<string> rompecabezas)
  {
    var regex = MyRegex();
    return rompecabezas
      .Select(x => regex.Replace(x, ""))
      .Select(y => $"{y.First()}{y.Last()}")
      .Select(int.Parse)
      .ToList();
  }

  private static int WordToNumber(string word)
  {
    var wordToNumberMap = new Dictionary<string, int>
    {
      { "one", 1 },
      { "two", 2 },
      { "three", 3 },
      { "four", 4 },
      { "five", 5 },
      { "six", 6 },
      { "seven", 7 },
      { "eight", 8 },
      { "nine", 9 }
    };

    return wordToNumberMap.GetValueOrDefault(word, 0);
  }

  [GeneratedRegex("\\D")]
  private static partial Regex MyRegex();
}