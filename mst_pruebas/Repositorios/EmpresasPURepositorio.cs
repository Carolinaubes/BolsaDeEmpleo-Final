using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class EmpresasPruebaUnitaria
    {
        //Se declara un atributo de tipo IEmpresasRepositorio. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IEmpresasRepositorio? iRepositorio = null;
        private Empresas? entidad = null;
        private IAuditoriasRepositorio? iAuditoriasRepositorio = null;

        public EmpresasPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            iAuditoriasRepositorio = new AuditoriasRepositorio(conexion);

            //Se instancia un objeto de la clase EmpresasRepositorio, que implementa IEmpresasRepositorio, y se asigna a iRepositorio. Esto permite que iRepositorio use los métodos de la clase hija EmpresasRepositorio
            iRepositorio = new EmpresasRepositorio(conexion, iAuditoriasRepositorio);
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
        private void Guardar() // Este metodo guarda una instancia de Empresas en la base de datos
        {
            entidad = new Empresas()
            {
                Cod_empresa = 140,
                Nombre = "Starbucks",
                Direccion = "Avenida 56",
                Rol_id = 1
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
        private void Listar() //Este metodo lista la instancia Empresas en la base de datos
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        private void Buscar() //Este metodo Busca un id especifico de la instancia Empresas en la base de datos
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar() //Este metodo modifica la dirección de la empresa
        {
            entidad!.Direccion = "Calle 190";
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
