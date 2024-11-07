using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonas_EstudiosPresentacion
    {
        Task<List<Personas_Estudios>> Listar();
        Task<List<Personas_Estudios>> Buscar(Personas_Estudios entidad, string tipo);
        Task<Personas_Estudios> Guardar(Personas_Estudios entidad);
        Task<Personas_Estudios> Modificar(Personas_Estudios entidad);
        Task<Personas_Estudios> Borrar(Personas_Estudios entidad);
    }
}