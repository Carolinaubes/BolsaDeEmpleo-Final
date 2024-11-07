using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IVacantesPresentacion
    {
        Task<List<Vacantes>> Listar();
        Task<List<Vacantes>> Buscar(Vacantes entidad, string tipo);
        Task<Vacantes> Guardar(Vacantes entidad);
        Task<Vacantes> Modificar(Vacantes entidad);
        Task<Vacantes> Borrar(Vacantes entidad);
    }
}