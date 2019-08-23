using System;
using CoreEscuela.Entidades;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var escuela=new Escuela("Mi escuelita",2010);
            escuela.Pais= "Colombia";
            escuela.Ciudad= "Sogamoso";
            Console.WriteLine(escuela.Nombre);
        }
    }
}
