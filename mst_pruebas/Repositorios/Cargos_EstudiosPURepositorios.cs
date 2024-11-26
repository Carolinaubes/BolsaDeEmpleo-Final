using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class Cargos_EstudiosPruebaUnitaria
    {
        //Se declara un atributo de tipo ICargos_EstudiosRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private ICargos_EstudiosRepositorio? iRepositorio = null;
        private Cargos_Estudios? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public Cargos_EstudiosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase Cargos_EstudiosRepositorio, que implementa ICargos_EstudiosRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija Cargos_EstudiosRepositorio
            iRepositorio = new Cargos_EstudiosRepositorio(conexion, iAuditoriasRepositorio);
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
        private void Guardar()
        {
            entidad = new Cargos_Estudios() //// Este metodo guarda una instancia de Cargos_Estudios en la base de datos
            {
                Cargo_id = 1,
                Estudio_id = 1
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar() //Este metodo lista la instancia Cargos_Estudios
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        private void Buscar() //Este metodo Busca un id especifico de la instancia Cargos_Estudios en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar() //Modifica el id del cargo asociado a un estudio
        {
            entidad!.Cargo_id = 1;
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
