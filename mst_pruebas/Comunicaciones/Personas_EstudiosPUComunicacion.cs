﻿using lib_entidades.Modelos;
using lib_comunicaciones;
using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using asp_servicios.Nucleo;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class Personas_EstudiosPruebaUnitaria
    {
        //Se declara un atributo de tipo IPersonas_EstudiosComunicacion. Aunque no se pueden instanciar objetos de una interfaz, esta puede tomar la forma de una clase que la implemente
        private IPersonas_EstudiosComunicacion? iComunicacion = null;
        private Personas_Estudios? entidad = null;
        //private IAuditoriasComunicacion? iAuditoriasComunicacion = null;

        public Personas_EstudiosPruebaUnitaria()
        {
            //var conexion = new Conexion();
            //conexion.StringConnection = Configuracion.ObtenerValor("ConectionString");
            //iAuditoriasComunicacion = new AuditoriasComunicacion(conexion);

            //Se instancia un objeto de la clase Personas_EstudiosComunicacion, que implementa IPersonas_EstudiosComunicacion, y se asigna a iComunicacion. Esto permite que iComunicacion use los métodos de la clase hija Personas_EstudiosComunicacion
            iComunicacion = new Personas_EstudiosComunicacion();
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
        private async void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Personas_Estudios()
            {
                Persona_id = 1,
                Estudio_id = 1
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
            datos["Tipo"] = "CODIGO ESTUDIO";
            var respuesta = await iComunicacion!.Buscar(datos);
            Assert.IsTrue(!respuesta.ContainsKey("Error"));
        }
        private async void Modificar() //Modifica el id del cargo asociado a un estudio
        {
            var datos = new Dictionary<string, object>();
            entidad!.Estudio_id = 1;

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