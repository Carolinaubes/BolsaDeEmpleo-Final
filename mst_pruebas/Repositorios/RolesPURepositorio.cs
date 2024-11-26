using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class RolesPruebaUnitaria
    {
        //Se declara un atributo de tipo IRolesRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IRolesRepositorio? iRepositorio = null;
        private Roles? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public RolesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase RolesRepositorio, que implementa IRolesRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija RolesRepositorio
            iRepositorio = new RolesRepositorio(conexion,iAuditoriasRepositorio);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Guardar() // Este metodo guarda una instancia de Roles en la base de datos
        {
            entidad = new Roles()
            {
                Nombre = "Administrador"
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar() //Este metodo lista la instancia Roles en la base de datos
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar() //Este metodo Busca un id especifico de la instancia Roles en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        public void Modificar() // Este metodo modifica el nombre del Rol
        {
            entidad!.Nombre = "Admin";
            entidad = iRepositorio!.Modificar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        public void Borrar() //Este metodo borra una instancia especifica 
        {
            entidad = iRepositorio!.Borrar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}