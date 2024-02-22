using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Xml.XPath;

namespace ClassLibraryEntidades
{
    public class ClienteJson : ICrudAlumno
    {

        private string _filePathAlumnos;
        private string _filePathId;
        private int _id;
        private List<Alumno> _listAlumnos = new List<Alumno>();

        public ClienteJson(string path, string pathId)
        {
            _filePathAlumnos = path;
            _filePathId = pathId;
        }

        public Alumno Crear(string nombre, string documento)
        {
            if (!File.Exists(_filePathAlumnos))                
            {
                _id = 1;
            }
            else
            {
                _id++;
            }
            Alumno alumno = new Alumno(nombre, documento, _id);
            _listAlumnos.Add(alumno);
            SaveItems(_listAlumnos);
            return alumno;
        }
        public Alumno? ReadOne(int id)
        {
            if (File.Exists(_filePathAlumnos))
            {
                List<Alumno> listAlumno = Read();
                Alumno? alumnoEncontrado = BuscarPersonaPorId(id, listAlumno);
                return alumnoEncontrado;
            }
            return null;

        }
        public List<Alumno> Read()
        {
            string contenido = File.ReadAllText(_filePathAlumnos);
            List<Alumno>? listaAlumno = JsonConvert.DeserializeObject<List<Alumno>>(contenido);
            return listaAlumno;
        }
        public Alumno? BuscarPersonaPorId(int id, List<Alumno>? listAlumno )
        {   

            foreach(Alumno alumno in listAlumno)
            {
                if(alumno.Id == id)
                {
                    return alumno;
                }
            }
            return null;
        }
        public List<Alumno> ReadAll()
        {

            List<Alumno>? listaAlumno = Read();
            return listaAlumno;
        }


        public void Delete(int id)
        {
            List<Alumno> listAlumno = Read();
            foreach (Alumno alumno in listAlumno)
            {
                if(alumno.Id == id)
                {
                    alumno.Activo = false;
                    SaveItems(listAlumno);
                }
            }



        }





        public void Update(int id, string nombreCorreccion, string documentoCorreccion)
        {
            bool found = false;
            try
            {
                List<Alumno> listAlumno = Read();
                foreach (Alumno alumno in listAlumno)
                {
                    if (alumno.Id == id)
                    {
                        if (nombreCorreccion != string.Empty)
                        {
                            alumno.Nombre = nombreCorreccion;
                        }
                        if (documentoCorreccion != string.Empty)
                        {
                            alumno.Documento = documentoCorreccion;
                        }
                        SaveItems(listAlumno);
                        found = true;
                        break;
                    }
                }
                if( !found )
                    throw new Exception();
            }
            catch(Exception e)
            {
                throw new BadIdReQException("Error al encontrar una Id valida", e);
            }

        }


        private void SaveItems(List<Alumno> alumnos )
        {
            string json = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
            //Console.WriteLine(json);
            File.WriteAllText(_filePathAlumnos, json);
        }

    }
}
