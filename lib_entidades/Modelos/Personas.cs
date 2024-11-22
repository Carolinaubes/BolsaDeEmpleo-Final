using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Personas
    {
        [Key] public int Id { get; set; }  //Identificador de persona
        public string? Cedula { get; set; } //Corresponde a la cedula de la persona
        public string? Nombre { get; set; } //Se refiere al nombre de la persona
        public string? Direccion { get; set; } //Direccion de la persona
        public int Rol_id { get; set; } //Rol que posee: Empresa o Persona

        //Creacion de objetos
        [ForeignKey("Rol_id")] public Roles? _Rol { get; set; } //Objeto de Roles

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Direccion) ||
                Rol_id <= 0)
                return false;
            return true;
        }
    }
}