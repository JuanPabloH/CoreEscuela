using System.Collections.Generic;
using System;
using CoreEscuela.util;

namespace  CoreEscuela.Entidades
{
    public class Escuela: ObjetoEscuelaBase, ILugar
    {

        public int AñoCreacion{get;set;}
        public string Pais{get;set;}
        public string Ciudad{get;set;}

        public string Direccion{get; set;}
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
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DibujarLinea();
            Console.WriteLine("Limpiando Escuela");
            
            foreach (var curso in Cursos)
            {
                curso.LimpiarLugar();
            }
            Printer.EscribirTitulo($"{Nombre} limpia");
            Printer.Beep(1000,cantidad:3);
        }
    }
    
}