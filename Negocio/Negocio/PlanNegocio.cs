namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class PlanNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Plan/";

        // Método estático para obtener todos los Plans
        public async static Task<IEnumerable<Plan>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Planes
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Plan
            var data = JsonConvert.DeserializeObject<IEnumerable<Plan>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Plan> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Plan por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Plan
            var data = JsonConvert.DeserializeObject<Plan>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Boolean> Add(Plan plan)
        {
            // Realizar una solicitud POST a la API para agregar un Plan
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, plan);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(int id, PlanDTO planDTO)
        {
            // Serializar el objeto Plan en formato JSON
            var json = JsonConvert.SerializeObject(planDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar un Plan
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Delete(Plan plan)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Plan
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{plan.Id_plan}");

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
|  y enviar un objeto Plan en formato JSON como parte del cuerpo de la solicitud.                                       |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Plan se envía al servidor para agregar un nuevo Plan a través de la API.                     |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Plan, y se encarga de serializar automáticamente el objeto en formato JSON         |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Plan en formato JSON                   |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/