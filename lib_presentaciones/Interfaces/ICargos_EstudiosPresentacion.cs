using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface ICargos_EstudiosPresentacion
    {
        Task<List<Cargos_Estudios>> Listar();
        Task<List<Cargos_Estudios>> Buscar(Cargos_Estudios entidad, string tipo);
        Task<Cargos_Estudios> Guardar(Cargos_Estudios entidad);
        Task<Cargos_Estudios> Modificar(Cargos_Estudios entidad);
        Task<Cargos_Estudios> Borrar(Cargos_Estudios entidad);
    }
}