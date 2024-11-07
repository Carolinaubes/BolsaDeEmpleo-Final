using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Cargos_EstudiosRepositorio : ICargos_EstudiosRepositorio
    {
        private Conexion? conexion = null;

        public Cargos_EstudiosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Cargos_Estudios> Listar()
        {
            return conexion!.Listar<Cargos_Estudios>();
        }

        public List<Cargos_Estudios> Buscar(Expression<Func<Cargos_Estudios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Cargos_Estudios Guardar(Cargos_Estudios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Cargos_Estudios Modificar(Cargos_Estudios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Cargos_Estudios Borrar(Cargos_Estudios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}