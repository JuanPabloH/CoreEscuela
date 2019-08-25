using System;
using System.Collections.Generic;
namespace CoreEscuela.Entidades
{
    public class Curso: ObjetoEscuelaBase
    {
     public TiposJornada Jornada { get; set; } 
    
    public List<Asignatura> Asignatura{get;set;}
    public List<Alumno> Alumno{get;set;}
     

    }
}