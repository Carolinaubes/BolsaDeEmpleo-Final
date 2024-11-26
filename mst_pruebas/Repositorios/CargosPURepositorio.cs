using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class CargosPruebaUnitaria
    {
        //Se declara un atributo de tipo ICargosRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private ICargosRepositorio? iRepositorio = null;
        private Cargos? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public CargosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase CargosRepositorio, que implementa ICargosRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija CargosRepositorio
            iRepositorio = new CargosRepositorio(conexion, iAuditoriasRepositorio); //Aca se esta inicializando la conexion dentro de la clase CargosRepositorio para que iRepositorio pueda usar los metodos con normalidad.
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
        private void Guardar() // Este metodo guarda una instancia de Cargos en la base de datos
        {
            entidad = new Cargos()
            {
                Nombre = "Desarrollador",
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar() //Este metodo lista la instancia Cargos en la base de datos
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        public void Buscar() //Este metodo Busca un id especifico de la instancia Cargos en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar() //Cambia el cargo
        {
            entidad!.Nombre = "Administrador";
            entidad = iRepositorio!.Modificar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Borrar() //Este metodo borra una instancia especifica
        {
            entidad = iRepositorio!.Borrar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}
