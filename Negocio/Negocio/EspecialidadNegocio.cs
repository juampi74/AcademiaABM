namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class EspecialidadNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Especialidad/";

        public async static Task<IEnumerable<Especialidad>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Especialidad>>(response);
            return data;
        }

        public async static Task<Especialidad> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Especialidad>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Especialidad especialidad)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, especialidad);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, EspecialidadDTO especialidadDTO)
        {
            var json = JsonConvert.SerializeObject(especialidadDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }
        
        public async static Task<HttpResponseMessage> Delete(Especialidad especialidad)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{especialidad.Id_especialidad}");
            return response;
        }
    }
}