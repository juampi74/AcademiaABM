namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class InscripcionNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Inscripcion/";

        public async static Task<IEnumerable<Alumno_Inscripcion>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Alumno_Inscripcion>>(response);
            return data;
        }

        public async static Task<Alumno_Inscripcion> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Alumno_Inscripcion>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Alumno_Inscripcion inscripcion)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, inscripcion);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, Alumno_InscripcionDTO inscripcionDTO)
        {
            var json = JsonConvert.SerializeObject(inscripcionDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Alumno_Inscripcion inscripcion)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{inscripcion.Id_inscripcion}");
            return response;
        }

        public async static Task<Dictionary<string, int>> GetInscripcionesPorCurso()
        {
            var inscripciones = await GetAll();
            var cursos = await CursoNegocio.GetAll();
            var resultado = new Dictionary<string, int>();

            foreach (var curso in cursos)
            {
                var cursoIdentificador = $"{curso.Comision.Desc_comision} - {curso.Materia.Desc_materia}";

                var cantidad = inscripciones.Count(ins => ins.Id_curso == curso.Id_curso);
                
                resultado[cursoIdentificador] = cantidad;
            }

            return resultado;
        }

        public async static Task<IEnumerable<Alumno_Inscripcion>> GetInscripcionesPorAlumno(string id_persona)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}Alumno/{id_persona}");
            var data = JsonConvert.DeserializeObject<IEnumerable<Alumno_Inscripcion>>(response);
            return data;
        }

        public async static Task<IEnumerable<Alumno_Inscripcion>> GetInscripcionesCursosDocente(string id_persona)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}Docente/{id_persona}");
            var data = JsonConvert.DeserializeObject<IEnumerable<Alumno_Inscripcion>>(response);
            return data;
        }
    }
}