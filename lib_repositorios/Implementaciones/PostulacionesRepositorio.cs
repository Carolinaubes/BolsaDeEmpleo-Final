using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class PostulacionesRepositorio : IPostulacionesRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public PostulacionesRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Postulaciones> Listar()
        {
            return Buscar(x => x != null);
        }

        public List<Postulaciones> Buscar(Expression<Func<Postulaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Postulaciones Guardar(Postulaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Postulaciones",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Postulaciones Modificar(Postulaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Postulaciones",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });

            return entidad;
        }

        public Postulaciones Borrar(Postulaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Postulaciones",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });

            return entidad;
        }
    }
}