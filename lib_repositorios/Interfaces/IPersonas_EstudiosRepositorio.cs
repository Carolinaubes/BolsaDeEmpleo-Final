using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IPersonas_EstudiosRepositorio
    {
        void Configurar(string string_conexion);
        List<Personas_Estudios> Listar();
        List<Personas_Estudios> Buscar(Expression<Func<Personas_Estudios, bool>> condiciones);
        Personas_Estudios Guardar(Personas_Estudios entidad);
        Personas_Estudios Modificar(Personas_Estudios entidad);
        Personas_Estudios Borrar(Personas_Estudios entidad);
    }
}