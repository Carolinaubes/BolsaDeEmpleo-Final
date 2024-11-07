using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IEmpresasPresentacion
    {
        Task<List<Empresas>> Listar();
        Task<List<Empresas>> Buscar(Empresas entidad, string tipo);
        Task<Empresas> Guardar(Empresas entidad);
        Task<Empresas> Modificar(Empresas entidad);
        Task<Empresas> Borrar(Empresas entidad);
    }
}