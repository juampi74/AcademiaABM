namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class InscripcionNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Inscripcion/";

        // Método estático para obtener todos las Inscripciones
        public async static Task<IEnumerable<Alumno_Inscripcion>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de las Inscripciones
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Inscripcion
            var data = JsonConvert.DeserializeObject<IEnumerable<Alumno_Inscripcion>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Alumno_Inscripcion> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Inscripcion por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Inscripcion
            var data = JsonConvert.DeserializeObject<Alumno_Inscripcion>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Alumno_Inscripcion inscripcion)
        {
            // Realizar una solicitud POST a la API para agregar una Inscripcion
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, inscripcion);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, Alumno_InscripcionDTO inscripcionDTO)
        {
            // Serializar el objeto Inscripcion en formato JSON
            var json = JsonConvert.SerializeObject(inscripcionDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar una Inscripcion
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Alumno_Inscripcion inscripcion)
        {
            // Realizar una solicitud DELETE a la API para eliminar una Inscripcion
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{inscripcion.Id_inscripcion}");

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<Dictionary<string, int>> GetInscripcionesPorCurso()
        {
            var inscripciones = await GetAll(); // Obtén todas las inscripciones
            var cursos = await CursoNegocio.GetAll(); // Obtén todos los cursos
            var resultado = new Dictionary<string, int>();

            // Mapea cada curso con su respectiva cantidad de inscripciones
            foreach (var curso in cursos)
            {
                var cursoIdentificador = $"{curso.Comision.Desc_comision} - {curso.Materia.Desc_materia}";

                var cantidad = inscripciones.Count(ins => ins.Id_curso == curso.Id_curso); // Asegúrate de que Id_curso está en Alumno_Inscripcion
                
                resultado[cursoIdentificador] = cantidad;
            }

            return resultado;
        }
    }
}

/*
 -----------------------------------------------------------------------------------------------------------------------
|-------------------------------------------------  PostAsJsonAsync  ---------------------------------------------------|
|-----------------------------------------------------------------------------------------------------------------------|
|  El método PostAsJsonAsync se utiliza en el método Add para realizar una solicitud POST a la API                      |
|  y enviar un objeto Inscripcion en formato JSON como parte del cuerpo de la solicitud.                                      |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Inscripcion se envía al servidor para agregar un nuevo Inscripcion a través de la API.                   |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Inscripcion, y se encarga de serializar automáticamente el objeto en formato JSON        |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Inscripcion en formato JSON                  |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/