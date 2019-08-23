using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string nombre;
        public string direccion;
        public string ceo;
        public int anhoFundacion;

        public void timbrar()
        {
            Console.Beep(2000, 3000);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola");
            var miEscuela= new Escuela();
            miEscuela.nombre= "Nueva Academia";
            miEscuela.direccion= "Carrera 12 ";
            miEscuela.ceo="Juan Herrera";
            miEscuela.anhoFundacion= 2001;
            Console.WriteLine("Timbre");
            miEscuela.timbrar();
        }
    }
}
