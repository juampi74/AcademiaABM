namespace Negocio
{
    using System.Text;
    using Newtonsoft.Json;
    
    using Entidades;

    public class UsuarioNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Usuario/";

        public async static Task<IEnumerable<Usuario>> GetAll()
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);
            var data = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(response);
            return data;
        }

        public async static Task<Usuario> GetOne(int id)
        {
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");
            var data = JsonConvert.DeserializeObject<Usuario>(response);
            return data;
        }

        public async static Task<HttpResponseMessage> Add(Usuario usuario)
        {
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, usuario);
            return response;
        }

        public async static Task<HttpResponseMessage> Update(int id, UsuarioDTO usuarioDTO)
        {
            var json = JsonConvert.SerializeObject(usuarioDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);
            return response;
        }

        public async static Task<HttpResponseMessage> Delete(Usuario usuario)
        {
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{usuario.Id_usuario}");
            return response;
        }

        public static Usuario ComprobarUsuarioIngresado(IEnumerable<Usuario> listadoUsuarios, string nombreUsuario, string clave)
        {
            foreach (var usuario in listadoUsuarios)
            {
                if (usuario.Nombre_usuario == nombreUsuario && usuario.Clave == clave)
                {
                    return usuario;
                }
            }

            return null;
        }
    }
}