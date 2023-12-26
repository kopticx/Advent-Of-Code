using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Years._2015;

public class Day4_2015
{
  public static void Start()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var input = Console.ReadLine();

    Solution(input, 5, 1);
    Solution(input, 6, 2);
  }

  private static void Solution(string input, byte numZeros, byte response)
  {
    var s = new StringBuilder(input);
    var i = 1;

    while (!GetMd5Hash(s.ToString()).StartsWith("".PadLeft(numZeros, '0')))
    {
      s = new StringBuilder(input);

      s.Append(i);

      i++;
    }

    Console.WriteLine($"\nResultado {response}:");
    Console.WriteLine(i - 1);
  }

  [Obsolete("Obsolete")]
  private static String GetMd5Hash(String input)
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