using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2022;

public class Day5_2022
{
  public void Run()
  {
    Console.WriteLine("Ingresa los stacks sin los numeros, al terminar escribe BREAK");
    List<string> auxStacks = new List<string>();
    string[][] stacks1 = new string[40][];
    string[][] stacks2 = new string[40][];
    string input;

    while (true)
    {
      //Remplazamos los espacios blancos de 3 por un 0 con corchetes [0]
      //de esta manera podemos saber que ese espacio esta en blanco
      input = Console.ReadLine().Replace("    ", "[0]");

      if (input != "BREAK")
      {
        //Quitamos todos los corchetes
        Regex reg = new Regex(@"[^a-zA-Z0-9]+");
        var quitarCochetes = reg.Replace(input, "");

        auxStacks.Add(quitarCochetes);
      }
      else break;
    }

//Recorreremos de la ultima poscion del array al inicio para llenar los stacks
    for (int i = stacks1.Length - 1; i >= 0; i--)
    {
      //Asiganos el spacio interno del array
      stacks1[i] = new string[9];
      stacks2[i] = new string[9];

      if (auxStacks.Count() > 0)
      {
        //Sirve para recorrer el array interno de izquierda a derecha y llenar los stacks de esa fila
        int auxHorizontal = 0;

        //Nos ayuda a saber cual es ultimo indice de la lista
        int auxLastIndexList = auxStacks.Count() - 1;

        foreach (var item in auxStacks[auxLastIndexList])
        {
          if (Char.IsLetter(item))
          {
            stacks1[i][auxHorizontal] = item.ToString();
            stacks2[i][auxHorizontal] = item.ToString();
          }

          auxHorizontal++;
        }

        //Eliminamos la ultima linea del stack
        auxStacks.RemoveAt(auxLastIndexList);
      }
    }

    Console.WriteLine("\nIngresa tus instrucciones, al terminar escribe BREAK");
    List<string> instrucciones = new List<string>();

    while (true)
    {
      input = Console.ReadLine();
      if (input != "BREAK") instrucciones.Add(input);
      else break;
    }

    Parte1(stacks1, instrucciones);
    Parte2(stacks2, instrucciones);
  }

  void Parte1(string[][] stacks1, List<string> instrucciones)
  {
    foreach (var item in instrucciones)
    {
      //Stack de elementos que se van a intercambiar
      List<string> stackCambio = new List<string>();

      //Sirve para obtener solo los numeros de las intruccuines de cambios de posicion
      var splitNumbers = item.Split(" ");

      //[1] Cuantos va a cambiar
      //[3] De Donde va a salir
      //[5] A Donde va a llegar
      var conteoStacksSalida = int.Parse(splitNumbers[1]);
      var filaSalida = int.Parse(splitNumbers[3]) - 1;
      var filaDestino = int.Parse(splitNumbers[5]) - 1;

      //Obtenemos los elementos que vamos a intercambiar
      for (int i = 0; i < stacks1.Length; i++)
      {
        if (conteoStacksSalida > 0)
        {
          if (stacks1[i][filaSalida] != null)
          {
            stackCambio.Insert(0, stacks1[i][filaSalida]);
            stacks1[i][filaSalida] = null;
            conteoStacksSalida--;
          }
        }
        else break;
      }

      //Variable para saber desde que indice insertamos el Stack
      int inicioStackCambio = 0;

      //Obtenemos la posicion
      for (int i = 0; i < stacks1.Length; i++)
      {
        if (stacks1[i][filaDestino] != null)
        {
          inicioStackCambio = i - stackCambio.Count();
          break;
        }
        else
        {
          inicioStackCambio = stacks1.Length - stackCambio.Count();
        }
      }

      //Hacemos del cambio de stack
      for (int i = inicioStackCambio; i < stacks1.Length; i++)
      {
        if (stackCambio.Count() > 0)
        {
          stacks1[i][filaDestino] = stackCambio[0];
          stackCambio.RemoveAt(0);
        }
        else break;
      }
    }

    int auxColum = 0;
    string respuesta = "";

    while (auxColum < 9)
    {
      for (int i = 0; i < stacks1.Length; i++)
      {
        var valor = stacks1[i][auxColum];

        if (valor != null)
        {
          respuesta += valor;
          break;
        }
      }

      auxColum++;
    }

    Console.WriteLine("\nRespuesta Parte1: ");
    Console.WriteLine(respuesta);
  }

  void Parte2(string[][] stacks2, List<string> instrucciones)
  {
    foreach (var item in instrucciones)
    {
      //Stack de elementos que se van a intercambiar
      List<string> stackCambio2 = new List<string>();

      //Sirve para obtener solo los numeros de las intruccuines de cambios de posicion
      var splitNumbers = item.Split(" ");

      //[1] Cuantos va a cambiar
      //[3] De Donde va a salir
      //[5] A Donde va a llegar
      var conteoStacksSalida = int.Parse(splitNumbers[1]);
      var filaSalida = int.Parse(splitNumbers[3]) - 1;
      var filaDestino = int.Parse(splitNumbers[5]) - 1;

      //Obtenemos los elementos que vamos a intercambiar
      for (int i = 0; i < stacks2.Length; i++)
      {
        if (conteoStacksSalida > 0)
        {
          if (stacks2[i][filaSalida] != null)
          {
            stackCambio2.Add(stacks2[i][filaSalida]);
            stacks2[i][filaSalida] = null;
            conteoStacksSalida--;
          }
        }
        else break;
      }

      //Variable para saber desde que indice insertamos el Stack
      int inicioStackCambio = 0;

      //Obtenemos la posicion
      for (int i = 0; i < stacks2.Length; i++)
      {
        if (stacks2[i][filaDestino] != null)
        {
          inicioStackCambio = i - stackCambio2.Count();
          break;
        }
        else
        {
          inicioStackCambio = stacks2.Length - stackCambio2.Count();
        }
      }

      //Hacemos del cambio de stack
      for (int i = inicioStackCambio; i < stacks2.Length; i++)
      {
        if (stackCambio2.Count() > 0)
        {
          stacks2[i][filaDestino] = stackCambio2[0];
          stackCambio2.RemoveAt(0);
        }
        else break;
      }
    }

    int auxColum = 0;
    string respuesta = "";

    while (auxColum < 9)
    {
      for (int i = 0; i < stacks2.Length; i++)
      {
        var valor = stacks2[i][auxColum];

        if (valor != null)
        {
          respuesta += valor;
          break;
        }
      }

      auxColum++;
    }

    Console.WriteLine("\nRespuesta Parte2: ");
    Console.WriteLine(respuesta);
  }
}