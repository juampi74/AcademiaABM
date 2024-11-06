namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class PlanNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Plan/";

        public async static Task<IEnumerable<Plan>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Plan>>(response);
            return data;
        }

        public async static Task<Plan> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Plan>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Plan plan)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, plan);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, PlanDTO planDTO)
        {
            var json = JsonConvert.SerializeObject(planDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Plan plan)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{plan.Id_plan}");
            return response;
        }
    }
}