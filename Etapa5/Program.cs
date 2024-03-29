﻿using System;
using CoreEscuela.Entidades;
using static System.Console;
using System.Collections.Generic;
using CoreEscuela.util;
using System.Linq;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AcciondelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o,s)=> Printer.Beep(100,100,1);
            var engine= new EscuelaEngine();
            engine.Inicializar();
            Printer.EscribirTitulo("Bienvenidos a la escuela");
            var reporteador= new Reporteador(engine.GetDiccionarioObjetos());
            var evList= reporteador.GetListaEvaluaciones();
            var asigList= reporteador.GetListaAsignatura();
            var listaEvXAsig=reporteador.GetListaEvPorAsignatura();

            var listaPromXAsig= reporteador.GetPromedioPorAsignatura();
            
            
        }

        
        private static void AcciondelEvento(object sender, EventArgs e)
        {
            Printer.EscribirTitulo("SALIENDO");
            Printer.Beep(3000,1000,3);
            Printer.EscribirTitulo("SALIÓ");
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.EscribirTitulo("Cursos de la escuela");
            
            if (escuela?.Cursos!=null)
            {
               foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"{curso.Nombre} , {curso.UniqueId}");
                } 
            }
            
        }
    }
}
