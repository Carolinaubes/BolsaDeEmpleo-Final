using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class VacantesRepositorio : IVacantesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public VacantesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Vacantes> Listar()
        {
            return Buscar(x => x != null);
        }

        public List<Vacantes> Buscar(Expression<Func<Vacantes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }


        public Vacantes Guardar(Vacantes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Vacantes",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Vacantes Modificar(Vacantes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Vacantes",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });

            return entidad;
        }

        public Vacantes Borrar(Vacantes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Vacantes",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });

            return entidad;
        }
    }
}