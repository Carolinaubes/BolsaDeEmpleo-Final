using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public PersonasRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Personas> Listar()
        {
            return conexion!.Listar<Personas>();
        }

        public List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Personas Guardar(Personas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Personas Modificar(Personas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });

            return entidad;
        }

        public Personas Borrar(Personas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });

            return entidad;
        }
    }
}