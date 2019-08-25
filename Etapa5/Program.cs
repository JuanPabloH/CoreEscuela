using System;
using CoreEscuela.Entidades;
using static System.Console;
using System.Collections.Generic;
using CoreEscuela.util;
namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine= new EscuelaEngine();
            Printer.EscribirTitulo("Bienvenidos a la escuela");
            //Printer.Beep(10000);
            engine.Inicializar();
            ImprimirCursosEscuela(engine.Escuela);
            var listaObj= engine.GetObjetosEscuela();
            
            
        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre== "301";
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
