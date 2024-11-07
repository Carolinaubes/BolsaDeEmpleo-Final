using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IAccionesRepositorio
    {
        void Configurar(string string_conexion);
        List<Acciones> Listar();
        List<Acciones> Buscar(Expression<Func<Acciones, bool>> condiciones);
        Acciones Guardar(Acciones entidad);
        Acciones Modificar(Acciones entidad);
        Acciones Borrar(Acciones entidad);
    }
}