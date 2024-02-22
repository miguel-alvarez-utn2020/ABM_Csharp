namespace ClassLibraryEntidades
{
    public abstract class Persona
    {
        protected string nombre;
        protected string documento;


        protected Persona(string nombre, string documento)
        {
            this.nombre = nombre;
            this.documento = documento;
        }

        public virtual string Saludar() 
        {
            return $"Hola {this.nombre}";
        
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }

        }
    }
}
