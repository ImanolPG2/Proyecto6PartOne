using System;
class Program
{
    static void Main(string[] args)
    {
        int[] arregloOrdenado = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

        Console.WriteLine("Arreglo ordenado:");
        ImprimirArreglo(arregloOrdenado);

        while (true)
        {
            Console.Write("\nIngrese un número entero para buscar (o 'X' para salir): ");
            string entrada = Console.ReadLine();

            if (entrada.ToUpper() == "X")
            {
                Console.WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                break;
            }

            if (int.TryParse(entrada, out int numeroBuscado))
            {
                int resultado = BusquedaBinaria(arregloOrdenado, numeroBuscado);

                if (resultado != -1)
                {
                    Console.WriteLine($"El número {numeroBuscado} existe en el arreglo en la posición {resultado}.");
                }
                else
                {
                    Console.WriteLine($"El número {numeroBuscado} no existe en el arreglo.");
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero o 'X' para salir.");
            }
        }
    }

    static int BusquedaBinaria(int[] arreglo, int objetivo)
    {
        return BusquedaBinariaRecursiva(arreglo, objetivo, 0, arreglo.Length - 1);
    }

    static int BusquedaBinariaRecursiva(int[] arreglo, int objetivo, int izquierda, int derecha)
    {
        if (izquierda > derecha)
        {
            return -1;
        }

        int medio = izquierda + (derecha - izquierda) / 2;

        if (arreglo[medio] == objetivo)
        {
            return medio;
        }
        else if (arreglo[medio] > objetivo)
        {
            return BusquedaBinariaRecursiva(arreglo, objetivo, izquierda, medio - 1);
        }
        else
        {
            return BusquedaBinariaRecursiva(arreglo, objetivo, medio + 1, derecha);
        }
    }

    static void ImprimirArreglo(int[] arreglo)
    {
        foreach (int numero in arreglo)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();
    }
}