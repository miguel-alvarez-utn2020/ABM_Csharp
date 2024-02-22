using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntidades
{
    public interface ICrudAlumno
    {
        Alumno Crear(string nombre, string documento);

        Alumno ReadOne(int id);

        List<Alumno> ReadAll();




        void Update(int id, string nombre, string documento);

        void Delete(int id);




    }
}