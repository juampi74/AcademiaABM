namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class ComisionNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Comision/";

        // Método estático para obtener todos los Comisions
        public async static Task<IEnumerable<Comision>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Comisiones
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Comision
            var data = JsonConvert.DeserializeObject<IEnumerable<Comision>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Comision> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Comision por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Comision
            var data = JsonConvert.DeserializeObject<Comision>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Boolean> Add(Comision comision)
        {
            // Realizar una solicitud POST a la API para agregar un Comision
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, comision);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(int id, ComisionDTO comisionDTO)
        {
            // Serializar el objeto Comision en formato JSON
            var json = JsonConvert.SerializeObject(comisionDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar una Comision
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Delete(Comision comision)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Comision
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{comision.Id_comision}");

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
|  y enviar un objeto Comision en formato JSON como parte del cuerpo de la solicitud.                                   |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Comision se envía al servidor para agregar un nuevo Comision a través de la API.             |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Comision en formato JSON               |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/