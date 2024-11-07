using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IAuditoriasRepositorio
    {
        void Configurar(string string_conexion);
        List<Auditorias> Listar();
        List<Auditorias> Buscar(Expression<Func<Auditorias, bool>> condiciones);
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
    }
}