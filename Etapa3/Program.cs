using System;
using CoreEscuela.Entidades;
using static System.Console;
using System.Collections.Generic;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var escuela=new Escuela("Mi escuelita",2010,TiposEscuela.Primaria,
                        ciudad:"Sogamoso", pais:"Colombia");
            escuela.Cursos= new List<Curso>(){
                new Curso{Nombre="101",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="201",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="301",Jornada=TiposJornada.Mañana}
            };
            escuela.Cursos.Add(new Curso(){Nombre="102",Jornada=TiposJornada.Mañana});
            escuela.Cursos.Add(new Curso(){Nombre="202",Jornada=TiposJornada.Tarde});
            
            var otraColeccion=new List<Curso>(){
                new Curso{Nombre="103",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="501",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="501",Jornada=TiposJornada.Tarde}
            };
            
            
            escuela.Cursos.AddRange(otraColeccion);
            
            ImprimirCursosEscuela(escuela);
   /*         Predicate<Curso> miAlgoritmo = Predicado;
            //predicado
            //escuela.Cursos.RemoveAll(miAlgoritmo);
            
            //delegado
            escuela.Cursos.RemoveAll(delegate(Curso cur)
            {
                return cur.Nombre=="301";
            });
            //lambda
            escuela.Cursos.RemoveAll(cur =>cur.Nombre=="501" && cur.Jornada==TiposJornada.Tarde);
    */

            WriteLine("======================");
            

            ImprimirCursosEscuela(escuela);
            


        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre== "301";
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
