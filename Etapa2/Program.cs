using System;
using CoreEscuela.Entidades;
using static System.Console;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var escuela=new Escuela("Mi escuelita",2010,TiposEscuela.Primaria,
                        ciudad:"Sogamoso", pais:"Colombia");
            
            escuela.Cursos= new Curso[]{
                new Curso{Nombre="101"},
                new Curso{Nombre="201"},
                new Curso{Nombre="301"}
            };
            
            ImprimirCursosEscuela(escuela);
            


        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("==============================");
            WriteLine("Cursos de la escuela");
            WriteLine("==============================");
            
            if (escuela?.Cursos!=null)
            {
               foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} , {curso.UniqueId}");
                } 
            }
            
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int i=0;
            while (i<arregloCursos.Length)
            {
                WriteLine($"{arregloCursos[i].Nombre} , {arregloCursos[i].UniqueId}");
                i++;
            }
        }
        private static void ImprimirCursoDosWhile(Curso[] arregloCursos)
        {
            int i=0;
            do
            {
                WriteLine($"{arregloCursos[i].Nombre} , {arregloCursos[i].UniqueId}");
                i++;
            }while (i<arregloCursos.Length);
        }


        private static void ImprimirCursoFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                WriteLine($"{arregloCursos[i].Nombre} , {arregloCursos[i].UniqueId}");
            }
        }


        private static void ImprimirCursoForeach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                WriteLine($"{curso.Nombre} , {curso.UniqueId}");
            }
        }
    }
}
