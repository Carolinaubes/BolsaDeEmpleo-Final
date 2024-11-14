using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPersonasAplicacion
    {
        void Configurar(string string_conexion);
        List<Personas> Buscar(Personas entidad, string tipo);
        List<Personas> Listar();
        Personas Guardar(Personas entidad);
        Personas Modificar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}
