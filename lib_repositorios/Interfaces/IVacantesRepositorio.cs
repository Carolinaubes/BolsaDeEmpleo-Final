using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IVacantesRepositorio
    {
        void Configurar(string string_conexion);
        List<Vacantes> Listar();
        List<Vacantes> Buscar(Expression<Func<Vacantes, bool>> condiciones);
        Vacantes Guardar(Vacantes entidad);
        Vacantes Modificar(Vacantes entidad);
        Vacantes Borrar(Vacantes entidad);
    }
}