using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class EmpresasRepositorio : IEmpresasRepositorio
    {
        private Conexion? conexion = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public EmpresasRepositorio(Conexion conexion, IAuditoriasRepositorio iAuditoriasRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriasRepositorio = iAuditoriasRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Empresas> Listar()
        {
            return Buscar(x => x != null);
        }

        public List<Empresas> Buscar(Expression<Func<Empresas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Empresas Guardar(Empresas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            iAuditoriasRepositorio!.Guardar(new Auditorias()
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
            iAuditoriasRepositorio!.Guardar(new Auditorias()
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
            iAuditoriasRepositorio!.Guardar(new Auditorias()
            {
                Nom_Entidad = "Empresas",
                Entidad_id = entidad.Id,
                Accion = "Borrar"
            });
            return entidad;
        }
    }
}