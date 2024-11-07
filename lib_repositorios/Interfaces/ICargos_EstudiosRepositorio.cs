using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface ICargos_EstudiosRepositorio
    {
        void Configurar(string string_conexion);
        List<Cargos_Estudios> Listar();
        List<Cargos_Estudios> Buscar(Expression<Func<Cargos_Estudios, bool>> condiciones);
        Cargos_Estudios Guardar(Cargos_Estudios entidad);
        Cargos_Estudios Modificar(Cargos_Estudios entidad);
        Cargos_Estudios Borrar(Cargos_Estudios entidad);
    }
}