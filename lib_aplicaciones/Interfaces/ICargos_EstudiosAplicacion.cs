using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface ICargos_EstudiosAplicacion
    {
        void Configurar(string string_conexion);
        List<Cargos_Estudios> Buscar(Cargos_Estudios entidad, string tipo);
        List<Cargos_Estudios> Listar();
        Cargos_Estudios Guardar(Cargos_Estudios entidad);
        Cargos_Estudios Modificar(Cargos_Estudios entidad);
        Cargos_Estudios Borrar(Cargos_Estudios entidad);
    }
}
