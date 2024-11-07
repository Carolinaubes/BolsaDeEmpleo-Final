using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ICargosRepositorio
    {
        void Configurar(string string_conexion);
        List<Cargos> Listar();
        List<Cargos> Buscar(Expression<Func<Cargos, bool>> condiciones);
        Cargos Guardar(Cargos entidad);
        Cargos Modificar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}