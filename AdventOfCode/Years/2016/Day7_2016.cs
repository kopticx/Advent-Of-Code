namespace AdventOfCode.Years._2016;

public class Day7_2016
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

    Part1(rompecabezas);
    Part2(rompecabezas);
  }

  private static void Part1(List<string> rompecabezas)
  {
    var validIPs = 0;

    foreach (var item in rompecabezas)
    {
      var splitedString = DecodeString(item);

      var valid = false;
      var conteinedSquareBrackets = false;

      foreach (var elements in splitedString)
      {
        for (var i = 0; i < elements.Length - 3; i++)
        {
          var sequence = elements.Substring(i, 4).GroupBy(x => x).Any(x => x.Count() > 2);
          if(sequence) continue;

          var sequenceCondition = elements[i] == elements[i + 3] && elements[i + 1] == elements[i + 2];
          if(!sequenceCondition) continue;

          if (sequenceCondition && !elements.StartsWith('['))
          {
            valid = true;
            conteinedSquareBrackets = false;
          }
          else
          {
            valid = false;
            conteinedSquareBrackets = true;
            break;
          }
        }

        if(conteinedSquareBrackets) break;
      }

      if(valid) validIPs++;
    }

    Console.WriteLine("\nRespuesta:");
    Console.WriteLine(validIPs);
  }

  private static void Part2(List<string> rompecabezas)
  {
    var validIPs = 0;

    foreach (var item in rompecabezas)
    {
      var splitedString = DecodeString(item);

      var valid = false;

      var elementsWithoutSquareBrackets = splitedString.Where(x => !x.StartsWith('[')).ToList();
      var elementsWithSquareBrackets = splitedString.Where(x => x.StartsWith('[')).ToList();

      foreach (var element in elementsWithoutSquareBrackets)
      {
        for (var i = 0; i < element.Length - 2; i++)
        {
          var sequence = element.Substring(i, 3);

          var sequenceElementsCount = sequence.GroupBy(x => x).Any(x => x.Count() == 2);
          if(!sequenceElementsCount) continue;

          var sequenceCondition = element[i] == element[i + 2] && element[i + 1] != element[i];
          if(!sequenceCondition) continue;

          var secondSequence = $"{sequence[1]}{sequence[0]}{sequence[1]}";

          if (elementsWithSquareBrackets.Any(x => x.Contains(secondSequence)))
          {
            validIPs++;
            valid = true;
            break;
          }
        }

        if (valid) break;
      }
    }

    Console.WriteLine("\nRespuesta:");
    Console.WriteLine(validIPs);
  }

  private static List<string> DecodeString(string input)
  {
    var splitedString = new List<string>();

    var copyItem = input;
    var countCloseCorchete = copyItem.Count(x => x == ']');

    for (int i = 0; i < countCloseCorchete + 1; i++)
    {
      if (copyItem.Any(x => x == '[') == false && copyItem.Any(x => x == ']') == false)
      {
        splitedString.Add(copyItem);
        break;
      }

      var substringAux = copyItem.Substring(0, copyItem.IndexOf('['));
      splitedString.Add(substringAux);

      copyItem = copyItem.Remove(0, substringAux.Length);

      substringAux = copyItem.Substring(0, copyItem.IndexOf(']') + 1);
      splitedString.Add(substringAux);

      copyItem = copyItem.Remove(0, substringAux.Length);
    }

    return splitedString;
  }
}