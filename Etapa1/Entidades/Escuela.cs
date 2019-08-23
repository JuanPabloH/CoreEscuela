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
        


        public Escuela(string nombre, int año)=>(Nombre,AñoCreacion)=(nombre,año);
    }
    
}