﻿using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class AccionesAplicacion : IAccionesAplicacion
    {
        private IAccionesRepositorio? iRepositorio = null;

        public AccionesAplicacion(IAccionesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Acciones Borrar(Acciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Acciones Guardar(Acciones entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Acciones> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Acciones> Buscar(Acciones entidad, string tipo)
        {
            Expression<Func<Acciones, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE ACCION": condiciones = x => x.Nombre!.Contains(entidad.Nombre!); break;
                
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Acciones Modificar(Acciones entidad)
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

