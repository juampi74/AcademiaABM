namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class CursoNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Curso/";

        // Método estático para obtener todos los Cursos
        public async static Task<IEnumerable<Curso>> GetAll()
        {
           var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
           var data = JsonConvert.DeserializeObject<IEnumerable<Curso>>(response);
           return data;
        }

        public async static Task<Curso> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Curso por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Curso
            var data = JsonConvert.DeserializeObject<Curso>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Curso curso)
        {
            // Realizar una solicitud POST a la API para agregar un Curso
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, curso);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, CursoDTO cursoDTO)
        {
            // Serializar el objeto Curso en formato JSON
            var json = JsonConvert.SerializeObject(cursoDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar un Curso
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Curso curso)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Curso
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{curso.Id_curso}");

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }
    }
}

/*
 -----------------------------------------------------------------------------------------------------------------------
|-------------------------------------------------  PostAsJsonAsync  ---------------------------------------------------|
|-----------------------------------------------------------------------------------------------------------------------|
|  El método PostAsJsonAsync se utiliza en el método Add para realizar una solicitud POST a la API                      |
|  y enviar un objeto Curso en formato JSON como parte del cuerpo de la solicitud.                                      |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Curso se envía al servidor para agregar un nuevo Curso a través de la API.                   |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Curso, y se encarga de serializar automáticamente el objeto en formato JSON        |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Curso en formato JSON                  |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/