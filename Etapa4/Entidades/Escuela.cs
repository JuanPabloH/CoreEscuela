using System.Collections.Generic;

namespace  CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;
        public string Nombre{
            get{return nombre;}
            set{nombre=value.ToUpper();}
        }

        public int AñoCreacion{get;set;}
        public string Pais{get;set;}
        public string Ciudad{get;set;}
        public TiposEscuela TipoEscuela{get;set;}

        public List<Curso> Cursos { get; set; }


        public Escuela(string nombre, int año)=>(Nombre,AñoCreacion)=(nombre,año);

        public Escuela(string nombre, int año, 
                        TiposEscuela tipo, string pais="",
                        string ciudad ="")
        {
            (Nombre,AñoCreacion)=(nombre,año);
            Pais=pais;
            Ciudad=ciudad;
        }

        public override string ToString()
        {
            return $"Nombre: \"{nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
    
}