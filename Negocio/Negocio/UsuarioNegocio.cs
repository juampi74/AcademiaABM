namespace Negocio
{
    using Newtonsoft.Json;
    using Entidades;
    using System.Text;

    public class UsuarioNegocio
    {
        static readonly string defaultURL = "https://localhost:7111/api/Usuario/";

        // Método estático para obtener todos los Usuarios
        public async static Task<IEnumerable<Usuario>> GetAll()
        {
            // Realizar una solicitud GET a la API para obtener los datos de los Usuarios
            var response = await Conexion.Instancia.Cliente.GetStringAsync(defaultURL);

            // Deserializar la respuesta JSON en una colección de objetos Usuario
            var data = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Usuario> GetOne(int id)
        {
            // Realizar una solicitud GET a la API para obtener los datos de un Usuario por su ID
            var response = await Conexion.Instancia.Cliente.GetStringAsync($"{defaultURL}{id}");

            // Deserializar la respuesta JSON en un objeto Usuario
            var data = JsonConvert.DeserializeObject<Usuario>(response);

            // Devolver los datos obtenidos
            return data;
        }

        public async static Task<Boolean> Add(Usuario usuario)
        {
            // Realizar una solicitud POST a la API para agregar un Usuario
            var response = await Conexion.Instancia.Cliente.PostAsJsonAsync(defaultURL, usuario);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Update(int id, UsuarioDTO usuarioDTO)
        {
            // Serializar el objeto Usuario en formato JSON
            var json = JsonConvert.SerializeObject(usuarioDTO);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realizar una solicitud PATCH a la API para actualizar un Usuario
            var response = await Conexion.Instancia.Cliente.PatchAsync($"{defaultURL}{id}", content);

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public async static Task<Boolean> Delete(Usuario usuario)
        {
            // Realizar una solicitud DELETE a la API para eliminar un Usuario
            var response = await Conexion.Instancia.Cliente.DeleteAsync($"{defaultURL}{usuario.Id_usuario}");

            // Devolver verdadero si la solicitud fue exitosa, falso en caso contrario
            return response.IsSuccessStatusCode;
        }

        public static bool ComprobarUsuarioIngresado(IEnumerable<Usuario> listadoUsuarios, string nombreUsuario, string clave)
        {
            foreach (var usuario in listadoUsuarios)
            {
                if (usuario.Nombre_usuario == nombreUsuario && usuario.Clave == clave)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

/*
 -----------------------------------------------------------------------------------------------------------------------
|-------------------------------------------------  PostAsJsonAsync  ---------------------------------------------------|
|-----------------------------------------------------------------------------------------------------------------------|
|  El método PostAsJsonAsync se utiliza en el método Add para realizar una solicitud POST a la API                      |
|  y enviar un objeto Usuario en formato JSON como parte del cuerpo de la solicitud.                                     |
|  Cuando se envía una solicitud POST, generalmente se necesita enviar datos al servidor en el cuerpo de la solicitud.  |
|  En este caso, el objeto Usuario se envía al servidor para agregar un nuevo Usuario a través de la API.                 |
|  El método PostAsJsonAsync es una conveniencia proporcionada por la biblioteca HttpClient en .NET.                    |
|  Toma la URL de la API y el objeto Usuario, y se encarga de serializar automáticamente el objeto en formato JSON       |
|  y enviarlo al servidor en el cuerpo de la solicitud.                                                                 |
|  Esto simplifica el proceso de enviar datos JSON a través de una solicitud POST,                                      |
|  ya que no es necesario realizar manualmente la serialización del objeto y establecer los encabezados de la solicitud.|
|  La biblioteca HttpClient se encarga de eso por nosotros.                                                             |
|  En resumen, PostAsJsonAsync es utilizado en este método para enviar un objeto Usuario en formato JSON                 |
|  a través de una solicitud POST a la API.                                                                             |
|-----------------------------------------------------------------------------------------------------------------------|
|-------------------------------------------------  PutAsJsonAsync  ----------------------------------------------------|
|-----------------------------------------------------------------------------------------------------------------------|
|  El método PutAsJsonAsync se utiliza en el método Update para realizar una solicitud PUT a la API                     |
|  y enviar un objeto Usuario en formato JSON como parte del cuerpo de la solicitud.                                     |
 -----------------------------------------------------------------------------------------------------------------------
*/