using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class CargosPruebaUnitaria
    {
        //Se declara un atributo de tipo ICargos_EstudiosComunicacion. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private ICargosComunicacion? iComunicacion = null;
        private Cargos? entidad = null;
        //private IAuditoriasComunicacion? iAuditoriasComunicacion = null;

        public CargosPruebaUnitaria()
        {
            //var conexion = new Conexion();
            //conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            //iAuditoriasComunicacion = new AuditoriasComunicacion(conexion);

            //Se instancia un objeto de la clase Cargos_EstudiosComunicacion, que implementa ICargos_EstudiosComunicacion, y se asigna a iComunicacion. Esto permite que iComunicacion use los métodos de la clase hija Cargos_EstudiosComunicacion
            iComunicacion = new CargosComunicacion();
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
        private async void Guardar() // Este metodo guarda una instancia de Cargos en la base de datos
        {
            var datos = new Dictionary<string, object>();
            entidad = new Cargos()
            {
                Nombre = "Desarrollador"
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
            datos["Tipo"] = "NOMBRE";
            var respuesta = await iComunicacion!.Buscar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Modificar() //Cambia el cargo
        {
            var datos = new Dictionary<string, object>();
            entidad!.Nombre = "Administrador";

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
