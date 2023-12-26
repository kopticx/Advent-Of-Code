namespace AdventOfCode.Years._2022;

public class Day7_2022
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
    var copyRompecabezas = new List<string>(rompecabezas);
    copyRompecabezas.RemoveRange(0, 2);

    var currentDirectory = new List<string> { "/" };
    var treeDirectory = new List<string>();
    var directoriesSize = new Dictionary<string, long> { { "/", 0 } };

    while (copyRompecabezas.Any())
    {
      if (copyRompecabezas.First().Contains(".."))
      {
        currentDirectory.Remove(currentDirectory.Last());
        copyRompecabezas.RemoveAt(0);
        continue;
      }

      if (copyRompecabezas.First().Contains("cd"))
      {
        var directory = copyRompecabezas.First().Split(" ")[2];
        currentDirectory.Add(directory);
        copyRompecabezas.RemoveRange(0, 2);
      }

      var indexNextCommand = copyRompecabezas.FindIndex(x => x.StartsWith("$")) != -1
        ? copyRompecabezas.FindIndex(x => x.StartsWith("$"))
        : copyRompecabezas.Count;

      var rangeDataActualDirectory = copyRompecabezas.GetRange(0, indexNextCommand);

      var files = rangeDataActualDirectory.Where(x => x.Any(char.IsNumber)).Select(x => int.Parse(x.Split(" ")[0]));

      var nameDirectory = currentDirectory.Last() != "/"
        ? $"[{currentDirectory[^2]}][{currentDirectory.Last()}]"
        : currentDirectory.Last();

      if (directoriesSize.Any(x => x.Key == nameDirectory))
      {
        directoriesSize[nameDirectory] = files.Sum();
      }
      else if (files.Sum() != 0) directoriesSize.Add(nameDirectory, files.Sum());

      var directories = rangeDataActualDirectory.Where(x => x.StartsWith("dir"))
        .Select(x => $"[{currentDirectory[^1]}][{x.Split(" ")[1]}]");
      copyRompecabezas.RemoveRange(0, indexNextCommand);

      if (!directories.Any()) continue;

      var stringDirectories = string.Join(",", directories);
      stringDirectories = stringDirectories.Insert(0, $"{nameDirectory} -> ");

      treeDirectory.Add(stringDirectories);
    }

    var allHasValue = false;
    var directoriesValids = new List<string>();
    while (!allHasValue)
    {
      allHasValue = true;
      foreach (var item in treeDirectory)
      {
        var split = item.Split(" -> ");

        var directory = split[0];

        var validDirectory = split[1].Split(",").All(x => directoriesSize.Any(z => z.Key == x));

        if (!validDirectory)
        {
          allHasValue = false;
          continue;
        }

        if (directoriesSize.All(x => x.Key != directory)) directoriesSize.Add(directory, 0);

        var subDirectories = split[1].Split(",").Select(x => directoriesSize[x]);

        if (validDirectory && !directoriesValids.Any(x => x == directory))
        {
          directoriesSize[directory] += subDirectories.Sum();
          directoriesValids.Add(directory);
        }
      }
    }

    Console.WriteLine("\nResultado 1:");
    Console.WriteLine(directoriesSize.Where(x => x.Value <= 100000).Sum(x => x.Value));
  }
}