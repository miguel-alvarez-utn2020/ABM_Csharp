using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntidades
{
    public class Alumno : Persona
    {
        private int _id = 0;
        private bool _activo = false;
        public Alumno(string nombre, string documento, int id) : base(nombre, documento)
        {
            _id = id;
            _activo = true;
        }

        public override string Saludar()
        {
            return base.Saludar();
        }

        public string Saludar(string mensaje)
        {
            return $"{base.Saludar()}, {mensaje}";
        }
        public int Id 
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }


    }
}
