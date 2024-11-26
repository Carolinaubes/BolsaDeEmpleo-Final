using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class VacantesPruebaUnitaria
    {
        //Se declara un atributo de tipo IVacantesRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IVacantesRepositorio? iRepositorio = null;
        private Vacantes? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public VacantesPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase VacantesRepositorio, que implementa IVacantesRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija VacantesRepositorio
            iRepositorio = new VacantesRepositorio(conexion,iAuditoriasRepositorio);
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

        private void Guardar() // Este metodo guarda una instancia de Vacantes en la base de datos
        {
            entidad = new Vacantes()
            {
                Empresa_id = 1,
                Cargo_id = 1,
                Disponibilidad = true
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar() //Este metodo lista la instancia Vacantes en la base de datos
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        public void Buscar() //Este metodo Busca un id especifico de la instancia Vacantes en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        public void Modificar() // Este metodo modifica el estado de disponibilidad 
        {
            entidad!.Disponibilidad = false;
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