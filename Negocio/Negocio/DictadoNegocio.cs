namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class DictadoNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Dictado/";

        // Método estático para obtener todos los Dictados
        public async static Task<IEnumerable<Docente_Curso>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Dictados
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Dictado
            var data = JsonConvert.DeserializeObject<IEnumerable<Docente_Curso>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Docente_Curso> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Dictado por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Dictado
            var data = JsonConvert.DeserializeObject<Docente_Curso>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Boolean> Add(Docente_Curso dictado)
        {
            // Realizar una solicitud POST a la API para agregar un Dictado
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, dictado);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(int id, Docente_CursoDTO dictadoDTO)
        {
            // Serializar el objeto Dictado en formato JSON
            var json = JsonConvert.SerializeObject(dictadoDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar un Dictado
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Delete(Docente_Curso dictado)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Dictado
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{dictado.Id_dictado}");

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }
    }
}

/*
 -----------------------------------------------------------------------------------------------------------------------
|-------------------------------------------------  PostAsJsonAsync  ---------------------------------------------------|
|-----------------------------------------------------------------------------------------------------------------------|
|  El método PostAsJsonAsync se utiliza en el método Add para realizar una solicitud POST a la API                      |
|  y enviar un objeto Dictado en formato JSON como parte del cuerpo de la solicitud.                                      |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Dictado se envía al servidor para agregar un nuevo Dictado a través de la API.                   |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Dictado, y se encarga de serializar automáticamente el objeto en formato JSON        |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Dictado en formato JSON                  |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/