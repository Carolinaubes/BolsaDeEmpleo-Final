using lib_comunicaciones.Interfaces;

namespace lib_comunicaciones.Implementaciones
{
    public class EstudiosComunicacion : IEstudiosComunicacion
    {
        private Comunicaciones? comunicaciones = null;
        private string? Nombre = "Estudios";

        public EstudiosComunicacion()
        {
            comunicaciones = new Comunicaciones(Nombre);
        }

        public async Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Guardar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos)
        {
            //datos contiene un diccionario con la url y url token
            datos = comunicaciones!.BuildUrl(datos, "Buscar");
            return await comunicaciones!.Execute(datos); // el await nos permite que espere la ejecucion completa evitando errores como el time out
        }

        public async Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Listar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Modificar");
            return await comunicaciones!.Execute(datos);
        }

        public async Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos)
        {
            datos = comunicaciones!.BuildUrl(datos, "Borrar");
            return await comunicaciones!.Execute(datos);
        }
    }
}
