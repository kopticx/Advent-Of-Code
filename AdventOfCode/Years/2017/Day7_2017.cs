using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2017;

public partial class Day7_2017
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas");
    var rompecabezas = new List<string>();
    string input;

    while (true)
    {
      input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
  {
    var elements = new List<string>();
    var childrens = new List<string>();

    foreach (var item in rompecabezas)
    {
      var split = item.Split("->");

      var part1Split = split[0].Split(' ')[0];
      elements.Add(part1Split);

      if (split.Length != 2) continue;
      var part2Split = split[1].Trim().Split(',').Select(item2 => item2.Trim());

      childrens.AddRange(part2Split);
    }

    var except = elements.Except(childrens).ToList();

    Console.WriteLine("\nResultado 1:");
    Console.WriteLine(except.First());

    Parte2(rompecabezas, except.First());
  }

  private static void Parte2(List<string> rompecabezas, string response)
  {
    var timeMeasure = new Stopwatch();
    timeMeasure.Start();
    var elementsWithChildrens = rompecabezas.Where(x => x.Contains("->")).ToList();

    var itemResponse = elementsWithChildrens.FirstOrDefault(x => x.StartsWith(response));
    elementsWithChildrens.Remove(itemResponse);

    var elementsWithoutChildrens = rompecabezas.Where(x => !x.Contains("->")).ToList();

    var elementsWithValue = elementsWithoutChildrens.Select(GetSplit).ToDictionary(split => split.key, split => split.number);
    elementsWithValue.Remove(response);

    var allHaveValue = false;

    while (!allHaveValue)
    {
      if (elementsWithValue.GroupBy(x => x.Value).Count() == 2)
      {
        break;
      }

      allHaveValue = true;
      foreach (var item in elementsWithChildrens)
      {
        var split = GetSplit(item);

        var sumChildrens = 0;
        var allChildrensHaveValue = true;

        var allChildrensExists = split.childrens!.All(x => elementsWithValue.ContainsKey(x));

        if (!allChildrensExists)
        {
          allHaveValue = false;
          continue;
        }

        var childrensHaveSameValue = new List<int>();

        foreach (var children in split.childrens!)
        {
          if(elementsWithValue.Any(x => x.Key == children))
          {
            var value = elementsWithValue[children];

            childrensHaveSameValue.Add(value);

            sumChildrens += value;
            elementsWithValue.Remove(children);
          }
        }

        if (childrensHaveSameValue.GroupBy(x => x).Count() > 1)
        {
          var keyDiferentValue = childrensHaveSameValue.GroupBy(x => x).OrderBy(x => x.Count());
          var indexDiferentValue = childrensHaveSameValue.IndexOf(keyDiferentValue.First().Key);

          var itemDifferentValue = rompecabezas.FirstOrDefault(x => x.StartsWith(split.key));
          var splitItemDifferentValue = GetSplit(itemDifferentValue);

          var itemToSubtract = splitItemDifferentValue.childrens![indexDiferentValue];

          var stringItemToSubtract = rompecabezas.FirstOrDefault(x => x.StartsWith(itemToSubtract));

          var splitItemToSubtract = GetSplit(stringItemToSubtract);
          Console.WriteLine("\nResultado 2:");
          Console.WriteLine(splitItemToSubtract.number - (keyDiferentValue.First().Key - keyDiferentValue.Last().Key));
          goto end;
        }

        if(allChildrensHaveValue) elementsWithValue.Add(split.key, split.number + sumChildrens);
      }
    }

    end:

    timeMeasure.Stop();
    Console.WriteLine($"\nTiempo: {timeMeasure.Elapsed.TotalMilliseconds} ms");
  }

  private static (string key, int number, List<string>? childrens) GetSplit(string item)
  {
    var split = item.Split("->");

    var part1Split = split[0].Split(' ')[0];
    var numSplit = MyRegex().Replace(split[0].Split(' ')[1], "");
    var numParent = int.Parse(numSplit);

    if (split.Length < 2) return (part1Split, numParent, null);

    var part2Split = split[1].Trim().Split(',').Select(item2 => item2.Trim()).ToList();
    return (part1Split, numParent, part2Split);
  }

  [GeneratedRegex("[^0-9]")]
  private static partial Regex MyRegex();
}