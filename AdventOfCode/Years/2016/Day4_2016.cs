namespace AdventOfCode.Years._2016;

public class Day4_2016
{
  public static void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas: ");
    var rompecabezas = new List<string>();

    while (true)
    {
      var input = Console.ReadLine();

      if (input != "BREAK") rompecabezas.Add(input);
      else break;
    }

    Parte1(rompecabezas);
    Parte2(rompecabezas);
  }

  private static void Parte1(List<string> rompecabezas)
  {
    var sumaID = 0;
    var valido = true;

    foreach (var item in rompecabezas)
    {
      var ID = item.Substring(item.Length - 10, 3);
      var verificacion = item.Substring(item.Length - 6, 5);

      var letrasComunes = item.GroupBy(x => x).OrderByDescending(z => z.Count()).ThenBy(j => j.Key).Select(y => y.Key)
        .ToList();
      letrasComunes.RemoveAll(x => x.Equals('-'));
      letrasComunes.RemoveAll(char.IsNumber);
      letrasComunes.RemoveRange(5, letrasComunes.Count - 5);

      for (var i = 0; i < letrasComunes.Count; i++)
      {
        if (letrasComunes[i].Equals(verificacion[i])) valido = true;
        else
        {
          valido = false;
          break;
        }
      }

      if (valido) sumaID += int.Parse(ID);
    }

    Console.WriteLine("\nRespuesta Parte 1: ");
    Console.WriteLine(sumaID);
  }

  private static void Parte2(List<string> rompecabezas)
  {
    var realRooms = new List<string>();
    var valido = true;

    foreach (var item in rompecabezas)
    {
      var verificacion = item.Substring(item.Length - 6, 5);

      var letrasComunes = item.GroupBy(x => x).OrderByDescending(z => z.Count()).ThenBy(j => j.Key).Select(y => y.Key)
        .ToList();
      letrasComunes.RemoveAll(x => x.Equals('-'));
      letrasComunes.RemoveAll(char.IsNumber);
      letrasComunes.RemoveRange(5, letrasComunes.Count - 5);

      for (var i = 0; i < letrasComunes.Count; i++)
      {
        if (letrasComunes[i].Equals(verificacion[i])) valido = true;
        else
        {
          valido = false;
          break;
        }
      }

      if (valido) realRooms.Add(item);
    }

    // a ==  97
    // z == 122

    foreach (var item in realRooms)
    {
      var removeCheckSum = item.Remove(item.Length - 7);
      var sectorID = int.Parse(removeCheckSum.Split('-').Last());
      var roomNameEncripted = String.Join(" ", removeCheckSum.Remove(removeCheckSum.Length - 4).Split('-').ToList());

      var decryptedRoomName = "";

      foreach (var character in roomNameEncripted)
      {
        if (character != ' ')
        {
          var reciduo = sectorID % 26;

          if (Convert.ToInt32(character) + reciduo < 122)
            decryptedRoomName += Convert.ToChar(Convert.ToInt32(character + reciduo));
          else
          {
            var resta = 122 - Convert.ToInt32(character);
            reciduo -= resta;

            decryptedRoomName += Convert.ToChar(Convert.ToInt32(97 + reciduo - 1));
          }
        }
        else
        {
          decryptedRoomName += " ";
        }
      }

      if (decryptedRoomName != "northpole object storage") continue;
      Console.WriteLine("\nRespuesta Parte 2: ");
      Console.WriteLine(sectorID);
      break;
    }
  }
}