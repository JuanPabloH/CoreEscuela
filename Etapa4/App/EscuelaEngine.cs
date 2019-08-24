using CoreEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela{get;set;}

        public EscuelaEngine()
        {
            
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Mi escuelita", 2010, TiposEscuela.Primaria,
                                    ciudad: "Sogamoso", pais: "Colombia");

            CargarCursos();
            
           
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsiganturas = new List<Asignatura>(){
                    new Asignatura{Nombre="Matematicas"},
                    new Asignatura{Nombre="Edu. Fisica"},
                    new Asignatura{Nombre="Castellano"},
                    new Asignatura{Nombre="Ciencias Naturales"},
                    new Asignatura{Nombre="Artes"}
                };
                curso.Asignatura=listaAsiganturas;
            }
        }

        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string [] nombre1={"Alba","Juan","Viviana","Slendy","Laura","Crisito","Pablo"};
            string [] nombre2={"Pedra","Pabla","Jose","Felipe","Andres","Manuel","Eusebio"};
            string [] apellido={"Herrera","Rodriguez","Stark","Rogers","Carter","Petro","Jeje"};

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from ap in apellido
                                select new Alumno{Nombre=$"{n1} {n2} {ap}"};
            return listaAlumnos.OrderBy((alum)=> alum.UniqueId).Take(cantidad).ToList();
            
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso{Nombre="101",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="201",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="301",Jornada=TiposJornada.Mañana},
                new Curso{Nombre="103",Jornada=TiposJornada.Tarde},
                new Curso{Nombre="501",Jornada=TiposJornada.Tarde}
            };
            Random rnd= new Random();
            
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom= rnd.Next(5,20);
                curso.Alumno=GenerarAlumnos(cantRandom);
            }
        }
    }

}