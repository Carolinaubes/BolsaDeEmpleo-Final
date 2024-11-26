using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class EstudiosPruebaUnitaria
    {
        //Se declara un atributo de tipo IEstudiosRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IEstudiosRepositorio? iRepositorio = null;
        private Estudios? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public EstudiosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase EstudiosRepositorio, que implementa IEstudiosRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija EstudiosRepositorio
            iRepositorio = new EstudiosRepositorio(conexion,iAuditoriasRepositorio);
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
        private void Guardar() // Este metodo guarda una instancia de Estudios en la base de datos
        {
            entidad = new Estudios()
            {
                Cod_estudio = 1,
                Nombre = "Periodismo"
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar() //Este metodo lista la instancia Estudios en la base de datos
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        private void Buscar() //Este metodo Busca un id especifico de la instancia Estudios en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar() //Cambia el nombre del estudio
        {
            entidad!.Nombre = "Arquitectura";
            entidad = iRepositorio!.Modificar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Borrar() //Este metodo borra una instancia especifica
        {
            {
                entidad = iRepositorio!.Borrar(entidad!);
                var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
                Assert.IsTrue(lista.Count == 0);
            }
        }
    }
}
