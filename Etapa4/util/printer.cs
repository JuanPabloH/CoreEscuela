using static System.Console;
using System;
namespace CoreEscuela.util
{
    public static class Printer
    {
        public static void DibujarLinea(int tam=10)
        {               
            WriteLine("".PadLeft(tam,'='));
        }

        public static void EscribirTitulo(string titulo)
        {     
            var tam= titulo.Length+4;
            DibujarLinea(tam);
            WriteLine($"| {titulo} |");
            DibujarLinea(tam);
        }

        public static void Beep(int hz=2000, int tiempo=500, int cantidad=1)
        {
            while (cantidad-->0)
            {
                Console.Beep(hz,tiempo);

            }

        }
    }
}