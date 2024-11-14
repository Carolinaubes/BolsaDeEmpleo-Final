using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class Personas_EstudiosAplicacion : IPersonas_EstudiosAplicacion
    {
        private IPersonas_EstudiosRepositorio? iRepositorio = null;

        public Personas_EstudiosAplicacion(IPersonas_EstudiosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Personas_Estudios Borrar(Personas_Estudios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Personas_Estudios Guardar(Personas_Estudios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Personas_Estudios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Personas_Estudios> Buscar(Personas_Estudios entidad, string tipo)
        {
            Expression<Func<Personas_Estudios, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "CEDULA": condiciones = x => x._Persona!.Cedula!.Contains(entidad._Persona!.Cedula!); break;
                case "CODIGO ESTUDIO": condiciones = x => x._Estudio!.Cod_estudio == entidad._Estudio!.Cod_estudio; break;
                case "COMPLEJA":
                    condiciones =
                        x => x._Persona!.Cedula!.Contains(entidad._Persona!.Cedula!) ||
                             x._Estudio!.Cod_estudio == entidad._Estudio!.Cod_estudio; break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Personas_Estudios Modificar(Personas_Estudios entidad)
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