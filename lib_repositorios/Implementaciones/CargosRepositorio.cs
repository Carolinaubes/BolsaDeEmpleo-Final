using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class CargosRepositorio : ICargosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public CargosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
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

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Cargos Modificar(Cargos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}