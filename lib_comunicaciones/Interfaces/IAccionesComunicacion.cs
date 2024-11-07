namespace lib_comunicaciones.Interfaces
{
    public interface IAccionesComunicacion
    {
        //recibe peticiones y saca diccionarios
        //task lo del hilo, permite que al ejecutar el codigo se bloquea seguir utilizandolo con el bug 
        //hasta que ud no me responde no va a continuar, la parte grafica no se va a bloquear

        //en la base de datos hay muchos registros por eso la funcion de listar()
        //en la presnetacion 
        Task<Dictionary<string, object>> Listar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Buscar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Guardar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Modificar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> Borrar(Dictionary<string, object> datos);
    }
}
