namespace AdventOfCode.Years._2022;

public class Day6_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = Console.ReadLine();

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  public void Parte1(string rompecabezas)
  {
    for (int i = 0; i < rompecabezas.Length; i++)
    {
      var startPacketChars = rompecabezas.Skip(i).Take(4);
      var startPacket = string.Join("", startPacketChars);

      var groupPacket = startPacket.GroupBy(x => x).Select(x => x.Count()).ToList();

      if (groupPacket.Count == 4)
      {
        Console.WriteLine("\nRespuesta Parte 1:");
        Console.WriteLine(i + 4);
        break;
      }
    }
  }

  public void Parte2(string rompecabezas)
  {
    for (int i = 0; i < rompecabezas.Length; i++)
    {
      var startPacketChars = rompecabezas.Skip(i).Take(14);
      var startPacket = string.Join("", startPacketChars);

      var groupPacket = startPacket.GroupBy(x => x).Select(x => x.Count()).ToList();

      if (groupPacket.Count == 14)
      {
        Console.WriteLine("\nRespuesta Parte 2:");
        Console.WriteLine(i + 14);
        break;
      }
    }
  }
}