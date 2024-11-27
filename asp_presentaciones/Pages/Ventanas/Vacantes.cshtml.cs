using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages.Ventanas
{
    public class VacantesModel : PageModel
    {
        private IVacantesPresentacion? iPresentacion = null;
        private static int modif;
        private static int IDBorrar;

        public VacantesModel(IVacantesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Vacantes()
                {
                    _Empresa = new Empresas()
                    {
                        _Rol = new Roles()
                    },
                    _Cargo = new Cargos()
                };

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Vacantes? Actual { get; set; }
        [BindProperty] public Vacantes? Filtro { get; set; }
        [BindProperty] public List<Vacantes>? Lista { get; set; }


        public virtual void OnGet() { OnPostBtRefrescar(); }

        public void OnPostBtRefrescar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                var variable_session2 = HttpContext.Session.GetString("Empresa");
                var variable_session3 = HttpContext.Session.GetString("Administrador");
                if (String.IsNullOrEmpty(variable_session) && String.IsNullOrEmpty(variable_session2) && String.IsNullOrEmpty(variable_session3))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro = new Vacantes()
                {
                    _Cargo = new Cargos()
                    //_Estudio = new Estudios(),

                };

                Filtro!._Cargo!.Nombre = Filtro!._Cargo!.Nombre ?? ""; //El objeto llega vacio

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "NOMBRE CARGO");
                task.Wait();
                Lista = task.Result;
                Actual = null;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtNuevo()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Actual = new Vacantes();
                modif = 0;
                //{
                //    _Empresa = new Empresas()
                //    {
                //        _Rol = new Roles()
                //    },
                //    _Cargo = new Cargos()
                //}
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtModificar(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Editar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                modif = Actual!.Id;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtGuardar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Editar;
                Task<Vacantes>? task = null;
                Actual!.Id = modif;
                if (Actual!.Id == 0)
                    task = this.iPresentacion!.Guardar(Actual!);
                else
                    task = this.iPresentacion!.Modificar(Actual!);
                task.Wait();
                Actual = task.Result;
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrarVal(string data)
        {
            try
            {
                OnPostBtRefrescar();
                Accion = Enumerables.Ventanas.Borrar;
                Actual = Lista!.FirstOrDefault(x => x.Id.ToString() == data);
                IDBorrar = Actual!.Id;

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public virtual void OnPostBtBorrar()
        {
            try
            {
                Actual!.Id = IDBorrar;
                var task = this.iPresentacion!.Borrar(Actual!);
                Actual = task.Result;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCancelar()
        {
            try
            {
                Accion = Enumerables.Ventanas.Listas;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtCerrar()
        {
            try
            {
                if (Accion == Enumerables.Ventanas.Listas)
                    OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }



    }
}