using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IPostulacionesPresentacion
    {
        Task<List<Postulaciones>> Listar();
        Task<List<Postulaciones>> Buscar(Postulaciones entidad, string tipo);
        Task<Postulaciones> Guardar(Postulaciones entidad);
        Task<Postulaciones> Modificar(Postulaciones entidad);
        Task<Postulaciones> Borrar(Postulaciones entidad);
    }
}