using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class VacantesAplicacion : IVacantesAplicacion
    {
        private IVacantesRepositorio? iRepositorio = null;

        public VacantesAplicacion(IVacantesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Vacantes Borrar(Vacantes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Vacantes Guardar(Vacantes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Vacantes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Vacantes> Buscar(Vacantes entidad, string tipo)
        {
            Expression<Func<Vacantes, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE CARGO": condiciones = x => x._Cargo!.Nombre!.Contains(entidad._Cargo!.Nombre!); break;
                case "CODIGO EMPRESA": condiciones = x => x._Empresa!.Cod_empresa == entidad._Empresa!.Cod_empresa; break;
                case "COMPLEJA":
                    condiciones =
                        x => x._Cargo!.Nombre!.Contains(entidad._Cargo!.Nombre!) ||
                             x._Empresa!.Cod_empresa == entidad._Empresa!.Cod_empresa; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Vacantes Modificar(Vacantes entidad)
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
