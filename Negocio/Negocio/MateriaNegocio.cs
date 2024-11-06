namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class MateriaNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Materia/";

        public async static Task<IEnumerable<Materia>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Materia>>(response);
            return data;
        }

        public async static Task<Materia> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Materia>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, materia);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, MateriaDTO materiaDTO)
        {
            var json = JsonConvert.SerializeObject(materiaDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Materia materia)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{materia.Id_materia}");
            return response;
        }

        public async static Task<IEnumerable<Materia>> GetMateriasParaComision(string id_comision)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}Comision/{id_comision}");
            var data = JsonConvert.DeserializeObject<IEnumerable<Materia>>(response);
            return data;
        }
    }
}