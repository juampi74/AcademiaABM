namespace Negocio
{
    using System.Net.Http.Headers;

    // Clase sellada que implementa el patrón Singleton para garantizar una única instancia en todo el programa
    public sealed class Conexion
    {
        private Conexion() { }

        private static Conexion? instancia;

        private HttpClient _Cliente = new HttpClient();

        // Propiedad pública que devuelve una instancia de HttpClient para realizar solicitudes HTTP
        public HttpClient Cliente
        {
            get { return _Cliente; }
        }

        // Propiedad estática de solo lectura que devuelve la única instancia de la clase Conexion
        public static Conexion Instancia
        {
            get
            {
                // Si la instancia es null, se crea una nueva instancia y se configuran las cabeceras de solicitud predeterminadas
                if (instancia == null)
                {
                    instancia = new Conexion();
                    instancia._Cliente.DefaultRequestHeaders.Accept.Clear();
                    instancia._Cliente.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );
                }
                return instancia;
            }
        }

    }
}

/*
Este código define una clase llamada Conexion en el espacio de nombres Negocio.
La clase Conexion es una clase sellada, lo que significa que no se puede heredar de ella.
La clase Conexion tiene un constructor privado,
lo que significa que no se puede crear una instancia de la clase directamente desde fuera de la clase.
Esto se hace para asegurarse de que solo haya una instancia de la clase en todo el programa.
La clase también tiene una variable estática llamada instancia, que es una referencia a la única instancia de la clase Conexion.
Esta variable se inicializa como null al principio.
La clase también tiene una propiedad pública llamada Cliente, que devuelve una instancia de la clase HttpClient.
La propiedad Cliente tiene un getter que simplemente devuelve la variable _Cliente.
La parte más interesante de esta clase es la propiedad estática Instancia.
Esta propiedad es una propiedad de solo lectura que devuelve la única instancia de la clase Conexion.
Si la variable instancia es null, lo que significa que aún no se ha creado una instancia de la clase,
se crea una nueva instancia de la clase Conexion y se asigna a la variable instancia.
Luego, se configuran las cabeceras de solicitud predeterminadas del cliente HTTP _Cliente
para aceptar el tipo de contenido "application/json". Finalmente, se devuelve la instancia de la clase Conexion.
En resumen, esta clase Conexion implementa el patrón de diseño Singleton,
lo que significa que solo puede haber una instancia de la clase en todo el programa.
La instancia se crea la primera vez que se accede a la propiedad Instancia
y se devuelve en todas las llamadas posteriores a esa propiedad.
La clase también proporciona una propiedad Cliente que devuelve una instancia de HttpClient para realizar solicitudes HTTP.
*/