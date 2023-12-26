namespace AdventOfCode.Years._2022;

public class Day4_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas, escribe BREAK");
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
    int respuesta = 0;

    foreach (var item in parte1)
    {
      var split = item.Split(new char[] { ',', '-' }).Select(x => int.Parse(x)).ToArray();

      var rango1 = Enumerable.Range(split[0], split[1] - split[0] + 1);
      var rango2 = Enumerable.Range(split[2], split[3] - split[2] + 1);

      var conteo = rango1.Intersect(rango2).Count();

      if (conteo == rango1.Count() || conteo == rango2.Count()) respuesta++;
    }

    Console.WriteLine("\nRespuesta Parte 1:");
    Console.WriteLine(respuesta);
  }

  void Parte2(List<string> parte2)
  {
    int respuesta = 0;

    foreach (var item in parte2)
    {
      var split = item.Split(new char[] { ',', '-' }).Select(x => int.Parse(x)).ToArray();

      var rango1 = Enumerable.Range(split[0], split[1] - split[0] + 1);
      var rango2 = Enumerable.Range(split[2], split[3] - split[2] + 1);

      var conteo = rango1.Intersect(rango2).Count();

      if (conteo != 0) respuesta++;
    }

    Console.WriteLine("\nRespuesta Parte 2:");
    Console.WriteLine(respuesta);
  }
}