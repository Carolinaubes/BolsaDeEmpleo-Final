using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class Cargos_EstudiosAplicacion : ICargos_EstudiosAplicacion
    {
        private ICargos_EstudiosRepositorio? iRepositorio = null;

        public Cargos_EstudiosAplicacion(ICargos_EstudiosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Cargos_Estudios Borrar(Cargos_Estudios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Cargos_Estudios Guardar(Cargos_Estudios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Cargos_Estudios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Cargos_Estudios> Buscar(Cargos_Estudios entidad, string tipo)
        {
            Expression<Func<Cargos_Estudios, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE CARGO": condiciones = x => x._Cargo!.Nombre!.Contains(entidad._Cargo!.Nombre!); break;
                case "CODIGO ESTUDIO": condiciones = x => x._Estudio!.Cod_estudio == entidad._Estudio!.Cod_estudio; break;
                case "COMPLEJA":
                    condiciones =
                        x => x._Cargo!.Nombre!.Contains(entidad._Cargo!.Nombre!) ||
                             x._Estudio!.Cod_estudio == entidad._Estudio!.Cod_estudio; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Cargos_Estudios Modificar(Cargos_Estudios entidad)
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
