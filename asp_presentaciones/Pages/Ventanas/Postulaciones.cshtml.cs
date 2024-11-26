using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages.Ventanas
{
    public class PostulacionesModel : PageModel
    {
        private IPostulacionesPresentacion? iPresentacion = null;

        public PostulacionesModel(IPostulacionesPresentacion iPresentacion)
        {
            try
            {
                this.iPresentacion = iPresentacion;
                Filtro = new Postulaciones()
                {
                    _Vacantes = new Vacantes()
                    {
                        _Cargo = new Cargos(),
                        _Empresa = new Empresas()
                        {
                            _Rol = new Roles()
                        }
                    },
                    _Personas = new Personas()
                    {
                        _Rol = new Roles()
                    }
                };

            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        [BindProperty] public Enumerables.Ventanas Accion { get; set; }
        [BindProperty] public Postulaciones? Actual { get; set; }
        [BindProperty] public Postulaciones? Filtro { get; set; }
        [BindProperty] public List<Postulaciones>? Lista { get; set; }


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
                Filtro!._Personas!.Cedula = Filtro!._Personas!.Cedula ?? ""; //El objeto llega vacio
                //Filtro!.Persona_id = Filtro!.Persona_id; NO FUNCIONA

                Accion = Enumerables.Ventanas.Listas;
                var task = this.iPresentacion!.Buscar(Filtro!, "CEDULA");
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
                Actual = new Postulaciones()
                {
                    _Vacantes = new Vacantes()
                    {
                        _Cargo = new Cargos(),
                        _Empresa = new Empresas()
                        {
                            _Rol = new Roles()
                        }
                    },
                    _Personas = new Personas()
                    {
                        _Rol = new Roles()
                    }
                };
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
                Task<Postulaciones>? task = null;
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
