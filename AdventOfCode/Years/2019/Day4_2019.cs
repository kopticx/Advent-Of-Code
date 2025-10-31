namespace AdventOfCode.Years._2019;

public static class Day4_2019
{
  public static void Start()
  {
    Console.WriteLine("Enter your puzzle:");
    var input = Console.ReadLine();
    
    var split = input.Split('-').Select(int.Parse).ToList();

    var range = Enumerable.Range(split[0], split[1] - split[0]);
    
    Parte1(range);
  }

  private static void Parte1(IEnumerable<int> range)
  {
    var result = 0;
    var passwords = new List<int>();

    foreach (var item in range)
    {
      var itemString = item.ToString();
      var decrease = false;

      for (var i = 0; i < itemString.Length - 1; i++)
      {
        if (int.Parse(itemString[i].ToString()) > int.Parse(itemString[i + 1].ToString()))
        {
          decrease = true;
          break;
        }
      }

      if (!decrease)
      {
        var adjacent = itemString.GroupBy(x => x).Any(x => x.Count() >= 2);

        if (adjacent)
        {
          result++;
          passwords.Add(item);
        }
      }
    }

    Console.WriteLine($"\nResult 1: \n{result}");
    
    Parte2(passwords);
  }

  private static void Parte2(List<int> passwords)
  {
    var result = 0;

    foreach (var item in passwords)
    {
      var itemString = item.ToString();

      var grouped = itemString.GroupBy(x => x).Where(x => x.Count() > 2).Select(x => x.Key).ToList();

      if (grouped.Count == 0) result++;
      else
      {
        var removeAdjacents = itemString.Replace(grouped.First().ToString(), string.Empty);

        var par = removeAdjacents.GroupBy(x => x).Any(x => x.Count() == 2);

        if (par) result++;
      }
    }

    Console.WriteLine($"\nResult 2: \n{result}");
  }
}