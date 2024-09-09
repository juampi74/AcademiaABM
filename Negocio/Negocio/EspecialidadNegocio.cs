namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class EspecialidadNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Especialidad/";

        // Método estático para obtener todos los Especialidads
        public async static Task<IEnumerable<Especialidad>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Especialidades
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Especialidad
            var data = JsonConvert.DeserializeObject<IEnumerable<Especialidad>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Especialidad> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Especialidad por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Especialidad
            var data = JsonConvert.DeserializeObject<Especialidad>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Boolean> Add(Especialidad especialidad)
        {
            // Realizar una solicitud POST a la API para agregar un Especialidad
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, especialidad);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(int id, EspecialidadDTO especialidadDTO)
        {
            // Serializar el objeto Especialidad en formato JSON
            var json = JsonConvert.SerializeObject(especialidadDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar una Especialidad
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }
        
        public async static Task<Boolean> Delete(Especialidad especialidad)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Especialidad
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{especialidad.Id_especialidad}");

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
|  y enviar un objeto Especialidad en formato JSON como parte del cuerpo de la solicitud.                               |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Especialidad se envía al servidor para agregar un nuevo Especialidad a través de la API.     |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Especialidad, y se encarga de serializar automáticamente el objeto en formato JSON |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Especialidad en formato JSON           |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/