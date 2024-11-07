using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEstudiosPresentacion
    {
        Task<List<Estudios>> Listar();
        Task<List<Estudios>> Buscar(Estudios entidad, string tipo);
        Task<Estudios> Guardar(Estudios entidad);
        Task<Estudios> Modificar(Estudios entidad);
        Task<Estudios> Borrar(Estudios entidad);
    }
}