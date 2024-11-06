namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class DictadoNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Dictado/";

        public async static Task<IEnumerable<Docente_Curso>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Docente_Curso>>(response);
            return data;
        }

        public async static Task<Docente_Curso> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Docente_Curso>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Docente_Curso dictado)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, dictado);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, Docente_CursoDTO dictadoDTO)
        {
            var json = JsonConvert.SerializeObject(dictadoDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Docente_Curso dictado)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{dictado.Id_dictado}");
            return response;
        }
    }
}