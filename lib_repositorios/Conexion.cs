﻿using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public class Conexion : DbContext
    {
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Acciones>? Acciones { get; set; }
        protected DbSet<Auditorias>? Auditorias { get; set; }
        protected DbSet<Cargos>? Cargos { get; set; }
        protected DbSet<Cargos_Estudios>? Cargos_Estudios { get; set; }
        protected DbSet<Empresas>? Empresas { get; set; }
        protected DbSet<Estudios>? Estudios { get; set; }
        protected DbSet<Personas>? Personas { get; set; }
        protected DbSet<Personas_Estudios>? Personas_Estudios { get; set; }
        protected DbSet<Postulaciones>? Postulaciones{ get; set; }
        protected DbSet<Roles>? Roles { get; set; }
        protected DbSet<Vacantes>? Vacantes { get; set; }

        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>().ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}