using System.Collections.Generic;
using CoreEscuela.Entidades;
using System;
using System.Linq;
namespace CoreEscuela.App
{
    public  class Reporteador
    {
        Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> dic)
        {
            if(dic==null)
                throw new ArgumentNullException(nameof(dic));
                _diccionario=dic;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluación,
                                                out IEnumerable<ObjetoEscuelaBase> lista ))
            {
                return lista.Cast<Evaluación>();
            }
            {
                return new List<Evaluación>();
            }
            
            
        }


        public IEnumerable<string> GetListaAsignatura()
        {
            

            return  GetListaAsignatura(out var dummy);
            
        }

        public IEnumerable<string> GetListaAsignatura(
            out IEnumerable<Evaluación> listaEvaluaciones)
        {
            listaEvaluaciones= GetListaEvaluaciones();

            return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
            
        }

        public Dictionary<string,IEnumerable<Evaluación>> GetListaEvPorAsignatura()
        {
            var dicRta= new Dictionary<string,IEnumerable<Evaluación>>();
            var listaAsig= GetListaAsignatura(out var listaEv);
            foreach (var asignatura in listaAsig)
            {
                var evalAsig= from eval in listaEv
                                where eval.Asignatura.Nombre==asignatura
                                select eval;
                dicRta.Add(asignatura,evalAsig);
            }
            
            return dicRta;
        }

        public Dictionary<string, IEnumerable<object>> GetPromedioPorAsignatura()
        {
            var rta= new Dictionary<string, IEnumerable<object>>();
            var dicEvalxAsig= GetListaEvPorAsignatura();

            foreach (var asigEv in dicEvalxAsig)
            {
                var promsAlum= from eval in asigEv.Value
                            group eval by new{
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into groupEvalsAlumno
                            select new AlumnoPromedio
                            {   alumnoId=groupEvalsAlumno.Key.UniqueId,
                                alumnoNombre= groupEvalsAlumno.Key.Nombre,
                                promedio = groupEvalsAlumno.Average(evalucacion => evalucacion.nota)
                            };
                rta.Add(asigEv.Key,promsAlum);
            }
            return rta;
        }
    }
}