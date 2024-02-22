using ClassLibraryEntidades;

namespace ConsoleAppEjemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClienteJson saveToJson = new ClienteJson("DB.json", "DB_ID.json");
            SerializadorAlumno serializer = new SerializadorAlumno(saveToJson);
            List<Alumno> listAlumnos = serializer.ReadAll();
            //Alumno alumnoA = serializer.Crear("Migule", "33288260");
            //Alumno alumnoB = serializer.Crear("Ale", "33288260");
            //Alumno alumnoC = serializer.Crear("Pepe", "33288260");
            //Alumno alumnoD = serializer.Crear("Juan", "33288260");
            //Console.WriteLine(alumnoA.Id);
            //Console.WriteLine(alumnoB.Id);
            //Console.WriteLine(alumnoC.Id);
            //Console.WriteLine(alumnoD.Id);

            //Console.WriteLine(alumnoD.Nombre);

            Alumno alumno1 = serializer.ReadOne(1);
            //foreach(Alumno alumno in listAlumnos)
            //{
            //    Console.WriteLine(alumno.Nombre);
            //    Console.WriteLine(alumno.Activo);
            //}


            //serializer.Delete(4);
            try
            {
                serializer.Update(6, "Dabby", "");

                foreach (Alumno alumno in listAlumnos)
                {
                
                    if ( alumno.Activo != true)
                    {
                        Console.WriteLine($"{ alumno.Activo} Nombre {alumno.Nombre}");
                    }
                
                }
            }
            catch (BadIdReQException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
