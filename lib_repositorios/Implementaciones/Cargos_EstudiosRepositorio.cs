using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Cargos_EstudiosRepositorio : ICargos_EstudiosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;
        public Cargos_EstudiosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Cargos_Estudios> Listar()
        {
            return Buscar(x => x != null);
        }

        public List<Cargos_Estudios> Buscar(Expression<Func<Cargos_Estudios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Cargos_Estudios Guardar(Cargos_Estudios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Cargos_Estudios Modificar(Cargos_Estudios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Cargos_Estudios Borrar(Cargos_Estudios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Cargos_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}