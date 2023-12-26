namespace AdventOfCode.Years._2022;

public class Day3_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al terminar escribe BREAK");
    List<string> rompecabezas = new List<string>();
    string input;

    while (true)
    {
      input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  void Parte1(List<string> parte1)
  {
    int suma = 0;

    foreach (var item in parte1)
    {
      var indexMitad = item.Length / 2;

      var mitad1 = item.Substring(0, indexMitad).GroupBy(x => x).Select(x => x.Key).ToList();
      var mitad2 = item.Substring(indexMitad, item.Length - indexMitad).GroupBy(x => x).Select(x => x.Key).ToList();

      var comportamientoIgual = mitad1.Intersect(mitad2).First();

      switch (Char.IsLower(comportamientoIgual))
      {
        case true:
          suma += Convert.ToInt32(comportamientoIgual - 96);
          break;

        case false:
          suma += Convert.ToInt32(comportamientoIgual - 38);
          break;
      }
    }

    Console.WriteLine("\nRespuesta Parte 1:");
    Console.WriteLine(suma);
  }

  void Parte2(List<string> parte2)
  {
    int suma = 0;

    while(parte2.Count() > 0)
    {
      var take3 = parte2.Take(3).ToList();
      var item1 = take3[0].ToList();
      var item2 = take3[1].ToList();
      var item3 = take3[2].ToList();

      var comportamientoIgual = item1.Intersect(item2).Intersect(item3).First();

      switch (Char.IsLower(comportamientoIgual))
      {
        case true:
          suma += Convert.ToInt32(comportamientoIgual - 96);
          break;

        case false:
          suma += Convert.ToInt32(comportamientoIgual - 38);
          break;
      }

      parte2.RemoveRange(0, 3);
    }

    Console.WriteLine("\nRespuesta Parte 2:");
    Console.WriteLine(suma);
  }
}