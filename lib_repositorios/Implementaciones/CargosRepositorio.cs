using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class CargosRepositorio : ICargosRepositorio
    {
        private Conexion? conexion = null;

        public CargosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Cargos> Listar()
        {
            return conexion!.Listar<Cargos>();
        }

        public List<Cargos> Buscar(Expression<Func<Cargos, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Cargos Guardar(Cargos entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Cargos Modificar(Cargos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}