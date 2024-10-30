namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class PersonaNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Persona/";

        // Método estático para obtener todos los Personas
        public async static Task<IEnumerable<Persona>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Personas
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Persona
            var data = JsonConvert.DeserializeObject<IEnumerable<Persona>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Persona> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Persona por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Persona
            var data = JsonConvert.DeserializeObject<Persona>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Persona persona)
        {
            // Realizar una solicitud POST a la API para agregar un Persona
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, persona);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, PersonaDTO personaDTO)
        {
            // Serializar el objeto Persona en formato JSON
            var json = JsonConvert.SerializeObject(personaDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar una Persona
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Persona persona)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Persona
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{persona.Id_persona}");

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response;
        }

        public async static Task<Dictionary<string, int>> GetAlumnosPorPlan()
        {
            var alumnos = (await GetAll()).Where(per => per.Tipo_persona == 0).ToList();
            var planes = await PlanNegocio.GetAll();
            var resultado = new Dictionary<string, int>();

            foreach (var plan in planes)
            {
                var planIdentificador = $"{plan.Especialidad.Desc_especialidad} - {plan.Desc_plan}";

                var cantidad = alumnos.Count(alu => alu.Id_plan == plan.Id_plan);

                resultado[planIdentificador] = cantidad;
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
|  y enviar un objeto Persona en formato JSON como parte del cuerpo de la solicitud.                                    |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Persona se envía al servidor para agregar un nuevo Persona a través de la API.               |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Persona, y se encarga de serializar automáticamente el objeto en formato JSON      |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Persona en formato JSON                |
|  a través de una solicitud POST a la API.                                                                             |
 -----------------------------------------------------------------------------------------------------------------------
*/