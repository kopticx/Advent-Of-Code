namespace AdventOfCode.Years._2017;

public class Day1_2017
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas");
    var rompecabezas = Console.ReadLine();

    var suma = 0;
    string numero;

    for (int i = 0; i < rompecabezas.Length; i++)
    {
      if (i + 1 < rompecabezas.Length)
      {
        if (rompecabezas[i] == rompecabezas[i + 1])
        {
          numero = rompecabezas[i].ToString();

          suma += Int32.Parse(numero);
        }
      }
      else break;
    }

    if (rompecabezas[rompecabezas.Length - 1] == rompecabezas[0])
    {
      numero = rompecabezas[0].ToString();

      suma += Int32.Parse(numero);
    }

    Console.WriteLine("\nLa respuesta es: {0}", suma);
  }

  private static void Parte1(string rompecabezas, int suma)
  {
    var response = 0;

    if (rompecabezas[rompecabezas.Length - 1] == rompecabezas[0])
    {
      var numero = rompecabezas[0].ToString();

      response = suma + Int32.Parse(numero);
    }

    Console.WriteLine("\nResultado 1:");
    Console.WriteLine(response);
  }
}