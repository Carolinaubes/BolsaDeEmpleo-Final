using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IAuditoriasRepositorio? iRepositorio = null;

        public AuditoriasAplicacion(IAuditoriasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Auditorias> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Auditorias> Buscar(Auditorias entidad, string tipo)
        {
            Expression<Func<Auditorias, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE ENTIDAD": condiciones = x => x.Nom_Entidad!.Contains(entidad.Nom_Entidad!); break;
                case "NOMBRE ACCION": condiciones = x => x.Accion == entidad.Accion; break;
                case "COMPLEJA":
                    condiciones =
                        x => x.Nom_Entidad!.Contains(entidad.Nom_Entidad!) ||
                             x.Accion == entidad.Accion; break;

                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}
