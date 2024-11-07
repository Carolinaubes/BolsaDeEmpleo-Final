using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICargosPresentacion
    {
        Task<List<Cargos>> Listar();
        Task<List<Cargos>> Buscar(Cargos entidad, string tipo);
        Task<Cargos> Guardar(Cargos entidad);
        Task<Cargos> Modificar(Cargos entidad);
        Task<Cargos> Borrar(Cargos entidad);
    }
}