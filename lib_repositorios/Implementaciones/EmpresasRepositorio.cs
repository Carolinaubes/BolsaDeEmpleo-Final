using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EmpresasRepositorio : IEmpresasRepositorio
    {
        private Conexion? conexion = null;

        public EmpresasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Empresas> Listar()
        {
            return conexion!.Listar<Empresas>();
        }

        public List<Empresas> Buscar(Expression<Func<Empresas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Empresas Guardar(Empresas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            IAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Empresas",
                Entidad_id = entidad.Id,
                Accion = "Guardar"
            });
            return entidad;
        }

        public Empresas Modificar(Empresas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            IAuditoriasRepositorio!.Modificar(new Auditorias()
            {
                Nom_Entidad = "Empresas",
                Entidad_id = entidad.Id,
                Accion = "Modificar"
            });
            return entidad;
        }

        public Empresas Borrar(Empresas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            IAuditoriasRepositorio!.Borrar(new Auditorias()
            {
                Nom_Entidad = "Empresas",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}