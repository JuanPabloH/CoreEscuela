using System;
using CoreEscuela.Entidades;
namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var escuela=new Escuela("Mi escuelita",2010,TiposEscuela.Primaria,
                        ciudad:"Sogamoso", pais:"Colombia");
            escuela.TipoEscuela= TiposEscuela.Primaria; 
            Console.WriteLine(escuela);
        }
    }
}
