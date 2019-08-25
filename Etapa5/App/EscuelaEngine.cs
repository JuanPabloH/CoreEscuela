using CoreEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
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


        public Dictionary<string,IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {

            
            var diccionario= new Dictionary<string,IEnumerable<ObjetoEscuelaBase>>();
            diccionario.Add("Escuela",new [] {Escuela} );
            diccionario.Add("Cursos",Escuela.Cursos.Cast<ObjetoEscuelaBase>());




            return diccionario;
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvalicaciones= true,
            bool traeAlumnos= true,
            bool traeAsignaturas= true,
            bool traeCursos= true
            
            )
            {
                return GetObjetosEscuela(out int dummy,out dummy,out dummy,out dummy);
            }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            bool traeEvalicaciones= true,
            bool traeAlumnos= true,
            bool traeAsignaturas= true,
            bool traeCursos= true
            
            )
         {
             return GetObjetosEscuela(out contEvaluaciones,out int dummy,out dummy,out dummy);
         }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contCursos,
            bool traeEvalicaciones= true,
            bool traeAlumnos= true,
            bool traeAsignaturas= true,
            bool traeCursos= true
            
            )
        {
            return GetObjetosEscuela(out contEvaluaciones,out contCursos,out int dummy,out dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contCursos,
            out int contAsignaturas,
            bool traeEvalicaciones= true,
            bool traeAlumnos= true,
            bool traeAsignaturas= true,
            bool traeCursos= true
            
            )
        {
            return GetObjetosEscuela(out contEvaluaciones,out contCursos,out contAsignaturas,out int dummy);
        }
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int contEvaluaciones,
            out int contCursos,
            out int contAsignaturas,
            out int contAlumnos,
            bool traeEvalicaciones= true,
            bool traeAlumnos= true,
            bool traeAsignaturas= true,
            bool traeCursos= true
            
            )
        {
            contAsignaturas=contAlumnos=contEvaluaciones=0;
            
            var listaObj= new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            if (traeCursos)
            {
                listaObj.AddRange(Escuela.Cursos);
            }
            contCursos=Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {   
                contAsignaturas += curso.Asignatura.Count;
                contAlumnos+= curso.Alumno.Count;
                if (traeAsignaturas)
                {
                    listaObj.AddRange(curso.Asignatura);   
                }                
                if (traeAlumnos)
                {
                    listaObj.AddRange(curso.Alumno);
                }
                
                if (traeEvalicaciones)
                {
                    foreach (var alumno in curso.Alumno)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        contEvaluaciones+=alumno.Evaluaciones.Count;
                    }
                }
                
            }
            
            return listaObj.AsReadOnly();
        }


#region Métodos de carga
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
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignatura)
                {
                    foreach (var alumno in curso.Alumno)
                    {
                        var rdn = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev= new Evaluación
                            {
                                Asignatura= asignatura,
                                Nombre= $"{asignatura.Nombre} Ev #{i+1}",
                                nota= (float)(5*rdn.NextDouble()),
                                Alumno=alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
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

       #endregion Métodos de carga 
    
    
    }

}