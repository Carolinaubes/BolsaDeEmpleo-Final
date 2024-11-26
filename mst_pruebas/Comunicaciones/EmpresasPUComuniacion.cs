
using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class EmpresasPruebaUnitaria
    {
        //Se declara un atributo de tipo IEmpresasComunicacion. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IEmpresasComunicacion? iComunicacion = null;
        private Empresas? entidad = null;
        //private IAuditoriasComunicacion? iAuditoriasComunicacion = null;

        public EmpresasPruebaUnitaria()
        {
            //var conexion = new Conexion();
            //conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            //iAuditoriasComunicacion = new AuditoriasComunicacion(conexion);

            //Se instancia un objeto de la clase EmpresasComunicacion, que implementa IEmpresasComunicacion, y se asigna a iComunicacion. Esto permite que iComunicacion use los métodos de la clase hija EmpresasComunicacion
            iComunicacion = new EmpresasComunicacion();
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
        private async void Guardar() // Este metodo guarda una instancia de Empresas en la base de datos
        {
            var datos = new Dictionary<string, object>();
            entidad = new Empresas()
            {
                Cod_empresa = 140,
                Nombre = "Starbucks",
                Direccion = "Avenida 56"
            };

            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Guardar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Listar() //Este metodo lista la instancia Cargos_Estudios
        {
            var datos = new Dictionary<string, object>();
            var respuesta = await iComunicacion!.Listar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Buscar() //Este metodo Busca un id especifico de la instancia Cargos_Estudios en la base de datos
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "CODIGO EMPRESA";
            var respuesta = await iComunicacion!.Buscar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Modificar() //Este metodo modifica la dirección de la empresa
        {
            var datos = new Dictionary<string, object>();
            entidad!.Direccion = "Calle 190";

            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Modificar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Borrar() //Este metodo borra una instancia especifica 
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            var respuesta = await iComunicacion!.Borrar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
    }
}
