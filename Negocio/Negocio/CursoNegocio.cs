namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class CursoNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Curso/";

        public async static Task<IEnumerable<Curso>> GetAll()
        {
           var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
           var data = JsonConvert.DeserializeObject<IEnumerable<Curso>>(response);
           return data;
        }

        public async static Task<Curso> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Curso>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Curso curso)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, curso);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, CursoDTO cursoDTO)
        {
            var json = JsonConvert.SerializeObject(cursoDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Curso curso)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{curso.Id_curso}");
            return response;
        }

        public async static Task<IEnumerable<Curso>> GetCursosParaPersona(string id_persona)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}Persona/{id_persona}");
            var data = JsonConvert.DeserializeObject<IEnumerable<Curso>>(response);
            return data;
        }
    }
}