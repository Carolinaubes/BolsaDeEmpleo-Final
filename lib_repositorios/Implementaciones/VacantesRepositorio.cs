using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class VacantesRepositorio : IVacantesRepositorio
    {
        private Conexion? conexion = null;

        public VacantesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Vacantes> Listar()
        {
            return conexion!.Listar<Vacantes>();
        }

        public List<Vacantes> Buscar(Expression<Func<Vacantes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Vacantes Guardar(Vacantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Vacantes Modificar(Vacantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Vacantes Borrar(Vacantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}