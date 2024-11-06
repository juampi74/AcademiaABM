namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class ComisionNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Comision/";

        public async static Task<IEnumerable<Comision>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Comision>>(response);
            return data;
        }

        public async static Task<Comision> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Comision>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Comision comision)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, comision);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, ComisionDTO comisionDTO)
        {
            var json = JsonConvert.SerializeObject(comisionDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Comision comision)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{comision.Id_comision}");
            return response;
        }
    }
}