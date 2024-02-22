using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibraryEntidades
{
    public class SerializadorAlumno : ICrudAlumno
    {
        private ICrudAlumno _cliente;
        public SerializadorAlumno(ICrudAlumno cliente) 
        {
            _cliente = cliente;
        }

        public Alumno Crear(string nombre, string documento)
        {
            Alumno nuevoAlumno = _cliente.Crear(nombre, documento);
            return nuevoAlumno;
        }

        public void Delete(int id)
        {
            _cliente.Delete(id);
        }

        public List<Alumno> ReadAll()
        {
            List<Alumno> list = _cliente.ReadAll();

            return list;
        }

        public Alumno ReadOne(int id)
        {
            Alumno alumno = _cliente.ReadOne(id);
            return alumno;
        }


        public void Update(int id, string nombre, string documento)
        {
            _cliente.Update(id, nombre, documento);
        }

    }
}
