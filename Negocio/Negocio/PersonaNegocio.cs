namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class PersonaNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Persona/";

        public async static Task<IEnumerable<Persona>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Persona>>(response);
            return data;
        }

        public async static Task<Persona> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Persona>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Persona persona)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, persona);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, PersonaDTO personaDTO)
        {
            var json = JsonConvert.SerializeObject(personaDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Persona persona)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{persona.Id_persona}");
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