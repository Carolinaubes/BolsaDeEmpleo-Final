using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface ICargosAplicacion
    {
        void Configurar(string string_conexion);
        List<Cargos> Buscar(Cargos entidad, string tipo);
        List<Cargos> Listar();
        Cargos Guardar(Cargos entidad);
        Cargos Modificar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}
