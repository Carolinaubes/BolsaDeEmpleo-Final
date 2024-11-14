using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPostulacionesAplicacion
    {
        void Configurar(string string_conexion);
        List<Postulaciones> Buscar(Postulaciones entidad, string tipo);
        List<Postulaciones> Listar();
        Postulaciones Guardar(Postulaciones entidad);
        Postulaciones Modificar(Postulaciones entidad);
        Postulaciones Borrar(Postulaciones entidad);
    }
}
