using System;
namespace CoreEscuela.Entidades
{
    public class Curso
    {
     public string UniqueId { get; private set; }
     public string Nombre { get; set; }  
     public TiposJornada TiposJornada { get; set; } 
    
     public Curso()=>UniqueId= Guid.NewGuid().ToString();

    }
}