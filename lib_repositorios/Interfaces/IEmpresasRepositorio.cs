using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IEmpresasRepositorio
    {
        void Configurar(string string_conexion);
        List<Empresas> Listar();
        List<Empresas> Buscar(Expression<Func<Empresas, bool>> condiciones);
        Empresas Guardar(Empresas entidad);
        Empresas Modificar(Empresas entidad);
        Empresas Borrar(Empresas entidad);
    }
}