using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IEmpresasAplicacion
    {
        void Configurar(string string_conexion);
        List<Empresas> Buscar(Empresas entidad, string tipo);
        List<Empresas> Listar();
        Empresas Guardar(Empresas entidad);
        Empresas Modificar(Empresas entidad);
        Empresas Borrar(Empresas entidad);
    }
}