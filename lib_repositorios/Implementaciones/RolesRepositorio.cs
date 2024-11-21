using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class RolesRepositorio : IRolesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public RolesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Roles> Listar()
        {
            return conexion!.Listar<Roles>();
        }

        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Roles Guardar(Roles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Roles",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Roles",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });

            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Roles",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });

            return entidad;
        }
    }
}