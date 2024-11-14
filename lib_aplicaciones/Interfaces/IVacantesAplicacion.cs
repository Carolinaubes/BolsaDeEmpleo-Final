using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IVacantesAplicacion
    {
        void Configurar(string string_conexion);
        List<Vacantes> Buscar(Vacantes entidad, string tipo);
        List<Vacantes> Listar();
        Vacantes Guardar(Vacantes entidad);
        Vacantes Modificar(Vacantes entidad);
        Vacantes Borrar(Vacantes entidad);
    }
}
