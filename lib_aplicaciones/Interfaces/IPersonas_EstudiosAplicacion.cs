using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IPersonas_EstudiosAplicacion
    {
        void Configurar(string string_conexion);
        List<Personas_Estudios> Buscar(Personas_Estudios entidad, string tipo);
        List<Personas_Estudios> Listar();
        Personas_Estudios Guardar(Personas_Estudios entidad);
        Personas_Estudios Modificar(Personas_Estudios entidad);
        Personas_Estudios Borrar(Personas_Estudios entidad);
    }
}
