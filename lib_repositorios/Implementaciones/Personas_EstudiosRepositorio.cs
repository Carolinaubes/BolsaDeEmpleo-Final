using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Personas_EstudiosRepositorio : IPersonas_EstudiosRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public Personas_EstudiosRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Personas_Estudios> Listar()
        {
            return Buscar(x => x!=null);
        }


        public List<Personas_Estudios> Buscar(Expression<Func<Personas_Estudios, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Personas_Estudios Guardar(Personas_Estudios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });

            return entidad;
        }

        public Personas_Estudios Modificar(Personas_Estudios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });

            return entidad;
        }

        public Personas_Estudios Borrar(Personas_Estudios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();

            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Personas_Estudios",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });

            return entidad;
        }
    }
}