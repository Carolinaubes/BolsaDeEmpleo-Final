using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EstudiosRepositorio : IEstudiosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public EstudiosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Estudios> Listar()
        {
            return conexion!.Listar<Estudios>();
        }

        public List<Estudios> Buscar(Expression<Func<Estudios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Estudios Guardar(Estudios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Estudios",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Estudios Modificar(Estudios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Estudios",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Estudios Borrar(Estudios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Estudios",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}