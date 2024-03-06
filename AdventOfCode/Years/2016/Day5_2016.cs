using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Years._2016;

public class Day5_2016
{
  //TODO: Pending performance improvements

  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = Console.ReadLine();

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  private static void Parte1(string rompecabezas)
  {
    var j = 1;
    var contrasena = "";

    var s = new StringBuilder(rompecabezas);

    for (var i = 0; i < 8; i++)
    {
      while (!GetMD5Hash(s.ToString()).StartsWith("00000"))
      {
        s = new StringBuilder(rompecabezas);

        j++;

        s.Append(j);
      }

      s = new StringBuilder(rompecabezas).Append(j + 1);

      contrasena += GetMD5Hash($"{rompecabezas}{j}").Substring(5,1);
    }

    Console.WriteLine("\nRespuesta Parte 1: ");
    Console.WriteLine(contrasena);
  }

  private static void Parte2(string rompecabezas)
  {
    var j = 1;
    var contrasena = new List<string>() { "", "", "", "", "", "", "", "" };

    var  s = new StringBuilder(rompecabezas);

    while(contrasena.Exists(x => x.Equals("")))
    {
      while (!GetMD5Hash(s.ToString()).StartsWith("00000"))
      {
        s = new StringBuilder(rompecabezas);

        j++;

        s.Append(j);
      }

      s = new StringBuilder(rompecabezas).Append(j + 1);

      var posicion = GetMD5Hash($"{rompecabezas}{j}").Substring(5, 1);
      var charPassword = GetMD5Hash($"{rompecabezas}{j}").Substring(6, 1);

      if (char.IsNumber(char.Parse(posicion)) && int.Parse(posicion) < 8 && contrasena[int.Parse(posicion)].Equals(""))
      {
        contrasena[int.Parse(posicion)] = charPassword;
      }
    }

    Console.WriteLine("\nRespuesta Parte 2: ");
    contrasena.ForEach(Console.Write);
  }

  static string GetMD5Hash(String input)
  {
    var bs = Encoding.UTF8.GetBytes(input);
    bs = MD5.HashData(bs);
    var s = new StringBuilder();
    foreach (var b in bs)
    {
      s.Append(b.ToString("x2").ToLower());
    }

    var hash = s.ToString();
    return hash;
  }
}