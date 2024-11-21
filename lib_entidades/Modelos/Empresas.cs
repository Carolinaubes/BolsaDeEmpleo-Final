using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Empresas
    {
        [Key] public int Id { get; set; } //Identificador de la empresa
        public int Cod_empresa { get; set; } //Es un codigo que identifica a la empresa
        public string? Nombre { get; set; } //Corresponde al nombre que posea esa Empresa
        public string? Direccion { get; set; } //Direccion de la empresa
        public int Rol_id { get; set; } //Rol que posee: Empresa o Persona

        //Creacion de objetos
        [ForeignKey("Rol_id")] public Roles? _Rol { get; set; } //Objeto de Roles

        public bool Validar()
        {
            if (Cod_empresa <= 0 ||
                string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Direccion) ||
                Rol_id <= 0)
                return false;
            return true;
        }
    }
}