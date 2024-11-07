using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IRolesRepositorio
    {
        void Configurar(string string_conexion);
        List<Roles> Listar();
        List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones);
        Roles Guardar(Roles entidad);
        Roles Modificar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}