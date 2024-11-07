using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IEstudiosAplicacion
    {
        void Configurar(string string_conexion);
        List<Estudios> Buscar(Estudios entidad, string tipo);
        List<Estudios> Listar();
        Estudios Guardar(Estudios entidad);
        Estudios Modificar(Estudios entidad);
        Estudios Borrar(Estudios entidad);
    }
}
