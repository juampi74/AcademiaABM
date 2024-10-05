namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class MateriaNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Materia/";

        // Método estático para obtener todos los Materias
        public async static Task<IEnumerable<Materia>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Materias
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Materia
            var data = JsonConvert.DeserializeObject<IEnumerable<Materia>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Materia> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Materia por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Materia
            var data = JsonConvert.DeserializeObject<Materia>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Materia materia)
        {
            // Realizar una solicitud POST a la API para agregar un Materia
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, materia);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, MateriaDTO materiaDTO)
        {
            // Serializar el objeto Materia en formato JSON
            var json = JsonConvert.SerializeObject(materiaDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar una Materia
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Materia materia)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Materia
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{materia.Id_materia}");

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
|  y enviar un objeto Materia en formato JSON como parte del cuerpo de la solicitud.                                    |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Materia se envía al servidor para agregar un nuevo Materia a través de la API.               |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Materia, y se encarga de serializar automáticamente el objeto en formato JSON      |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Materia en formato JSON                |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/