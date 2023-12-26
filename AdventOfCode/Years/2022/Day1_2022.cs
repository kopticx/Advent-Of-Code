namespace AdventOfCode.Years._2022;

public class Day1_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al terminar escribe BREAK");

    List<string> rompecabezas = new List<string>();
    string input;

    while (true)
    {
      input = Console.ReadLine();

      if(input == "BREAK")
      {
        rompecabezas.Add("");
        break;
      }
      else
      {
        rompecabezas.Add(input);
      }
    }

    Parte1(rompecabezas);
  }

  void Parte1(List<string> rompecabezas1)
  {
    List<int> suma = new List<int>();
    var elfo = new List<int>();

    foreach (var item in rompecabezas1)
    {
      if(item != "")
      {
        elfo.Add(int.Parse(item));
      }
      else
      {
        suma.Add(elfo.Sum());
        elfo = new List<int>();
      }
    }

    Console.WriteLine("\nRepuesta Parte 1:");
    Console.WriteLine(suma.Max());

    Parte2(suma);
  }

  void Parte2(List<int> sumaBocadillos)
  {
    var top3 = sumaBocadillos.OrderByDescending(x => x).Take(3).ToList();

    Console.WriteLine("\nRespuesta Parte 2:");
    Console.WriteLine(top3.Sum());
  }
}