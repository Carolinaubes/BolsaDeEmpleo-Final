using lib_utilidades;
using Newtonsoft.Json;

namespace asp_servicios.Nucleo
{
    public class Configuracion
    {
        private static Dictionary<string, string>? datos = null;

        public static string ObtenerValor(string clave) //Esa clave es la key del json llamada StringConnection
        {
            string respuesta = "";
            if (datos == null)
                Cargar();
            respuesta = datos![clave].ToString(); //Obtiene el value de la key StringConnection
            return respuesta;
        }

        public static void Cargar()
        {
            if (!File.Exists(DatosGenerales.ruta_json))
                return;
            datos = new Dictionary<string, string>();
            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json); //Accede al archivo json (el secret que contiene la conexion)
            var json = jsonStream.ReadToEnd(); //Lee el secret
            datos = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)!; //Convierte el json que obtuve a un diccionario y se lo asigna al diccionario
            //que tenemos afuera al inicio de la clase
        }

    }
}