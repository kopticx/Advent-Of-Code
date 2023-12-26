namespace AdventOfCode.Years._2022;

public class Day2_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa tu rompecabezas, al temrinar escribe BREAK");

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
    var split = parte1.Select(x => x.Split(" ")).ToList();
    int puntucacion = 0;

    //A o X Piedra
    //B o Y Papel
    //C o Z Tijera

    foreach (var item in split)
    {
        switch (item[1])
        {
            case "X":
                puntucacion++;
                if (item[0] == "C") puntucacion += 6;
                else if (item[0] == "A") puntucacion += 3;
                break;

            case "Y":
                puntucacion += 2;
                if (item[0] == "A") puntucacion += 6;
                else if (item[0] == "B") puntucacion += 3;
                break;

            case "Z":
                puntucacion += 3;
                if (item[0] == "B") puntucacion += 6;
                else if (item[0] == "C") puntucacion += 3;
                break;
        }
    }

    Console.WriteLine("\nRespuesta Parte 1:");
    Console.WriteLine(puntucacion);
}

void Parte2(List<string> parte2)
{
    var split = parte2.Select(x => x.Split(" ")).ToList();
    int puntucacion = 0;

    //A o X Piedra == 1
    //B o Y Papel == 2
    //C o Z Tijera == 3

    //X == Perder == 1
    //Y == Empate == 3
    //Z == Ganar == 6

    foreach (var item in split)
    {
        switch (item[1])
        {
            case "X":
                if (item[0] == "C") puntucacion += 2;
                else if (item[0] == "B") puntucacion += 1;
                else if (item[0] == "A") puntucacion += 3;
                break;

            case "Y":
                puntucacion += 3;
                if (item[0] == "C") puntucacion += 3;
                else if (item[0] == "B") puntucacion += 2;
                else if (item[0] == "A") puntucacion += 1;
                break;

            case "Z":
                puntucacion += 6;
                if (item[0] == "C") puntucacion += 1;
                else if (item[0] == "B") puntucacion += 3;
                else if (item[0] == "A") puntucacion += 2;
                break;
        }
    }

    Console.WriteLine("\nRespuesta Parte 2:");
    Console.WriteLine(puntucacion);
}
}