using lib_utilidades;
using System.Text.Json.Serialization;

namespace lib_comunicaciones
{
    //esta clase va a ser mi postman en c#
    public class Comunicaciones
    {
        //si tengo una comunicacion y 5 servicios  que hago para no quemar la conexion?
        public string? Protocolo = "http://",
            Host = "localhost:5063",
            Servicio = "",// "asp_notas_servicios/", // nombre del servicio
            Nombre = string.Empty, //nombre del controlador al que nos vamos a conectar
            Final = string.Empty,
            token = null;

        public Comunicaciones(string nombre)
        {
            Nombre = nombre;
        }

        //etse metodo retorna el url y el url token en un diccionario 
        public Dictionary<string, object> BuildUrl(Dictionary<string, object> data, string Metodo)
        {
            data["Url"] = Protocolo + Host + "/" + Servicio + Nombre + "/" + Metodo + Final;
            data["UrlToken"] = Protocolo + Host + "/" + Servicio + "Token/Autenticar" + Final;
            return data;
        }

        //task manda un hilo cuando llamemos un metodo que tiene que ser esperado le mandara un mensaje 
        public async Task<Dictionary<string, object>> Execute(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                //llamamos al metodo autenticar y le pedimos la url y le pasa datos y usuario
                //ya no tendriamos que hacer uso del postman el autenticar este metodo 
                //autentifica el token de manera automatica
                respuesta = await Authenticate(datos);
                if (respuesta == null || respuesta.ContainsKey("Error"))
                    return respuesta!;
                respuesta.Clear();

                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlToken");
                datos["Bearer"] = token!;

                var stringData = JsonConversor.ConvertirAString(datos);

                var httpClient = new HttpClient(); //boton de enviar
                httpClient.Timeout = new TimeSpan(0, 4, 0);

                var message = await httpClient.PostAsync(url, new StringContent(stringData)); //permite hacer la peticion

                //los servicios deben devolver codigo
                if (!message.IsSuccessStatusCode) //nuestro codigo debe de estar entre 200
                {
                    respuesta.Add("Error", "lbErrorComunicacion");// sino saca este error
                    return respuesta;
                }

                var resp = await message.Content.ReadAsStringAsync(); //lee todo el contenido de la lista 
                httpClient.Dispose(); httpClient = null;

                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp); //sino hay error el
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        private async Task<Dictionary<string, object>> Authenticate(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                //convierte datos que es un diccionario con la conexion a un string luego lo almacena en un url
                var url = datos["UrlToken"].ToString();
                //crea un diccionario
                var temp = new Dictionary<string, object>();
                // en esta linea  llama a EncriptarConversor.Encriptar("Test.Trghhjsgdj");
                temp["Usuario"] = DatosGenerales.usuario_datos;// en este tem queda con la clave usuario para la autentificacion
                //convierte los datos mediante el metodo convertira string 
                var stringData = JsonConversor.ConvertirAString(temp);
                //instancia 
                var httpClient = new HttpClient();
                //le da un tiempo limite de 1 minuto
                httpClient.Timeout = new TimeSpan(0, 1, 0);
                //Con el client, hace la peticion POST (url) y el body que iria en el postman con el string del bearer convertido a HttpContent
                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData));

                if (!mensaje.IsSuccessStatusCode) //si es estado no es 200 ok devuelve este error
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                //en esta linea lee el mensaje la respuesta de httpclient
                var resp = await mensaje.Content.ReadAsStringAsync();
                //evita que consuma mas memoria de la necesaria
                httpClient.Dispose(); httpClient = null;
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorAutenticacion");
                    return respuesta;
                }

                resp = Replace(resp); //manda la autentificacion en forma de diccionario
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                token = respuesta["Token"].ToString();
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}
