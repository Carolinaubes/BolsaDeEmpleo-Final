using asp_servicios.Nucleo;
using lib_aplicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosAplicacion? iAplicacion = null; //En EstudiosAplicacion estan los metodos ya validados que incluyen las conexiones (los metodos sin validar los tiene EstudiosRepositorio)
        private TokenController? tokenController = null; //Se usa para autentificar 

        public EstudiosController(IEstudiosAplicacion? iAplicacion,
            TokenController tokenController)
        {
            this.iAplicacion = iAplicacion;
            this.tokenController = tokenController;
        }

        private Dictionary<string, object> ObtenerDatos()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = new StreamReader(Request.Body).ReadToEnd().ToString(); //Lee el body, que deberia contener al bearer
                if (string.IsNullOrEmpty(datos))
                    datos = "{}";
                return JsonConversor.ConvertirAObjeto(datos); //Convierte el json en un diccionario
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return respuesta;
            }
        }

        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos(); //Diccionario con el bearer o vacio ({})
                if (!tokenController!.Validate(datos)) //La validacion es falsa (o no mandaron bearer o ya se vencio el token)
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //En este punto, ya se valido que el token es correcto, continuo...

                //Esta linea le manda la el StringConnection a aplicacion, el cual internamente le asigna esta conexion al EstudiosRepositorio
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString")); //Le manda el stringConnection al aplicacion, es necesario para poder usar los metodos de GUARDAR/LISTAR/BORRAR/MODIFCAR...
                respuesta["Entidades"] = this.iAplicacion!.Listar(); //Le manda como value la lista de entidades

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta); //Convierto el diccionario "respuesta" en un string
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Buscar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos(); //Diccionario con el bearer o vacio ({})
                if (!tokenController!.Validate(datos)) //La validacion es falsa (o no mandaron bearer o ya se vencio el token)
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                //En este punto, ya se valido que el token es correcto, continuo...
                var entidad = JsonConversor.ConvertirAObjeto<Estudios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                var tipo = datos["Tipo"].ToString();

                //Esta linea le manda el StringConnection a aplicacion, el cual internamente le asigna esta conexion al EstudiosRepositorio
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString")); //Le manda el stringConnection al aplicacion, es necesario para poder usar los metodos de GUARDAR/LISTAR/BORRAR/MODIFCAR...
                respuesta["Entidades"] = this.iAplicacion!.Buscar(entidad, tipo);

                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Estudios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Guardar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Estudios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Modificar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                var datos = ObtenerDatos();
                if (!tokenController!.Validate(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }

                var entidad = JsonConversor.ConvertirAObjeto<Estudios>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));

                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("ConectionString"));
                entidad = this.iAplicacion!.Borrar(entidad);

                respuesta["Entidad"] = entidad;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}