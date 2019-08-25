using System;
using CoreEscuela.Entidades;
using static System.Console;
using System.Collections.Generic;
using CoreEscuela.util;
using System.Linq;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine= new EscuelaEngine();
            Printer.EscribirTitulo("Bienvenidos a la escuela");
            //Printer.Beep(10000);
            ImprimirCursosEscuela(engine.Escuela);

            Dictionary<int,string> diccionario= new Dictionary<int,string>();
            diccionario.Add(10,"Juan");
            diccionario.Add(5,"Vivis");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key} , Valor: {keyValPair.Value}");
            }
            
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.EscribirTitulo("Cursos de la escuela");
            
            if (escuela?.Cursos!=null)
            {
               foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} , {curso.UniqueId}");
                } 
            }
            
        }
    }
}
