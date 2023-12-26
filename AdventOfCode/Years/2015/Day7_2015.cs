namespace AdventOfCode.Years._2015;

public class Day7_2015
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
    var dictionary = new Dictionary<string, ushort>();
    const bool valid = false;

    GetWires(rompecabezas, valid, dictionary);

    Console.WriteLine("\nParte 1");
    Console.WriteLine(dictionary["a"]);

    Parte2(rompecabezas, dictionary["a"]);
  }

  private static void Parte2(List<string> rompecabezas, int result)
  {
    var index = rompecabezas.FindIndex(x => x.EndsWith("-> b"));
    rompecabezas[index] = $"{result} -> b";

    var dictionary = new Dictionary<string, ushort>();
    const bool valid = false;

    GetWires(rompecabezas, valid, dictionary);

    Console.WriteLine("\nParte 2");
    Console.WriteLine(dictionary["a"]);
  }

  private static void GetWires(List<string> rompecabezas, bool valid, Dictionary<string, ushort> dictionary)
  {
    while (!valid)
    {
      valid = true;
      foreach (var split in rompecabezas.Select(item => item.Split(' ').Where(x => x != "->")))
      {
        switch (split.Count())
        {
          case 2:
          {
            var element = split.First();

            var checkElement = CheckElement(element, dictionary);

            if (!checkElement)
            {
              valid = false;
              continue;
            }

            AddItemToDictionary(dictionary, split.Last(), element);
            continue;
          }

          case 3 when split.First() == "NOT":
          {
            var element = split.ElementAt(1);

            var checkElement = CheckElement(element, dictionary);

            if (!checkElement)
            {
              valid = false;
              continue;
            }

            if (char.IsNumber(element.First()))
            {
              var value = ushort.Parse(element);
              AddItemToDictionary(dictionary, split.Last(), ((ushort)~value).ToString());
            }
            else
            {
              var value = dictionary[element];
              AddItemToDictionary(dictionary, split.Last(), ((ushort)~value).ToString());
            }

            continue;
          }

          case 4:
          {
            var first = split.First();
            var second = split.ElementAt(2);

            var existsFirst = CheckElement(first, dictionary);
            if (!existsFirst)
            {
              valid = false;
              continue;
            }

            var existsSecond = CheckElement(second, dictionary);
            if (!existsSecond)
            {
              valid = false;
              continue;
            }

            var firstBitwise = char.IsNumber(first.First()) ? ushort.Parse(first) : dictionary[first];
            var secondBitwise = char.IsNumber(second.First()) ? ushort.Parse(second) : dictionary[second];

            var operation = split.ElementAt(1);

            var result = operation switch
            {
              "AND" => firstBitwise & secondBitwise,
              "OR" => firstBitwise | secondBitwise,
              "LSHIFT" => firstBitwise << secondBitwise,
              "RSHIFT" => firstBitwise >> secondBitwise
            };

            AddItemToDictionary(dictionary, split.Last(), result.ToString());
            break;
          }
        }
      }
    }
  }

  private static void AddItemToDictionary(Dictionary<string, ushort> dictionary, string key, string valueString)
  {
    var exists = dictionary.Any(x => x.Key == key);

    var value = char.IsNumber(valueString.First()) ? ushort.Parse(valueString) : dictionary[valueString];

    if (exists)
    {
      dictionary[key] = value;
    }
    else
    {
      dictionary.Add(key, value);
    }
  }

  private static bool CheckElement(string element, Dictionary<string, ushort> dictionary)
  {
    var isNumber = char.IsNumber(element.First());
    var existsKey = dictionary.Any(x => x.Key == element);

    return isNumber | existsKey;
  }
}