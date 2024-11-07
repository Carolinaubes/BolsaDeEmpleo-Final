using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using System.Text.Json.Serialization;

namespace lib_presentaciones.Implementaciones
{
    public class Personas_EstudiosPresentacion : IPersonas_EstudiosPresentacion
    {
        private IPersonas_EstudiosComunicacion? iComunicacion = null;

        public Personas_EstudiosPresentacion(IPersonas_EstudiosComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }

        public async Task<List<Personas_Estudios>> Listar()
        {
            var lista = new List<Personas_Estudios>();
            var datos = new Dictionary<string, object>();

            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Personas_Estudios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<List<Personas_Estudios>> Buscar(Personas_Estudios entidad, string tipo)
        {
            var lista = new List<Personas_Estudios>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;

            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Personas_Estudios>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        public async Task<Personas_Estudios> Guardar(Personas_Estudios entidad)
        {
            if (entidad.Id != 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Guardar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Personas_Estudios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Personas_Estudios> Modificar(Personas_Estudios entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Modificar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Personas_Estudios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        public async Task<Personas_Estudios> Borrar(Personas_Estudios entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }

            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            var respuesta = await iComunicacion!.Borrar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Personas_Estudios>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}